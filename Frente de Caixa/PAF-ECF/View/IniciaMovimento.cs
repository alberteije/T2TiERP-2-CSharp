/********************************************************************************
Title: T2TiPDV
Description: Janela utilizada para iniciar um noDTO movimento.

The MIT License

Copyright: Copyright (C) 2014 T2Ti.COM

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

       The author may be contacted at:
           alberteije@gmail.com

@author T2Ti.COM
@version 2.0
********************************************************************************/


using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PafEcf.DTO;
using PafEcf.Controller;

using PafEcf.Util;
using System.Collections.Generic;

namespace PafEcf.View
{

    public partial class IniciaMovimento : Form
    {

        private static DataTable DTTurno;

        public IniciaMovimento()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
            //
            ConfiguraDataSet();
            GridTurno.Focus();
        }

        private void ConfiguraDataSet()
        {
            // Tabela Fechamento
            DTTurno = new DataTable("TURNO");
            DTTurno.Columns.Add("DESCRICAO", typeof(string));
            DTTurno.Columns.Add("HORA_INICIO", typeof(string));
            DTTurno.Columns.Add("HORA_FIM", typeof(string));
            DTTurno.Columns.Add("ID", typeof(int));
            dataSet.Tables.Add(DTTurno);

            GridTurno.DataSource = dataSet;
            GridTurno.DataMember = dataSet.Tables["TURNO"].TableName;
            CarregarTurnos();
        }

        private void CarregarTurnos()
        {
            DataRow Registro;
            List<EcfTurnoDTO> ListaTurnos = (List<EcfTurnoDTO>)EcfTurnoController.ConsultaEcfTurnoLista("Id > 0");
            for (int i = 0; i <= ListaTurnos.Count - 1; i++)
            {
                Registro = DTTurno.NewRow();
                Registro["DESCRICAO"] = ListaTurnos[i].Descricao;
                Registro["HORA_INICIO"] = ListaTurnos[i].HoraInicio;
                Registro["HORA_FIM"] = ListaTurnos[i].HoraFim;
                Registro["ID"] = Convert.ToInt32(ListaTurnos[i].Id);
                DTTurno.Rows.Add(Registro);
            }
        }

        private void FIniciaMovimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
                botaoConfirma.PerformClick();
            if (e.KeyCode == Keys.Escape)
                botaoCancela.PerformClick();
        }

        private void GridTurno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                editValorSuprimento.Focus();
        }


        private void botaoConfirma_Click(object sender, EventArgs e)
        {
            Confirma();
        }

        private void botaoCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Confirma()
        {
            try
            {
                // verifica se senha e o nivel do operador estáo corretos
                EcfOperadorDTO Operador = EcfFuncionarioController.Usuario(editLoginOperador.Text, editSenhaOperador.Text);
                if (Operador != null)
                {
                    // verifica se senha do gerente esta correta
                    EcfOperadorDTO Gerente = EcfFuncionarioController.Usuario(editLoginGerente.Text, editSenhaGerente.Text);
                    if (Gerente != null)
                    {
                        // verifica nivel de acesso do gerente/supervisor
                        if ((Gerente.EcfFuncionario.NivelAutorizacao == "G") || (Gerente.EcfFuncionario.NivelAutorizacao == "S"))
                        {
                            if (ECFUtil.ImpressoraOK())
                            {
                                DataRow Registro = DTTurno.Rows[GridTurno.CurrentRow.Index];

                                // insere movimento
                                Sessao.Instance.Movimento = new EcfMovimentoDTO();
                                Sessao.Instance.Movimento.EcfTurno.Id = Convert.ToInt32(Registro["ID"]);
                                Sessao.Instance.Movimento.EcfImpressora.Id = Sessao.Instance.Configuracao.EcfImpressora.Id;
                                Sessao.Instance.Movimento.EcfEmpresa.Id = Sessao.Instance.Configuracao.EcfEmpresa.Id;
                                Sessao.Instance.Movimento.EcfOperador.Id = Operador.Id;
                                Sessao.Instance.Movimento.EcfCaixa.Id = Sessao.Instance.Configuracao.EcfCaixa.Id;
                                Sessao.Instance.Movimento.IdGerenteSupervisor = Gerente.Id;
                                Sessao.Instance.Movimento.DataAbertura = DataModule.ACBrECF.DataHora;
                                Sessao.Instance.Movimento.HoraAbertura = DataModule.ACBrECF.DataHora.ToString("hh:mm:ss");
                                if (editValorSuprimento.Text != "")
                                    Sessao.Instance.Movimento.TotalSuprimento = Convert.ToDecimal(editValorSuprimento.Text);
                                Sessao.Instance.Movimento.StatusMovimento = "A";
                                Sessao.Instance.Movimento = EcfMovimentoController.GravaEcfMovimento(Sessao.Instance.Movimento);
                            }
                            else
                            {
                                MessageBox.Show("Não foi possivel abrir o movimento!.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scSomenteConsulta;
                                this.Close();
                            }

                            // insere suprimento
                            if (editValorSuprimento.Text != "")
                            {
                                try
                                {
                                    ECFUtil.Suprimento(Convert.ToDecimal(editValorSuprimento.Text), Sessao.Instance.Configuracao.DescricaoSuprimento);

                                    EcfSuprimentoDTO Suprimento = new EcfSuprimentoDTO();
                                    Suprimento.IdEcfMovimento = Sessao.Instance.Movimento.Id;
                                    Suprimento.DataSuprimento = DataModule.ACBrECF.DataHora;
                                    Suprimento.Valor = Convert.ToDecimal(editValorSuprimento.Text);
                                    EcfSuprimentoController.GravaEcfSuprimento(Suprimento);

                                    Sessao.Instance.Movimento.TotalSuprimento = Sessao.Instance.Movimento.TotalSuprimento + Suprimento.Valor;
                                    EcfMovimentoController.GravaEcfMovimento(Sessao.Instance.Movimento);
                                }
                                catch (Exception eError)
                                {
                                    Log.write(eError.ToString());
                                }
                            }

                            if (Sessao.Instance.Movimento != null)
                            {
                                MessageBox.Show("Movimento aberto com sucesso.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scAberto;
                                ImprimeAbertura();
                            }
                            Application.DoEvents();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Gerente ou Supervisor: nivel de acesso incorreto.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            editLoginGerente.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Gerente ou Supervisor: dados incorretos.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        editLoginGerente.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Operador: dados incorretos.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    editSenhaOperador.Focus();
                }
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }


        public void ImprimeAbertura()
        {
            DataModule.ACBrECF.AbreRelatorioGerencial(Sessao.Instance.Configuracao.EcfRelatorioGerencial.X.Value);
            DataModule.ACBrECF.LinhaRelatorioGerencial(new string('=', 48));
            DataModule.ACBrECF.LinhaRelatorioGerencial(" ABERTURA DE CAIXA ");
            DataModule.ACBrECF.PulaLinhas(1);
            DataModule.ACBrECF.LinhaRelatorioGerencial("DATA DE ABERTURA  : " + Sessao.Instance.Movimento.DataAbertura);
            DataModule.ACBrECF.LinhaRelatorioGerencial("HORA DE ABERTURA  : " + Sessao.Instance.Movimento.HoraAbertura);
            DataModule.ACBrECF.LinhaRelatorioGerencial(Sessao.Instance.Movimento.EcfCaixa.Nome + "  OPERADOR: " + Sessao.Instance.Movimento.EcfOperador.Login);
            DataModule.ACBrECF.LinhaRelatorioGerencial("MOVIMENTO: " + Convert.ToString(Sessao.Instance.Movimento.Id));
            DataModule.ACBrECF.LinhaRelatorioGerencial(new string('=', 48));
            DataModule.ACBrECF.PulaLinhas(1);
            if (editValorSuprimento.Text != "")
                DataModule.ACBrECF.LinhaRelatorioGerencial("SUPRIMENTO...: " + Convert.ToDecimal(editValorSuprimento.Text).ToString("0.00"));
            else
                DataModule.ACBrECF.LinhaRelatorioGerencial("SUPRIMENTO...: 0.00");
            DataModule.ACBrECF.PulaLinhas(3);
            DataModule.ACBrECF.LinhaRelatorioGerencial(" ________________________________________ ");
            DataModule.ACBrECF.LinhaRelatorioGerencial(" VISTO DO CAIXA ");
            DataModule.ACBrECF.PulaLinhas(3);
            DataModule.ACBrECF.LinhaRelatorioGerencial(" ________________________________________ ");
            DataModule.ACBrECF.LinhaRelatorioGerencial(" VISTO DO SUPERVISOR ");

            DataModule.ACBrECF.FechaRelatorio();
            PAFUtil.GravarR06("RG");
        }
    }

}

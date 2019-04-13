using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SISGMFWeb.ServicoSISGMFReference;

namespace SISGMFWeb.Account
{
    public partial class FuncionarioConsulta : System.Web.UI.Page
    {
        private int IdMercado;

        protected void Page_Load(object sender, EventArgs e)
        {
            AdicionarCabecalho();
            IdMercado = int.Parse(Request.QueryString["id_mercado"]);
            //
            Page.DataBind();
            //
            if (Session["MercadoNome"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                CarregarDados();
            }
        }


        private void CarregarDados()
        {
            try
            {
                LabelTitulo.Text = "Funcionários do Mercado: " + Request.QueryString["nome_mercado"];

                TableDados.Rows.Clear();
                AdicionarCabecalho();

                using (ServicoSISGMFClient Servico = new ServicoSISGMFClient())
                {
                    // Total de Vendedores por Área
                    FuncionarioDTO Funcionarios = new FuncionarioDTO();
                    Funcionarios.IdMercado = IdMercado;
                    List<FuncionarioDTO> ListaServ = Servico.SelectFuncionario(Funcionarios);

                    // Para cada Área monta uma linha na Table
                    foreach (FuncionarioDTO objAdd in ListaServ)
                    {
                        TableRow Linha = new TableRow();

                        TableCell ColunaNome = new TableCell();
                        ColunaNome.Text = objAdd.Nome;
                        Linha.Cells.Add(ColunaNome);

                        TableCell ColunaFuncao = new TableCell();
                        ColunaFuncao.Text = objAdd.Cargo.Nome;
                        Linha.Cells.Add(ColunaFuncao);

                        TableCell ColunaCelular1 = new TableCell();
                        ColunaCelular1.Text = objAdd.Celular1;
                        Linha.Cells.Add(ColunaCelular1);

                        TableCell ColunaCelular2 = new TableCell();
                        ColunaCelular2.Text = objAdd.Celular2;
                        Linha.Cells.Add(ColunaCelular2);

                        TableDados.Rows.Add(Linha);
                    }

                }

                AdicionarRodape();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AdicionarCabecalho()
        {
            TableHeaderRow LinhaCabecalho = new TableHeaderRow();

            LinhaCabecalho.BackColor = System.Drawing.Color.CadetBlue;
            LinhaCabecalho.ForeColor = System.Drawing.Color.White;

            TableHeaderCell ColunaCabecalhoArea = new TableHeaderCell();
            ColunaCabecalhoArea.Text = "Nome";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoArea);

            TableHeaderCell ColunaCabecalhoTotalVendedores = new TableHeaderCell();
            ColunaCabecalhoTotalVendedores.Text = "Função";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoTotalVendedores);

            TableHeaderCell ColunaCabecalhoPresencas = new TableHeaderCell();
            ColunaCabecalhoPresencas.Text = "Celular 1";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoPresencas);

            TableHeaderCell ColunaCabecalhoAusencias = new TableHeaderCell();
            ColunaCabecalhoAusencias.Text = "Celular 2";
            LinhaCabecalho.Cells.Add(ColunaCabecalhoAusencias);

            TableDados.Rows.Add(LinhaCabecalho);
        }


        private void AdicionarRodape()
        {
            TableFooterRow LinhaRodape = new TableFooterRow();

            LinhaRodape.Font.Bold = true;
            LinhaRodape.BackColor = System.Drawing.Color.CadetBlue;
            LinhaRodape.ForeColor = System.Drawing.Color.White;

            TableDados.Rows.Add(LinhaRodape);
        }

        protected void LinkButtonVoltar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Administracao.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FolhaClient.ViewModel.Folha;
using System.Diagnostics;
using Reportman.Reporting;
using Reportman.Drawing.Forms;
using System.Collections.ObjectModel;
using FolhaClient.ServicoFolhaReference;

namespace FolhaClient.View.Folha
{
    /// <summary>
    /// Interaction logic for FolhaPrincipal.xaml
    /// </summary>
    public partial class InformativosGuiasPrincipal : UserControl
    {
        public ObservableCollection<ColaboradorDTO> ListaColaborador { get; set; }
        private ColaboradorDTO _ColaboradorSelected;


        /// EXERCICIO
        /// Implemente a geração do arquivo de acordo com o padrão FEBRABAN

        public InformativosGuiasPrincipal()
        {
            InitializeComponent();
            ListaColaborador = new ObservableCollection<ColaboradorDTO>();

            using (ServicoFolhaClient Servico = new ServicoFolhaClient())
            {
                ColaboradorDTO Colaborador = new ColaboradorDTO();

                List<ColaboradorDTO> ListaServ = Servico.selectColaboradorPagina(0, 1, Colaborador);

                ListaColaborador.Clear();

                foreach (ColaboradorDTO objAdd in ListaServ)
                {
                    ListaColaborador.Add(objAdd);
                }
            }
        }


        public ColaboradorDTO ColaboradorSelected
        {
            get { return _ColaboradorSelected; }
            set
            {
                _ColaboradorSelected = value;
            }
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            ERPClient.JanelaInformativosGuias.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Implementado a critério do Participante do T2Ti ERP");
            // Relatório dos valores calculados para os colaboradores mês a mês dentro de determinado ano. 
            // Implementado a critério do Participante do T2Ti ERP
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Implementado a critério do Participante do T2Ti ERP");
            // Relatório com todos os rendimentos de um determinado período, por colaborador.
            // Implementado a critério do Participante do T2Ti ERP
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aguardar levantamento de requisitos do segundo ciclo por conta do eSocial");
            //Aguardar levantamento de requisitos do segundo ciclo por conta do eSocial
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aguardar levantamento de requisitos do segundo ciclo por conta do eSocial");
            //Aguardar levantamento de requisitos do segundo ciclo por conta do eSocial
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aguardar levantamento de requisitos do segundo ciclo por conta do eSocial");
            //Aguardar levantamento de requisitos do segundo ciclo por conta do eSocial
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aguardar levantamento de requisitos do segundo ciclo por conta do eSocial");
            //Aguardar levantamento de requisitos do segundo ciclo por conta do eSocial
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aguardar levantamento de requisitos do segundo ciclo por conta do eSocial");
            //Aguardar levantamento de requisitos do segundo ciclo por conta do eSocial
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Report rp = new Report();
                rp.LoadFromFile("GPS.rep");

                rp.Params["EMPRESA"].Value = "T2TI.COM";
                rp.Params["PERIODOAPURACAO"].Value = dpPeriodoApuracao.Text;
                rp.Params["DATAVENCIMENTO"].Value = dpVencimento.Text;
                rp.Params["CODIGORECEITA"].Value = textBoxCodReceita.Text;
                rp.Params["NUMEROREFERENCIA"].Value = textBoxNumRef.Text;
                rp.Params["VALORPRINCIPAL"].Value = textBoxVlrPrincipal.Text;
                rp.Params["VALORMULTA"].Value = textBoxMulta.Text;
                rp.Params["VALORJURO"].Value = textBoxJuros.Text;
                rp.Params["VALORTOTAL"].Value = textBoxTotal.Text;

                rp.AsyncExecution = false;

                PrintOutWinForms prw = new PrintOutWinForms();
                prw.Preview = true;
                prw.SystemPreview = false;
                prw.ShowPrintDialog = false;
                prw.Print(rp.MetaFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            gerarDarf();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            gerarDarf();
        }

        private void gerarDarf() {
            try
            {
                Report rp = new Report();
                rp.LoadFromFile("DARF.rep");

                rp.Params["EMPRESA"].Value = "T2TI.COM";
                rp.Params["PERIODOAPURACAO"].Value = dpPeriodoApuracao.Text;
                rp.Params["DATAVENCIMENTO"].Value = dpVencimento.Text;
                rp.Params["CODIGORECEITA"].Value = textBoxCodReceita.Text;
                rp.Params["NUMEROREFERENCIA"].Value = textBoxNumRef.Text;
                rp.Params["VALORPRINCIPAL"].Value = textBoxVlrPrincipal.Text;
                rp.Params["VALORMULTA"].Value = textBoxMulta.Text;
                rp.Params["VALORJURO"].Value = textBoxJuros.Text;
                rp.Params["VALORTOTAL"].Value = textBoxTotal.Text;

                rp.AsyncExecution = false;

                PrintOutWinForms prw = new PrintOutWinForms();
                prw.Preview = true;
                prw.SystemPreview = false;
                prw.ShowPrintDialog = false;
                prw.Print(rp.MetaFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            /* PROBLEMAS NO OCX
            try
            {
                ReportManX rp = new ReportManX();

                rp.filename = "DARF.rep";
                rp.SetParamValue("EMPRESA", "T2TI.COM");
                rp.SetParamValue("PERIODOAPURACAO", dpPeriodoApuracao.Text);
                rp.SetParamValue("DATAVENCIMENTO", dpVencimento.Text);
                rp.SetParamValue("CODIGORECEITA", textBoxCodReceita.Text);
                rp.SetParamValue("NUMEROREFERENCIA", textBoxNumRef.Text);
                rp.SetParamValue("VALORPRINCIPAL", textBoxVlrPrincipal.Text);
                rp.SetParamValue("VALORMULTA", textBoxMulta.Text);
                rp.SetParamValue("VALORJURO", textBoxJuros.Text);
                rp.SetParamValue("VALORTOTAL", textBoxTotal.Text);
                rp.Execute();

            }
            catch (Exception ex)
            {
            }*/
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            try
            {
                FolhaViewModel model = new FolhaViewModel();
                model.gerarCaged(textBoxCompetenciaCaged.Text, cbAutorizadoCaged.Text.Substring(0, 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            try
            {
                FolhaViewModel model = new FolhaViewModel();
                model.gerarSefip(textBoxCompetenciaGfip.Text, cbRecolhimentoGfip.Text.Substring(0, 3));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
    }
}

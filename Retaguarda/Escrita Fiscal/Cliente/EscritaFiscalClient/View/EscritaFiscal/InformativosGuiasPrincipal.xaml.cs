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
using EscritaFiscalClient.ViewModel.EscritaFiscal;
using System.Diagnostics;
using reportman;
using System.ServiceModel.Channels;
using Reportman.Reporting;
using Reportman.Drawing.Forms;

namespace EscritaFiscalClient.View.EscritaFiscal
{
    /// <summary>
    /// Interaction logic for EscritaFiscalPrincipal.xaml
    /// </summary>
    public partial class InformativosGuiasPrincipal : UserControl
    {
        private FiscalApuracaoIcmsViewModel viewModel;
        public InformativosGuiasPrincipal()
        {
            InitializeComponent();
            viewModel = new FiscalApuracaoIcmsViewModel();
            this.DataContext = viewModel;
        }

        private void btGerar_Click(object sender, RoutedEventArgs e)
        {
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

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            ERPClient.JanelaInformativosGuias.Close();
        }

        
    }
}

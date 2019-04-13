using FastReport;
using NFe.ViewModel;
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

namespace NFe.View
{
    /// <summary>
    /// Interaction logic for NFeDados.xaml
    /// </summary>
    public partial class NFeDados : UserControl
    {
        public NFeDados()
        {
            try
            {
                InitializeComponent();
                tabDadosBasicos.Content = new NFeDadosBasicos();
                tabDestinatario.Content = new NFeDestinatario();
                tabCupomVinculado.Content = new NFeCupomVinculado();
                tabEntregaRetirada.Content = new NFeEntregaRetirada();
                tabTransporte.Content = new NFeTransporte();
                tabCobranca.Content = new NFeFatura();
                tabProdutos.Content = new NFeProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");                
            }
        }

        private void btEnviar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((NFeViewModel)this.DataContext).GerarXmlNfe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }

        }

        private void btImprimirDanfe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((NFeViewModel)this.DataContext).ImprimirDANFE();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((NFeViewModel)this.DataContext).ConsultarStatusServico();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }

        }

        private void btInutilizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((NFeViewModel)this.DataContext).Inutilizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }

        }

        // EXERCICIO: refine o processo e imprima a etiqueta de acordo com a sua necessidade
        private void btEtiqueta_Click(object sender, RoutedEventArgs e)
        {
            Report rpt = new Report();
            rpt.Load("c:\\testes\\EMBALAGEM.frx");
            rpt.SetParameterValue("XEmitente", "T2Ti.COM");
            rpt.SetParameterValue("XCodigo", "Chave de Acesso");
            rpt.SetParameterValue("XDescricao", "Produtos Diversos");

            // EXERCICIO: pesquise sobre o SSCC e como ele deve ser implementado nessa rotina
            rpt.SetParameterValue("XSSCC", "123456789123456789");

            rpt.SetParameterValue("XConteudo", "NumeroNfe");

            // EXERCICIO: calcule a quantidade de itens para ser informada aqui
            rpt.SetParameterValue("XQuantidade", "10");

            rpt.Prepare();
            rpt.ShowPrepared();
        }

        private void btCCe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((NFeViewModel)this.DataContext).CCe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

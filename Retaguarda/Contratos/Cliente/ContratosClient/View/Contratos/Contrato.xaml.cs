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
using ContratosClient.ViewModel.Contratos;
using GEDClient.View.GED;

namespace ContratosClient.View.Contratos
{
    /// <summary>
    /// Interaction logic for Contrato.xaml
    /// </summary>
    public partial class Contrato : UserControl
    {
        public Contrato()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContratoViewModel)this.DataContext).IsEditar= false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TabGED.Content is ModuloIncluirDocumentoView &&
                    ((ModuloIncluirDocumentoView)TabGED.Content).idDocumento != null)
                    ((ContratoViewModel)this.DataContext).ContratoSelected.Numero = ((ModuloIncluirDocumentoView)TabGED.Content).idDocumento.ToString();

                ((ContratoViewModel)this.DataContext).salvarAtualizarContrato();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((ContratoViewModel)this.DataContext).atualizarListaContrato(0);
                ((ContratoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
		
		private void btPesquisarTipoContrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContratoViewModel)DataContext).pesquisarTipoContrato();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
	
		private void btPesquisarContratoSolicitacaoServico_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContratoViewModel)DataContext).pesquisarContratoSolicitacaoServico();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btGerar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContratoViewModel)DataContext).gerarContrato();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
    }
}

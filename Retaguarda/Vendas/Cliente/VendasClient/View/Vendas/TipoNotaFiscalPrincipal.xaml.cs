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
using VendasClient.ViewModel.Vendas;
using VendasClient.VendasReference;

namespace VendasClient.View.Vendas
{
    /// <summary>
    /// Interaction logic for TipoNotaFiscalPrincipal.xaml
    /// </summary>
    public partial class TipoNotaFiscalPrincipal : UserControl
    {
        private TipoNotaFiscalViewModel viewModel;
        public TipoNotaFiscalPrincipal()
        {
            InitializeComponent();
            viewModel = new TipoNotaFiscalViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.TipoNotaFiscalSelected != null)
                    viewModel.IsEditar = true;
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                viewModel.TipoNotaFiscalSelected = new TipoNotaFiscalDTO();
                viewModel.TipoNotaFiscalSelected.Empresa = new EmpresaDTO { Id = 1 };
                viewModel.IsEditar = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.TipoNotaFiscalSelected != null)
                {
                    viewModel.excluirTipoNotaFiscal();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaTipoNotaFiscal(0);
                }                
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

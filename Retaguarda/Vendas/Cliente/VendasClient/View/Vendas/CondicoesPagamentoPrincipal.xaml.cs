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
using VendasClient.VendasReference;
using VendasClient.ViewModel.Vendas;

namespace VendasClient.View.Vendas
{
    /// <summary>
    /// Interaction logic for CondicoesPagamentoPrincipal.xaml
    /// </summary>
    public partial class CondicoesPagamentoPrincipal : UserControl
    {
        private CondicoesPagamentoViewModel viewModel;
        public CondicoesPagamentoPrincipal()
        {
            InitializeComponent();
            viewModel = new CondicoesPagamentoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.CondicoesPagamentoSelected != null)
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
                viewModel.CondicoesPagamentoSelected = new CondicoesPagamentoDTO();
                viewModel.CondicoesPagamentoSelected.ListaCondicoesParcela = new List<CondicoesParcelaDTO>();
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
                if (viewModel.CondicoesPagamentoSelected != null)
                {
                    viewModel.excluirCondicoesPagamento();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaCondicoesPagamento(0);
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

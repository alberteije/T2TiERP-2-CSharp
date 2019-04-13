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
using OrcamentoClient.ViewModel.Orcamento;

namespace OrcamentoClient.View.Orcamento
{
    public partial class OrcamentoDetalhe : UserControl
    {
        public OrcamentoDetalhe()
        {
            InitializeComponent();
        }

        private void btPesquisarPeriodo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((OrcamentoViewModel)DataContext).pesquisarPeriodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btGerarOrcamento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((OrcamentoViewModel)DataContext).gerarOrcamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btConfirmar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((OrcamentoViewModel)DataContext).gravarOrcamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((OrcamentoViewModel)DataContext).carregaViewOrcamentoGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btCarregaOrcado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((OrcamentoViewModel)DataContext).carregaOrcado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dpData_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dpDataBase.SelectedDate = dpData.SelectedDate.Value.AddYears(-1);
        }

        private void btCalcularVariacao_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((OrcamentoViewModel)DataContext).calcularTaxa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

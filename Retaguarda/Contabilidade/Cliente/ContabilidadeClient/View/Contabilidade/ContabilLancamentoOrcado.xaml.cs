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
using ContabilidadeClient.ViewModel.Contabilidade;

namespace ContabilidadeClient.View.Contabilidade
{
    /// <summary>
    /// Interaction logic for ContabilLancamentoOrcado.xaml
    /// </summary>
    public partial class ContabilLancamentoOrcado : UserControl
    {
        public ContabilLancamentoOrcado()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContabilLancamentoOrcadoViewModel)this.DataContext).IsEditar= false;
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
                ((ContabilLancamentoOrcadoViewModel)this.DataContext).salvarAtualizarContabilLancamentoOrcado();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((ContabilLancamentoOrcadoViewModel)this.DataContext).atualizarListaContabilLancamentoOrcado(0);
                ((ContabilLancamentoOrcadoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarContabilConta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContabilLancamentoOrcadoViewModel)DataContext).pesquisarContabilConta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}

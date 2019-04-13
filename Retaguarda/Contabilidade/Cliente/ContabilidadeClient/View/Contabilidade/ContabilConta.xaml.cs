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
    /// Interaction logic for ContabilConta.xaml
    /// </summary>
    public partial class ContabilConta : UserControl
    {
        public ContabilConta()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContabilContaViewModel)this.DataContext).IsEditar= false;
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
                ((ContabilContaViewModel)this.DataContext).salvarAtualizarContabilConta();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((ContabilContaViewModel)this.DataContext).atualizarListaContabilConta(0);
                ((ContabilContaViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarPlanoContaRefSped_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContabilContaViewModel)DataContext).pesquisarPlanoContaRefSped();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


		
		private void btPesquisarPlanoConta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContabilContaViewModel)DataContext).pesquisarPlanoConta();
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
                ((ContabilContaViewModel)DataContext).pesquisarContabilConta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}

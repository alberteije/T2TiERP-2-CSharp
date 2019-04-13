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

namespace ContabilidadeClient.View.Contabilidade
{
    /// <summary>
    /// Interaction logic for ContabilIndice.xaml
    /// </summary>
    public partial class ContabilIndice : UserControl
    {
        public ContabilIndice()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContabilIndiceViewModel)this.DataContext).IsEditar= false;
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
                ((ContabilIndiceViewModel)this.DataContext).salvarAtualizarContabilIndice();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((ContabilIndiceViewModel)this.DataContext).atualizarListaContabilIndice(0);
                ((ContabilIndiceViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarIndiceEconomico_Click(object sender, RoutedEventArgs e)
        {
	        /*
             * Implemente essa rotina no servidor e no cliente
             * 
            try
            {
                ((ContabilIndiceViewModel)DataContext).pesquisarIndiceEconomico();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
             */
        }


    }
}

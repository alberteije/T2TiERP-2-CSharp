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
    /// Interaction logic for PlanoContaRefSped.xaml
    /// </summary>
    public partial class PlanoContaRefSped : UserControl
    {
        public PlanoContaRefSped()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((PlanoContaRefSpedViewModel)this.DataContext).IsEditar= false;
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
                ((PlanoContaRefSpedViewModel)this.DataContext).salvarAtualizarPlanoContaRefSped();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((PlanoContaRefSpedViewModel)this.DataContext).atualizarListaPlanoContaRefSped(0);
                ((PlanoContaRefSpedViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

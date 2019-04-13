using System;
using System.Windows;
using System.Windows.Controls;
using ContabilidadeClient.ViewModel.Contabilidade;

namespace ContabilidadeClient.View.Contabilidade
{
    /// <summary>
    /// Interaction logic for ContabilLivro.xaml
    /// </summary>
    public partial class ContabilLivro : UserControl
    {
        public ContabilLivro()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContabilLivroViewModel)this.DataContext).IsEditar= false;
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
                ((ContabilLivroViewModel)this.DataContext).salvarAtualizarContabilLivro();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((ContabilLivroViewModel)this.DataContext).atualizarListaContabilLivro(0);
                ((ContabilLivroViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

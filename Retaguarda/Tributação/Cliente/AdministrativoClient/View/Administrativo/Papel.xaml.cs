using System;
using System.Windows;
using System.Windows.Controls;
using AdministrativoClient.ViewModel.Administrativo;

namespace AdministrativoClient.View.Administrativo
{
    /// <summary>
    /// Interaction logic for Papel.xaml
    /// </summary>
    public partial class Papel : UserControl
    {
        public Papel()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((PapelViewModel)this.DataContext).IsEditar= false;
                ((PapelViewModel)this.DataContext).ListaControleAcesso.Clear();
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
                ((PapelViewModel)this.DataContext).salvarAtualizarPapel();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((PapelViewModel)this.DataContext).atualizarListaPapel(0);
                ((PapelViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

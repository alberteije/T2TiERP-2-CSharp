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
using FolhaClient.ViewModel.Folha;

namespace FolhaClient.View.Folha
{
    /// <summary>
    /// Interaction logic for FolhaFeriasColetivas.xaml
    /// </summary>
    public partial class FolhaFeriasColetivas : UserControl
    {
        public FolhaFeriasColetivas()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FolhaFeriasColetivasViewModel)this.DataContext).IsEditar= false;
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
                ((FolhaFeriasColetivasViewModel)this.DataContext).salvarAtualizarFolhaFeriasColetivas();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((FolhaFeriasColetivasViewModel)this.DataContext).atualizarListaFolhaFeriasColetivas(0);
                ((FolhaFeriasColetivasViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

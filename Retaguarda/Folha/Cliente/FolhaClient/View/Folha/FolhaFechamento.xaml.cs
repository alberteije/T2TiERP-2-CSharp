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
    /// Interaction logic for FolhaFechamento.xaml
    /// </summary>
    public partial class FolhaFechamento : UserControl
    {
        public FolhaFechamento()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FolhaFechamentoViewModel)this.DataContext).IsEditar= false;
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
                ((FolhaFechamentoViewModel)this.DataContext).salvarAtualizarFolhaFechamento();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((FolhaFechamentoViewModel)this.DataContext).atualizarListaFolhaFechamento(0);
                ((FolhaFechamentoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

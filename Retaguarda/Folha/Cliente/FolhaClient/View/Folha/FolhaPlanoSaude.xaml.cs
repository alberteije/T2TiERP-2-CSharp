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
    /// Interaction logic for FolhaPlanoSaude.xaml
    /// </summary>
    public partial class FolhaPlanoSaude : UserControl
    {
        public FolhaPlanoSaude()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FolhaPlanoSaudeViewModel)this.DataContext).IsEditar= false;
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
                ((FolhaPlanoSaudeViewModel)this.DataContext).salvarAtualizarFolhaPlanoSaude();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((FolhaPlanoSaudeViewModel)this.DataContext).atualizarListaFolhaPlanoSaude(0);
                ((FolhaPlanoSaudeViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


        private void btPesquisarColaborador_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FolhaPlanoSaudeViewModel)DataContext).pesquisarColaborador();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarOperadoraPlanoSaude_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FolhaPlanoSaudeViewModel)DataContext).pesquisarOperadoraPlanoSaude();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}

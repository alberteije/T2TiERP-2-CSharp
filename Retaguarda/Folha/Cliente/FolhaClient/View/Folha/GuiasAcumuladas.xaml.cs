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
    /// Interaction logic for GuiasAcumuladas.xaml
    /// </summary>
    public partial class GuiasAcumuladas : UserControl
    {
        public GuiasAcumuladas()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((GuiasAcumuladasViewModel)this.DataContext).IsEditar= false;
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
                ((GuiasAcumuladasViewModel)this.DataContext).salvarAtualizarGuiasAcumuladas();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((GuiasAcumuladasViewModel)this.DataContext).atualizarListaGuiasAcumuladas(0);
                ((GuiasAcumuladasViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

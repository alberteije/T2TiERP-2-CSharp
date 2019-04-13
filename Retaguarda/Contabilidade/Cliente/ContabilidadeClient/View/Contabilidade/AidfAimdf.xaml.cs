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
    /// Interaction logic for AidfAimdf.xaml
    /// </summary>
    public partial class AidfAimdf : UserControl
    {
        public AidfAimdf()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((AidfAimdfViewModel)this.DataContext).IsEditar= false;
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
                ((AidfAimdfViewModel)this.DataContext).salvarAtualizarAidfAimdf();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((AidfAimdfViewModel)this.DataContext).atualizarListaAidfAimdf(0);
                ((AidfAimdfViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

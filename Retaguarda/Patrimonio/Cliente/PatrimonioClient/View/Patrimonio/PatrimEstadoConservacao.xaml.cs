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
using PatrimonioClient.ViewModel.Patrimonio;

namespace PatrimonioClient.View.Patrimonio
{
    /// <summary>
    /// Interaction logic for PatrimEstadoConservacao.xaml
    /// </summary>
    public partial class PatrimEstadoConservacao : UserControl
    {
        public PatrimEstadoConservacao()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((PatrimEstadoConservacaoViewModel)this.DataContext).IsEditar= false;
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
                ((PatrimEstadoConservacaoViewModel)this.DataContext).salvarAtualizarPatrimEstadoConservacao();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((PatrimEstadoConservacaoViewModel)this.DataContext).atualizarListaPatrimEstadoConservacao(0);
                ((PatrimEstadoConservacaoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

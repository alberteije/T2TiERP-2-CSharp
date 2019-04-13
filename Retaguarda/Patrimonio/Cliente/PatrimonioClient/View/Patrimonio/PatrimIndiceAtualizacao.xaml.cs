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
    /// Interaction logic for PatrimIndiceAtualizacao.xaml
    /// </summary>
    public partial class PatrimIndiceAtualizacao : UserControl
    {
        public PatrimIndiceAtualizacao()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((PatrimIndiceAtualizacaoViewModel)this.DataContext).IsEditar= false;
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
                ((PatrimIndiceAtualizacaoViewModel)this.DataContext).salvarAtualizarPatrimIndiceAtualizacao();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((PatrimIndiceAtualizacaoViewModel)this.DataContext).atualizarListaPatrimIndiceAtualizacao(0);
                ((PatrimIndiceAtualizacaoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

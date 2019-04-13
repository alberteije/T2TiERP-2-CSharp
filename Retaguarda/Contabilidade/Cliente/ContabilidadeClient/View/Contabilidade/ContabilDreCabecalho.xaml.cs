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

namespace ContabilidadeClient.View.Contabilidade
{
    /// <summary>
    /// Interaction logic for ContabilDreCabecalho.xaml
    /// </summary>
    public partial class ContabilDreCabecalho : UserControl
    {
        public ContabilDreCabecalho()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContabilDreCabecalhoViewModel)this.DataContext).IsEditar= false;
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
                ((ContabilDreCabecalhoViewModel)this.DataContext).salvarAtualizarContabilDreCabecalho();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((ContabilDreCabecalhoViewModel)this.DataContext).atualizarListaContabilDreCabecalho(0);
                ((ContabilDreCabecalhoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

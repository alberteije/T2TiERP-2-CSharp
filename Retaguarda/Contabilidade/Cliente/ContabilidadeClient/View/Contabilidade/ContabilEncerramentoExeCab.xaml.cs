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
    /// Interaction logic for ContabilEncerramentoExeCab.xaml
    /// </summary>
    public partial class ContabilEncerramentoExeCab : UserControl
    {
        public ContabilEncerramentoExeCab()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContabilEncerramentoExeCabViewModel)this.DataContext).IsEditar= false;
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
                ((ContabilEncerramentoExeCabViewModel)this.DataContext).salvarAtualizarContabilEncerramentoExeCab();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((ContabilEncerramentoExeCabViewModel)this.DataContext).atualizarListaContabilEncerramentoExeCab(0);
                ((ContabilEncerramentoExeCabViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}

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

namespace PatrimonioClient.View.Patrimonio
{
    /// <summary>
    /// Interaction logic for PatrimTipoAquisicaoBem.xaml
    /// </summary>
    public partial class PatrimTipoAquisicaoBem : UserControl
    {
        public PatrimTipoAquisicaoBem()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((PatrimTipoAquisicaoBemViewModel)this.DataContext).IsEditar= false;
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
                ((PatrimTipoAquisicaoBemViewModel)this.DataContext).salvarAtualizarPatrimTipoAquisicaoBem();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((PatrimTipoAquisicaoBemViewModel)this.DataContext).atualizarListaPatrimTipoAquisicaoBem(0);
                ((PatrimTipoAquisicaoBemViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
		
    }
}

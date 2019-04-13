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
using ContratosClient.ViewModel.Contratos;

namespace ContratosClient.View.Contratos
{
    /// <summary>
    /// Interaction logic for TipoContrato.xaml
    /// </summary>
    public partial class TipoContrato : UserControl
    {
        public TipoContrato()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((TipoContratoViewModel)this.DataContext).IsEditar= false;
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
                ((TipoContratoViewModel)this.DataContext).salvarAtualizarTipoContrato();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((TipoContratoViewModel)this.DataContext).atualizarListaTipoContrato(0);
                ((TipoContratoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
    }
}

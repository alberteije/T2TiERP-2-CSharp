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
using AdministrativoClient.ViewModel.Administrativo;
using AdministrativoClient.ServicoAdministrativoReference;

namespace AdministrativoClient.View.Administrativo
{
    /// <summary>
    /// Interaction logic for TributIcmsCustomCabPrincipal.xaml
    /// </summary>
    public partial class TributIcmsCustomCabPrincipal : UserControl
    {
        private TributIcmsCustomCabViewModel viewModel;
        public TributIcmsCustomCabPrincipal()
        {
            InitializeComponent();
            viewModel = new TributIcmsCustomCabViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.TributIcmsCustomCabSelected != null)
                    viewModel.IsEditar = true;
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                viewModel.TributIcmsCustomCabSelected = new TributIcmsCustomCabDTO();
                viewModel.TributIcmsCustomCabSelected.ListaTributIcmsCustomDet = new List<TributIcmsCustomDetDTO>();

                viewModel.IsEditar = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.TributIcmsCustomCabSelected != null)
                {
                    viewModel.excluirTributIcmsCustomCab();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaTributIcmsCustomCab(0);
                }                
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

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
using AdministrativoClient.ServicoAdministrativoReference;
using AdministrativoClient.ViewModel.Administrativo;

namespace AdministrativoClient.View.Administrativo
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class TributIcmsCustomDetPrincipal : UserControl
    {
        public TributIcmsCustomDetPrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TributIcmsCustomDetDTO detalheDTO = new TributIcmsCustomDetDTO();
                detalheDTO.IdTributIcmsCustomCab = ((TributIcmsCustomCabViewModel)DataContext).TributIcmsCustomCabSelected.Id;

                ((TributIcmsCustomCabViewModel)DataContext).TributIcmsCustomDetSelected = detalheDTO;
                TributIcmsCustomDet viewDetalhe = new TributIcmsCustomDet();
                viewDetalhe.btSair.Click += new RoutedEventHandler(btSair_Click);
                viewDetalhe.btGravar.Click += new RoutedEventHandler(btGravar_Click);
                tabDetalhe.Content = viewDetalhe;
                tabDetalhe.IsSelected = true;
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
                if (((TributIcmsCustomCabViewModel)DataContext).TributIcmsCustomCabSelected != null)
                {
                    ((TributIcmsCustomCabViewModel)DataContext).TributIcmsCustomCabSelected.
                        ListaTributIcmsCustomDet.Remove(
                        ((TributIcmsCustomCabViewModel)DataContext).TributIcmsCustomDetSelected);
                    viewLista.dataGrid.Items.Refresh();
                }                
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((TributIcmsCustomCabViewModel)DataContext).TributIcmsCustomDetSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    TributIcmsCustomDet viewDetalhe = new TributIcmsCustomDet();
                    viewDetalhe.btSair.Click += new RoutedEventHandler(btSair_Click);
                    viewDetalhe.btGravar.Click += new RoutedEventHandler(btGravar_Click);
                    tabDetalhe.Content = viewDetalhe;
                }                
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema");
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        void btGravar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((TributIcmsCustomCabViewModel)DataContext).TributIcmsCustomCabSelected.
                    ListaTributIcmsCustomDet.Add(((TributIcmsCustomCabViewModel)DataContext).
                    TributIcmsCustomDetSelected);
                viewLista.dataGrid.Items.Refresh();
                tabDetalheLista.IsSelected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                viewLista.dataGrid.Items.Refresh();
                tabDetalheLista.IsSelected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

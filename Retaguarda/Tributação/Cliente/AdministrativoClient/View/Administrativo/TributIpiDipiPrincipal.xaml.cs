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
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class TributIpiDipiPrincipal : UserControl
    {
        public TributIpiDipiPrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TributIpiDipiDTO detalheDTO = new TributIpiDipiDTO();
                detalheDTO.IdTributConfiguraOfGt = ((TributConfiguraOfGtViewModel)DataContext).TributConfiguraOfGtSelected.Id;

                ((TributConfiguraOfGtViewModel)DataContext).TributIpiDipiSelected = detalheDTO;
                TributIpiDipi viewDetalhe = new TributIpiDipi();
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
                if (((TributConfiguraOfGtViewModel)DataContext).TributConfiguraOfGtSelected != null)
                {
                    ((TributConfiguraOfGtViewModel)DataContext).TributConfiguraOfGtSelected.
                        ListaTributIpiDipi.Remove(
                        ((TributConfiguraOfGtViewModel)DataContext).TributIpiDipiSelected);
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
                if (((TributConfiguraOfGtViewModel)DataContext).TributIpiDipiSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    TributIpiDipi viewDetalhe = new TributIpiDipi();
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
                ((TributConfiguraOfGtViewModel)DataContext).TributConfiguraOfGtSelected.
                    ListaTributIpiDipi.Add(((TributConfiguraOfGtViewModel)DataContext).
                    TributIpiDipiSelected);
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

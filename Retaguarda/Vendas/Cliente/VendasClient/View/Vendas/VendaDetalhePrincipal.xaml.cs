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
using VendasClient.VendasReference;
using VendasClient.ViewModel.Vendas;

namespace VendasClient.View.Vendas
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class VendaDetalhePrincipal : UserControl
    {
        public VendaDetalhePrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VendaDetalheDTO detalheDTO = new VendaDetalheDTO();
                detalheDTO.IdVendaCabecalho = ((VendaCabecalhoViewModel)DataContext).VendaCabecalhoSelected.Id;

                ((VendaCabecalhoViewModel)DataContext).VendaDetalheSelected = detalheDTO;
                VendaDetalhe viewDetalhe = new VendaDetalhe();
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
                if (((VendaCabecalhoViewModel)DataContext).VendaCabecalhoSelected != null)
                {
                    ((VendaCabecalhoViewModel)DataContext).VendaCabecalhoSelected.
                        ListaVendaDetalhe.Remove(
                        ((VendaCabecalhoViewModel)DataContext).VendaDetalheSelected);
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
                if (((VendaCabecalhoViewModel)DataContext).VendaDetalheSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    VendaDetalhe viewDetalhe = new VendaDetalhe();
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
                ((VendaCabecalhoViewModel)DataContext).VendaCabecalhoSelected.
                    ListaVendaDetalhe.Add(((VendaCabecalhoViewModel)DataContext).
                    VendaDetalheSelected);
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

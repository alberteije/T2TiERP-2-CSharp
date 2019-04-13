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
using EscritaFiscalClient.ServicoEscritaFiscalReference;
using EscritaFiscalClient.ViewModel.EscritaFiscal;

namespace EscritaFiscalClient.View.EscritaFiscal
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class SimplesNacionalDetalhePrincipal : UserControl
    {
        public SimplesNacionalDetalhePrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SimplesNacionalDetalheDTO detalheDTO = new SimplesNacionalDetalheDTO();
                detalheDTO.IdSimplesNacionalCabecalho = ((SimplesNacionalCabecalhoViewModel)DataContext).SimplesNacionalCabecalhoSelected.Id;

                ((SimplesNacionalCabecalhoViewModel)DataContext).SimplesNacionalDetalheSelected = detalheDTO;
                SimplesNacionalDetalhe viewDetalhe = new SimplesNacionalDetalhe();
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
                if (((SimplesNacionalCabecalhoViewModel)DataContext).SimplesNacionalCabecalhoSelected != null)
                {
                    ((SimplesNacionalCabecalhoViewModel)DataContext).SimplesNacionalCabecalhoSelected.
                        ListaSimplesNacionalDetalhe.Remove(
                        ((SimplesNacionalCabecalhoViewModel)DataContext).SimplesNacionalDetalheSelected);
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
                if (((SimplesNacionalCabecalhoViewModel)DataContext).SimplesNacionalDetalheSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    SimplesNacionalDetalhe viewDetalhe = new SimplesNacionalDetalhe();
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
                ((SimplesNacionalCabecalhoViewModel)DataContext).SimplesNacionalCabecalhoSelected.
                    ListaSimplesNacionalDetalhe.Add(((SimplesNacionalCabecalhoViewModel)DataContext).
                    SimplesNacionalDetalheSelected);
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

using System;
using System.Windows;
using System.Windows.Controls;
using ContasPagarClient.ContasPagarService;
using ContasPagarClient.ViewModel.ContasPagar;

namespace ContasPagarClient.View.ContasPagar
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class FinParcelaPagarPrincipal : UserControl
    {
        public FinParcelaPagarPrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FinParcelaPagarDTO detalheDTO = new FinParcelaPagarDTO();
                detalheDTO.IdFinLancamentoPagar = ((FinLancamentoPagarViewModel)DataContext).FinLancamentoPagarSelected.Id;

                ((FinLancamentoPagarViewModel)DataContext).FinParcelaPagarSelected = detalheDTO;
                FinParcelaPagar viewDetalhe = new FinParcelaPagar();
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
                if (((FinLancamentoPagarViewModel)DataContext).FinLancamentoPagarSelected != null)
                {
                    ((FinLancamentoPagarViewModel)DataContext).FinLancamentoPagarSelected.
                        ListaFinParcelaPagar.Remove(
                        ((FinLancamentoPagarViewModel)DataContext).FinParcelaPagarSelected);
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
                if (((FinLancamentoPagarViewModel)DataContext).FinParcelaPagarSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    FinParcelaPagar viewDetalhe = new FinParcelaPagar();
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
                ((FinLancamentoPagarViewModel)DataContext).FinLancamentoPagarSelected.
                    ListaFinParcelaPagar.Add(((FinLancamentoPagarViewModel)DataContext).
                    FinParcelaPagarSelected);
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

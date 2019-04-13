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
    public partial class FinParcelaPagamentoPrincipal : UserControl
    {
        public FinParcelaPagamentoPrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FinParcelaPagamentoDTO detalheDTO = new FinParcelaPagamentoDTO();
                detalheDTO.IdFinParcelaPagar = ((ViewFinLancamentoPagarViewModel)DataContext).ViewFinLancamentoPagarSelected.IdParcelaPagar;

                ((ViewFinLancamentoPagarViewModel)DataContext).FinParcelaPagamentoSelected = detalheDTO;
                FinParcelaPagamento viewDetalhe = new FinParcelaPagamento();
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
                if (((ViewFinLancamentoPagarViewModel)DataContext).ViewFinLancamentoPagarSelected != null)
                {
                    ((ViewFinLancamentoPagarViewModel)DataContext).ViewFinLancamentoPagarSelected.
                        ListaFinParcelaPagamento.Remove(
                        ((ViewFinLancamentoPagarViewModel)DataContext).FinParcelaPagamentoSelected);
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
                if (((ViewFinLancamentoPagarViewModel)DataContext).FinParcelaPagamentoSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    FinParcelaPagamento viewDetalhe = new FinParcelaPagamento();
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
                ((ViewFinLancamentoPagarViewModel)DataContext).ViewFinLancamentoPagarSelected.
                    ListaFinParcelaPagamento.Add(((ViewFinLancamentoPagarViewModel)DataContext).
                    FinParcelaPagamentoSelected);
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

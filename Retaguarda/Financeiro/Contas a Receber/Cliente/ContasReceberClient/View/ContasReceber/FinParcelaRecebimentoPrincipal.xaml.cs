using System;
using System.Windows;
using System.Windows.Controls;
using ContasReceberClient.ContasReceberService;
using ContasReceberClient.ViewModel.ContasReceber;

namespace ContasReceberClient.View.ContasReceber
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class FinParcelaRecebimentoPrincipal : UserControl
    {
        public FinParcelaRecebimentoPrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FinParcelaRecebimentoDTO detalheDTO = new FinParcelaRecebimentoDTO();
                detalheDTO.IdFinParcelaReceber = ((ViewFinLancamentoReceberViewModel)DataContext).ViewFinLancamentoReceberSelected.IdParcelaReceber;

                ((ViewFinLancamentoReceberViewModel)DataContext).FinParcelaRecebimentoSelected = detalheDTO;
                FinParcelaRecebimento viewDetalhe = new FinParcelaRecebimento();
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
                if (((ViewFinLancamentoReceberViewModel)DataContext).ViewFinLancamentoReceberSelected != null)
                {
                    ((ViewFinLancamentoReceberViewModel)DataContext).ViewFinLancamentoReceberSelected.
                        ListaFinParcelaRecebimento.Remove(
                        ((ViewFinLancamentoReceberViewModel)DataContext).FinParcelaRecebimentoSelected);
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
                if (((ViewFinLancamentoReceberViewModel)DataContext).FinParcelaRecebimentoSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    FinParcelaRecebimento viewDetalhe = new FinParcelaRecebimento();
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
                ((ViewFinLancamentoReceberViewModel)DataContext).ViewFinLancamentoReceberSelected.
                    ListaFinParcelaRecebimento.Add(((ViewFinLancamentoReceberViewModel)DataContext).
                    FinParcelaRecebimentoSelected);
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

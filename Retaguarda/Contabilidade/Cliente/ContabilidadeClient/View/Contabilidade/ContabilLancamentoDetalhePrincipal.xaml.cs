using System;
using System.Windows;
using System.Windows.Controls;
using ContabilidadeClient.ServicoContabilidadeReference;

namespace ContabilidadeClient.View.Contabilidade
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class ContabilLancamentoDetalhePrincipal : UserControl
    {
        public ContabilLancamentoDetalhePrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContabilLancamentoDetalheDTO detalheDTO = new ContabilLancamentoDetalheDTO();
                detalheDTO.IdContabilLancamentoCabecalho = ((ContabilLancamentoCabecalhoViewModel)DataContext).ContabilLancamentoCabecalhoSelected.Id;

                ((ContabilLancamentoCabecalhoViewModel)DataContext).ContabilLancamentoDetalheSelected = detalheDTO;
                ContabilLancamentoDetalhe viewDetalhe = new ContabilLancamentoDetalhe();
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
                if (((ContabilLancamentoCabecalhoViewModel)DataContext).ContabilLancamentoCabecalhoSelected != null)
                {
                    ((ContabilLancamentoCabecalhoViewModel)DataContext).ContabilLancamentoCabecalhoSelected.
                        ListaContabilLancamentoDetalhe.Remove(
                        ((ContabilLancamentoCabecalhoViewModel)DataContext).ContabilLancamentoDetalheSelected);
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
                if (((ContabilLancamentoCabecalhoViewModel)DataContext).ContabilLancamentoDetalheSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    ContabilLancamentoDetalhe viewDetalhe = new ContabilLancamentoDetalhe();
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
                ((ContabilLancamentoCabecalhoViewModel)DataContext).ContabilLancamentoCabecalhoSelected.
                    ListaContabilLancamentoDetalhe.Add(((ContabilLancamentoCabecalhoViewModel)DataContext).
                    ContabilLancamentoDetalheSelected);
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

using System;
using System.Windows;
using System.Windows.Controls;
using EstoqueClient.EstoqueServiceReference;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class EstoqueReajusteDetalhePrincipal : UserControl
    {
        public EstoqueReajusteDetalhePrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EstoqueReajusteDetalheDTO detalheDTO = new EstoqueReajusteDetalheDTO();
                detalheDTO.IdEstoqueReajusteCabecalho = ((EstoqueReajusteCabecalhoViewModel)DataContext).EstoqueReajusteCabecalhoSelected.Id;

                ((EstoqueReajusteCabecalhoViewModel)DataContext).EstoqueReajusteDetalheSelected = detalheDTO;
                EstoqueReajusteDetalhe viewDetalhe = new EstoqueReajusteDetalhe();
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
                if (((EstoqueReajusteCabecalhoViewModel)DataContext).EstoqueReajusteCabecalhoSelected != null)
                {
                    ((EstoqueReajusteCabecalhoViewModel)DataContext).EstoqueReajusteCabecalhoSelected.
                        ListaEstoqueReajusteDetalhe.Remove(
                        ((EstoqueReajusteCabecalhoViewModel)DataContext).EstoqueReajusteDetalheSelected);
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
                if (((EstoqueReajusteCabecalhoViewModel)DataContext).EstoqueReajusteDetalheSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    EstoqueReajusteDetalhe viewDetalhe = new EstoqueReajusteDetalhe();
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
                ((EstoqueReajusteCabecalhoViewModel)DataContext).EstoqueReajusteCabecalhoSelected.
                    ListaEstoqueReajusteDetalhe.Add(((EstoqueReajusteCabecalhoViewModel)DataContext).
                    EstoqueReajusteDetalheSelected);
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

        private void btCalculo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((EstoqueReajusteCabecalhoViewModel)DataContext).realizarCalculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

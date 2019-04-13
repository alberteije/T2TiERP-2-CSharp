using System;
using System.Windows;
using System.Windows.Controls;
using EstoqueClient.EstoqueServiceReference;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class EstoqueContagemDetalhePrincipal : UserControl
    {
        public EstoqueContagemDetalhePrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EstoqueContagemDetalheDTO detalheDTO = new EstoqueContagemDetalheDTO();
                detalheDTO.IdEstoqueContagemCabecalho = ((EstoqueContagemCabecalhoViewModel)DataContext).EstoqueContagemCabecalhoSelected.Id;

                ((EstoqueContagemCabecalhoViewModel)DataContext).EstoqueContagemDetalheSelected = detalheDTO;
                EstoqueContagemDetalhe viewDetalhe = new EstoqueContagemDetalhe();
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
                if (((EstoqueContagemCabecalhoViewModel)DataContext).EstoqueContagemCabecalhoSelected != null)
                {
                    ((EstoqueContagemCabecalhoViewModel)DataContext).EstoqueContagemCabecalhoSelected.listaContagemDetalhe.Remove(
                        ((EstoqueContagemCabecalhoViewModel)DataContext).EstoqueContagemDetalheSelected);
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
                if (((EstoqueContagemCabecalhoViewModel)DataContext).EstoqueContagemDetalheSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    EstoqueContagemDetalhe viewDetalhe = new EstoqueContagemDetalhe();
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
                ((EstoqueContagemCabecalhoViewModel)DataContext).EstoqueContagemCabecalhoSelected.
                    listaContagemDetalhe.Add(((EstoqueContagemCabecalhoViewModel)DataContext).
                    EstoqueContagemDetalheSelected);
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
                ((EstoqueContagemCabecalhoViewModel)DataContext).realizarCalculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

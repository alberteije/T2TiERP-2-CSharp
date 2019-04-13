using System;
using System.Windows;
using System.Windows.Controls;
using EstoqueClient.EstoqueServiceReference;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class RequisicaoInternaDetalhePrincipal : UserControl
    {
        public RequisicaoInternaDetalhePrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RequisicaoInternaDetalheDTO detalheDTO = new RequisicaoInternaDetalheDTO();
                detalheDTO.IdRequisicaoInternaCabecalho = ((RequisicaoInternaCabecalhoViewModel)DataContext).RequisicaoInternaCabecalhoSelected.Id;

                ((RequisicaoInternaCabecalhoViewModel)DataContext).RequisicaoInternaDetalheSelected = detalheDTO;
                RequisicaoInternaDetalhe viewDetalhe = new RequisicaoInternaDetalhe();
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
                if (((RequisicaoInternaCabecalhoViewModel)DataContext).RequisicaoInternaCabecalhoSelected != null)
                {
                    ((RequisicaoInternaCabecalhoViewModel)DataContext).RequisicaoInternaCabecalhoSelected.
                        ListaRequisicaoInternaDetalhe.Remove(
                        ((RequisicaoInternaCabecalhoViewModel)DataContext).RequisicaoInternaDetalheSelected);
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
                if (((RequisicaoInternaCabecalhoViewModel)DataContext).RequisicaoInternaDetalheSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    RequisicaoInternaDetalhe viewDetalhe = new RequisicaoInternaDetalhe();
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
                ((RequisicaoInternaCabecalhoViewModel)DataContext).RequisicaoInternaCabecalhoSelected.
                    ListaRequisicaoInternaDetalhe.Add(((RequisicaoInternaCabecalhoViewModel)DataContext).
                    RequisicaoInternaDetalheSelected);
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

using System;
using System.Windows;
using System.Windows.Controls;
using ContabilidadeClient.ServicoContabilidadeReference;
using ContabilidadeClient.ViewModel.Contabilidade;
    
namespace ContabilidadeClient.View.Contabilidade
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class ContabilTermoPrincipal : UserControl
    {
        public ContabilTermoPrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContabilTermoDTO detalheDTO = new ContabilTermoDTO();
                detalheDTO.IdContabilLivro = ((ContabilLivroViewModel)DataContext).ContabilLivroSelected.Id;

                ((ContabilLivroViewModel)DataContext).ContabilTermoSelected = detalheDTO;
                ContabilTermo viewDetalhe = new ContabilTermo();
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
                if (((ContabilLivroViewModel)DataContext).ContabilLivroSelected != null)
                {
                    ((ContabilLivroViewModel)DataContext).ContabilLivroSelected.
                        ListaContabilTermo.Remove(
                        ((ContabilLivroViewModel)DataContext).ContabilTermoSelected);
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
                if (((ContabilLivroViewModel)DataContext).ContabilTermoSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    ContabilTermo viewDetalhe = new ContabilTermo();
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
                ((ContabilLivroViewModel)DataContext).ContabilLivroSelected.
                    ListaContabilTermo.Add(((ContabilLivroViewModel)DataContext).
                    ContabilTermoSelected);
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

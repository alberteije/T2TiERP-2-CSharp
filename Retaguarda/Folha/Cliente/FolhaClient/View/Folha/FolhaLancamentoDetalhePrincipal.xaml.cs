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
using FolhaClient.ServicoFolhaReference;
using FolhaClient.ViewModel.Folha;

namespace FolhaClient.View.Folha
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class FolhaLancamentoDetalhePrincipal : UserControl
    {
        public FolhaLancamentoDetalhePrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FolhaLancamentoDetalheDTO detalheDTO = new FolhaLancamentoDetalheDTO();
                detalheDTO.IdFolhaLancamentoCabecalho = ((FolhaLancamentoCabecalhoViewModel)DataContext).FolhaLancamentoCabecalhoSelected.Id;

                ((FolhaLancamentoCabecalhoViewModel)DataContext).FolhaLancamentoDetalheSelected = detalheDTO;
                FolhaLancamentoDetalhe viewDetalhe = new FolhaLancamentoDetalhe();
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
                if (((FolhaLancamentoCabecalhoViewModel)DataContext).FolhaLancamentoCabecalhoSelected != null)
                {
                    ((FolhaLancamentoCabecalhoViewModel)DataContext).FolhaLancamentoCabecalhoSelected.
                        ListaFolhaLancamentoDetalhe.Remove(
                        ((FolhaLancamentoCabecalhoViewModel)DataContext).FolhaLancamentoDetalheSelected);
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
                if (((FolhaLancamentoCabecalhoViewModel)DataContext).FolhaLancamentoDetalheSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    FolhaLancamentoDetalhe viewDetalhe = new FolhaLancamentoDetalhe();
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
                ((FolhaLancamentoCabecalhoViewModel)DataContext).FolhaLancamentoCabecalhoSelected.
                    ListaFolhaLancamentoDetalhe.Add(((FolhaLancamentoCabecalhoViewModel)DataContext).
                    FolhaLancamentoDetalheSelected);
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

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
    public partial class FolhaPppAtividadePrincipal : UserControl
    {
        public FolhaPppAtividadePrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FolhaPppAtividadeDTO detalheDTO = new FolhaPppAtividadeDTO();
                detalheDTO.IdFolhaPpp = ((FolhaPppViewModel)DataContext).FolhaPppSelected.Id;

                ((FolhaPppViewModel)DataContext).FolhaPppAtividadeSelected = detalheDTO;
                FolhaPppAtividade viewDetalhe = new FolhaPppAtividade();
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
                if (((FolhaPppViewModel)DataContext).FolhaPppSelected != null)
                {
                    ((FolhaPppViewModel)DataContext).FolhaPppSelected.
                        ListaFolhaPppAtividade.Remove(
                        ((FolhaPppViewModel)DataContext).FolhaPppAtividadeSelected);
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
                if (((FolhaPppViewModel)DataContext).FolhaPppAtividadeSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    FolhaPppAtividade viewDetalhe = new FolhaPppAtividade();
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
                ((FolhaPppViewModel)DataContext).FolhaPppSelected.
                    ListaFolhaPppAtividade.Add(((FolhaPppViewModel)DataContext).
                    FolhaPppAtividadeSelected);
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

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
using PatrimonioClient.ServicoPatrimonioReference;
using PatrimonioClient.ViewModel.Patrimonio;

namespace PatrimonioClient.View.Patrimonio
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class PatrimMovimentacaoBemPrincipal : UserControl
    {
        public PatrimMovimentacaoBemPrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PatrimMovimentacaoBemDTO detalheDTO = new PatrimMovimentacaoBemDTO();
                detalheDTO.IdPatrimBem = ((PatrimBemViewModel)DataContext).PatrimBemSelected.Id;

                ((PatrimBemViewModel)DataContext).PatrimMovimentacaoBemSelected = detalheDTO;
                PatrimMovimentacaoBem viewDetalhe = new PatrimMovimentacaoBem();
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
                if (((PatrimBemViewModel)DataContext).PatrimMovimentacaoBemSelected != null)
                {
                    ((PatrimBemViewModel)DataContext).PatrimBemSelected.
                        ListaPatrimMovimentacaoBem.Remove(
                        ((PatrimBemViewModel)DataContext).PatrimMovimentacaoBemSelected);
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
                if (((PatrimBemViewModel)DataContext).PatrimMovimentacaoBemSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    PatrimMovimentacaoBem viewDetalhe = new PatrimMovimentacaoBem();
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
                ((PatrimBemViewModel)DataContext).PatrimBemSelected.
                    ListaPatrimMovimentacaoBem.Add(((PatrimBemViewModel)DataContext).
                    PatrimMovimentacaoBemSelected);
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

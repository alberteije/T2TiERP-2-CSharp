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
using ContratosClient.ContratosReference;
using ContratosClient.ViewModel.Contratos;

namespace ContratosClient.View.Contratos
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class ContratoPrevFaturamentoPrincipal : UserControl
    {
        public ContratoPrevFaturamentoPrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContratoPrevFaturamentoDTO detalheDTO = new ContratoPrevFaturamentoDTO();
                detalheDTO.IdContrato = ((ContratoViewModel)DataContext).ContratoSelected.Id;

                ((ContratoViewModel)DataContext).ContratoPrevFaturamentoSelected = detalheDTO;
                ContratoPrevFaturamento viewDetalhe = new ContratoPrevFaturamento();
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
                if (((ContratoViewModel)DataContext).ContratoSelected != null)
                {
                    ((ContratoViewModel)DataContext).ContratoSelected.
                        ListaContratoPrevFaturamento.Remove(
                        ((ContratoViewModel)DataContext).ContratoPrevFaturamentoSelected);
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
                if (((ContratoViewModel)DataContext).ContratoPrevFaturamentoSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    ContratoPrevFaturamento viewDetalhe = new ContratoPrevFaturamento();
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
                ((ContratoViewModel)DataContext).ContratoSelected.
                    ListaContratoPrevFaturamento.Add(((ContratoViewModel)DataContext).
                    ContratoPrevFaturamentoSelected);
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

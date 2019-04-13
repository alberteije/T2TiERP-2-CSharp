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
    public partial class ContratoHistFaturamentoPrincipal : UserControl
    {
        public ContratoHistFaturamentoPrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContratoHistFaturamentoDTO detalheDTO = new ContratoHistFaturamentoDTO();
                detalheDTO.IdContrato = ((ContratoViewModel)DataContext).ContratoSelected.Id;

                ((ContratoViewModel)DataContext).ContratoHistFaturamentoSelected = detalheDTO;
                ContratoHistFaturamento viewDetalhe = new ContratoHistFaturamento();
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
                        ListaContratoHistFaturamento.Remove(
                        ((ContratoViewModel)DataContext).ContratoHistFaturamentoSelected);
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
                if (((ContratoViewModel)DataContext).ContratoHistFaturamentoSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    ContratoHistFaturamento viewDetalhe = new ContratoHistFaturamento();
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
                    ListaContratoHistFaturamento.Add(((ContratoViewModel)DataContext).
                    ContratoHistFaturamentoSelected);
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

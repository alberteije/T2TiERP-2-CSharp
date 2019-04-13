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
using VendasClient.ViewModel.Vendas;
using VendasClient.VendasReference;

namespace VendasClient.View.Vendas
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class CondicoesParcelaPrincipal : UserControl
    {
        public CondicoesParcelaPrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CondicoesParcelaDTO detalheDTO = new CondicoesParcelaDTO();
                detalheDTO.IdCondicoesPagamento = ((CondicoesPagamentoViewModel)DataContext).CondicoesPagamentoSelected.Id;

                ((CondicoesPagamentoViewModel)DataContext).CondicoesParcelaSelected = detalheDTO;
                CondicoesParcela viewDetalhe = new CondicoesParcela();
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
                if (((CondicoesPagamentoViewModel)DataContext).CondicoesPagamentoSelected != null)
                {
                    ((CondicoesPagamentoViewModel)DataContext).CondicoesPagamentoSelected.
                        ListaCondicoesParcela.Remove(
                        ((CondicoesPagamentoViewModel)DataContext).CondicoesParcelaSelected);
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
                if (((CondicoesPagamentoViewModel)DataContext).CondicoesParcelaSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    CondicoesParcela viewDetalhe = new CondicoesParcela();
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
                ((CondicoesPagamentoViewModel)DataContext).CondicoesPagamentoSelected.
                    ListaCondicoesParcela.Add(((CondicoesPagamentoViewModel)DataContext).
                    CondicoesParcelaSelected);
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

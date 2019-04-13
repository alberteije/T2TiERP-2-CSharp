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
using ContabilidadeClient.ServicoContabilidadeReference;

namespace ContabilidadeClient.View.Contabilidade
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class ContabilIndiceValorPrincipal : UserControl
    {
        public ContabilIndiceValorPrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContabilIndiceValorDTO detalheDTO = new ContabilIndiceValorDTO();
                detalheDTO.IdContabilIndice = ((ContabilIndiceViewModel)DataContext).ContabilIndiceSelected.Id;

                ((ContabilIndiceViewModel)DataContext).ContabilIndiceValorSelected = detalheDTO;
                ContabilIndiceValor viewDetalhe = new ContabilIndiceValor();
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
                if (((ContabilIndiceViewModel)DataContext).ContabilIndiceSelected != null)
                {
                    ((ContabilIndiceViewModel)DataContext).ContabilIndiceSelected.
                        ListaContabilIndiceValor.Remove(
                        ((ContabilIndiceViewModel)DataContext).ContabilIndiceValorSelected);
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
                if (((ContabilIndiceViewModel)DataContext).ContabilIndiceValorSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    ContabilIndiceValor viewDetalhe = new ContabilIndiceValor();
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
                ((ContabilIndiceViewModel)DataContext).ContabilIndiceSelected.
                    ListaContabilIndiceValor.Add(((ContabilIndiceViewModel)DataContext).
                    ContabilIndiceValorSelected);
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

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
    public partial class ContabilEncerramentoExeDetPrincipal : UserControl
    {
        public ContabilEncerramentoExeDetPrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContabilEncerramentoExeDetDTO detalheDTO = new ContabilEncerramentoExeDetDTO();
                detalheDTO.IdContabilEncerramentoExeCab = ((ContabilEncerramentoExeCabViewModel)DataContext).ContabilEncerramentoExeCabSelected.Id;

                ((ContabilEncerramentoExeCabViewModel)DataContext).ContabilEncerramentoExeDetSelected = detalheDTO;
                ContabilEncerramentoExeDet viewDetalhe = new ContabilEncerramentoExeDet();
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
                if (((ContabilEncerramentoExeCabViewModel)DataContext).ContabilEncerramentoExeCabSelected != null)
                {
                    ((ContabilEncerramentoExeCabViewModel)DataContext).ContabilEncerramentoExeCabSelected.
                        ListaContabilEncerramentoExeDet.Remove(
                        ((ContabilEncerramentoExeCabViewModel)DataContext).ContabilEncerramentoExeDetSelected);
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
                if (((ContabilEncerramentoExeCabViewModel)DataContext).ContabilEncerramentoExeDetSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    ContabilEncerramentoExeDet viewDetalhe = new ContabilEncerramentoExeDet();
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
                ((ContabilEncerramentoExeCabViewModel)DataContext).ContabilEncerramentoExeCabSelected.
                    ListaContabilEncerramentoExeDet.Add(((ContabilEncerramentoExeCabViewModel)DataContext).
                    ContabilEncerramentoExeDetSelected);
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

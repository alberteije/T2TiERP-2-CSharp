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

namespace ]
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class OsEvolucaoPrincipal : UserControl
    {
        public OsEvolucaoPrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OsEvolucaoDTO detalheDTO = new OsEvolucaoDTO();
                detalheDTO.Id = ((ViewModel)DataContext).Selected.Id;

                ((ViewModel)DataContext).OsEvolucaoSelected = detalheDTO;
                OsEvolucao viewDetalhe = new OsEvolucao();
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
                if (((ViewModel)DataContext).Selected != null)
                {
                    ((ViewModel)DataContext).Selected.
                        ListaOsEvolucao.Remove(
                        ((ViewModel)DataContext).OsEvolucaoSelected);
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
                if (((ViewModel)DataContext).OsEvolucaoSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    OsEvolucao viewDetalhe = new OsEvolucao();
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
                ((ViewModel)DataContext).Selected.
                    ListaOsEvolucao.Add(((ViewModel)DataContext).
                    OsEvolucaoSelected);
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

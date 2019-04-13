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
    public partial class PatrimDocumentoBemPrincipal : UserControl
    {
        public PatrimDocumentoBemPrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PatrimDocumentoBemDTO detalheDTO = new PatrimDocumentoBemDTO();
                detalheDTO.IdPatrimBem = ((PatrimBemViewModel)DataContext).PatrimBemSelected.Id;

                ((PatrimBemViewModel)DataContext).PatrimDocumentoBemSelected = detalheDTO;
                PatrimDocumentoBem viewDetalhe = new PatrimDocumentoBem();
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
                if (((PatrimBemViewModel)DataContext).PatrimBemSelected != null)
                {
                    ((PatrimBemViewModel)DataContext).PatrimBemSelected.
                        ListaPatrimDocumentoBem.Remove(
                        ((PatrimBemViewModel)DataContext).PatrimDocumentoBemSelected);
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
                if (((PatrimBemViewModel)DataContext).PatrimDocumentoBemSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    PatrimDocumentoBem viewDetalhe = new PatrimDocumentoBem();
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
                    ListaPatrimDocumentoBem.Add(((PatrimBemViewModel)DataContext).
                    PatrimDocumentoBemSelected);
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

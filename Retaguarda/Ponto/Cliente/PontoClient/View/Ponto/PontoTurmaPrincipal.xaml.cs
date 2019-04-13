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
using PontoClient.ServicoPontoReference;
using PontoClient.ViewModel.Ponto;

namespace PontoClient.View.Ponto
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class PontoTurmaPrincipal : UserControl
    {
        public PontoTurmaPrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PontoTurmaDTO detalheDTO = new PontoTurmaDTO();
                detalheDTO.IdPontoEscala = ((PontoEscalaViewModel)DataContext).PontoEscalaSelected.Id;

                ((PontoEscalaViewModel)DataContext).PontoTurmaSelected = detalheDTO;
                PontoTurma viewDetalhe = new PontoTurma();
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
                if (((PontoEscalaViewModel)DataContext).PontoEscalaSelected != null)
                {
                    ((PontoEscalaViewModel)DataContext).PontoEscalaSelected.
                        ListaPontoTurma.Remove(
                        ((PontoEscalaViewModel)DataContext).PontoTurmaSelected);
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
                if (((PontoEscalaViewModel)DataContext).PontoTurmaSelected != null)
                {
                    tabDetalhe.IsSelected = true;
                    PontoTurma viewDetalhe = new PontoTurma();
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
                ((PontoEscalaViewModel)DataContext).PontoEscalaSelected.
                    ListaPontoTurma.Add(((PontoEscalaViewModel)DataContext).
                    PontoTurmaSelected);
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

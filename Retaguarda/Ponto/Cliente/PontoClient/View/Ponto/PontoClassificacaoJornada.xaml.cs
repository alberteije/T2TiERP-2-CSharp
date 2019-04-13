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
using PontoClient.ViewModel.Ponto;

namespace PontoClient.View.Ponto
{
    /// <summary>
    /// Interaction logic for PontoClassificacaoJornada.xaml
    /// </summary>
    public partial class PontoClassificacaoJornada : UserControl
    {
        public PontoClassificacaoJornada()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((PontoClassificacaoJornadaViewModel)this.DataContext).IsEditar= false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((PontoClassificacaoJornadaViewModel)this.DataContext).salvarAtualizarPontoClassificacaoJornada();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((PontoClassificacaoJornadaViewModel)this.DataContext).atualizarListaPontoClassificacaoJornada(0);
                ((PontoClassificacaoJornadaViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
    }
}

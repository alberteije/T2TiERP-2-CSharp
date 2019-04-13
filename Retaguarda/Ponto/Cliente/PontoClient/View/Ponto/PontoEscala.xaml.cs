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
    /// Interaction logic for PontoEscala.xaml
    /// </summary>
    public partial class PontoEscala : UserControl
    {
        public PontoEscala()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((PontoEscalaViewModel)this.DataContext).IsEditar= false;
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
                ((PontoEscalaViewModel)this.DataContext).salvarAtualizarPontoEscala();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((PontoEscalaViewModel)this.DataContext).atualizarListaPontoEscala(0);
                ((PontoEscalaViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

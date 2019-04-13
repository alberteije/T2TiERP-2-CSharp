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

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for NFeDados.xaml
    /// </summary>
    public partial class NFeDados : UserControl
    {
        public NFeDados()
        {
            try
            {
                InitializeComponent();
                tabDadosBasicos.Content = new NFeDadosBasicos();
                tabEmitente.Content = new NFeEmitente();
                tabCupomVinculado.Content = new NFeCupomVinculado();
                tabEntregaRetirada.Content = new NFeEntregaRetirada();
                tabTransporte.Content = new NFeTransporte();
                tabCobranca.Content = new NFeFatura();
                tabProdutos.Content = new NFeProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");                
            }
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((EstoqueViewModel)this.DataContext).carregarTabLista();
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
                ((EstoqueViewModel)this.DataContext).salvarNFe();
                MessageBox.Show("Operação efetuada com sucesso.", "Mensagem do sistema");
                ((EstoqueViewModel)this.DataContext).carregarTabLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

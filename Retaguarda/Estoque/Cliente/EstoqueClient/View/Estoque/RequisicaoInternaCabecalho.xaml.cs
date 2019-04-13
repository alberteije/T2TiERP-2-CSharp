using System;
using System.Windows;
using System.Windows.Controls;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for RequisicaoInternaCabecalho.xaml
    /// </summary>
    public partial class RequisicaoInternaCabecalho : UserControl
    {
        public RequisicaoInternaCabecalho()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((RequisicaoInternaCabecalhoViewModel)this.DataContext).IsEditar= false;
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
                ((RequisicaoInternaCabecalhoViewModel)this.DataContext).salvarAtualizarRequisicaoInternaCabecalho();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((RequisicaoInternaCabecalhoViewModel)this.DataContext).atualizarListaRequisicaoInternaCabecalho(0);
                ((RequisicaoInternaCabecalhoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarColaborador_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((RequisicaoInternaCabecalhoViewModel)DataContext).pesquisarColaborador();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}

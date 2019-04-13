using System;
using System.Windows;
using System.Windows.Controls;
using ComprasClient.ViewModel.Compras;

namespace ComprasClient.View.Compras
{
    /// <summary>
    /// Interaction logic for CompraTipoRequisicao.xaml
    /// </summary>
    public partial class CompraTipoRequisicao : UserControl
    {
        public CompraTipoRequisicao()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((CompraTipoRequisicaoViewModel)this.DataContext).IsEditar= false;
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
                ((CompraTipoRequisicaoViewModel)this.DataContext).salvarAtualizarCompraTipoRequisicao();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((CompraTipoRequisicaoViewModel)this.DataContext).atualizarListaCompraTipoRequisicao(0);
                ((CompraTipoRequisicaoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}

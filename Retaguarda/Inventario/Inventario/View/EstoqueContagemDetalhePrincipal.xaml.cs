using Cadastros.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class EstoqueContagemDetalhePrincipal : UserControl
    {
        public EstoqueContagemDetalhePrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            /// EXERCICIO
            /// Permita o usuário selecionar todos os produtos de determinado grupo ou subgrupo
            /// para realizar a contagem

            /// EXERCICIO
            /// Quando a quantidade contada for igual a quantidade do sistema, atualize o campo
            /// FECHADO_CONTAGEM


            /*
            try
            {
                EstoqueContagemDetalheDTO detalheDTO = new EstoqueContagemDetalheDTO();
                detalheDTO.IdEstoqueContagemCabecalho = ((EstoqueContagemCabecalhoViewModel)DataContext).EstoqueContagemCabecalhoSelected.Id;

                ((EstoqueContagemCabecalhoViewModel)DataContext).EstoqueContagemDetalheSelected = detalheDTO;
                EstoqueContagemDetalhe viewDetalhe = new EstoqueContagemDetalhe();
                viewDetalhe.btSair.Click += new RoutedEventHandler(btSair_Click);
                viewDetalhe.btGravar.Click += new RoutedEventHandler(btGravar_Click);
                tabDetalhe.Content = viewDetalhe;
                tabDetalhe.IsSelected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }*/
        }

        private void btCalculo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((InventarioContagemCabViewModel)DataContext).realizarCalculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

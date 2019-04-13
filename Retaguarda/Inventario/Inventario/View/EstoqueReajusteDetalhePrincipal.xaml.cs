using Cadastros.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for DetalhePrincipal.xaml
    /// </summary>
    public partial class EstoqueReajusteDetalhePrincipal : UserControl
    {
        public EstoqueReajusteDetalhePrincipal()
        {
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            /// EXERCICIO
            /// Permita o usuário selecionar todos os produtos de determinado grupo ou subgrupo
            /// para realizar a contagem

            /// EXERCICIO
            ///  Adapte essa janela para ajustar também a quantidade do estoque de forma
            ///  manual fornecendo uma justificativa, de acordo com o requisito 002.
            ///  Observe no Change-log quais campos foram adicionados nas tabelas para
            ///  permitir o reajuste na quantidade.            

            /*
            try
            {
                EstoqueReajusteDetalheDTO detalheDTO = new EstoqueReajusteDetalheDTO();
                detalheDTO.IdEstoqueReajusteCabecalho = ((EstoqueReajusteCabecalhoViewModel)DataContext).EstoqueReajusteCabecalhoSelected.Id;

                ((EstoqueReajusteCabecalhoViewModel)DataContext).EstoqueReajusteDetalheSelected = detalheDTO;
                EstoqueReajusteDetalhe viewDetalhe = new EstoqueReajusteDetalhe();
                viewDetalhe.btSair.Click += new RoutedEventHandler(btSair_Click);
                viewDetalhe.btGravar.Click += new RoutedEventHandler(btGravar_Click);
                tabDetalhe.Content = viewDetalhe;
                tabDetalhe.IsSelected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        */}

        private void btCalculo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((EstoqueReajusteCabecalhoViewModel)DataContext).realizarCalculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}

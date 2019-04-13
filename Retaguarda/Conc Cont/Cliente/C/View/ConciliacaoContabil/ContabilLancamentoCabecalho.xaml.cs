using System;
using System.Windows;
using System.Windows.Controls;

namespace ConciliacaoContabilClient.View.ConciliacaoContabil
{
    /// <summary>
    /// Interaction logic for ContabilLancamentoCabecalho.xaml
    /// </summary>
    public partial class ContabilLancamentoCabecalho : UserControl
    {
        public ContabilLancamentoCabecalho()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContabilLancamentoCabecalhoViewModel)this.DataContext).IsEditar= false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void BotaoConciliacao_Click(object sender, RoutedEventArgs e)
        {
            /*
               Faça um laço na lista e verifique se os dados de lançamento correspondem com tipo de lançamento:
              		Um Débito para Vários Créditos Tag="UDVC"
				    Um Crédito para Vários Débitos Tag="UCVD"
                    Um Débito para Um Crédito Tag="UDUC"
                    Vários Débitos para Vários Créditos Tag="VDVC"
             */ 

        }

        private void BotaoEstorno_Click(object sender, RoutedEventArgs e)
        {
            /* Implementado a critério do Participante do T2Ti ERP 
            
            Pesquise sobre estornos de lançamentos contábeis e implemente no seu sistema.

            */ 
        }

        private void BotaoTransferencia_Click(object sender, RoutedEventArgs e)
        {
            /* Implementado a critério do Participante do T2Ti ERP 
            
            Pesquise sobre transferência de lançamentos contábeis e implemente no seu sistema.

            */ 
        }

        private void BotaoComplementacao_Click(object sender, RoutedEventArgs e)
        {
            /* Implementado a critério do Participante do T2Ti ERP 
            
            Pesquise sobre complementação de lançamentos contábeis e implemente no seu sistema.

            */ 
        }

    }
}

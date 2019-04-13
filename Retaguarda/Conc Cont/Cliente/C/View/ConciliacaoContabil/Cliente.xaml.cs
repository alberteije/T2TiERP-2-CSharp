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
using ConciliacaoContabilClient.ViewModel.ConciliacaoContabil;
using ConciliacaoContabilClient.ServicoConciliacaoContabilReference;
using ConciliacaoContabilClient.Model;

namespace ConciliacaoContabilClient.View.ConciliacaoContabil
{
    /// <summary>
    /// Interaction logic for Cliente.xaml
    /// </summary>
    public partial class Cliente : UserControl
    {
        public Cliente()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ConciliaClienteViewModel)this.DataContext).IsEditar= false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void BotaoListarLancamentos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ConciliaClienteViewModel)this.DataContext).atualizarListaViewConciliaCliente(0);
                ((ConciliaClienteViewModel)this.DataContext).atualizarListaContabilLancamentoDetalhe(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void BotaoConciliacao_Click(object sender, RoutedEventArgs e)
        {
            foreach (ViewConciliaClienteDTO LancamentoViewConciliaCliente in ((ConciliaClienteViewModel)this.DataContext).ListaViewConciliaCliente)
            {
                foreach (ContabilLancamentoDetalheDTO LancamentoContabil in ((ConciliaClienteViewModel)this.DataContext).ListaContabilLancamentoDetalhe)
                {
                    if (LancamentoViewConciliaCliente.ValorRecebido == LancamentoContabil.Valor)
                    {
                        LancamentoConciliadoDTO LancamentoConciliado = new LancamentoConciliadoDTO();
                        LancamentoConciliado.Mes = String.Format("{0:MM}", LancamentoViewConciliaCliente.DataRecebimento);
                        LancamentoConciliado.Ano = String.Format("{0:YYYY}", LancamentoViewConciliaCliente.DataRecebimento); 
                        LancamentoConciliado.DataMovimento = LancamentoViewConciliaCliente.DataRecebimento;
                        LancamentoConciliado.DataBalancete = LancamentoViewConciliaCliente.DataRecebimento;
                        LancamentoConciliado.HistoricoExtrato = LancamentoViewConciliaCliente.Historico;
                        LancamentoConciliado.ValorExtrato = LancamentoViewConciliaCliente.ValorRecebido;
                        LancamentoConciliado.Classificacao = LancamentoContabil.ContabilConta.Classificacao;
                        LancamentoConciliado.HistoricoConta = LancamentoContabil.Historico;
                        LancamentoConciliado.Tipo = LancamentoContabil.Tipo;
                        LancamentoConciliado.ValorConta = LancamentoContabil.Valor;

                        ((ConciliaClienteViewModel)this.DataContext).ListaLancamentoConciliado.Add(LancamentoConciliado);
                    }
                }
            }
        }

    }
}

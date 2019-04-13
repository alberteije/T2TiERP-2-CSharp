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
    /// Interaction logic for Fornecedor.xaml
    /// </summary>
    public partial class Fornecedor : UserControl
    {
        public Fornecedor()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ConciliaFornecedorViewModel)this.DataContext).IsEditar= false;
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
                ((ConciliaFornecedorViewModel)this.DataContext).atualizarListaViewConciliaFornecedor(0);
                ((ConciliaFornecedorViewModel)this.DataContext).atualizarListaContabilLancamentoDetalhe(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void BotaoConciliacao_Click(object sender, RoutedEventArgs e)
        {
            foreach (ViewConciliaFornecedorDTO LancamentoViewConciliaFornecedor in ((ConciliaFornecedorViewModel)this.DataContext).ListaViewConciliaFornecedor)
            {
                foreach (ContabilLancamentoDetalheDTO LancamentoContabil in ((ConciliaFornecedorViewModel)this.DataContext).ListaContabilLancamentoDetalhe)
                {
                    if (LancamentoViewConciliaFornecedor.ValorPago == LancamentoContabil.Valor)
                    {
                        LancamentoConciliadoDTO LancamentoConciliado = new LancamentoConciliadoDTO();
                        LancamentoConciliado.Mes = String.Format("{0:MM}", LancamentoViewConciliaFornecedor.DataPagamento);
                        LancamentoConciliado.Ano = String.Format("{0:YYYY}", LancamentoViewConciliaFornecedor.DataPagamento);
                        LancamentoConciliado.DataMovimento = LancamentoViewConciliaFornecedor.DataPagamento;
                        LancamentoConciliado.DataBalancete = LancamentoViewConciliaFornecedor.DataPagamento;
                        LancamentoConciliado.HistoricoExtrato = LancamentoViewConciliaFornecedor.Historico;
                        LancamentoConciliado.ValorExtrato = LancamentoViewConciliaFornecedor.ValorPago;
                        LancamentoConciliado.Classificacao = LancamentoContabil.ContabilConta.Classificacao;
                        LancamentoConciliado.HistoricoConta = LancamentoContabil.Historico;
                        LancamentoConciliado.Tipo = LancamentoContabil.Tipo;
                        LancamentoConciliado.ValorConta = LancamentoContabil.Valor;

                        ((ConciliaFornecedorViewModel)this.DataContext).ListaLancamentoConciliado.Add(LancamentoConciliado);
                    }
                }
            }
        }

    }
}

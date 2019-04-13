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
    /// Interaction logic for ContaCaixa.xaml
    /// </summary>
    public partial class ContaCaixa : UserControl
    {
        public ContaCaixa()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ConciliaContaCaixaViewModel)this.DataContext).IsEditar= false;
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
                ((ConciliaContaCaixaViewModel)this.DataContext).atualizarListaFinExtratoContaBanco(0);
                ((ConciliaContaCaixaViewModel)this.DataContext).atualizarListaContabilLancamentoDetalhe(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void BotaoConciliacao_Click(object sender, RoutedEventArgs e)
        {
            foreach (FinExtratoContaBancoDTO LancamentoExtrato in ((ConciliaContaCaixaViewModel)this.DataContext).ListaFinExtratoContaBanco)
            {
                foreach (ContabilLancamentoDetalheDTO LancamentoContabil in ((ConciliaContaCaixaViewModel)this.DataContext).ListaContabilLancamentoDetalhe)
                {
                    if (LancamentoExtrato.Valor == LancamentoContabil.Valor)
                    {
                        LancamentoConciliadoDTO LancamentoConciliado = new LancamentoConciliadoDTO();
                        LancamentoConciliado.Mes = LancamentoExtrato.Mes;
                        LancamentoConciliado.Ano = LancamentoExtrato.Ano;
                        LancamentoConciliado.DataMovimento = LancamentoExtrato.DataMovimento;
                        LancamentoConciliado.DataBalancete = LancamentoExtrato.DataBalancete;
                        LancamentoConciliado.HistoricoExtrato = LancamentoExtrato.Historico;
                        LancamentoConciliado.ValorExtrato = LancamentoExtrato.Valor;
                        LancamentoConciliado.Classificacao = LancamentoContabil.ContabilConta.Classificacao;
                        LancamentoConciliado.HistoricoConta = LancamentoContabil.Historico;
                        LancamentoConciliado.Tipo = LancamentoContabil.Tipo;
                        LancamentoConciliado.ValorConta = LancamentoContabil.Valor;

                        ((ConciliaContaCaixaViewModel)this.DataContext).ListaLancamentoConciliado.Add(LancamentoConciliado);
                    }
                }
            }
        }

    }
}

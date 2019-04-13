using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchWindow.Attributes;
using ContasPagarClient.ContasPagarService;


namespace ContasPagarClient.Model
{
    public class ServicoContasPagar : ContasPagarServiceClient
    {
        [SearchWindowDataSource(typeof(ContabilContaDTO))]
        public new List<ContabilContaDTO> selectContabilConta(ContabilContaDTO ContabilConta)
        {
            return base.selectContabilConta(ContabilConta);
        }

        [SearchWindowDataSource(typeof(PlanoNaturezaFinanceiraDTO))]
        public new List<PlanoNaturezaFinanceiraDTO> selectPlanoNaturezaFinanceira(PlanoNaturezaFinanceiraDTO PlanoNaturezaFinanceira)
        {
            return base.selectPlanoNaturezaFinanceira(PlanoNaturezaFinanceira);
        }

        [SearchWindowDataSource(typeof(FinDocumentoOrigemDTO))]
        public new List<FinDocumentoOrigemDTO> selectFinDocumentoOrigem(FinDocumentoOrigemDTO FinDocumentoOrigem)
        {
            return base.selectFinDocumentoOrigem(FinDocumentoOrigem);
        }

        [SearchWindowDataSource(typeof(ViewPessoaFornecedorDTO))]
        public new List<ViewPessoaFornecedorDTO> selectViewPessoaFornecedor(ViewPessoaFornecedorDTO ViewPessoaFornecedor)
        {
            return base.selectViewPessoaFornecedor(ViewPessoaFornecedor);
        }

        [SearchWindowDataSource(typeof(FinStatusParcelaDTO))]
        public new List<FinStatusParcelaDTO> selectFinStatusParcela(FinStatusParcelaDTO FinStatusParcela)
        {
            return base.selectFinStatusParcela(FinStatusParcela);
        }

        [SearchWindowDataSource(typeof(FinTipoPagamentoDTO))]
        public new List<FinTipoPagamentoDTO> selectFinTipoPagamento(FinTipoPagamentoDTO FinTipoPagamento)
        {
            return base.selectFinTipoPagamento(FinTipoPagamento);
        }

    }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchWindow.Attributes;
using ContasReceberClient.ContasReceberService;


namespace ContasReceberClient.Model
{
    public class ServicoContasReceber : ContasReceberServiceClient
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

        [SearchWindowDataSource(typeof(ViewPessoaClienteDTO))]
        public new List<ViewPessoaClienteDTO> selectViewPessoaCliente(ViewPessoaClienteDTO ViewPessoaCliente)
        {
            return base.selectViewPessoaCliente(ViewPessoaCliente);
        }
 
        [SearchWindowDataSource(typeof(FinStatusParcelaDTO))]
        public new List<FinStatusParcelaDTO> selectFinStatusParcela(FinStatusParcelaDTO FinStatusParcela)
        {
            return base.selectFinStatusParcela(FinStatusParcela);
        }

        [SearchWindowDataSource(typeof(ContaCaixaDTO))]
        public new List<ContaCaixaDTO> selectContaCaixa(ContaCaixaDTO ContaCaixa)
        {
            return base.selectContaCaixa(ContaCaixa);
        }

        [SearchWindowDataSource(typeof(FinTipoRecebimentoDTO))]
        public new List<FinTipoRecebimentoDTO> selectFinTipoRecebimento(FinTipoRecebimentoDTO FinTipoRecebimento)
        {
            return base.selectFinTipoRecebimento(FinTipoRecebimento);
        }

    }



}

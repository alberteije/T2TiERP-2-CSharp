using T2TiCte.Servico;
using SearchWindow.Attributes;
using System;
using System.Collections.Generic;

namespace NFe.Model
{
    public class ServicoNFe : ServidorClient
    {

        [SearchWindowDataSource(typeof(ProdutoDTO))]
        public new List<ProdutoDTO> selectProduto(ProdutoDTO produto)
        {
            try
            {
                return base.SelectProduto(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [SearchWindowDataSource(typeof(TributOperacaoFiscalDTO))]
        public new List<TributOperacaoFiscalDTO> selectOperacaoFiscal(TributOperacaoFiscalDTO operacaoFiscal)
        {
            try
            {
                return base.SelectTributOperacaoFiscal(operacaoFiscal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

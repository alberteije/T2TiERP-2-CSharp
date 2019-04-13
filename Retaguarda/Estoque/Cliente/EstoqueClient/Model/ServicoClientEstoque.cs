using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchWindow.Attributes;
using EstoqueClient.EstoqueServiceReference;

namespace EstoqueClient.Model
{
    public class ServicoEstoque : ServicoEstoqueClient
    {
        [SearchWindowDataSource(typeof(ColaboradorDTO))]
        public List<ColaboradorDTO> selectColaborador(ColaboradorDTO colaborador)
        {
            try
            {
                return base.selectColaborador(colaborador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [SearchWindowDataSource(typeof(ProdutoDTO))]
        public List<ProdutoDTO> selectProduto(ProdutoDTO produto) 
        {
            try
            {
                return base.selectProduto(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchWindow.Attributes;
using Inventario.Servico;

namespace EstoqueClient.Model
{
    public class ServicoEstoque : ServidorClient
    {
        [SearchWindowDataSource(typeof(ProdutoDTO), new string[] { "Id", "Nome" }, new string[] { "Id", "Nome" })]
        public new IList<ProdutoDTO> SelectProduto(ProdutoDTO dtoPesquisa)
        {
            return base.SelectProduto(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(ColaboradorDTO), new string[] { "Id", "Pessoa.Nome" }, new string[] { "Id", "Nome" })]
        public IList<ColaboradorDTO> SelectColaborador(ColaboradorDTO colaborador)
        {
            try
            {
                return base.SelectColaborador(colaborador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

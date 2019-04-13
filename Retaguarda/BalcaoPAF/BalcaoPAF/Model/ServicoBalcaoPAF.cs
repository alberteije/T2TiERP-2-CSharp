using BalcaoPAF.ServidorReference;
using SearchWindow.Attributes;
using System.Collections.Generic;

namespace BalcaoPAF.Model
{
    public class ServicoBalcaoPAF : ServiceServidor
    {

        [SearchWindowDataSource(typeof(ProdutoDTO), new string[] { "Id", "Nome" }, new string[] { "Id", "Nome" })]
        public new IList<ProdutoDTO> SelectProduto(ProdutoDTO dtoPesquisa)
        {
            return base.SelectProduto(dtoPesquisa);
        }

        /*
         * Exercício: Implemente a pesquisa por Pessoa
         * 
        [SearchWindowDataSource(typeof(PessoaDTO), new string[] { "Id", "Nome" }, new string[] { "Id", "Nome" })]
        public new IList<ProdutoDTO> SelectPessoa(PessoaDTO dtoPesquisa)
        {
            return base.SelectPessoa(dtoPesquisa);
        }
         */ 
    }
}

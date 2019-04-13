using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchWindow.Attributes;
using OrdemServico.Servico;

namespace OrdemServico.Model
{
    public class ServicoOrdemServico : ServidorClient
    {
        [SearchWindowDataSource(typeof(ProdutoDTO), new string[] { "Id", "Nome" }, new string[] { "Id", "Nome" })]
        public new IList<ProdutoDTO> SelectProduto(ProdutoDTO dtoPesquisa)
        {
            return base.SelectProduto(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(ComissaoPerfilDTO), new string[] { "Id", "Nome" }, new string[] { "Id", "Nome" })]
        public new IList<ComissaoPerfilDTO> SelectProduto(ComissaoPerfilDTO dtoPesquisa)
        {
            return base.SelectComissaoPerfil(dtoPesquisa);
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

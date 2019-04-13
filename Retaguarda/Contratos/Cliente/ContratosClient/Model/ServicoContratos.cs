using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContratosClient.ContratosReference;
using SearchWindow.Attributes;

namespace ContratosClient.Model
{
    public class ServicoContratos : ServicoContratosClient
    {
        [SearchWindowDataSource(typeof(SetorDTO))]
        public new List<SetorDTO> selectSetor(SetorDTO dtoPesquisa)
        {
            return base.selectSetor(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(FornecedorDTO), new string[] { "Pessoa.Nome", "Desde" }, new string[] { "Nome", "Data cad." })]
        public new List<FornecedorDTO> selectFornecedor(FornecedorDTO dtoPesquisa)
        {
            return base.selectFornecedor(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(ClienteDTO), new string[] { "Pessoa.Nome", "Desde" }, new string[] { "Nome", "Data cad." })]
        public new List<ClienteDTO> selectCliente(ClienteDTO dtoPesquisa)
        {
            return base.selectCliente(dtoPesquisa);
        }
        [SearchWindowDataSource(typeof(ColaboradorDTO), new string[] { "Pessoa.Nome", "Matricula" }, new string[] { "Nome", "Matricula" })]
        public new List<ColaboradorDTO> selectColaborador(ColaboradorDTO dtoPesquisa)
        {
            return base.selectColaborador(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(ContratoTipoServicoDTO))]
        public new List<ContratoTipoServicoDTO> selectContratoTipoServico(ContratoTipoServicoDTO dtoPesquisa)
        {
            return base.selectContratoTipoServico(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(TipoContratoDTO))]
        public new List<TipoContratoDTO> selectTipoContrato(TipoContratoDTO dtoPesquisa)
        {
            return base.selectTipoContrato(dtoPesquisa);
        }


        [SearchWindowDataSource(typeof(ContratoSolicitacaoServicoDTO), new string[] { "Id","Colaborador.Pessoa.Nome", "Data", "Descricao" }, new string[] { "Id","Colaborador", "Data", "Descrição" })]
        public new List<ContratoSolicitacaoServicoDTO> selectContratoSolicitacaoServico(ContratoSolicitacaoServicoDTO dtoPesquisa)
        {
            return base.selectContratoSolicitacaoServico(dtoPesquisa);
        }
    }
}

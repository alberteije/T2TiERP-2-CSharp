using Cadastros.ServidorReference;
using SearchWindow.Attributes;
using System.Collections.Generic;

namespace Cadastros.Model
{
    public class ServicoCadastros : ServiceServidor
    {

        [SearchWindowDataSource(typeof(ProdutoDTO), new string[] { "Id", "Nome" }, new string[] { "Id", "Nome" })]
        public new IList<ProdutoDTO> SelectProduto(ProdutoDTO dtoPesquisa)
        {
            return base.SelectProduto(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(CboDTO), new string[] { "Id", "Nome", "Codigo", "Codigo1994" }, new string[] { "Id", "Nome", "Codigo", "Codigo1994" })]
        public new IList<CboDTO> SelectCbo(CboDTO dtoPesquisa)
        {
            return base.SelectCbo(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(AtividadeForCliDTO))]
        public new IList<AtividadeForCliDTO> SelectAtividadeForCli(AtividadeForCliDTO atividadeforcli)
        {
            return base.SelectAtividadeForCli(atividadeforcli);
        }

        /*
        [SearchWindowDataSource(typeof(SituacaoForCliDTO))]
        public new IList<SituacaoForCliDTO> SelectSituacaoForCli(SituacaoForCliDTO situacaoforcli)
        {
            return base.SelectSituacaoForCli(situacaoforcli);
        }
        */

        [SearchWindowDataSource(typeof(EstadoCivilDTO))]
        public new IList<EstadoCivilDTO> SelectEstadoCivil(EstadoCivilDTO estadocivil)
        {
            return base.SelectEstadoCivil(estadocivil);
        }

        /*
        [SearchWindowDataSource(typeof(ContabilContaDTO))]
        public new IList<ContabilContaDTO> SelectContabilConta(ContabilContaDTO ContabilConta)
        {
            return base.SelectContabilConta(ContabilConta);
        }
        */

        /*
        [SearchWindowDataSource(typeof(TributOperacaoFiscalDTO))]
        public new IList<TributOperacaoFiscalDTO> SelectTributOperacaoFiscal(TributOperacaoFiscalDTO TributOperacaoFiscal)
        {
            return base.SelectTributOperacaoFiscal(TributOperacaoFiscal);
        }
        */

        /*
        [SearchWindowDataSource(typeof(SetorDTO))]
        public new IList<SetorDTO> SelectSetor(SetorDTO Setor)
        {
            return base.SelectSetor(Setor);
        }
        */

        [SearchWindowDataSource(typeof(CargoDTO))]
        public new IList<CargoDTO> SelectCargo(CargoDTO Cargo)
        {
            return base.SelectCargo(Cargo);
        }

        /*
        [SearchWindowDataSource(typeof(NivelFormacaoDTO))]
        public new IList<NivelFormacaoDTO> SelectNivelFormacao(NivelFormacaoDTO NivelFormacao)
        {
            return base.SelectNivelFormacao(NivelFormacao);
        }


        [SearchWindowDataSource(typeof(TipoColaboradorDTO))]
        public new IList<TipoColaboradorDTO> SelectTipoColaborador(TipoColaboradorDTO TipoColaborador)
        {
            return base.SelectTipoColaborador(TipoColaborador);
        }

        [SearchWindowDataSource(typeof(SituacaoColaboradorDTO))]
        public new IList<SituacaoColaboradorDTO> SelectSituacaoColaborador(SituacaoColaboradorDTO SituacaoColaborador)
        {
            return base.SelectSituacaoColaborador(SituacaoColaborador);
        }

        [SearchWindowDataSource(typeof(SindicatoDTO))]
        public new IList<SindicatoDTO> SelectSindicato(SindicatoDTO Sindicato)
        {
            return base.SelectSindicato(Sindicato);
        }

        [SearchWindowDataSource(typeof(ProdutoGrupoDTO))]
        public new IList<ProdutoGrupoDTO> SelectProdutoGrupo(ProdutoGrupoDTO ProdutoGrupo)
        {
            return base.SelectProdutoGrupo(ProdutoGrupo);
        }
        */

        [SearchWindowDataSource(typeof(ProdutoSubGrupoDTO))]
        public new IList<ProdutoSubGrupoDTO> SelectProdutoSubGrupo(ProdutoSubGrupoDTO ProdutoSubGrupo)
        {
            return base.SelectProdutoSubGrupo(ProdutoSubGrupo);
        }

        [SearchWindowDataSource(typeof(ProdutoMarcaDTO))]
        public new IList<ProdutoMarcaDTO> SelectProdutoMarca(ProdutoMarcaDTO ProdutoMarca)
        {
            return base.SelectProdutoMarca(ProdutoMarca);
        }

        [SearchWindowDataSource(typeof(TributGrupoTributarioDTO))]
        public new IList<TributGrupoTributarioDTO> SelectTributGrupoTributario(TributGrupoTributarioDTO TributGrupoTributario)
        {
            return base.SelectTributGrupoTributario(TributGrupoTributario);
        }

        [SearchWindowDataSource(typeof(AlmoxarifadoDTO))]
        public new IList<AlmoxarifadoDTO> SelectAlmoxarifado(AlmoxarifadoDTO Almoxarifado)
        {
            return base.SelectAlmoxarifado(Almoxarifado);
        }

        [SearchWindowDataSource(typeof(UnidadeProdutoDTO))]
        public new IList<UnidadeProdutoDTO> SelectUnidadeProduto(UnidadeProdutoDTO UnidadeProduto)
        {
            return base.SelectUnidadeProduto(UnidadeProduto);
        }

        [SearchWindowDataSource(typeof(TributIcmsCustomCabDTO))]
        public new IList<TributIcmsCustomCabDTO> SelectTributIcmsCustomCab(TributIcmsCustomCabDTO TributIcmsCustomCab)
        {
            return base.SelectTributIcmsCustomCab(TributIcmsCustomCab);
        }
    }
}

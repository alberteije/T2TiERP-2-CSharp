using Servidor.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Servidor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServidor
    {

        #region === Comum ===

        #region Usuario
        [OperationContract]
        UsuarioDTO SelectUsuario(String login, String senha);
        #endregion

        #region Empresa
        [OperationContract]
        EmpresaDTO SelectObjetoEmpresa(string pFiltro);
        [OperationContract]
        IList<EmpresaDTO> SelectEmpresa(EmpresaDTO empresa);
        [OperationContract]
        IList<EmpresaDTO> SelectEmpresaPagina(int primeiroResultado, int quantidadeResultados, EmpresaDTO empresa);
        #endregion

        #endregion

        #region === Cadastros ===

        #region EstadoCivil
        [OperationContract]
        void DeleteEstadoCivil(EstadoCivilDTO estadoCivil);
        [OperationContract]
        EstadoCivilDTO SalvarAtualizarEstadoCivil(EstadoCivilDTO estadoCivil);
        [OperationContract]
        IList<EstadoCivilDTO> SelectEstadoCivil(EstadoCivilDTO estadoCivil);
        [OperationContract]
        IList<EstadoCivilDTO> SelectEstadoCivilPagina(int primeiroResultado, int quantidadeResultados, EstadoCivilDTO estadoCivil);
        #endregion 

        #region AtividadeForCli
        [OperationContract]
        void DeleteAtividadeForCli(AtividadeForCliDTO atividadeForCli);
        [OperationContract]
        AtividadeForCliDTO SalvarAtualizarAtividadeForCli(AtividadeForCliDTO atividadeForCli);
        [OperationContract]
        IList<AtividadeForCliDTO> SelectAtividadeForCli(AtividadeForCliDTO atividadeForCli);
        [OperationContract]
        IList<AtividadeForCliDTO> SelectAtividadeForCliPagina(int primeiroResultado, int quantidadeResultados, AtividadeForCliDTO atividadeForCli);
        #endregion 

        #region Cargo
        [OperationContract]
        void DeleteCargo(CargoDTO cargo);
        [OperationContract]
        CargoDTO SalvarAtualizarCargo(CargoDTO cargo);
        [OperationContract]
        IList<CargoDTO> SelectCargo(CargoDTO cargo);
        [OperationContract]
        IList<CargoDTO> SelectCargoPagina(int primeiroResultado, int quantidadeResultados, CargoDTO cargo);
        #endregion 

        #region Cbo
        [OperationContract]
        void DeleteCbo(CboDTO cbo);
        [OperationContract]
        CboDTO SalvarAtualizarCbo(CboDTO cbo);
        [OperationContract]
        IList<CboDTO> SelectCbo(CboDTO cbo);
        [OperationContract]
        IList<CboDTO> SelectCboPagina(int primeiroResultado, int quantidadeResultados, CboDTO cbo);
        #endregion 

        #region OperadoraPlanoSaude
        [OperationContract]
        void DeleteOperadoraPlanoSaude(OperadoraPlanoSaudeDTO operadoraPlanoSaude);
        [OperationContract]
        OperadoraPlanoSaudeDTO SalvarAtualizarOperadoraPlanoSaude(OperadoraPlanoSaudeDTO operadoraPlanoSaude);
        [OperationContract]
        IList<OperadoraPlanoSaudeDTO> SelectOperadoraPlanoSaude(OperadoraPlanoSaudeDTO operadoraPlanoSaude);
        [OperationContract]
        IList<OperadoraPlanoSaudeDTO> SelectOperadoraPlanoSaudePagina(int primeiroResultado, int quantidadeResultados, OperadoraPlanoSaudeDTO operadoraPlanoSaude);
        #endregion 

        #region Pais
        [OperationContract]
        void DeletePais(PaisDTO pais);
        [OperationContract]
        PaisDTO SalvarAtualizarPais(PaisDTO pais);
        [OperationContract]
        IList<PaisDTO> SelectPais(PaisDTO pais);
        [OperationContract]
        IList<PaisDTO> SelectPaisPagina(int primeiroResultado, int quantidadeResultados, PaisDTO pais);
        #endregion 

        #region Produto
        [OperationContract]
        void DeleteProduto(ProdutoDTO produto);
        [OperationContract]
        ProdutoDTO SalvarAtualizarProduto(ProdutoDTO produto);
        [OperationContract]
        IList<ProdutoDTO> SelectProduto(ProdutoDTO produto);
        [OperationContract]
        ProdutoDTO SelectProdutoId(ProdutoDTO produto);
        [OperationContract]
        IList<ProdutoDTO> SelectProdutoPagina(int primeiroResultado, int quantidadeResultados, ProdutoDTO produto);
        #endregion 

        #region ProdutoSubGrupo
        [OperationContract]
        void DeleteProdutoSubGrupo(ProdutoSubGrupoDTO produtoSubGrupo);
        [OperationContract]
        ProdutoSubGrupoDTO SalvarAtualizarProdutoSubGrupo(ProdutoSubGrupoDTO produtoSubGrupo);
        [OperationContract]
        IList<ProdutoSubGrupoDTO> SelectProdutoSubGrupo(ProdutoSubGrupoDTO produtoSubGrupo);
        [OperationContract]
        IList<ProdutoSubGrupoDTO> SelectProdutoSubGrupoPagina(int primeiroResultado, int quantidadeResultados, ProdutoSubGrupoDTO produtoSubGrupo);
        #endregion 

        #region ProdutoMarca
        [OperationContract]
        void DeleteProdutoMarca(ProdutoMarcaDTO produtoMarca);
        [OperationContract]
        ProdutoMarcaDTO SalvarAtualizarProdutoMarca(ProdutoMarcaDTO produtoMarca);
        [OperationContract]
        IList<ProdutoMarcaDTO> SelectProdutoMarca(ProdutoMarcaDTO produtoMarca);
        [OperationContract]
        IList<ProdutoMarcaDTO> SelectProdutoMarcaPagina(int primeiroResultado, int quantidadeResultados, ProdutoMarcaDTO produtoMarca);
        #endregion 

        #region Almoxarifado
        [OperationContract]
        void DeleteAlmoxarifado(AlmoxarifadoDTO almoxarifado);
        [OperationContract]
        AlmoxarifadoDTO SalvarAtualizarAlmoxarifado(AlmoxarifadoDTO almoxarifado);
        [OperationContract]
        IList<AlmoxarifadoDTO> SelectAlmoxarifado(AlmoxarifadoDTO almoxarifado);
        [OperationContract]
        IList<AlmoxarifadoDTO> SelectAlmoxarifadoPagina(int primeiroResultado, int quantidadeResultados, AlmoxarifadoDTO almoxarifado);
        #endregion 

        #region Pessoa
        [OperationContract]
        void DeletePessoa(PessoaDTO pessoa);
        [OperationContract]
        PessoaDTO SalvarAtualizarPessoa(PessoaDTO pessoa);
        [OperationContract]
        IList<PessoaDTO> SelectPessoa(PessoaDTO pessoa);
        [OperationContract]
        IList<PessoaDTO> SelectPessoaPagina(int primeiroResultado, int quantidadeResultados, PessoaDTO pessoa);
        #endregion 

        #region Banco
        [OperationContract]
        void DeleteBanco(BancoDTO banco);
        [OperationContract]
        BancoDTO SalvarAtualizarBanco(BancoDTO banco);
        [OperationContract]
        IList<BancoDTO> SelectBanco(BancoDTO banco);
        [OperationContract]
        IList<BancoDTO> SelectBancoPagina(int primeiroResultado, int quantidadeResultados, BancoDTO banco);
        #endregion 

        #region Contador
        [OperationContract]
        IList<ContadorDTO> SelectContador(ContadorDTO contador);
        [OperationContract]
        IList<ContadorDTO> SelectContadorPagina(int primeiroResultado, int quantidadeResultados, ContadorDTO contador);
        #endregion

        #region UnidadeProduto
        [OperationContract]
        void DeleteUnidadeProduto(UnidadeProdutoDTO unidadeProduto);
        [OperationContract]
        UnidadeProdutoDTO SalvarAtualizarUnidadeProduto(UnidadeProdutoDTO unidadeProduto);
        [OperationContract]
        IList<UnidadeProdutoDTO> SelectUnidadeProduto(UnidadeProdutoDTO unidadeProduto);
        [OperationContract]
        IList<UnidadeProdutoDTO> SelectUnidadeProdutoPagina(int primeiroResultado, int quantidadeResultados, UnidadeProdutoDTO unidadeProduto);
        #endregion 

        #region Colaborador
        [OperationContract]
        int DeleteColaborador(ColaboradorDTO colaborador);
        [OperationContract]
        ColaboradorDTO SalvarAtualizarColaborador(ColaboradorDTO colaborador);
        [OperationContract]
        IList<ColaboradorDTO> SelectColaborador(ColaboradorDTO colaborador);
        [OperationContract]
        IList<ColaboradorDTO> SelectColaboradorPagina(int primeiroResultado, int quantidadeResultados, ColaboradorDTO colaborador);
        #endregion 

        #endregion

        #region === Compras ===

        #region CompraRequisicaoDetalhe
        [OperationContract]
        int DeleteCompraRequisicaoDetalhe(CompraRequisicaoDetalheDTO compraRequisicaoDetalhe);
        [OperationContract]
        CompraRequisicaoDetalheDTO SalvarAtualizarCompraRequisicaoDetalhe(CompraRequisicaoDetalheDTO compraRequisicaoDetalhe);
        [OperationContract]
        IList<CompraRequisicaoDetalheDTO> SelectCompraRequisicaoDetalhe(CompraRequisicaoDetalheDTO compraRequisicaoDetalhe);
        [OperationContract]
        IList<CompraRequisicaoDetalheDTO> SelectCompraRequisicaoDetalhePagina(int primeiroResultado, int quantidadeResultados, CompraRequisicaoDetalheDTO compraRequisicaoDetalhe);
        #endregion 

        #region CompraTipoPedido
        [OperationContract]
        int DeleteCompraTipoPedido(CompraTipoPedidoDTO compraTipoPedido);
        [OperationContract]
        CompraTipoPedidoDTO SalvarAtualizarCompraTipoPedido(CompraTipoPedidoDTO compraTipoPedido);
        [OperationContract]
        IList<CompraTipoPedidoDTO> SelectCompraTipoPedido(CompraTipoPedidoDTO compraTipoPedido);
        [OperationContract]
        IList<CompraTipoPedidoDTO> SelectCompraTipoPedidoPagina(int primeiroResultado, int quantidadeResultados, CompraTipoPedidoDTO compraTipoPedido);
        #endregion 

        #region CompraCotacaoDetalhe
        [OperationContract]
        int DeleteCompraCotacaoDetalhe(CompraCotacaoDetalheDTO compraCotacaoDetalhe);
        [OperationContract]
        CompraCotacaoDetalheDTO SalvarAtualizarCompraCotacaoDetalhe(CompraCotacaoDetalheDTO compraCotacaoDetalhe);
        [OperationContract]
        IList<CompraCotacaoDetalheDTO> SelectCompraCotacaoDetalhe(CompraCotacaoDetalheDTO compraCotacaoDetalhe);
        [OperationContract]
        IList<CompraCotacaoDetalheDTO> SelectCompraCotacaoDetalhePagina(int primeiroResultado, int quantidadeResultados, CompraCotacaoDetalheDTO compraCotacaoDetalhe);
        #endregion 

        #region CompraTipoRequisicao
        [OperationContract]
        int DeleteCompraTipoRequisicao(CompraTipoRequisicaoDTO compraTipoRequisicao);
        [OperationContract]
        CompraTipoRequisicaoDTO SalvarAtualizarCompraTipoRequisicao(CompraTipoRequisicaoDTO compraTipoRequisicao);
        [OperationContract]
        IList<CompraTipoRequisicaoDTO> SelectCompraTipoRequisicao(CompraTipoRequisicaoDTO compraTipoRequisicao);
        [OperationContract]
        IList<CompraTipoRequisicaoDTO> SelectCompraTipoRequisicaoPagina(int primeiroResultado, int quantidadeResultados, CompraTipoRequisicaoDTO compraTipoRequisicao);
        #endregion 

        #region CompraCotacao
        [OperationContract]
        int DeleteCompraCotacao(CompraCotacaoDTO compraCotacao);
        [OperationContract]
        CompraCotacaoDTO SalvarAtualizarCompraCotacao(CompraCotacaoDTO compraCotacao);
        [OperationContract]
        IList<CompraCotacaoDTO> SelectCompraCotacao(CompraCotacaoDTO compraCotacao);
        [OperationContract]
        IList<CompraCotacaoDTO> SelectCompraCotacaoPagina(int primeiroResultado, int quantidadeResultados, CompraCotacaoDTO compraCotacao);
        #endregion 

        #region CompraFornecedorCotacao
        [OperationContract]
        int DeleteCompraFornecedorCotacao(CompraFornecedorCotacaoDTO compraFornecedorCotacao);
        [OperationContract]
        CompraFornecedorCotacaoDTO SalvarAtualizarCompraFornecedorCotacao(CompraFornecedorCotacaoDTO compraFornecedorCotacao);
        [OperationContract]
        IList<CompraFornecedorCotacaoDTO> SelectCompraFornecedorCotacao(CompraFornecedorCotacaoDTO compraFornecedorCotacao);
        [OperationContract]
        IList<CompraFornecedorCotacaoDTO> SelectCompraFornecedorCotacaoPagina(int primeiroResultado, int quantidadeResultados, CompraFornecedorCotacaoDTO compraFornecedorCotacao);
        #endregion 

        #region CompraReqCotacaoDetalhe
        [OperationContract]
        int DeleteCompraReqCotacaoDetalhe(CompraReqCotacaoDetalheDTO compraReqCotacaoDetalhe);
        [OperationContract]
        CompraReqCotacaoDetalheDTO SalvarAtualizarCompraReqCotacaoDetalhe(CompraReqCotacaoDetalheDTO compraReqCotacaoDetalhe);
        [OperationContract]
        IList<CompraReqCotacaoDetalheDTO> SelectCompraReqCotacaoDetalhe(CompraReqCotacaoDetalheDTO compraReqCotacaoDetalhe);
        [OperationContract]
        IList<CompraReqCotacaoDetalheDTO> SelectCompraReqCotacaoDetalhePagina(int primeiroResultado, int quantidadeResultados, CompraReqCotacaoDetalheDTO compraReqCotacaoDetalhe);
        #endregion 

        #region CompraRequisicao
        [OperationContract]
        int DeleteCompraRequisicao(CompraRequisicaoDTO compraRequisicao);
        [OperationContract]
        CompraRequisicaoDTO SalvarAtualizarCompraRequisicao(CompraRequisicaoDTO compraRequisicao);
        [OperationContract]
        IList<CompraRequisicaoDTO> SelectCompraRequisicao(CompraRequisicaoDTO compraRequisicao);
        [OperationContract]
        IList<CompraRequisicaoDTO> SelectCompraRequisicaoPagina(int primeiroResultado, int quantidadeResultados, CompraRequisicaoDTO compraRequisicao);
        #endregion 

        #region CompraPedido
        [OperationContract]
        int DeleteCompraPedido(CompraPedidoDTO compraPedido);
        [OperationContract]
        CompraPedidoDTO SalvarAtualizarCompraPedido(CompraPedidoDTO compraPedido);
        [OperationContract]
        IList<CompraPedidoDTO> SelectCompraPedido(CompraPedidoDTO compraPedido);
        [OperationContract]
        IList<CompraPedidoDTO> SelectCompraPedidoPagina(int primeiroResultado, int quantidadeResultados, CompraPedidoDTO compraPedido);
        #endregion 

        #region CompraPedidoDetalhe
        [OperationContract]
        int DeleteCompraPedidoDetalhe(CompraPedidoDetalheDTO compraPedidoDetalhe);
        [OperationContract]
        CompraPedidoDetalheDTO SalvarAtualizarCompraPedidoDetalhe(CompraPedidoDetalheDTO compraPedidoDetalhe);
        [OperationContract]
        IList<CompraPedidoDetalheDTO> SelectCompraPedidoDetalhe(CompraPedidoDetalheDTO compraPedidoDetalhe);
        [OperationContract]
        IList<CompraPedidoDetalheDTO> SelectCompraPedidoDetalhePagina(int primeiroResultado, int quantidadeResultados, CompraPedidoDetalheDTO compraPedidoDetalhe);
        #endregion 

        #region CompraCotacaoPedidoDetalhe
        [OperationContract]
        int DeleteCompraCotacaoPedidoDetalhe(CompraCotacaoPedidoDetalheDTO compraCotacaoPedidoDetalhe);
        [OperationContract]
        CompraCotacaoPedidoDetalheDTO SalvarAtualizarCompraCotacaoPedidoDetalhe(CompraCotacaoPedidoDetalheDTO compraCotacaoPedidoDetalhe);
        [OperationContract]
        IList<CompraCotacaoPedidoDetalheDTO> SelectCompraCotacaoPedidoDetalhe(CompraCotacaoPedidoDetalheDTO compraCotacaoPedidoDetalhe);
        [OperationContract]
        IList<CompraCotacaoPedidoDetalheDTO> SelectCompraCotacaoPedidoDetalhePagina(int primeiroResultado, int quantidadeResultados, CompraCotacaoPedidoDetalheDTO compraCotacaoPedidoDetalhe);
        #endregion 

        #endregion

        #region === Escrita Fiscal ===

        #region FiscalTermo
        [OperationContract]
        int DeleteFiscalTermo(FiscalTermoDTO fiscalTermo);
        [OperationContract]
        FiscalTermoDTO SalvarAtualizarFiscalTermo(FiscalTermoDTO fiscalTermo);
        [OperationContract]
        IList<FiscalTermoDTO> SelectFiscalTermo(FiscalTermoDTO fiscalTermo);
        [OperationContract]
        IList<FiscalTermoDTO> SelectFiscalTermoPagina(int primeiroResultado, int quantidadeResultados, FiscalTermoDTO fiscalTermo);
        #endregion 

        #region NotaFiscalTipo
        [OperationContract]
        int DeleteNotaFiscalTipo(NotaFiscalTipoDTO notaFiscalTipo);
        [OperationContract]
        NotaFiscalTipoDTO SalvarAtualizarNotaFiscalTipo(NotaFiscalTipoDTO notaFiscalTipo);
        [OperationContract]
        IList<NotaFiscalTipoDTO> SelectNotaFiscalTipo(NotaFiscalTipoDTO notaFiscalTipo);
        [OperationContract]
        IList<NotaFiscalTipoDTO> SelectNotaFiscalTipoPagina(int primeiroResultado, int quantidadeResultados, NotaFiscalTipoDTO notaFiscalTipo);
        #endregion 

        #region SimplesNacionalCabecalho
        [OperationContract]
        int DeleteSimplesNacionalCabecalho(SimplesNacionalCabecalhoDTO simplesNacionalCabecalho);
        [OperationContract]
        SimplesNacionalCabecalhoDTO SalvarAtualizarSimplesNacionalCabecalho(SimplesNacionalCabecalhoDTO simplesNacionalCabecalho);
        [OperationContract]
        IList<SimplesNacionalCabecalhoDTO> SelectSimplesNacionalCabecalho(SimplesNacionalCabecalhoDTO simplesNacionalCabecalho);
        [OperationContract]
        IList<SimplesNacionalCabecalhoDTO> SelectSimplesNacionalCabecalhoPagina(int primeiroResultado, int quantidadeResultados, SimplesNacionalCabecalhoDTO simplesNacionalCabecalho);
        #endregion 

        #region RegistroCartorio
        [OperationContract]
        int DeleteRegistroCartorio(RegistroCartorioDTO registroCartorio);
        [OperationContract]
        RegistroCartorioDTO SalvarAtualizarRegistroCartorio(RegistroCartorioDTO registroCartorio);
        [OperationContract]
        IList<RegistroCartorioDTO> SelectRegistroCartorio(RegistroCartorioDTO registroCartorio);
        [OperationContract]
        IList<RegistroCartorioDTO> SelectRegistroCartorioPagina(int primeiroResultado, int quantidadeResultados, RegistroCartorioDTO registroCartorio);
        #endregion 

        #region FiscalParametro
        [OperationContract]
        int DeleteFiscalParametro(FiscalParametroDTO fiscalParametro);
        [OperationContract]
        FiscalParametroDTO SalvarAtualizarFiscalParametro(FiscalParametroDTO fiscalParametro);
        [OperationContract]
        IList<FiscalParametroDTO> SelectFiscalParametro(FiscalParametroDTO fiscalParametro);
        [OperationContract]
        IList<FiscalParametroDTO> SelectFiscalParametroPagina(int primeiroResultado, int quantidadeResultados, FiscalParametroDTO fiscalParametro);
        #endregion 

        #region FiscalApuracaoIcms
        [OperationContract]
        int DeleteFiscalApuracaoIcms(FiscalApuracaoIcmsDTO fiscalApuracaoIcms);
        [OperationContract]
        FiscalApuracaoIcmsDTO SalvarAtualizarFiscalApuracaoIcms(FiscalApuracaoIcmsDTO fiscalApuracaoIcms);
        [OperationContract]
        IList<FiscalApuracaoIcmsDTO> SelectFiscalApuracaoIcms(FiscalApuracaoIcmsDTO fiscalApuracaoIcms);
        [OperationContract]
        IList<FiscalApuracaoIcmsDTO> SelectFiscalApuracaoIcmsPagina(int primeiroResultado, int quantidadeResultados, FiscalApuracaoIcmsDTO fiscalApuracaoIcms);
        #endregion 

        #region FiscalLivro
        [OperationContract]
        int DeleteFiscalLivro(FiscalLivroDTO fiscalLivro);
        [OperationContract]
        FiscalLivroDTO SalvarAtualizarFiscalLivro(FiscalLivroDTO fiscalLivro);
        [OperationContract]
        IList<FiscalLivroDTO> SelectFiscalLivro(FiscalLivroDTO fiscalLivro);
        [OperationContract]
        IList<FiscalLivroDTO> SelectFiscalLivroPagina(int primeiroResultado, int quantidadeResultados, FiscalLivroDTO fiscalLivro);
        #endregion 


        #endregion

        #region === NFe ===

        #region NfeCabecalho
        [OperationContract]
        void DeleteNfeCabecalho(NfeCabecalhoDTO nfeCabecalho);
        [OperationContract]
        NfeCabecalhoDTO SalvarAtualizarNfeCabecalho(NfeCabecalhoDTO nfeCabecalho);
        [OperationContract]
        IList<NfeCabecalhoDTO> SelectNfeCabecalho(NfeCabecalhoDTO nfeCabecalho);
        [OperationContract]
        IList<NfeCabecalhoDTO> SelectNfeCabecalhoPagina(int primeiroResultado, int quantidadeResultados, NfeCabecalhoDTO nfeCabecalho);
        [OperationContract]
        NfeCabecalhoDTO SelectNfeCabecalhoId(int id);
        #endregion

        #endregion

        #region === Tributação ===

        #region TributOperacaoFiscal
        [OperationContract]
        int DeleteTributOperacaoFiscal(TributOperacaoFiscalDTO tributOperacaoFiscal);
        [OperationContract]
        TributOperacaoFiscalDTO SalvarAtualizarTributOperacaoFiscal(TributOperacaoFiscalDTO tributOperacaoFiscal);
        [OperationContract]
        IList<TributOperacaoFiscalDTO> SelectTributOperacaoFiscal(TributOperacaoFiscalDTO tributOperacaoFiscal);
        [OperationContract]
        IList<TributOperacaoFiscalDTO> SelectTributOperacaoFiscalPagina(int primeiroResultado, int quantidadeResultados, TributOperacaoFiscalDTO tributOperacaoFiscal);
        #endregion 

        #region TributGrupoTributario
        [OperationContract]
        void DeleteTributGrupoTributario(TributGrupoTributarioDTO tributGrupoTributario);
        [OperationContract]
        TributGrupoTributarioDTO SalvarAtualizarTributGrupoTributario(TributGrupoTributarioDTO tributGrupoTributario);
        [OperationContract]
        IList<TributGrupoTributarioDTO> SelectTributGrupoTributario(TributGrupoTributarioDTO tributGrupoTributario);
        [OperationContract]
        IList<TributGrupoTributarioDTO> SelectTributGrupoTributarioPagina(int primeiroResultado, int quantidadeResultados, TributGrupoTributarioDTO tributGrupoTributario);
        #endregion 

        #region TributIcmsCustomCab
        [OperationContract]
        void DeleteTributIcmsCustomCab(TributIcmsCustomCabDTO tributIcmsCustomCab);
        [OperationContract]
        TributIcmsCustomCabDTO SalvarAtualizarTributIcmsCustomCab(TributIcmsCustomCabDTO tributIcmsCustomCab);
        [OperationContract]
        IList<TributIcmsCustomCabDTO> SelectTributIcmsCustomCab(TributIcmsCustomCabDTO tributIcmsCustomCab);
        [OperationContract]
        IList<TributIcmsCustomCabDTO> SelectTributIcmsCustomCabPagina(int primeiroResultado, int quantidadeResultados, TributIcmsCustomCabDTO tributIcmsCustomCab);
        #endregion 

        #region ViewTributacaoCofins
        [OperationContract]
        ViewTributacaoCofinsDTO SelectViewTributacaoCofins(ViewTributacaoCofinsDTO viewTributacaoCofins);
        #endregion 

        #region ViewTributacaoPis
        [OperationContract]
        ViewTributacaoPisDTO SelectViewTributacaoPis(ViewTributacaoPisDTO viewTributacaoPis);
        #endregion 

        #region ViewTributacaoIcms
        [OperationContract]
        ViewTributacaoIcmsDTO SelectViewTributacaoIcms(ViewTributacaoIcmsDTO viewTributacaoIcms);
        #endregion

        #endregion

        #region === Sintegra ===

        [OperationContract]
        byte[] GerarSintegra(string pDataIni, string pDataFim, string pCodigoConvenio, string pFinalidade, string pNaturezaInformacao, string pIdEmpresa, string pInventario, string pIdContador);

        #endregion

        #region === Sped ===

        [OperationContract]
        byte[] GerarSped(string pDataIni, string pDataFim, string pVersao, string pFinalidade, string pPerfil, string pIdEmpresa, string pInventario, string pIdContador);
        [OperationContract]
        byte[] GerarSpedContribuicoes(string pDataIni, string pDataFim, string pVersao, string pTipoEscrituracao, string pIdEmpresa, string pIdContador);
        [OperationContract]
        byte[] GerarSpedContabil(string pDataIni, string pDataFim, string pFormaEscrituracao, string pLayoutVersao, string pIdEmpresa);
        
        #endregion

        #region === BalcaoPAF ===

        #region DavCabecalho
        [OperationContract]
        void DeleteDavCabecalho(DavCabecalhoDTO davCabecalho);
        [OperationContract]
        DavCabecalhoDTO SalvarAtualizarDavCabecalho(DavCabecalhoDTO davCabecalho);
        [OperationContract]
        IList<DavCabecalhoDTO> SelectDavCabecalho(DavCabecalhoDTO davCabecalho);
        [OperationContract]
        IList<DavCabecalhoDTO> SelectDavCabecalhoPagina(int primeiroResultado, int quantidadeResultados, DavCabecalhoDTO davCabecalho);
        [OperationContract]
        DavCabecalhoDTO SelectObjetoDavCabecalho(string pFiltro);
        #endregion

        #region PreVendaCabecalho
        [OperationContract]
        void DeletePreVendaCabecalho(PreVendaCabecalhoDTO preVendaCabecalho);
        [OperationContract]
        PreVendaCabecalhoDTO SalvarAtualizarPreVendaCabecalho(PreVendaCabecalhoDTO preVendaCabecalho);
        [OperationContract]
        IList<PreVendaCabecalhoDTO> SelectPreVendaCabecalho(PreVendaCabecalhoDTO preVendaCabecalho);
        [OperationContract]
        IList<PreVendaCabecalhoDTO> SelectPreVendaCabecalhoPagina(int primeiroResultado, int quantidadeResultados, PreVendaCabecalhoDTO preVendaCabecalho);
        [OperationContract]
        PreVendaCabecalhoDTO SelectObjetoPreVendaCabecalho(string pFiltro);
        #endregion

        #endregion

        #region === PCP ===
        
        #region PcpServicoEquipamento
        [OperationContract]
        int DeletePcpServicoEquipamento(PcpServicoEquipamentoDTO pcpServicoEquipamento);
        [OperationContract]
        PcpServicoEquipamentoDTO SalvarAtualizarPcpServicoEquipamento(PcpServicoEquipamentoDTO pcpServicoEquipamento);
        [OperationContract]
        IList<PcpServicoEquipamentoDTO> SelectPcpServicoEquipamento(PcpServicoEquipamentoDTO pcpServicoEquipamento);
        [OperationContract]
        IList<PcpServicoEquipamentoDTO> SelectPcpServicoEquipamentoPagina(int primeiroResultado, int quantidadeResultados, PcpServicoEquipamentoDTO pcpServicoEquipamento);
        #endregion

        #region PcpOpDetalhe
        [OperationContract]
        int DeletePcpOpDetalhe(PcpOpDetalheDTO pcpOpDetalhe);
        [OperationContract]
        PcpOpDetalheDTO SalvarAtualizarPcpOpDetalhe(PcpOpDetalheDTO pcpOpDetalhe);
        [OperationContract]
        IList<PcpOpDetalheDTO> SelectPcpOpDetalhe(PcpOpDetalheDTO pcpOpDetalhe);
        [OperationContract]
        IList<PcpOpDetalheDTO> SelectPcpOpDetalhePagina(int primeiroResultado, int quantidadeResultados, PcpOpDetalheDTO pcpOpDetalhe);
        #endregion 

        #region PcpOpCabecalho
        [OperationContract]
        int DeletePcpOpCabecalho(PcpOpCabecalhoDTO pcpOpCabecalho);
        [OperationContract]
        PcpOpCabecalhoDTO SalvarAtualizarPcpOpCabecalho(PcpOpCabecalhoDTO pcpOpCabecalho);
        [OperationContract]
        IList<PcpOpCabecalhoDTO> SelectPcpOpCabecalho(PcpOpCabecalhoDTO pcpOpCabecalho);
        [OperationContract]
        IList<PcpOpCabecalhoDTO> SelectPcpOpCabecalhoPagina(int primeiroResultado, int quantidadeResultados, PcpOpCabecalhoDTO pcpOpCabecalho);
        #endregion 

        #region PcpServicoColaborador
        [OperationContract]
        int DeletePcpServicoColaborador(PcpServicoColaboradorDTO pcpServicoColaborador);
        [OperationContract]
        PcpServicoColaboradorDTO SalvarAtualizarPcpServicoColaborador(PcpServicoColaboradorDTO pcpServicoColaborador);
        [OperationContract]
        IList<PcpServicoColaboradorDTO> SelectPcpServicoColaborador(PcpServicoColaboradorDTO pcpServicoColaborador);
        [OperationContract]
        IList<PcpServicoColaboradorDTO> SelectPcpServicoColaboradorPagina(int primeiroResultado, int quantidadeResultados, PcpServicoColaboradorDTO pcpServicoColaborador);
        #endregion 

        #region PcpInstrucao
        [OperationContract]
        int DeletePcpInstrucao(PcpInstrucaoDTO pcpInstrucao);
        [OperationContract]
        PcpInstrucaoDTO SalvarAtualizarPcpInstrucao(PcpInstrucaoDTO pcpInstrucao);
        [OperationContract]
        IList<PcpInstrucaoDTO> SelectPcpInstrucao(PcpInstrucaoDTO pcpInstrucao);
        [OperationContract]
        IList<PcpInstrucaoDTO> SelectPcpInstrucaoPagina(int primeiroResultado, int quantidadeResultados, PcpInstrucaoDTO pcpInstrucao);
        #endregion 

        #region PcpInstrucaoOp
        [OperationContract]
        int DeletePcpInstrucaoOp(PcpInstrucaoOpDTO pcpInstrucaoOp);
        [OperationContract]
        PcpInstrucaoOpDTO SalvarAtualizarPcpInstrucaoOp(PcpInstrucaoOpDTO pcpInstrucaoOp);
        [OperationContract]
        IList<PcpInstrucaoOpDTO> SelectPcpInstrucaoOp(PcpInstrucaoOpDTO pcpInstrucaoOp);
        [OperationContract]
        IList<PcpInstrucaoOpDTO> SelectPcpInstrucaoOpPagina(int primeiroResultado, int quantidadeResultados, PcpInstrucaoOpDTO pcpInstrucaoOp);
        #endregion 

        #region PcpServico
        [OperationContract]
        int DeletePcpServico(PcpServicoDTO pcpServico);
        [OperationContract]
        PcpServicoDTO SalvarAtualizarPcpServico(PcpServicoDTO pcpServico);
        [OperationContract]
        IList<PcpServicoDTO> SelectPcpServico(PcpServicoDTO pcpServico);
        [OperationContract]
        IList<PcpServicoDTO> SelectPcpServicoPagina(int primeiroResultado, int quantidadeResultados, PcpServicoDTO pcpServico);
        #endregion 

        
        #endregion

        #region === Inventário ===
        
        #region InventarioContagemCab
        [OperationContract]
        int DeleteInventarioContagemCab(InventarioContagemCabDTO inventarioContagemCab);
        [OperationContract]
        InventarioContagemCabDTO SalvarAtualizarInventarioContagemCab(InventarioContagemCabDTO inventarioContagemCab);
        [OperationContract]
        IList<InventarioContagemCabDTO> SelectInventarioContagemCab(InventarioContagemCabDTO inventarioContagemCab);
        [OperationContract]
        IList<InventarioContagemCabDTO> SelectInventarioContagemCabPagina(int primeiroResultado, int quantidadeResultados, InventarioContagemCabDTO inventarioContagemCab);
        #endregion 
        
        #region EstoqueReajusteCabecalho
        [OperationContract]
        int DeleteEstoqueReajusteCabecalho(EstoqueReajusteCabecalhoDTO estoqueReajusteCabecalho);
        [OperationContract]
        EstoqueReajusteCabecalhoDTO SalvarAtualizarEstoqueReajusteCabecalho(EstoqueReajusteCabecalhoDTO estoqueReajusteCabecalho);
        [OperationContract]
        IList<EstoqueReajusteCabecalhoDTO> SelectEstoqueReajusteCabecalho(EstoqueReajusteCabecalhoDTO estoqueReajusteCabecalho);
        [OperationContract]
        IList<EstoqueReajusteCabecalhoDTO> SelectEstoqueReajusteCabecalhoPagina(int primeiroResultado, int quantidadeResultados, EstoqueReajusteCabecalhoDTO estoqueReajusteCabecalho);
        #endregion 

        #endregion

        #region === Comissões ===

        #region ComissaoPerfil
        [OperationContract]
        int DeleteComissaoPerfil(ComissaoPerfilDTO comissaoPerfil);
        [OperationContract]
        ComissaoPerfilDTO SalvarAtualizarComissaoPerfil(ComissaoPerfilDTO comissaoPerfil);
        [OperationContract]
        IList<ComissaoPerfilDTO> SelectComissaoPerfil(ComissaoPerfilDTO comissaoPerfil);
        [OperationContract]
        IList<ComissaoPerfilDTO> SelectComissaoPerfilPagina(int primeiroResultado, int quantidadeResultados, ComissaoPerfilDTO comissaoPerfil);
        #endregion 

        #region ComissaoObjetivo
        [OperationContract]
        int DeleteComissaoObjetivo(ComissaoObjetivoDTO comissaoObjetivo);
        [OperationContract]
        ComissaoObjetivoDTO SalvarAtualizarComissaoObjetivo(ComissaoObjetivoDTO comissaoObjetivo);
        [OperationContract]
        IList<ComissaoObjetivoDTO> SelectComissaoObjetivo(ComissaoObjetivoDTO comissaoObjetivo);
        [OperationContract]
        IList<ComissaoObjetivoDTO> SelectComissaoObjetivoPagina(int primeiroResultado, int quantidadeResultados, ComissaoObjetivoDTO comissaoObjetivo);
        #endregion 

        #endregion


        #region === Ordem de Serviço ===

        #region OsProdutoServico
        [OperationContract]
        int DeleteOsProdutoServico(OsProdutoServicoDTO osProdutoServico);
        [OperationContract]
        OsProdutoServicoDTO SalvarAtualizarOsProdutoServico(OsProdutoServicoDTO osProdutoServico);
        [OperationContract]
        IList<OsProdutoServicoDTO> SelectOsProdutoServico(OsProdutoServicoDTO osProdutoServico);
        [OperationContract]
        IList<OsProdutoServicoDTO> SelectOsProdutoServicoPagina(int primeiroResultado, int quantidadeResultados, OsProdutoServicoDTO osProdutoServico);
        #endregion 

        #region OsEvolucao
        [OperationContract]
        int DeleteOsEvolucao(OsEvolucaoDTO osEvolucao);
        [OperationContract]
        OsEvolucaoDTO SalvarAtualizarOsEvolucao(OsEvolucaoDTO osEvolucao);
        [OperationContract]
        IList<OsEvolucaoDTO> SelectOsEvolucao(OsEvolucaoDTO osEvolucao);
        [OperationContract]
        IList<OsEvolucaoDTO> SelectOsEvolucaoPagina(int primeiroResultado, int quantidadeResultados, OsEvolucaoDTO osEvolucao);
        #endregion 

        #region OsEquipamento
        [OperationContract]
        int DeleteOsEquipamento(OsEquipamentoDTO osEquipamento);
        [OperationContract]
        OsEquipamentoDTO SalvarAtualizarOsEquipamento(OsEquipamentoDTO osEquipamento);
        [OperationContract]
        IList<OsEquipamentoDTO> SelectOsEquipamento(OsEquipamentoDTO osEquipamento);
        [OperationContract]
        IList<OsEquipamentoDTO> SelectOsEquipamentoPagina(int primeiroResultado, int quantidadeResultados, OsEquipamentoDTO osEquipamento);
        #endregion 

        #region OsAberturaEquipamento
        [OperationContract]
        int DeleteOsAberturaEquipamento(OsAberturaEquipamentoDTO osAberturaEquipamento);
        [OperationContract]
        OsAberturaEquipamentoDTO SalvarAtualizarOsAberturaEquipamento(OsAberturaEquipamentoDTO osAberturaEquipamento);
        [OperationContract]
        IList<OsAberturaEquipamentoDTO> SelectOsAberturaEquipamento(OsAberturaEquipamentoDTO osAberturaEquipamento);
        [OperationContract]
        IList<OsAberturaEquipamentoDTO> SelectOsAberturaEquipamentoPagina(int primeiroResultado, int quantidadeResultados, OsAberturaEquipamentoDTO osAberturaEquipamento);
        #endregion 

        #region OsAbertura
        [OperationContract]
        int DeleteOsAbertura(OsAberturaDTO osAbertura);
        [OperationContract]
        OsAberturaDTO SalvarAtualizarOsAbertura(OsAberturaDTO osAbertura);
        [OperationContract]
        IList<OsAberturaDTO> SelectOsAbertura(OsAberturaDTO osAbertura);
        [OperationContract]
        IList<OsAberturaDTO> SelectOsAberturaPagina(int primeiroResultado, int quantidadeResultados, OsAberturaDTO osAbertura);
        #endregion 

        #region OsStatus
        [OperationContract]
        int DeleteOsStatus(OsStatusDTO osStatus);
        [OperationContract]
        OsStatusDTO SalvarAtualizarOsStatus(OsStatusDTO osStatus);
        [OperationContract]
        IList<OsStatusDTO> SelectOsStatus(OsStatusDTO osStatus);
        [OperationContract]
        IList<OsStatusDTO> SelectOsStatusPagina(int primeiroResultado, int quantidadeResultados, OsStatusDTO osStatus);
        #endregion 

        #endregion



        #region === Etiquetas ===

        #region EtiquetaTemplate
        [OperationContract]
        int DeleteEtiquetaTemplate(EtiquetaTemplateDTO etiquetaTemplate);
        [OperationContract]
        EtiquetaTemplateDTO SalvarAtualizarEtiquetaTemplate(EtiquetaTemplateDTO etiquetaTemplate);
        [OperationContract]
        IList<EtiquetaTemplateDTO> SelectEtiquetaTemplate(EtiquetaTemplateDTO etiquetaTemplate);
        [OperationContract]
        IList<EtiquetaTemplateDTO> SelectEtiquetaTemplatePagina(int primeiroResultado, int quantidadeResultados, EtiquetaTemplateDTO etiquetaTemplate);
        #endregion 


        #endregion


        #region === WMS ===
        
        #region WmsRua
        [OperationContract]
        int DeleteWmsRua(WmsRuaDTO wmsRua);
        [OperationContract]
        WmsRuaDTO SalvarAtualizarWmsRua(WmsRuaDTO wmsRua);
        [OperationContract]
        IList<WmsRuaDTO> SelectWmsRua(WmsRuaDTO wmsRua);
        [OperationContract]
        IList<WmsRuaDTO> SelectWmsRuaPagina(int primeiroResultado, int quantidadeResultados, WmsRuaDTO wmsRua);
        #endregion 

        #endregion


        #region VendaCabecalho
        [OperationContract]
        int DeleteVendaCabecalho(VendaCabecalhoDTO vendaCabecalho);
        [OperationContract]
        VendaCabecalhoDTO SalvarAtualizarVendaCabecalho(VendaCabecalhoDTO vendaCabecalho);
        [OperationContract]
        IList<VendaCabecalhoDTO> SelectVendaCabecalho(VendaCabecalhoDTO vendaCabecalho);
        [OperationContract]
        IList<VendaCabecalhoDTO> SelectVendaCabecalhoPagina(int primeiroResultado, int quantidadeResultados, VendaCabecalhoDTO vendaCabecalho);
        #endregion 


    }


    
}

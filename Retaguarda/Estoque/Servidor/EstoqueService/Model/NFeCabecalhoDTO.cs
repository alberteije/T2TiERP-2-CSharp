using System;
using System.Text;
using System.Collections.Generic;


namespace EstoqueService.Model
{

    public class NFeCabecalhoDTO
    {
        public NFeCabecalhoDTO() { }
        public int id { get; set; }
        public TributOperacaoFiscalDTO TributOperacaoFiscal { get; set; }
        public FornecedorDTO Fornecedor { get; set; }
        public ClienteDTO Cliente { get; set; }
        public int idEmpresa { get; set; }
        public System.Nullable<int> ufEmitente { get; set; }
        public string codigoNumerico { get; set; }
        public string naturezaOperacao { get; set; }
        public int indicadorFormaPagamento { get; set; }
        public string codigoModelo { get; set; }
        public string serie { get; set; }
        public string numero { get; set; }
        public System.Nullable<System.DateTime> dataEmissao { get; set; }
        public System.Nullable<System.DateTime> dataEntradaSaida { get; set; }
        public string horaEntradaSaida { get; set; }
        public string tipoOperacao { get; set; }
        public System.Nullable<int> codigoMunicipio { get; set; }
        public string formatoImpressaoDanfe { get; set; }
        public string tipoEmissao { get; set; }
        public string chaveAcesso { get; set; }
        public string digitoChaveAcesso { get; set; }
        public string ambiente { get; set; }
        public string finalidadeEmissao { get; set; }
        public string processoEmissao { get; set; }
        public string versaoProcessoEmissao { get; set; }
        public System.Nullable<System.DateTime> dataEntradaContingencia { get; set; }
        public string justificativaContingencia { get; set; }
        public System.Nullable<decimal> baseCalculoIcms { get; set; }
        public System.Nullable<decimal> valorIcms { get; set; }
        public System.Nullable<decimal> baseCalculoIcmsSt { get; set; }
        public System.Nullable<decimal> valorIcmsSt { get; set; }
        public System.Nullable<decimal> valorTotalProdutos { get; set; }
        public System.Nullable<decimal> valorFrete { get; set; }
        public System.Nullable<decimal> valorSeguro { get; set; }
        public System.Nullable<decimal> valorDesconto { get; set; }
        public System.Nullable<decimal> valorImpostoImportacao { get; set; }
        public System.Nullable<decimal> valorIpi { get; set; }
        public System.Nullable<decimal> valorPis { get; set; }
        public System.Nullable<decimal> valorCofins { get; set; }
        public System.Nullable<decimal> valorDespesasAcessorias { get; set; }
        public System.Nullable<decimal> valorTotal { get; set; }
        public System.Nullable<decimal> valorServicos { get; set; }
        public System.Nullable<decimal> baseCalculoIssqn { get; set; }
        public System.Nullable<decimal> valorIssqn { get; set; }
        public System.Nullable<decimal> valorPisIssqn { get; set; }
        public System.Nullable<decimal> valorCofinsIssqn { get; set; }
        public System.Nullable<decimal> valorRetidoPis { get; set; }
        public System.Nullable<decimal> valorRetidoCofins { get; set; }
        public System.Nullable<decimal> valorRetidoCsll { get; set; }
        public System.Nullable<decimal> baseCalculoIrrf { get; set; }
        public System.Nullable<decimal> valorRetidoIrrf { get; set; }
        public System.Nullable<decimal> baseCalculoPrevidencia { get; set; }
        public System.Nullable<decimal> valorRetidoPrevidencia { get; set; }
        public string comexUfEmbarque { get; set; }
        public string comexLocalEmbarque { get; set; }
        public string compraNotaEmpenho { get; set; }
        public string compraPedido { get; set; }
        public string compraContrato { get; set; }
        public string informacoesAddFisco { get; set; }
        public string informacoesAddContribuinte { get; set; }
        public string statusNota { get; set; }

        public IList<NFeDetalheDTO> listaDetalhe { get; set; }
        public IList<NFeCupomFiscalDTO> listaCupomFiscal { get; set; }
        public IList<NFeDuplicataDTO> listaDuplicata { get; set; }
        public NFeDestinatarioDTO destinatario { get; set; }
        public NFeLocalEntregaDTO localEntrega { get; set; }
        public NFeLocalRetiradaDTO localRetirada { get; set; }
        public NFeTransporteDTO transporte { get; set; }
        public NFeFaturaDTO fatura { get; set; }
        public NFeEmitenteDTO emitente { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeCabecalhoDTO {
        public NfeCabecalhoDTO() { }
        public int Id { get; set; }

        public TributOperacaoFiscalDTO TributOperacaoFiscal { get; set; }
        public VendaCabecalhoDTO VendaCabecalho { get; set; }
        public FornecedorDTO Fornecedor { get; set; }
        public ClienteDTO Cliente { get; set; }

        public NfeEmitenteDTO NfeEmitente { get; set; }
        public NfeDestinatarioDTO NfeDestinatario { get; set; }
        public NfeLocalEntregaDTO NfeLocalEntrega { get; set; }
        public NfeLocalRetiradaDTO NfeLocalRetirada { get; set; }
        public NfeTransporteDTO NfeTransporte { get; set; }
        public NfeFaturaDTO NfeFatura { get; set; }

        public int IdEmpresa { get; set; }
        public System.Nullable<int> UfEmitente { get; set; }
        public string CodigoNumerico { get; set; }
        public string NaturezaOperacao { get; set; }
        public System.Nullable<int> IndicadorFormaPagamento { get; set; }
        public string CodigoModelo { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public System.Nullable<System.DateTime> DataHoraEmissao { get; set; }
        public System.Nullable<System.DateTime> DataHoraEntradaSaida { get; set; }
        public System.Nullable<int> TipoOperacao { get; set; }
        public System.Nullable<int> LocalDestino { get; set; }
        public System.Nullable<int> CodigoMunicipio { get; set; }
        public System.Nullable<int> FormatoImpressaoDanfe { get; set; }
        public System.Nullable<int> TipoEmissao { get; set; }
        public string ChaveAcesso { get; set; }
        public string DigitoChaveAcesso { get; set; }
        public System.Nullable<int> Ambiente { get; set; }
        public System.Nullable<int> FinalidadeEmissao { get; set; }
        public System.Nullable<int> ConsumidorOperacao { get; set; }
        public System.Nullable<int> ConsumidorPresenca { get; set; }
        public System.Nullable<int> ProcessoEmissao { get; set; }
        public string VersaoProcessoEmissao { get; set; }
        public System.Nullable<System.DateTime> DataEntradaContingencia { get; set; }
        public string JustificativaContingencia { get; set; }
        public System.Nullable<decimal> BaseCalculoIcms { get; set; }
        public System.Nullable<decimal> ValorIcms { get; set; }
        public System.Nullable<decimal> ValorIcmsDesonerado { get; set; }
        public System.Nullable<decimal> BaseCalculoIcmsSt { get; set; }
        public System.Nullable<decimal> ValorIcmsSt { get; set; }
        public System.Nullable<decimal> ValorTotalProdutos { get; set; }
        public System.Nullable<decimal> ValorFrete { get; set; }
        public System.Nullable<decimal> ValorSeguro { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<decimal> ValorImpostoImportacao { get; set; }
        public System.Nullable<decimal> ValorIpi { get; set; }
        public System.Nullable<decimal> ValorPis { get; set; }
        public System.Nullable<decimal> ValorCofins { get; set; }
        public System.Nullable<decimal> ValorDespesasAcessorias { get; set; }
        public System.Nullable<decimal> ValorTotal { get; set; }
        public System.Nullable<decimal> ValorServicos { get; set; }
        public System.Nullable<decimal> BaseCalculoIssqn { get; set; }
        public System.Nullable<decimal> ValorIssqn { get; set; }
        public System.Nullable<decimal> ValorPisIssqn { get; set; }
        public System.Nullable<decimal> ValorCofinsIssqn { get; set; }
        public System.Nullable<System.DateTime> DataPrestacaoServico { get; set; }
        public System.Nullable<decimal> ValorDeducaoIssqn { get; set; }
        public System.Nullable<decimal> OutrasRetencoesIssqn { get; set; }
        public System.Nullable<decimal> DescontoIncondicionadoIssqn { get; set; }
        public System.Nullable<decimal> DescontoCondicionadoIssqn { get; set; }
        public System.Nullable<decimal> TotalRetencaoIssqn { get; set; }
        public System.Nullable<int> RegimeEspecialTributacao { get; set; }
        public System.Nullable<decimal> ValorRetidoPis { get; set; }
        public System.Nullable<decimal> ValorRetidoCofins { get; set; }
        public System.Nullable<decimal> ValorRetidoCsll { get; set; }
        public System.Nullable<decimal> BaseCalculoIrrf { get; set; }
        public System.Nullable<decimal> ValorRetidoIrrf { get; set; }
        public System.Nullable<decimal> BaseCalculoPrevidencia { get; set; }
        public System.Nullable<decimal> ValorRetidoPrevidencia { get; set; }
        public string ComexUfEmbarque { get; set; }
        public string ComexLocalEmbarque { get; set; }
        public string ComexLocalDespacho { get; set; }
        public string CompraNotaEmpenho { get; set; }
        public string CompraPedido { get; set; }
        public string CompraContrato { get; set; }
        public string InformacoesAddFisco { get; set; }
        public string InformacoesAddContribuinte { get; set; }
        public System.Nullable<int> StatusNota { get; set; }

        public int QuantidadeImpressaoDanfe { get; set; }

        // Grupo BA
        public IList<NfeReferenciadaDTO> ListaNfeReferenciada { get; set; } //0:500
        public IList<NfeNfReferenciadaDTO> ListaNfeNfReferenciada { get; set; } //0:500
        public IList<NfeCteReferenciadoDTO> ListaNfeCteReferenciado { get; set; } //0:500
        public IList<NfeProdRuralReferenciadaDTO> ListaNfeProdRuralReferenciada { get; set; } //0:500
        public IList<NfeCupomFiscalReferenciadoDTO> ListaNfeCupomFiscalReferenciado { get; set; } //0:500
        // Grupo GA
        public IList<NfeAcessoXmlDTO> ListaNfeAcessoXml { get; set; } //0:10
        // Grupo I
        public IList<NfeDetalheDTO> ListaNfeDetalhe { get; set; } //1:990
        // Grupo Y - Y07
        public IList<NfeDuplicataDTO> ListaNfeDuplicata { get; set; } //0:120
        // Grupo YA [usado apenas na NFC-e]
        public IList<NfeFormaPagamentoDTO> ListaNfeFormaPagamento { get; set; } //0:100
        // Grupo Z - Z10
        public IList<NfeProcessoReferenciadoDTO> ListaNfeProcessoReferenciado { get; set; } //0:100
    }
}

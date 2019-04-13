using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfeCabecalhoDTO {
        public NfeCabecalhoDTO() 
        {
            ListaNfeDetalhe = new List<NfeDetalheDTO>();
            ListaNfeFormaPagamento = new List<NfeFormaPagamentoDTO>();
        }
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public System.Nullable<int> IdNfceMovimento { get; set; }
        public System.Nullable<int> IdVendedor { get; set; }
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
        public System.Nullable<decimal> Troco { get; set; }

        public NfeDestinatarioDTO NfeDestinatario { get; set; }
        public IList<NfeDetalheDTO> ListaNfeDetalhe { get; set; }
        public IList<NfeFormaPagamentoDTO> ListaNfeFormaPagamento { get; set; }

    }
}

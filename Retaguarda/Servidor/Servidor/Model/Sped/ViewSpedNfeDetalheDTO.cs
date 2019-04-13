using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ViewSpedNfeDetalheDTO {
        public ViewSpedNfeDetalheDTO() { }
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public int IdNfeCabecalho { get; set; }
        public int NumeroItem { get; set; }
        public string CodigoProduto { get; set; }
        public string Gtin { get; set; }
        public string NomeProduto { get; set; }
        public string Ncm { get; set; }
        public int ExTipi { get; set; }
        public int Cfop { get; set; }
        public string UnidadeComercial { get; set; }
        public decimal QuantidadeComercial { get; set; }
        public decimal ValorUnitarioComercial { get; set; }
        public decimal ValorBrutoProduto { get; set; }
        public string GtinUnidadeTributavel { get; set; }
        public string UnidadeTributavel { get; set; }
        public decimal QuantidadeTributavel { get; set; }
        public decimal ValorUnitarioTributavel { get; set; }
        public decimal ValorFrete { get; set; }
        public decimal ValorSeguro { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorOutrasDespesas { get; set; }
        public string EntraTotal { get; set; }
        public decimal ValorSubtotal { get; set; }
        public decimal ValorTotal { get; set; }
        public string NumeroPedidoCompra { get; set; }
        public int ItemPedidoCompra { get; set; }
        public string InformacoesAdicionais { get; set; }
        public int IdTributOperacaoFiscal { get; set; }
        public int IdUnidadeProduto { get; set; }
        public string CstCofins { get; set; }
        public decimal QuantidadeVendidaCofins { get; set; }
        public decimal BaseCalculoCofins { get; set; }
        public decimal AliquotaCofinsPercentual { get; set; }
        public decimal AliquotaCofinsReais { get; set; }
        public decimal ValorCofins { get; set; }
        public string OrigemMercadoria { get; set; }
        public string CstIcms { get; set; }
        public string Csosn { get; set; }
        public string ModalidadeBcIcms { get; set; }
        public decimal TaxaReducaoBcIcms { get; set; }
        public decimal BaseCalculoIcms { get; set; }
        public decimal AliquotaIcms { get; set; }
        public decimal ValorIcms { get; set; }
        public string MotivoDesoneracaoIcms { get; set; }
        public string ModalidadeBcIcmsSt { get; set; }
        public decimal PercentualMvaIcmsSt { get; set; }
        public decimal PercentualReducaoBcIcmsSt { get; set; }
        public decimal ValorBaseCalculoIcmsSt { get; set; }
        public decimal AliquotaIcmsSt { get; set; }
        public decimal ValorIcmsSt { get; set; }
        public decimal ValorBcIcmsStRetido { get; set; }
        public decimal ValorIcmsStRetido { get; set; }
        public decimal ValorBcIcmsStDestino { get; set; }
        public decimal ValorIcmsStDestino { get; set; }
        public decimal AliquotaCreditoIcmsSn { get; set; }
        public decimal ValorCreditoIcmsSn { get; set; }
        public decimal PercentualBcOperacaoPropria { get; set; }
        public string UfSt { get; set; }
        public decimal ValorBcIi { get; set; }
        public decimal ValorDespesasAduaneiras { get; set; }
        public decimal ValorImpostoImportacao { get; set; }
        public decimal ValorIof { get; set; }
        public string EnquadramentoIpi { get; set; }
        public string CnpjProdutor { get; set; }
        public string CodigoSeloIpi { get; set; }
        public int QuantidadeSeloIpi { get; set; }
        public string EnquadramentoLegalIpi { get; set; }
        public string CstIpi { get; set; }
        public decimal ValorBaseCalculoIpi { get; set; }
        public decimal AliquotaIpi { get; set; }
        public decimal QuantidadeUnidadeTributavel { get; set; }
        public decimal ValorUnidadeTributavel { get; set; }
        public decimal ValorIpi { get; set; }
        public decimal BaseCalculoIssqn { get; set; }
        public decimal AliquotaIssqn { get; set; }
        public decimal ValorIssqn { get; set; }
        public int MunicipioIssqn { get; set; }
        public int ItemListaServicos { get; set; }
        public string TributacaoIssqn { get; set; }
        public string CstPis { get; set; }
        public decimal QuantidadeVendidaPis { get; set; }
        public decimal ValorBaseCalculoPis { get; set; }
        public decimal AliquotaPisPercentual { get; set; }
        public decimal AliquotaPisReais { get; set; }
        public decimal ValorPis { get; set; }
    }
}

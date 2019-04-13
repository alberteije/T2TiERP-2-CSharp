using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FiscalNotaFiscalEntradaDTO {
        public FiscalNotaFiscalEntradaDTO() { }
        public int Id { get; set; }
        public NfeCabecalhoDTO NfeCabecalho { get; set; }
        public string Competencia { get; set; }
        public System.Nullable<int> CfopEntrada { get; set; }
        public System.Nullable<decimal> ValorRateioFrete { get; set; }
        public System.Nullable<decimal> ValorCustoMedio { get; set; }
        public System.Nullable<decimal> ValorIcmsAntecipado { get; set; }
        public System.Nullable<decimal> ValorBcIcmsAntecipado { get; set; }
        public System.Nullable<decimal> ValorBcIcmsCreditado { get; set; }
        public System.Nullable<decimal> ValorBcPisCreditado { get; set; }
        public System.Nullable<decimal> ValorBcCofinsCreditado { get; set; }
        public System.Nullable<decimal> ValorBcIpiCreditado { get; set; }
        public string CstCreditoIcms { get; set; }
        public string CstCreditoPis { get; set; }
        public string CstCreditoCofins { get; set; }
        public string CstCreditoIpi { get; set; }
        public System.Nullable<decimal> ValorIcmsCreditado { get; set; }
        public System.Nullable<decimal> ValorPisCreditado { get; set; }
        public System.Nullable<decimal> ValorCofinsCreditado { get; set; }
        public System.Nullable<decimal> ValorIpiCreditado { get; set; }
        public System.Nullable<int> QtdeParcelaCreditoPis { get; set; }
        public System.Nullable<int> QtdeParcelaCreditoCofins { get; set; }
        public System.Nullable<int> QtdeParcelaCreditoIcms { get; set; }
        public System.Nullable<int> QtdeParcelaCreditoIpi { get; set; }
        public System.Nullable<decimal> AliquotaCreditoIcms { get; set; }
        public System.Nullable<decimal> AliquotaCreditoPis { get; set; }
        public System.Nullable<decimal> AliquotaCreditoCofins { get; set; }
        public System.Nullable<decimal> AliquotaCreditoIpi { get; set; }
    }
}

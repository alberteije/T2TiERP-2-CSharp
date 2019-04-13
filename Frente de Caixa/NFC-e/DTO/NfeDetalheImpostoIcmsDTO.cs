using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfeDetalheImpostoIcmsDTO {
        public NfeDetalheImpostoIcmsDTO() { }
        public int Id { get; set; }
        public int IdNfeDetalhe { get; set; }
        public System.Nullable<int> OrigemMercadoria { get; set; }
        public string CstIcms { get; set; }
        public string Csosn { get; set; }
        public System.Nullable<int> ModalidadeBcIcms { get; set; }
        public System.Nullable<decimal> TaxaReducaoBcIcms { get; set; }
        public System.Nullable<decimal> BaseCalculoIcms { get; set; }
        public System.Nullable<decimal> AliquotaIcms { get; set; }
        public System.Nullable<decimal> ValorIcms { get; set; }
        public System.Nullable<decimal> ValorIcmsOperacao { get; set; }
        public System.Nullable<decimal> PercentualDiferimento { get; set; }
        public System.Nullable<decimal> ValorIcmsDiferido { get; set; }
        public System.Nullable<int> MotivoDesoneracaoIcms { get; set; }
        public System.Nullable<decimal> ValorIcmsDesonerado { get; set; }
        public System.Nullable<int> ModalidadeBcIcmsSt { get; set; }
        public System.Nullable<decimal> PercentualMvaIcmsSt { get; set; }
        public System.Nullable<decimal> PercentualReducaoBcIcmsSt { get; set; }
        public System.Nullable<decimal> ValorBaseCalculoIcmsSt { get; set; }
        public System.Nullable<decimal> AliquotaIcmsSt { get; set; }
        public System.Nullable<decimal> ValorIcmsSt { get; set; }
        public System.Nullable<decimal> ValorBcIcmsStRetido { get; set; }
        public System.Nullable<decimal> ValorIcmsStRetido { get; set; }
        public System.Nullable<decimal> ValorBcIcmsStDestino { get; set; }
        public System.Nullable<decimal> ValorIcmsStDestino { get; set; }
        public System.Nullable<decimal> AliquotaCreditoIcmsSn { get; set; }
        public System.Nullable<decimal> ValorCreditoIcmsSn { get; set; }
        public System.Nullable<decimal> PercentualBcOperacaoPropria { get; set; }
        public string UfSt { get; set; }
    }
}

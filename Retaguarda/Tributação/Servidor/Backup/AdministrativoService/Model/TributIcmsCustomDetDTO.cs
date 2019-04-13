using System;
using System.Text;
using System.Collections.Generic;


namespace AdministrativoService.Model {
    
    public class TributIcmsCustomDetDTO {
        public TributIcmsCustomDetDTO() { }
        public int Id { get; set; }
        public int? IdTributIcmsCustomCab { get; set; }
        public string UfDestino { get; set; }
        public System.Nullable<int> Cfop { get; set; }
        public string CsosnB { get; set; }
        public string CstB { get; set; }
        public string ModalidadeBc { get; set; }
        public System.Nullable<decimal> Aliquota { get; set; }
        public System.Nullable<decimal> ValorPauta { get; set; }
        public System.Nullable<decimal> ValorPrecoMaximo { get; set; }
        public System.Nullable<decimal> Mva { get; set; }
        public System.Nullable<decimal> PorcentoBc { get; set; }
        public string ModalidadeBcSt { get; set; }
        public System.Nullable<decimal> AliquotaInternaSt { get; set; }
        public System.Nullable<decimal> AliquotaInterestadualSt { get; set; }
        public System.Nullable<decimal> PorcentoBcSt { get; set; }
        public System.Nullable<decimal> AliquotaIcmsSt { get; set; }
        public System.Nullable<decimal> ValorPautaSt { get; set; }
        public System.Nullable<decimal> ValorPrecoMaximoSt { get; set; }
    }
}

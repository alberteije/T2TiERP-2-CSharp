using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ViewSpedC190DTO {
        public ViewSpedC190DTO() { }
        public int Id { get; set; }
        public string CstIcms { get; set; }
        public System.Nullable<int> Cfop { get; set; }
        public System.Nullable<decimal> AliquotaIcms { get; set; }
        public System.Nullable<System.DateTime> DataHoraEmissao { get; set; }
        public System.Nullable<decimal> SomaValorOperacao { get; set; }
        public System.Nullable<decimal> SomaBaseCalculoIcms { get; set; }
        public System.Nullable<decimal> SomaValorIcms { get; set; }
        public System.Nullable<decimal> SomaBaseCalculoIcmsSt { get; set; }
        public System.Nullable<decimal> SomaValorIcmsSt { get; set; }
        public System.Nullable<decimal> SomaVlRedBc { get; set; }
        public System.Nullable<decimal> SomaValorIpi { get; set; }
    }
}

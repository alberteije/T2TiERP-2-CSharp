using System;
using System.Text;
using System.Collections.Generic;


namespace AdministrativoService.Model {
    
    public class TributIpiDipiDTO {
        public TributIpiDipiDTO() { }
        public int Id { get; set; }
        public int? IdTributConfiguraOfGt { get; set; }
        public TipoReceitaDipiDTO TipoReceitaDipi { get; set; }
        public string CstIpi { get; set; }
        public string ModalidadeBaseCalculo { get; set; }
        public System.Nullable<decimal> PorcentoBaseCalculo { get; set; }
        public System.Nullable<decimal> AliquotaPorcento { get; set; }
        public System.Nullable<decimal> AliquotaUnidade { get; set; }
        public System.Nullable<decimal> ValorPrecoMaximo { get; set; }
        public System.Nullable<decimal> ValorPautaFiscal { get; set; }
    }
}

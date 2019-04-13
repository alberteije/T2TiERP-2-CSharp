using System;
using System.Text;
using System.Collections.Generic;


namespace AdministrativoService.Model {
    
    public class TributCofinsCodApuracaoDTO {
        public TributCofinsCodApuracaoDTO() { }
        public int Id { get; set; }
        public int? IdTributConfiguraOfGt { get; set; }
        public string CstCofins { get; set; }
        public string CodigoApuracaoEfd { get; set; }
        public string ModalidadeBaseCalculo { get; set; }
        public System.Nullable<decimal> PorcentoBaseCalculo { get; set; }
        public System.Nullable<decimal> AliquotaPorcento { get; set; }
        public System.Nullable<decimal> AliquotaUnidade { get; set; }
        public System.Nullable<decimal> ValorPrecoMaximo { get; set; }
        public System.Nullable<decimal> ValorPautaFiscal { get; set; }
    }
}

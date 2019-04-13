using System;
using System.Text;
using System.Collections.Generic;


namespace AdministrativoService.Model {
    
    public class TributIssDTO {
        public TributIssDTO() { }
        public int Id { get; set; }
        public TributOperacaoFiscalDTO TributOperacaoFiscal { get; set; }
        public string ModalidadeBaseCalculo { get; set; }
        public System.Nullable<decimal> PorcentoBaseCalculo { get; set; }
        public System.Nullable<decimal> AliquotaPorcento { get; set; }
        public System.Nullable<decimal> AliquotaUnidade { get; set; }
        public System.Nullable<decimal> ValorPrecoMaximo { get; set; }
        public System.Nullable<decimal> ValorPautaFiscal { get; set; }
        public System.Nullable<int> ItemListaServico { get; set; }
        public string CodigoTributacao { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace EstoqueService.Model {
    
    public class NfeDetalheImpostoIpiDTO {
        public NfeDetalheImpostoIpiDTO() { }
        public int Id { get; set; }
        public int idNFeDetalhe { get; set; }
        public string EnquadramentoIpi { get; set; }
        public string CnpjProdutor { get; set; }
        public string CodigoSeloIpi { get; set; }
        public System.Nullable<int> QuantidadeSeloIpi { get; set; }
        public string EnquadramentoLegalIpi { get; set; }
        public string CstIpi { get; set; }
        public System.Nullable<decimal> ValorBaseCalculoIpi { get; set; }
        public System.Nullable<decimal> AliquotaIpi { get; set; }
        public System.Nullable<decimal> QuantidadeUnidadeTributavel { get; set; }
        public System.Nullable<decimal> ValorUnidadeTributavel { get; set; }
        public System.Nullable<decimal> ValorIpi { get; set; }
    }
}

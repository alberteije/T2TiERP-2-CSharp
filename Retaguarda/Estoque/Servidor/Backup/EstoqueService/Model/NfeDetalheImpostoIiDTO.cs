using System;
using System.Text;
using System.Collections.Generic;


namespace EstoqueService.Model {
    
    public class NfeDetalheImpostoIiDTO {
        public NfeDetalheImpostoIiDTO() { }
        public int Id { get; set; }
        public int idNFeDetalhe { get; set; }
        public System.Nullable<decimal> ValorBcIi { get; set; }
        public System.Nullable<decimal> ValorDespesasAduaneiras { get; set; }
        public System.Nullable<decimal> ValorImpostoImportacao { get; set; }
        public System.Nullable<decimal> ValorIof { get; set; }
    }
}

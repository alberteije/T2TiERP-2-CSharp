using System;
using System.Text;
using System.Collections.Generic;


namespace EstoqueService.Model {
    
    public class NfeDetalheImpostoIssqnDTO {
        public NfeDetalheImpostoIssqnDTO() { }
        public int Id { get; set; }
        public int idNFeDetalhe { get; set; }
        public System.Nullable<decimal> BaseCalculoIssqn { get; set; }
        public System.Nullable<decimal> AliquotaIssqn { get; set; }
        public System.Nullable<decimal> ValorIssqn { get; set; }
        public System.Nullable<int> MunicipioIssqn { get; set; }
        public System.Nullable<int> ItemListaServicos { get; set; }
    }
}

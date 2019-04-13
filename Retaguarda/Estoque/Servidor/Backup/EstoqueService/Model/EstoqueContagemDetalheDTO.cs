using System;
using System.Text;
using System.Collections.Generic;


namespace EstoqueService.Model {
    
    public class EstoqueContagemDetalheDTO {
        public EstoqueContagemDetalheDTO() { }
        public int Id { get; set; }
        public int IdEstoqueContagemCabecalho { get; set; }
        public ProdutoDTO Produto { get; set; }
        public System.Nullable<decimal> QuantidadeContada { get; set; }
        public System.Nullable<decimal> QuantidadeSistema { get; set; }
        public System.Nullable<decimal> Acuracidade { get; set; }
        public System.Nullable<decimal> Divergencia { get; set; }
    }
}

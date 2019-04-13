using System;
using System.Text;
using System.Collections.Generic;


namespace EstoqueService.Model {
    
    public class RequisicaoInternaDetalheDTO {
        public RequisicaoInternaDetalheDTO() { }
        public int Id { get; set; }
        public int IdRequisicaoInternaCabecalho { get; set; }
        public ProdutoDTO Produto { get; set; }
        public decimal Quantidade { get; set; }
    }
}

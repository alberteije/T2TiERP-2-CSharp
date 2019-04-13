using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class EstoqueReajusteDetalheDTO {
        public EstoqueReajusteDetalheDTO() { }
        public int Id { get; set; }
        public int IdEstoqueReajusteCabecalho { get; set; }
        public ProdutoDTO Produto { get; set; }
        public System.Nullable<decimal> ValorOriginal { get; set; }
        public System.Nullable<decimal> ValorReajuste { get; set; }
    }
}

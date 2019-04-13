using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class CompraRequisicaoDetalheDTO {
        public CompraRequisicaoDetalheDTO() { }
        public int Id { get; set; }
        public CompraRequisicaoDTO CompraRequisicao { get; set; }
        public ProdutoDTO Produto { get; set; }
        public System.Nullable<decimal> Quantidade { get; set; }
        public System.Nullable<decimal> QuantidadeCotada { get; set; }
        public string ItemCotado { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class ProdutoPromocaoDTO {
        public ProdutoPromocaoDTO() { }
        public int Id { get; set; }
        public ProdutoDTO Produto { get; set; }
        public System.Nullable<System.DateTime> DataInicio { get; set; }
        public System.Nullable<System.DateTime> DataFim { get; set; }
        public System.Nullable<decimal> QuantidadeEmPromocao { get; set; }
        public System.Nullable<decimal> QuantidadeMaximaCliente { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
    }
}

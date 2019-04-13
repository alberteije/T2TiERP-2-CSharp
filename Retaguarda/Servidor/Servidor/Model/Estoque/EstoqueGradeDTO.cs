using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class EstoqueGradeDTO {
        public EstoqueGradeDTO() { }
        public int Id { get; set; }
        public ProdutoDTO Produto { get; set; }
        public EstoqueTamanhoDTO EstoqueTamanho { get; set; }
        public EstoqueCorDTO EstoqueCor { get; set; }
        public string Codigo { get; set; }
        public System.Nullable<decimal> Quantidade { get; set; }
    }
}

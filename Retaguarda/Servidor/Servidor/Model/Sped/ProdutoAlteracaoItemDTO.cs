using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ProdutoAlteracaoItemDTO {
        public ProdutoAlteracaoItemDTO() { }
        public int Id { get; set; }
        public ProdutoDTO Produto { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public System.Nullable<System.DateTime> DataInicial { get; set; }
        public System.Nullable<System.DateTime> DataFinal { get; set; }
    }
}

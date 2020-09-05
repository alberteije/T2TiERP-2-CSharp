using System;
using System.Text;
using System.Collections.Generic;


namespace SISService.Model {
    
    public class ProdutoDTO {
        public ProdutoDTO() { }
        public int Id { get; set; }
        public CategoriaProdutoDTO CategoriaProduto { get; set; }
        public string Nome { get; set; }
    }
}

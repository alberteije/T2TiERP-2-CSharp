using System;
using System.Text;
using System.Collections.Generic;


namespace EstoqueService.Model {
    
    public class ProdutoGrupoDTO {
        public ProdutoGrupoDTO() { }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}

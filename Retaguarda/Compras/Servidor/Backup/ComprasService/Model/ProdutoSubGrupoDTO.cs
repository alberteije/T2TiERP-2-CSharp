using System;
using System.Text;
using System.Collections.Generic;


namespace ComprasService.Model {
    
    public class ProdutoSubGrupoDTO {
        public ProdutoSubGrupoDTO() { }
        public int Id { get; set; }
        public ProdutoGrupoDTO ProdutoGrupo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}

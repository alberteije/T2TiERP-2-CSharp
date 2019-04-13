using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class UnidadeConversaoDTO {
        public UnidadeConversaoDTO() { }
        public int Id { get; set; }
        public ProdutoDTO Produto { get; set; }
        public UnidadeProdutoDTO UnidadeProduto { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public decimal FatorConversao { get; set; }
    }
}

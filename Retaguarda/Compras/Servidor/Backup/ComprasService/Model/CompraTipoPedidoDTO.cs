using System;
using System.Text;
using System.Collections.Generic;


namespace ComprasService.Model {
    
    public class CompraTipoPedidoDTO {
        public CompraTipoPedidoDTO() { }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}

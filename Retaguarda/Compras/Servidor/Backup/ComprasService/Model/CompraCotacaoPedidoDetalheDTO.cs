using System;
using System.Text;
using System.Collections.Generic;


namespace ComprasService.Model {
    
    public class CompraCotacaoPedidoDetalheDTO {
        public CompraCotacaoPedidoDetalheDTO() { }
        public int Id { get; set; }
        public CompraPedidoDTO CompraPedido { get; set; }
        public CompraCotacaoDetalheDTO CompraCotacaoDetalhe { get; set; }
        public System.Nullable<decimal> QuantidadePedida { get; set; }
    }
}

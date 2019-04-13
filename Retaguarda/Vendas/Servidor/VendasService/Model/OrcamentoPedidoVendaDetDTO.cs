using System;
using System.Text;
using System.Collections.Generic;


namespace VendasService.Model {
    
    public class OrcamentoPedidoVendaDetDTO {
        public OrcamentoPedidoVendaDetDTO() { }
        public int? Id { get; set; }
        public ProdutoDTO Produto { get; set; }
        public int? IdOrcamentoPedidoVendaCab { get; set; }
        public decimal? Quantidade { get; set; }
        public decimal? ValorUnitario { get; set; }
        public decimal? ValorSubtotal { get; set; }
        public decimal? TaxaDesconto { get; set; }
        public decimal? ValorDesconto { get; set; }
        public decimal? ValorTotal { get; set; }
    }
}

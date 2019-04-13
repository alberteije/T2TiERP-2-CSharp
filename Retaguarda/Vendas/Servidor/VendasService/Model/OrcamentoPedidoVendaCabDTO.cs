using System;
using System.Text;
using System.Collections.Generic;


namespace VendasService.Model {
    
    public class OrcamentoPedidoVendaCabDTO {
        public OrcamentoPedidoVendaCabDTO() { }
        public int? Id { get; set; }
        public VendedorDTO Vendedor { get; set; }
        public TransportadoraDTO Transportadora { get; set; }
        public ClienteDTO Cliente { get; set; }
        public CondicoesPagamentoDTO CondicoesPagamento { get; set; }
        public string Tipo { get; set; }
        public string Codigo { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
        public System.Nullable<System.DateTime> DataEntrega { get; set; }
        public System.Nullable<System.DateTime> Validade { get; set; }
        public string TipoFrete { get; set; }
        public decimal? ValorSubtotal { get; set; }
        public decimal? ValorFrete { get; set; }
        public decimal? TaxaComissao { get; set; }
        public decimal? ValorComissao { get; set; }
        public decimal? TaxaDesconto { get; set; }
        public decimal? ValorDesconto { get; set; }
        public decimal? ValorTotal { get; set; }
        public string Observacao { get; set; }
        public string StatusPedido { get; set; }
        public IList<OrcamentoPedidoVendaDetDTO> ListaOrcamentoPedidoVendaDet { get; set; }
    }
}

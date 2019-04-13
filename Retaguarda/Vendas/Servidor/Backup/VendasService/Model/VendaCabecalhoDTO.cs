using System;
using System.Text;
using System.Collections.Generic;


namespace VendasService.Model {
    
    public class VendaCabecalhoDTO {
        public VendaCabecalhoDTO() { }
        public int Id { get; set; }
        public TransportadoraDTO Transportadora { get; set; }
        public TipoNotaFiscalDTO TipoNotaFiscal { get; set; }
        public ClienteDTO Cliente { get; set; }
        public VendedorDTO Vendedor { get; set; }
        public CondicoesPagamentoDTO CondicoesPagamento { get; set; }
        public OrcamentoPedidoVendaCabDTO OrcamentoPedidoVendaCab { get; set; }
        public System.Nullable<System.DateTime> DataVenda { get; set; }
        public System.Nullable<System.DateTime> DataSaida { get; set; }
        public string HoraSaida { get; set; }
        public System.Nullable<int> NumeroFatura { get; set; }
        public string LocalEntrega { get; set; }
        public string LocalCobranca { get; set; }
        public System.Nullable<decimal> ValorSubtotal { get; set; }
        public System.Nullable<decimal> TaxaComissao { get; set; }
        public System.Nullable<decimal> ValorComissao { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<decimal> ValorTotal { get; set; }
        public string TipoFrete { get; set; }
        public string FormaPagamento { get; set; }
        public System.Nullable<decimal> ValorFrete { get; set; }
        public System.Nullable<decimal> ValorSeguro { get; set; }
        public string Observacao { get; set; }
        public string Situacao { get; set; }

        public IList<VendaDetalheDTO> ListaVendaDetalhe { get; set; }
    }
}

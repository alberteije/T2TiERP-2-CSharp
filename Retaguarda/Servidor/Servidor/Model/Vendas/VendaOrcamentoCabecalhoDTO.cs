using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class VendaOrcamentoCabecalhoDTO {
        public VendaOrcamentoCabecalhoDTO() { }
        public int Id { get; set; }
        public VendaCondicoesPagamentoDTO VendaCondicoesPagamento { get; set; }
        public VendedorDTO Vendedor { get; set; }
        public TransportadoraDTO Transportadora { get; set; }
        public ClienteDTO Cliente { get; set; }
        public string Tipo { get; set; }
        public string Codigo { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
        public System.Nullable<System.DateTime> DataEntrega { get; set; }
        public System.Nullable<System.DateTime> Validade { get; set; }
        public string TipoFrete { get; set; }
        public System.Nullable<decimal> ValorSubtotal { get; set; }
        public System.Nullable<decimal> ValorFrete { get; set; }
        public System.Nullable<decimal> TaxaComissao { get; set; }
        public System.Nullable<decimal> ValorComissao { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<decimal> ValorTotal { get; set; }
        public string Observacao { get; set; }
        public string Situacao { get; set; }
    }
}

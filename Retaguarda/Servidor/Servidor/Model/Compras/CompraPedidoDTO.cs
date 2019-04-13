using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class CompraPedidoDTO {
        public CompraPedidoDTO() { }
        public int Id { get; set; }
        public CompraTipoPedidoDTO CompraTipoPedido { get; set; }
        public FornecedorDTO Fornecedor { get; set; }
        public System.Nullable<System.DateTime> DataPedido { get; set; }
        public System.Nullable<System.DateTime> DataPrevistaEntrega { get; set; }
        public System.Nullable<System.DateTime> DataPrevisaoPagamento { get; set; }
        public string LocalEntrega { get; set; }
        public string LocalCobranca { get; set; }
        public string Contato { get; set; }
        public System.Nullable<decimal> ValorSubtotal { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<decimal> ValorTotalPedido { get; set; }
        public string TipoFrete { get; set; }
        public string FormaPagamento { get; set; }
        public System.Nullable<decimal> BaseCalculoIcms { get; set; }
        public System.Nullable<decimal> ValorIcms { get; set; }
        public System.Nullable<decimal> BaseCalculoIcmsSt { get; set; }
        public System.Nullable<decimal> ValorIcmsSt { get; set; }
        public System.Nullable<decimal> ValorTotalProdutos { get; set; }
        public System.Nullable<decimal> ValorFrete { get; set; }
        public System.Nullable<decimal> ValorSeguro { get; set; }
        public System.Nullable<decimal> ValorOutrasDespesas { get; set; }
        public System.Nullable<decimal> ValorIpi { get; set; }
        public System.Nullable<decimal> ValorTotalNf { get; set; }
        public System.Nullable<int> QuantidadeParcelas { get; set; }
        public System.Nullable<int> DiasPrimeiroVencimento { get; set; }
        public System.Nullable<int> DiasIntervalo { get; set; }
    }
}

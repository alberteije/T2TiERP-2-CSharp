using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FinParcelaPagamentoDTO {
        public FinParcelaPagamentoDTO() { }
        public int Id { get; set; }
        public FinParcelaPagarDTO FinParcelaPagar { get; set; }
        public FinChequeEmitidoDTO FinChequeEmitido { get; set; }
        public FinTipoPagamentoDTO FinTipoPagamento { get; set; }
        public ContaCaixaDTO ContaCaixa { get; set; }
        public System.Nullable<System.DateTime> DataPagamento { get; set; }
        public System.Nullable<decimal> TaxaJuro { get; set; }
        public System.Nullable<decimal> TaxaMulta { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> ValorJuro { get; set; }
        public System.Nullable<decimal> ValorMulta { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<decimal> ValorPago { get; set; }
        public string Historico { get; set; }
    }
}

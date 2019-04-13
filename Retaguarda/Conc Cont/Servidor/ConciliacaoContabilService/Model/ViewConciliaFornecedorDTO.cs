using System;
using System.Text;
using System.Collections.Generic;


namespace ConciliacaoContabilService.Model {
    
    public class ViewConciliaFornecedorDTO {
        public ViewConciliaFornecedorDTO() { }
        public int Id { get; set; }
        public int IdFinParcelaPagar { get; set; }
        public int IdFinTipoPagamento { get; set; }
        public int IdContaCaixa { get; set; }
        public System.Nullable<System.DateTime> DataPagamento { get; set; }
        public System.Nullable<decimal> TaxaJuro { get; set; }
        public System.Nullable<decimal> TaxaMulta { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> ValorJuro { get; set; }
        public System.Nullable<decimal> ValorMulta { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<decimal> ValorPago { get; set; }
        public string Historico { get; set; }
        public int IdFornecedor { get; set; }
    }
}

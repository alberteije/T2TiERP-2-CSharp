using System;
using System.Text;
using System.Collections.Generic;


namespace ConciliacaoContabilService.Model {
    
    public class ViewConciliaClienteDTO {
        public ViewConciliaClienteDTO() { }
        public int Id { get; set; }
        public int IdFinParcelaReceber { get; set; }
        public int IdFinTipoRecebimento { get; set; }
        public int IdContaCaixa { get; set; }
        public System.Nullable<System.DateTime> DataRecebimento { get; set; }
        public System.Nullable<decimal> TaxaJuro { get; set; }
        public System.Nullable<decimal> TaxaMulta { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> ValorJuro { get; set; }
        public System.Nullable<decimal> ValorMulta { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<decimal> ValorRecebido { get; set; }
        public string Historico { get; set; }
        public int IdCliente { get; set; }
    }
}

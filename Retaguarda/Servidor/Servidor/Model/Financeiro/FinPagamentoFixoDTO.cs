using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FinPagamentoFixoDTO {
        public FinPagamentoFixoDTO() { }
        public int Id { get; set; }
        public string PagamentoCompartilhado { get; set; }
        public System.Nullable<int> QuantidadeParcela { get; set; }
        public System.Nullable<decimal> ValorTotal { get; set; }
        public System.Nullable<decimal> ValorAPagar { get; set; }
        public System.Nullable<System.DateTime> DataLancamento { get; set; }
        public string NumeroDocumento { get; set; }
        public string ImagemDocumento { get; set; }
        public System.Nullable<System.DateTime> PrimeiroVencimento { get; set; }
        public System.Nullable<int> IntervaloEntreParcelas { get; set; }
    }
}

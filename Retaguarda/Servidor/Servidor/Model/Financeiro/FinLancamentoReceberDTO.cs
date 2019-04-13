using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FinLancamentoReceberDTO {
        public FinLancamentoReceberDTO() { }
        public int Id { get; set; }
        public FinDocumentoOrigemDTO FinDocumentoOrigem { get; set; }
        public ClienteDTO Cliente { get; set; }
        public System.Nullable<int> QuantidadeParcela { get; set; }
        public System.Nullable<decimal> ValorTotal { get; set; }
        public System.Nullable<decimal> ValorAReceber { get; set; }
        public System.Nullable<System.DateTime> DataLancamento { get; set; }
        public string NumeroDocumento { get; set; }
        public System.Nullable<System.DateTime> PrimeiroVencimento { get; set; }
        public System.Nullable<decimal> TaxaComissao { get; set; }
        public System.Nullable<decimal> ValorComissao { get; set; }
        public System.Nullable<int> IntervaloEntreParcelas { get; set; }
        public string CodigoModuloLcto { get; set; }
        public System.Nullable<int> MescladoPara { get; set; }
        public System.Nullable<decimal> ValorDescontoConvenio { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class ContasPagarReceberDTO {
        public ContasPagarReceberDTO() { }
        public int Id { get; set; }
        public EcfVendaCabecalhoDTO EcfVendaCabecalho { get; set; }
        public System.Nullable<int> IdPlanoContas { get; set; }
        public System.Nullable<int> IdTipoDocumento { get; set; }
        public System.Nullable<int> IdPessoa { get; set; }
        public string Tipo { get; set; }
        public string NumeroDocumento { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public System.Nullable<System.DateTime> DataLancamento { get; set; }
        public System.Nullable<System.DateTime> PrimeiroVencimento { get; set; }
        public string NaturezaLancamento { get; set; }
        public System.Nullable<int> QuantidadeParcela { get; set; }
        public string CodigoTipoPagamento { get; set; }
    }
}

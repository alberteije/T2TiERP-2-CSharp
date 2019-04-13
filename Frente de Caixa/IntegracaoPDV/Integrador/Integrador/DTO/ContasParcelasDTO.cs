using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class ContasParcelasDTO {
        public ContasParcelasDTO() { }
        public int Id { get; set; }
        public ContasPagarReceberDTO ContasPagarReceber { get; set; }
        public System.Nullable<int> IdMeiosPagamento { get; set; }
        public System.Nullable<int> IdChequeEmitido { get; set; }
        public System.Nullable<int> IdContaCaixa { get; set; }
        public System.Nullable<System.DateTime> DataEmissao { get; set; }
        public System.Nullable<System.DateTime> DataVencimento { get; set; }
        public System.Nullable<System.DateTime> DataPagamento { get; set; }
        public System.Nullable<int> NumeroParcela { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public System.Nullable<decimal> TaxaJuros { get; set; }
        public System.Nullable<decimal> TaxaMulta { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> ValorJuros { get; set; }
        public System.Nullable<decimal> ValorMulta { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<decimal> TotalParcela { get; set; }
        public string Historico { get; set; }
        public string Situacao { get; set; }
    }
}

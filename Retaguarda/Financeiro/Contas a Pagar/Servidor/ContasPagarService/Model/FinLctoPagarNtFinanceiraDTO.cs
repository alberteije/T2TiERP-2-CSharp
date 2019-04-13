using System;
using System.Text;
using System.Collections.Generic;


namespace ContasPagarService.Model {
    
    public class FinLctoPagarNtFinanceiraDTO {
        public FinLctoPagarNtFinanceiraDTO() { }
        public int Id { get; set; }
        public int? IdFinLancamentoPagar { get; set; }
        public NaturezaFinanceiraDTO NaturezaFinanceira { get; set; }
        public System.Nullable<System.DateTime> DataInclusao { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
    }
}

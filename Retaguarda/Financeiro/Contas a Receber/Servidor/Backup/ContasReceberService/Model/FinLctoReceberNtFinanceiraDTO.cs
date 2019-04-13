using System;
using System.Text;
using System.Collections.Generic;


namespace ContasReceberService.Model {
    
    public class FinLctoReceberNtFinanceiraDTO {
        public FinLctoReceberNtFinanceiraDTO() { }
        public int Id { get; set; }
        public int IdFinLancamentoReceber { get; set; }
        public NaturezaFinanceiraDTO NaturezaFinanceira { get; set; }
        public System.Nullable<System.DateTime> DataInclusao { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
    }
}

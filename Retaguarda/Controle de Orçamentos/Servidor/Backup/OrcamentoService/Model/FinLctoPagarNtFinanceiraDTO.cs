using System;
using System.Text;
using System.Collections.Generic;


namespace OrcamentoService.Model
{
    
    public class FinLctoPagarNtFinanceiraDTO {
        public FinLctoPagarNtFinanceiraDTO() { }
        public int id { get; set; }
        public int? idFinLancamentoPagar { get; set; }
        public NaturezaFinanceiraDTO naturezaFinanceira { get; set; }
        public System.Nullable<System.DateTime> dataInclusao { get; set; }
        public System.Nullable<decimal> valor { get; set; }
    }
}

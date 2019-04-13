using System;
using System.Text;
using System.Collections.Generic;


namespace OrcamentoService.Model
{
    
    public class FinLctoReceberNtFinanceiraDTO {
        public FinLctoReceberNtFinanceiraDTO() { }
        public int id { get; set; }
        public int idFinLancamentoReceber { get; set; }
        public NaturezaFinanceiraDTO naturezaFinanceira { get; set; }
        public System.Nullable<System.DateTime> dataInclusao { get; set; }
        public System.Nullable<decimal> valor { get; set; }
    }
}

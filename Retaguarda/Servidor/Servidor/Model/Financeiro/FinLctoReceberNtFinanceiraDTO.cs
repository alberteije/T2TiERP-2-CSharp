using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FinLctoReceberNtFinanceiraDTO {
        public FinLctoReceberNtFinanceiraDTO() { }
        public int Id { get; set; }
        public FinLancamentoReceberDTO FinLancamentoReceber { get; set; }
        public ContabilLancamentoDetalheDTO ContabilLancamentoDetalhe { get; set; }
        public NaturezaFinanceiraDTO NaturezaFinanceira { get; set; }
        public System.Nullable<System.DateTime> DataInclusao { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public System.Nullable<decimal> Percentual { get; set; }
    }
}

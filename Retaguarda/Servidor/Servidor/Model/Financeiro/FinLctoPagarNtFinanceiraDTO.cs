using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FinLctoPagarNtFinanceiraDTO {
        public FinLctoPagarNtFinanceiraDTO() { }
        public int Id { get; set; }
        public FinLancamentoPagarDTO FinLancamentoPagar { get; set; }
        public ContabilLancamentoDetalheDTO ContabilLancamentoDetalhe { get; set; }
        public NaturezaFinanceiraDTO NaturezaFinanceira { get; set; }
        public System.Nullable<System.DateTime> DataInclusao { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public System.Nullable<decimal> Percentual { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace ContabilidadeService.Model {
    
    public class ContabilEncerramentoExeDetDTO {
        public ContabilEncerramentoExeDetDTO() { }
        public int Id { get; set; }
        public ContabilContaDTO ContabilConta { get; set; }
        public int? IdContabilEncerramentoExeCab { get; set; }
        public System.Nullable<decimal> SaldoAnterior { get; set; }
        public System.Nullable<decimal> ValorDebito { get; set; }
        public System.Nullable<decimal> ValorCredito { get; set; }
        public System.Nullable<decimal> Saldo { get; set; }
    }
}

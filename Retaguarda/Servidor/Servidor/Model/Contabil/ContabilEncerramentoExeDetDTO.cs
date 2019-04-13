using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ContabilEncerramentoExeDetDTO {
        public ContabilEncerramentoExeDetDTO() { }
        public int Id { get; set; }
        public ContabilContaDTO ContabilConta { get; set; }
        public ContabilEncerramentoExeCabDTO ContabilEncerramentoExeCab { get; set; }
        public System.Nullable<decimal> SaldoAnterior { get; set; }
        public System.Nullable<decimal> ValorDebito { get; set; }
        public System.Nullable<decimal> ValorCredito { get; set; }
        public System.Nullable<decimal> Saldo { get; set; }
    }
}

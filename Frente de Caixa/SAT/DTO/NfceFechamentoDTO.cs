using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfceFechamentoDTO {
        public NfceFechamentoDTO() { }
        public int Id { get; set; }
        public int IdNfceMovimento { get; set; }
        public string TipoPagamento { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
    }
}

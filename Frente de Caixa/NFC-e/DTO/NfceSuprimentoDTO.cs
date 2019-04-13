using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfceSuprimentoDTO {
        public NfceSuprimentoDTO() { }
        public int Id { get; set; }
        public int IdNfceMovimento { get; set; }
        public System.Nullable<System.DateTime> DataSuprimento { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public string Observacao { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfceSangriaDTO {
        public NfceSangriaDTO() { }
        public int Id { get; set; }
        public int IdNfceMovimento { get; set; }
        public System.Nullable<System.DateTime> DataSangria { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public string Observacao { get; set; }
    }
}

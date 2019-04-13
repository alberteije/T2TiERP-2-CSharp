using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfceCaixaDTO {
        public NfceCaixaDTO() { }
        public int Id { get; set; }
        public string Nome { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
    }
}

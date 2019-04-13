using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfceOperadorDTO {
        public NfceOperadorDTO() { }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string NivelAutorizacao { get; set; }
    }
}

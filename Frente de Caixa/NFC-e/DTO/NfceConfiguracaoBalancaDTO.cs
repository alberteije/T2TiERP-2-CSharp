using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfceConfiguracaoBalancaDTO {
        public NfceConfiguracaoBalancaDTO() { }
        public int Id { get; set; }
        public System.Nullable<int> Modelo { get; set; }
        public string Identificador { get; set; }
        public System.Nullable<int> HandShake { get; set; }
        public System.Nullable<int> Parity { get; set; }
        public System.Nullable<int> StopBits { get; set; }
        public System.Nullable<int> DataBits { get; set; }
        public System.Nullable<int> BaudRate { get; set; }
        public string Porta { get; set; }
        public System.Nullable<int> Timeout { get; set; }
        public string TipoConfiguracao { get; set; }
    }
}

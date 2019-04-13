using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfceConfiguracaoLeitorSerDTO {
        public NfceConfiguracaoLeitorSerDTO() { }
        public int Id { get; set; }
        public string Usa { get; set; }
        public string Porta { get; set; }
        public System.Nullable<int> Baud { get; set; }
        public System.Nullable<int> HandShake { get; set; }
        public System.Nullable<int> Parity { get; set; }
        public System.Nullable<int> StopBits { get; set; }
        public System.Nullable<int> DataBits { get; set; }
        public System.Nullable<int> Intervalo { get; set; }
        public string UsarFila { get; set; }
        public string HardFlow { get; set; }
        public string SoftFlow { get; set; }
        public string Sufixo { get; set; }
        public string ExcluirSufixo { get; set; }
    }
}

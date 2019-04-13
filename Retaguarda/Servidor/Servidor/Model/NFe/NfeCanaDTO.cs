using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeCanaDTO {
        public NfeCanaDTO() { }
        public int Id { get; set; }
        public NfeCabecalhoDTO NfeCabecalho { get; set; }
        public string Safra { get; set; }
        public string MesAnoReferencia { get; set; }
    }
}

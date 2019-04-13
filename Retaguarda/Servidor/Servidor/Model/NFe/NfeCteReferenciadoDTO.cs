using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeCteReferenciadoDTO {
        public NfeCteReferenciadoDTO() { }
        public int Id { get; set; }
        public int IdNfeCabecalho { get; set; }
        public string ChaveAcesso { get; set; }
    }
}

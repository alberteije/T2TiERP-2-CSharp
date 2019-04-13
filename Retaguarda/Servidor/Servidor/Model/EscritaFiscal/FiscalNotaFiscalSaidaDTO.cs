using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FiscalNotaFiscalSaidaDTO {
        public FiscalNotaFiscalSaidaDTO() { }
        public int Id { get; set; }
        public NfeCabecalhoDTO NfeCabecalho { get; set; }
        public string Competencia { get; set; }
    }
}

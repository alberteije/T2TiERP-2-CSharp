using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfceTipoPagamentoDTO {
        public NfceTipoPagamentoDTO() { }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string PermiteTroco { get; set; }
        public string GeraParcelas { get; set; }
    }
}

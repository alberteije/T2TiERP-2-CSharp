using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfceTurnoDTO {
        public NfceTurnoDTO() { }
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
    }
}

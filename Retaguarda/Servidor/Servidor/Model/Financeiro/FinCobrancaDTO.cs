using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FinCobrancaDTO {
        public FinCobrancaDTO() { }
        public int Id { get; set; }
        public System.Nullable<System.DateTime> DataContato { get; set; }
        public string HoraContato { get; set; }
        public string TelefoneContato { get; set; }
        public System.Nullable<System.DateTime> DataAcertoPagamento { get; set; }
        public System.Nullable<decimal> TotalReceberNaData { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeDuplicataDTO {
        public NfeDuplicataDTO() { }
        public int Id { get; set; }
        public int IdNfeCabecalho { get; set; }
        public string Numero { get; set; }
        public System.Nullable<System.DateTime> DataVencimento { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
    }
}

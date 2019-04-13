using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ChequeDTO {
        public ChequeDTO() { }
        public int Id { get; set; }
        public TalonarioChequeDTO TalonarioCheque { get; set; }
        public System.Nullable<int> Numero { get; set; }
        public string StatusCheque { get; set; }
        public System.Nullable<System.DateTime> DataStatus { get; set; }
    }
}

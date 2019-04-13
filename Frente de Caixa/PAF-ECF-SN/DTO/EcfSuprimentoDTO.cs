using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class EcfSuprimentoDTO {
        public EcfSuprimentoDTO() { }
        public int Id { get; set; }
        public int IdEcfMovimento { get; set; }
        public System.Nullable<System.DateTime> DataSuprimento { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class EcfSangriaDTO {
        public EcfSangriaDTO() { }
        public int Id { get; set; }
        public int IdEcfMovimento { get; set; }
        public System.Nullable<System.DateTime> DataSangria { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
    }
}

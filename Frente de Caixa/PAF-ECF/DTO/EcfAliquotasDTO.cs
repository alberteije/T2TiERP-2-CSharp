using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class EcfAliquotasDTO {
        public EcfAliquotasDTO() { }
        public int Id { get; set; }
        public string TotalizadorParcial { get; set; }
        public string EcfIcmsSt { get; set; }
        public string PafPSt { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class EcfDocumentosEmitidosDTO {
        public EcfDocumentosEmitidosDTO() { }
        public int Id { get; set; }
        public int IdEcfMovimento { get; set; }
        public System.Nullable<System.DateTime> DataEmissao { get; set; }
        public string HoraEmissao { get; set; }
        public string Tipo { get; set; }
        public System.Nullable<int> Coo { get; set; }
    }
}

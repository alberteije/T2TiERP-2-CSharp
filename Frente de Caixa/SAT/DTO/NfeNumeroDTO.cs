using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfeNumeroDTO {
        public NfeNumeroDTO() { }
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Serie { get; set; }
        public System.Nullable<int> Numero { get; set; }
    }
}

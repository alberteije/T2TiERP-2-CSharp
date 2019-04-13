using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class VendedorDTO {
        public VendedorDTO() { }
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public System.Nullable<decimal> Comissao { get; set; }
        public System.Nullable<decimal> MetaVendas { get; set; }
    }
}

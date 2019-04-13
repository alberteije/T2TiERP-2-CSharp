using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class VendedorDTO {
        public VendedorDTO() { }
        public int Id { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public System.Nullable<decimal> Comissao { get; set; }
        public System.Nullable<decimal> MetaVendas { get; set; }
        public string Gerente { get; set; }
        public System.Nullable<decimal> TaxaGerente { get; set; }
    }
}

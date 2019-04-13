using System;
using System.Text;
using System.Collections.Generic;


namespace VendasService.Model {
    
    public class VendedorDTO {
        public VendedorDTO() { }
        public int Id { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public string Comissao { get; set; }
        public string MetaVendas { get; set; }
    }
}

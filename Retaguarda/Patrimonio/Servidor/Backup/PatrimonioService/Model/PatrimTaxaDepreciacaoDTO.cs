using System;
using System.Text;
using System.Collections.Generic;


namespace PatrimonioService.Model {
    
    public class PatrimTaxaDepreciacaoDTO {
        public PatrimTaxaDepreciacaoDTO() { }
        public int Id { get; set; }
        public string Ncm { get; set; }
        public string Bem { get; set; }
        public System.Nullable<decimal> Vida { get; set; }
        public System.Nullable<decimal> Taxa { get; set; }
    }
}

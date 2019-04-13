using System;
using System.Text;
using System.Collections.Generic;


namespace ContabilidadeService.Model {
    
    public class PaisDTO {
        public PaisDTO() { }
        public int Id { get; set; }
        public System.Nullable<int> Codigo { get; set; }
        public string NomeEn { get; set; }
        public string NomePtbr { get; set; }
        public string Sigla2 { get; set; }
        public string Sigla3 { get; set; }
    }
}

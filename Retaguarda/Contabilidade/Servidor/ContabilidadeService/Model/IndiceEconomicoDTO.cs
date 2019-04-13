using System;
using System.Text;
using System.Collections.Generic;


namespace ContabilidadeService.Model {
    
    public class IndiceEconomicoDTO {
        public IndiceEconomicoDTO() { }
        public int Id { get; set; }
        public PaisDTO Pais { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}

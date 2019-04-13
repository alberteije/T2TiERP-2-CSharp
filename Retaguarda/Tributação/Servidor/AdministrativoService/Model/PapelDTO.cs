using System;
using System.Text;
using System.Collections.Generic;


namespace AdministrativoService.Model {
    
    public class PapelDTO {
        public PapelDTO() { }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string AcessoCompleto { get; set; }
    }
}

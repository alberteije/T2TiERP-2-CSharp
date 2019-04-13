using System;
using System.Text;
using System.Collections.Generic;


namespace PatrimonioService.Model {
    
    public class EstadoCivilDTO {
        public EstadoCivilDTO() {
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}

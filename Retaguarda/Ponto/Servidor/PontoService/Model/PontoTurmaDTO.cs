using System;
using System.Text;
using System.Collections.Generic;


namespace PontoService.Model {
    
    public class PontoTurmaDTO {
        public PontoTurmaDTO() { }
        public int Id { get; set; }
        public int? IdPontoEscala { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
    }
}

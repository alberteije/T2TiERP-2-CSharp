using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PontoTurmaDTO {
        public PontoTurmaDTO() { }
        public int Id { get; set; }
        public PontoEscalaDTO PontoEscala { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
    }
}

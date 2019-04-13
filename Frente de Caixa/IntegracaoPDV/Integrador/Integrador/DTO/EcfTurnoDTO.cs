using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class EcfTurnoDTO {
        public EcfTurnoDTO() { }
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
    }
}

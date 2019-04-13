using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeTransporteReboqueDTO {
        public NfeTransporteReboqueDTO() { }
        public int Id { get; set; }
        public NfeTransporteDTO NfeTransporte { get; set; }
        public string Placa { get; set; }
        public string Uf { get; set; }
        public string Rntc { get; set; }
    }
}

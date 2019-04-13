using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeTransporteVolumeLacreDTO {
        public NfeTransporteVolumeLacreDTO() { }
        public int Id { get; set; }
        public NfeTransporteVolumeDTO NfeTransporteVolume { get; set; }
        public string Numero { get; set; }
    }
}

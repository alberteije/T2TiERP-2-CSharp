using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeTransporteVolumeDTO {
        public NfeTransporteVolumeDTO() { }
        public int Id { get; set; }
        public NfeTransporteDTO NfeTransporte { get; set; }
        public System.Nullable<int> Quantidade { get; set; }
        public string Especie { get; set; }
        public string Marca { get; set; }
        public string Numeracao { get; set; }
        public System.Nullable<decimal> PesoLiquido { get; set; }
        public System.Nullable<decimal> PesoBruto { get; set; }
    }
}

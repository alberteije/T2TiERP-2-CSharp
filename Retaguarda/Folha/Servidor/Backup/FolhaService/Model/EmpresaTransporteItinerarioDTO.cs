using System;
using System.Text;
using System.Collections.Generic;


namespace FolhaService.Model {
    
    public class EmpresaTransporteItinerarioDTO {
        public EmpresaTransporteItinerarioDTO() { }
        public int Id { get; set; }
        public EmpresaTransporteDTO EmpresaTransporte { get; set; }
        public string Nome { get; set; }
        public System.Nullable<decimal> Tarifa { get; set; }
        public string Trajeto { get; set; }
    }
}

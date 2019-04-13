using System;
using System.Text;
using System.Collections.Generic;


namespace FolhaService.Model {
    
    public class FolhaValeTransporteDTO {
        public FolhaValeTransporteDTO() { }
        public int Id { get; set; }
        public EmpresaTransporteItinerarioDTO EmpresaTransporteItinerario { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public System.Nullable<int> Quantidade { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class WmsEstanteDTO {
        public WmsEstanteDTO() { }
        public int Id { get; set; }

        public WmsRuaDTO WmsRua { get; set; }

        public string Codigo { get; set; }
        public System.Nullable<int> QuantidadeCaixa { get; set; }
    }
}

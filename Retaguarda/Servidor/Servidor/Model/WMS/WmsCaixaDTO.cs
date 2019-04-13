using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class WmsCaixaDTO {
        public WmsCaixaDTO() { }
        public int Id { get; set; }

        public WmsEstanteDTO WmsEstante { get; set; }

        public string Codigo { get; set; }
        public System.Nullable<int> Altura { get; set; }
        public System.Nullable<int> Largura { get; set; }
        public System.Nullable<int> Profundidade { get; set; }
    }
}

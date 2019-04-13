using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class EtiquetaFormatoPapelDTO {
        public EtiquetaFormatoPapelDTO() { }
        public int Id { get; set; }
        public string Nome { get; set; }
        public System.Nullable<int> Altura { get; set; }
        public System.Nullable<int> Largura { get; set; }
    }
}

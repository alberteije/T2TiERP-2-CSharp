using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ContabilIndiceValorDTO {
        public ContabilIndiceValorDTO() { }
        public int Id { get; set; }
        public ContabilIndiceDTO ContabilIndice { get; set; }
        public System.Nullable<System.DateTime> DataIndice { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ContaContabilRateioDTO {
        public ContaContabilRateioDTO() { }
        public int Id { get; set; }
        public CentroResultadoDTO CentroResultado { get; set; }
        public ContabilContaDTO ContabilConta { get; set; }
        public System.Nullable<decimal> PorcentoRateio { get; set; }
    }
}

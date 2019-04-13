using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PatrimDepreciacaoBemDTO {
        public PatrimDepreciacaoBemDTO() { }
        public int Id { get; set; }
        public PatrimBemDTO PatrimBem { get; set; }
        public System.Nullable<System.DateTime> DataDepreciacao { get; set; }
        public System.Nullable<int> Dias { get; set; }
        public System.Nullable<decimal> Taxa { get; set; }
        public System.Nullable<decimal> Indice { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public System.Nullable<decimal> DepreciacaoAcumulada { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace PatrimonioService.Model {
    
    public class PatrimIndiceAtualizacaoDTO {
        public PatrimIndiceAtualizacaoDTO() { }
        public int Id { get; set; }
        public System.Nullable<System.DateTime> DataIndice { get; set; }
        public string Nome { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public System.Nullable<decimal> ValorAlternativo { get; set; }
    }
}

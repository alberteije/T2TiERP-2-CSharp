using System;
using System.Text;
using System.Collections.Generic;


namespace PatrimonioService.Model {
    
    public class PatrimMovimentacaoBemDTO {
        public PatrimMovimentacaoBemDTO() { }
        public int Id { get; set; }
        public int? IdPatrimBem { get; set; }
        public PatrimTipoMovimentacaoDTO PatrimTipoMovimentacao { get; set; }
        public System.Nullable<System.DateTime> DataMovimentacao { get; set; }
        public string Responsavel { get; set; }
    }
}

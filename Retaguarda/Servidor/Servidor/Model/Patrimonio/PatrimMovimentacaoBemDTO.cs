using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PatrimMovimentacaoBemDTO {
        public PatrimMovimentacaoBemDTO() { }
        public int Id { get; set; }
        public PatrimBemDTO PatrimBem { get; set; }
        public PatrimTipoMovimentacaoDTO PatrimTipoMovimentacao { get; set; }
        public System.Nullable<System.DateTime> DataMovimentacao { get; set; }
        public string Responsavel { get; set; }
    }
}

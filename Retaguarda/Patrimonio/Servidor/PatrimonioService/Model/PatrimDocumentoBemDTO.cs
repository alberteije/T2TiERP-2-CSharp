using System;
using System.Text;
using System.Collections.Generic;


namespace PatrimonioService.Model {
    
    public class PatrimDocumentoBemDTO {
        public PatrimDocumentoBemDTO() { }
        public int Id { get; set; }
        public int? IdPatrimBem { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
    }
}

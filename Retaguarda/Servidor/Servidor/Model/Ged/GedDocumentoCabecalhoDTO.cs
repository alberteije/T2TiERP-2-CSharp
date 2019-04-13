using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class GedDocumentoCabecalhoDTO {
        public GedDocumentoCabecalhoDTO() { }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public System.Nullable<System.DateTime> DataInclusao { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class GedDocumentoDetalheDTO {
        public GedDocumentoDetalheDTO() { }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string PalavraChave { get; set; }
        public string PodeExcluir { get; set; }
        public string PodeAlterar { get; set; }
        public string Assinado { get; set; }
        public System.Nullable<System.DateTime> DataFimVigencia { get; set; }
        public System.Nullable<System.DateTime> DataExclusao { get; set; }
    }
}

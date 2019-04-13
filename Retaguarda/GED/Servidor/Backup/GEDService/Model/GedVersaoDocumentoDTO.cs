using System;
using System.Text;
using System.Collections.Generic;


namespace GEDService.Model {
    
    public class GedVersaoDocumentoDTO {
        public GedVersaoDocumentoDTO() { }
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public int IdDocumento { get; set; }
        public int Versao { get; set; }
        public System.Nullable<System.DateTime> DataHora { get; set; }
        public string HashArquivo { get; set; }
        public string Caminho { get; set; }
        public string Acao { get; set; }
    }
}

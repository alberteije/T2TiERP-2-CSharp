using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class GedVersaoDocumentoDTO {
        public GedVersaoDocumentoDTO() { }
        public int Id { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public GedDocumentoDetalheDTO GedDocumento { get; set; }
        public int Versao { get; set; }
        public System.DateTime DataHora { get; set; }
        public string HashArquivo { get; set; }
        public string Caminho { get; set; }
        public string Acao { get; set; }
    }
}

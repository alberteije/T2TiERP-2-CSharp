using System;
using System.Text;
using System.Collections.Generic;


namespace GEDService.Model {
    
    public class GedDocumentoDTO {
        public GedDocumentoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public GedTipoDocumentoDTO GedTipoDocumento { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string PalavraChave { get; set; }
        public string PodeExcluir { get; set; }
        public string PodeAlterar { get; set; }
        public string Assinado { get; set; }
        public System.Nullable<System.DateTime> DataFimVigencia { get; set; }
        public System.Nullable<System.DateTime> DataExclusao { get; set; }

        public ArquivoDTO arquivo { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class GedTipoDocumentoDTO {
        public GedTipoDocumentoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Nome { get; set; }
        public System.Nullable<decimal> TamanhoMaximo { get; set; }
    }
}

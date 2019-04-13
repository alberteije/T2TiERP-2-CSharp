using System;
using System.Text;
using System.Collections.Generic;


namespace ContasReceberService.Model {
    
    public class FinDocumentoOrigemDTO {
        public FinDocumentoOrigemDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Codigo { get; set; }
        public string SiglaDocumento { get; set; }
        public string Descricao { get; set; }
    }
}

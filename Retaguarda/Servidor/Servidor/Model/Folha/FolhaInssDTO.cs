using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FolhaInssDTO {
        public FolhaInssDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Competencia { get; set; }
    }
}

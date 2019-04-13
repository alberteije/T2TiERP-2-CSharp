using System;
using System.Text;
using System.Collections.Generic;


namespace FolhaService.Model {
    
    public class EmpresaTransporteDTO {
        public EmpresaTransporteDTO() { }
        public int Id { get; set; }
        public ContabilContaDTO ContabilConta { get; set; }
        public string Uf { get; set; }
        public string Nome { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace FolhaService.Model {
    
    public class FolhaFechamentoDTO {
        public FolhaFechamentoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string FechamentoAtual { get; set; }
        public string ProximoFechamento { get; set; }
    }
}

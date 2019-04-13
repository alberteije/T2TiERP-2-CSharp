using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class OrcamentoPeriodoDTO {
        public OrcamentoPeriodoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Periodo { get; set; }
        public string Nome { get; set; }
    }
}

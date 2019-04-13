using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class SeguradoraDTO {
        public SeguradoraDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }
        public string Telefone { get; set; }
    }
}

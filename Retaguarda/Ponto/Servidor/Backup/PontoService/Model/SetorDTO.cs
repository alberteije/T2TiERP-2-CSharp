using System;
using System.Text;
using System.Collections.Generic;


namespace PontoService.Model {
    
    public class SetorDTO {
        public SetorDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}

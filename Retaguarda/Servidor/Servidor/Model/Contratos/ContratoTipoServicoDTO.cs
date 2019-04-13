using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ContratoTipoServicoDTO {
        public ContratoTipoServicoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}

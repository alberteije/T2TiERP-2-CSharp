using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ComissaoPerfilDTO {
        public ComissaoPerfilDTO() { }
        public EmpresaDTO Empresa { get; set; }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
    }
}

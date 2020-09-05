using System;
using System.Text;
using System.Collections.Generic;


namespace SISService.Model {
    
    public class UsuarioDTO {
        public UsuarioDTO() { }
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public int IdPapel { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
    }
}

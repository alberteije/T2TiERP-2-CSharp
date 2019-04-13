using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class EcfOperadorDTO {
        public EcfOperadorDTO() { }
        public int Id { get; set; }
        public EcfFuncionarioDTO EcfFuncionario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}

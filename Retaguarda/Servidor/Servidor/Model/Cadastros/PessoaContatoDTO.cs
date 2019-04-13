using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PessoaContatoDTO {
        public PessoaContatoDTO() { }
        public int Id { get; set; }
        public PessoaDTO Pessoa { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string FoneComercial { get; set; }
        public string FoneResidencial { get; set; }
        public string FoneCelular { get; set; }
    }
}

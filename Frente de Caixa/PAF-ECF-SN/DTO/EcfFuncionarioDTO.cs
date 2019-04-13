using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class EcfFuncionarioDTO {
        public EcfFuncionarioDTO() { }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public System.Nullable<decimal> ComissaoVista { get; set; }
        public System.Nullable<decimal> ComissaoPrazo { get; set; }
        public string NivelAutorizacao { get; set; }
    }
}

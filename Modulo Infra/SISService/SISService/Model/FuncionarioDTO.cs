using System;
using System.Text;
using System.Collections.Generic;


namespace SISService.Model {
    
    public class FuncionarioDTO {
        public FuncionarioDTO() { }
        public int Id { get; set; }
        public CargoDTO Cargo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
    }
}

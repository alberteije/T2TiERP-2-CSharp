using System;
using System.Text;
using System.Collections.Generic;


namespace AdministrativoService.Model {
    
    public class FuncaoDTO {
        public FuncaoDTO() { }
        public int Id { get; set; }
        public string DescricaoMenu { get; set; }
        public string ImagemMenu { get; set; }
        public string Metodo { get; set; }
        public string Nome { get; set; }
        public string Formulario { get; set; }
    }
}

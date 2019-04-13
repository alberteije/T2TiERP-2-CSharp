using System;
using System.Text;
using System.Collections.Generic;


namespace PatrimonioService.Model {
    
    public class ViewControleAcessoDTO {
        public ViewControleAcessoDTO() { }
        public int Id { get; set; }
        public int IdPapel { get; set; }
        public int IdFuncao { get; set; }
        public string Habilitado { get; set; }
        public string Nome { get; set; }
        public string Formulario { get; set; }
    }
}

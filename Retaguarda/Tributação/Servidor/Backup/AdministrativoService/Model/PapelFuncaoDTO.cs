using System;
using System.Text;
using System.Collections.Generic;


namespace AdministrativoService.Model {
    
    public class PapelFuncaoDTO {
        public PapelFuncaoDTO() { }
        public int Id { get; set; }
        public int IdPapel { get; set; }
        public int IdFuncao { get; set; }
        public string PodeConsultar { get; set; }
        public string PodeInserir { get; set; }
        public string PodeAlterar { get; set; }
        public string PodeExcluir { get; set; }
        public string Habilitado { get; set; }
    }
}

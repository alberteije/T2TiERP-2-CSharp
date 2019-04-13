using System;
using System.Text;
using System.Collections.Generic;


namespace ContabilidadeService.Model {
    
    public class PlanoContaRefSpedDTO {
        public PlanoContaRefSpedDTO() { }
        public int Id { get; set; }
        public string CodCtaRef { get; set; }
        public string Descricao { get; set; }
        public string Orientacoes { get; set; }
        public System.Nullable<System.DateTime> InicioValidade { get; set; }
        public System.Nullable<System.DateTime> FimValidade { get; set; }
        public string Tipo { get; set; }
    }
}

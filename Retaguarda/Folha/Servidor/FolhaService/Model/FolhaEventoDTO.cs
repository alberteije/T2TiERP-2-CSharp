using System;
using System.Text;
using System.Collections.Generic;


namespace FolhaService.Model {
    
    public class FolhaEventoDTO {
        public FolhaEventoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string Unidade { get; set; }
        public string BaseCalculo { get; set; }
        public System.Nullable<decimal> Taxa { get; set; }
    }
}

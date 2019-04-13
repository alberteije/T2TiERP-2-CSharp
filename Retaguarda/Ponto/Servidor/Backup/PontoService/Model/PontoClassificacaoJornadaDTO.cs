using System;
using System.Text;
using System.Collections.Generic;


namespace PontoService.Model {
    
    public class PontoClassificacaoJornadaDTO {
        public PontoClassificacaoJornadaDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Padrao { get; set; }
        public string DescontarHoras { get; set; }
    }
}

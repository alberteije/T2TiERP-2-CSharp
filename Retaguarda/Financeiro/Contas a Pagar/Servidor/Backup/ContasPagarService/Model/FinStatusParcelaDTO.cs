using System;
using System.Text;
using System.Collections.Generic;


namespace ContasPagarService.Model {
    
    public class FinStatusParcelaDTO {
        public FinStatusParcelaDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Situacao { get; set; }
        public string Descricao { get; set; }
        public string Procedimento { get; set; }
    }
}

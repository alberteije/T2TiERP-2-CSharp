using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class OrcamentoFluxoCaixaPeriodoDTO {
        public OrcamentoFluxoCaixaPeriodoDTO() { }
        public int Id { get; set; }
        public ContaCaixaDTO ContaCaixa { get; set; }
        public string Periodo { get; set; }
        public string Nome { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class CentroResultadoDTO {
        public CentroResultadoDTO() { }
        public int Id { get; set; }
        public PlanoCentroResultadoDTO PlanoCentroResultado { get; set; }
        public string Classificacao { get; set; }
        public string Descricao { get; set; }
        public string SofreRateiro { get; set; }
    }
}

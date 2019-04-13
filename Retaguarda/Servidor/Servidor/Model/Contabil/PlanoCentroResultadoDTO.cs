using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PlanoCentroResultadoDTO {
        public PlanoCentroResultadoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Nome { get; set; }
        public string Mascara { get; set; }
        public System.Nullable<int> Niveis { get; set; }
        public System.Nullable<System.DateTime> DataInclusao { get; set; }
    }
}

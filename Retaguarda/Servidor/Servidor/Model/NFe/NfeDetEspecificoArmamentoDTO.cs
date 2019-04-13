using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeDetEspecificoArmamentoDTO {
        public NfeDetEspecificoArmamentoDTO() { }
        public int Id { get; set; }
        public int IdNfeDetalhe { get; set; }
        public System.Nullable<int> TipoArma { get; set; }
        public string NumeroSerieArma { get; set; }
        public string NumeroSerieCano { get; set; }
        public string Descricao { get; set; }
    }
}

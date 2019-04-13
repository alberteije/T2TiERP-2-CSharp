using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class OsAberturaEquipamentoDTO {
        public OsAberturaEquipamentoDTO() { }
        public int Id { get; set; }

        public OsEquipamentoDTO OsEquipamento { get; set; }
        public OsAberturaDTO OsAbertura { get; set; }

        public string NumeroSerie { get; set; }
        public System.Nullable<int> TipoCobertura { get; set; }
    }
}

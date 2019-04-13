using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeDetEspecificoMedicamentoDTO {
        public NfeDetEspecificoMedicamentoDTO() { }
        public int Id { get; set; }
        public int IdNfeDetalhe { get; set; }
        public string NumeroLote { get; set; }
        public System.Nullable<decimal> QuantidadeLote { get; set; }
        public System.Nullable<System.DateTime> DataFabricacao { get; set; }
        public System.Nullable<System.DateTime> DataValidade { get; set; }
        public System.Nullable<decimal> PrecoMaximoConsumidor { get; set; }
    }
}

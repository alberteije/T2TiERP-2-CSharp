using System;
using System.Text;
using System.Collections.Generic;


namespace ContratosService.Model {
    
    public class ContratoPrevFaturamentoDTO {
        public ContratoPrevFaturamentoDTO() { }
        public int? Id { get; set; }
        public int? IdContrato { get; set; }
        public System.Nullable<System.DateTime> DataPrevista { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
    }
}

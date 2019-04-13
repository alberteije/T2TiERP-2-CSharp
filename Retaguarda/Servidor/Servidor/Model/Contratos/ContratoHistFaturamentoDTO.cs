using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ContratoHistFaturamentoDTO {
        public ContratoHistFaturamentoDTO() { }
        public int Id { get; set; }
        public ContratoDTO Contrato { get; set; }
        public System.Nullable<System.DateTime> DataFatura { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
    }
}

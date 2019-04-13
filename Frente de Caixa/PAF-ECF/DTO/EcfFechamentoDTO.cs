using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class EcfFechamentoDTO {
        public EcfFechamentoDTO() { }
        public int Id { get; set; }
        public int IdEcfMovimento { get; set; }
        public string TipoPagamento { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
    }
}

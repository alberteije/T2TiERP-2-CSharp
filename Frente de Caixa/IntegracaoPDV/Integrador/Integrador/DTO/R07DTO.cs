using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class R07DTO {
        public R07DTO() { }
        public int Id { get; set; }
        public int IdR06 { get; set; }
        public System.Nullable<int> Ccf { get; set; }
        public string MeioPagamento { get; set; }
        public System.Nullable<decimal> ValorPagamento { get; set; }
        public string Estorno { get; set; }
        public System.Nullable<decimal> ValorEstorno { get; set; }
        public string Logss { get; set; }
    }
}

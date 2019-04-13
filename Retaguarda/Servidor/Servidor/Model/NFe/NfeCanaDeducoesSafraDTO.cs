using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeCanaDeducoesSafraDTO {
        public NfeCanaDeducoesSafraDTO() { }
        public int Id { get; set; }
        public NfeCanaDTO NfeCana { get; set; }
        public string Decricao { get; set; }
        public System.Nullable<decimal> ValorDeducao { get; set; }
        public System.Nullable<decimal> ValorFornecimento { get; set; }
        public System.Nullable<decimal> ValorTotalDeducao { get; set; }
        public System.Nullable<decimal> ValorLiquidoFornecimento { get; set; }
    }
}

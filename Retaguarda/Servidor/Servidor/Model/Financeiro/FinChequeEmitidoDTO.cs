using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FinChequeEmitidoDTO {
        public FinChequeEmitidoDTO() { }
        public int Id { get; set; }
        public ChequeDTO Cheque { get; set; }
        public System.Nullable<System.DateTime> DataEmissao { get; set; }
        public System.Nullable<System.DateTime> BomPara { get; set; }
        public System.Nullable<System.DateTime> DataCompensacao { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public string NominalA { get; set; }
    }
}

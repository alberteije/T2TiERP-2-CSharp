using System;
using System.Text;
using System.Collections.Generic;


namespace CaixaBancosService.Model {
    
    public class ViewFinChequeNaoCompensadoDTO {
        public ViewFinChequeNaoCompensadoDTO() { }
        public int Id { get; set; }
        public int IdContaCaixa { get; set; }
        public string NomeContaCaixa { get; set; }
        public string Talao { get; set; }
        public System.Nullable<int> NumeroTalao { get; set; }
        public System.Nullable<int> NumeroCheque { get; set; }
        public string StatusCheque { get; set; }
        public System.Nullable<System.DateTime> DataStatus { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
    }
}

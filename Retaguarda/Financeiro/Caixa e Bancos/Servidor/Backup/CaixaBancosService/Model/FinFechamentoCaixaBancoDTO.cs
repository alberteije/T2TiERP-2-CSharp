using System;
using System.Text;
using System.Collections.Generic;


namespace CaixaBancosService.Model {
    
    public class FinFechamentoCaixaBancoDTO {
        public FinFechamentoCaixaBancoDTO() { }
        public int Id { get; set; }
        public int IdContaCaixa { get; set; }
        public System.Nullable<System.DateTime> DataFechamento { get; set; }
        public string MesAno { get; set; }
        public string Mes { get; set; }
        public string Ano { get; set; }
        public System.Nullable<decimal> SaldoAnterior { get; set; }
        public System.Nullable<decimal> Recebimentos { get; set; }
        public System.Nullable<decimal> Pagamentos { get; set; }
        public System.Nullable<decimal> SaldoConta { get; set; }
        public System.Nullable<decimal> ChequeNaoCompensado { get; set; }
        public System.Nullable<decimal> SaldoDisponivel { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace ConciliacaoContabilService.Model {
    
    public class FinExtratoContaBancoDTO {
        public FinExtratoContaBancoDTO() { }
        public int Id { get; set; }
        public ContaCaixaDTO ContaCaixa { get; set; }
        public string MesAno { get; set; }
        public string Mes { get; set; }
        public string Ano { get; set; }
        public System.Nullable<System.DateTime> DataMovimento { get; set; }
        public System.Nullable<System.DateTime> DataBalancete { get; set; }
        public string Historico { get; set; }
        public string Documento { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public string Conciliado { get; set; }
        public string Observacao { get; set; }
    }
}

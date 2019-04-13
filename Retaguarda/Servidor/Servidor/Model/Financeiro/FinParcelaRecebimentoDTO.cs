using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FinParcelaRecebimentoDTO {
        public FinParcelaRecebimentoDTO() { }
        public int Id { get; set; }
        public FinParcelaReceberDTO FinParcelaReceber { get; set; }
        public FinTipoRecebimentoDTO FinTipoRecebimento { get; set; }
        public FinChequeRecebidoDTO FinChequeRecebido { get; set; }
        public ContaCaixaDTO ContaCaixa { get; set; }
        public System.Nullable<System.DateTime> DataRecebimento { get; set; }
        public System.Nullable<decimal> TaxaJuro { get; set; }
        public System.Nullable<decimal> TaxaMulta { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> ValorJuro { get; set; }
        public System.Nullable<decimal> ValorMulta { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<decimal> ValorRecebido { get; set; }
        public string Historico { get; set; }
    }
}

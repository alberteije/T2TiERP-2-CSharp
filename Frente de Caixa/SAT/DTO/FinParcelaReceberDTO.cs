using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class FinParcelaReceberDTO {
        public FinParcelaReceberDTO() { }
        public int Id { get; set; }
        public int IdContaCaixa { get; set; }
        public int IdFinLancamentoReceber { get; set; }
        public int IdFinStatusParcela { get; set; }
        public System.Nullable<int> NumeroParcela { get; set; }
        public System.Nullable<System.DateTime> DataEmissao { get; set; }
        public System.Nullable<System.DateTime> DataVencimento { get; set; }
        public System.Nullable<System.DateTime> DescontoAte { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public System.Nullable<decimal> TaxaJuro { get; set; }
        public System.Nullable<decimal> TaxaMulta { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> ValorJuro { get; set; }
        public System.Nullable<decimal> ValorMulta { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public string EmitiuBoleto { get; set; }
        public string BoletoNossoNumero { get; set; }
    }
}

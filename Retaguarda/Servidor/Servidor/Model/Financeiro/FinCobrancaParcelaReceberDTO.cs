using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FinCobrancaParcelaReceberDTO {
        public FinCobrancaParcelaReceberDTO() { }
        public int Id { get; set; }
        public System.Nullable<int> IdFinLancamentoReceber { get; set; }
        public System.Nullable<int> IdFinParcelaReceber { get; set; }
        public System.Nullable<System.DateTime> DataVencimento { get; set; }
        public System.Nullable<decimal> ValorParcela { get; set; }
        public System.Nullable<decimal> ValorJuroSimulado { get; set; }
        public System.Nullable<decimal> ValorMultaSimulado { get; set; }
        public System.Nullable<decimal> ValorReceberSimulado { get; set; }
        public System.Nullable<decimal> ValorJuroAcordo { get; set; }
        public System.Nullable<decimal> ValorMultaAcordo { get; set; }
        public System.Nullable<decimal> ValorReceberAcordo { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class EcfTotalTipoPagamentoDTO {
        public EcfTotalTipoPagamentoDTO() { }
        public int Id { get; set; }
        public int IdEcfVendaCabecalho { get; set; }
        public EcfTipoPagamentoDTO EcfTipoPagamento { get; set; }
        public System.Nullable<System.DateTime> DataVenda { get; set; }
        public string SerieEcf { get; set; }
        public System.Nullable<int> Coo { get; set; }
        public System.Nullable<int> Ccf { get; set; }
        public System.Nullable<int> Gnf { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public string Nsu { get; set; }
        public string Estorno { get; set; }
        public string Rede { get; set; }
        public string CartaoDc { get; set; }
        public string Logss { get; set; }
    }
}

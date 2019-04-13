using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeFormaPagamentoDTO {
        public NfeFormaPagamentoDTO() { }
        public int Id { get; set; }
        public int IdNfeCabecalho { get; set; }
        public int IdNfceTipoPagamento { get; set; }
        public string Forma { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public string CnpjOperadoraCartao { get; set; }
        public string Bandeira { get; set; }
        public string NumeroAutorizacao { get; set; }
        public string Estorno { get; set; }
    }
}

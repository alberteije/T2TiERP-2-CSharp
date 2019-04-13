using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class EcfRecebimentoNaoFiscalDTO {
        public EcfRecebimentoNaoFiscalDTO() { }
        public int Id { get; set; }
        public int IdEcfMovimento { get; set; }
        public System.Nullable<System.DateTime> DataRecebimento { get; set; }
        public string Descricao { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
    }
}

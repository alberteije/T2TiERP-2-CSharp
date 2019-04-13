using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class ViewTotalPagamentoDataDTO {
        public ViewTotalPagamentoDataDTO() { }
        public int Id { get; set; }
        public System.Nullable<System.DateTime> DataVenda { get; set; }
        public int IdTipoPagamento { get; set; }
        public string Descricao { get; set; }
        public System.Nullable<decimal> ValorApurado { get; set; }
    }
}

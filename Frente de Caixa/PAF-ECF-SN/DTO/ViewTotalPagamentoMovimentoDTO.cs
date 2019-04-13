using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class ViewTotalPagamentoEcfMovimentoDTO {
        public ViewTotalPagamentoEcfMovimentoDTO() { }
        public int Id { get; set; }
        public int IdEcfMovimento { get; set; }
        public string Descricao { get; set; }
        public System.Nullable<decimal> ValorApurado { get; set; }
    }
}

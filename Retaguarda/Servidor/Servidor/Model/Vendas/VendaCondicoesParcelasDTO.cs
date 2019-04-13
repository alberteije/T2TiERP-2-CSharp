using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class VendaCondicoesParcelasDTO {
        public VendaCondicoesParcelasDTO() { }
        public int Id { get; set; }
        public VendaCondicoesPagamentoDTO VendaCondicoesPagamento { get; set; }
        public System.Nullable<int> Parcela { get; set; }
        public System.Nullable<int> Dias { get; set; }
        public System.Nullable<decimal> Taxa { get; set; }
    }
}

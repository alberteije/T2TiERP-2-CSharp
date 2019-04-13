using System;
using System.Text;
using System.Collections.Generic;


namespace VendasService.Model {
    
    public class CondicoesParcelaDTO {
        public CondicoesParcelaDTO() { }
        public virtual int? Id { get; set; }
        public virtual int? IdCondicoesPagamento { get; set; }
        public virtual System.Nullable<int> Parcela { get; set; }
        public virtual System.Nullable<int> Dias { get; set; }
        public virtual decimal? Taxa { get; set; }
    }
}

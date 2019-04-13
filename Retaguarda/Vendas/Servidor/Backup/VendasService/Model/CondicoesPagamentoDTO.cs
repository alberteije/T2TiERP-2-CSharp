using System;
using System.Text;
using System.Collections.Generic;


namespace VendasService.Model {
    
    public class CondicoesPagamentoDTO {
        public CondicoesPagamentoDTO() { }
        public int? Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal? FaturamentoMinimo { get; set; }
        public decimal? FaturamentoMaximo { get; set; }
        public decimal? IndiceCorrecao { get; set; }
        public System.Nullable<int> DiasTolerancia { get; set; }
        public decimal? ValorTolerancia { get; set; }
        public System.Nullable<int> PrazoMedio { get; set; }
        public IList<CondicoesParcelaDTO> ListaCondicoesParcela { get; set; }
    }
}

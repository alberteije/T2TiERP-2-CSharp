using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class OrcamentoFluxoCaixaDetalheDTO {
        public OrcamentoFluxoCaixaDetalheDTO() { }
        public int Id { get; set; }
        public OrcamentoFluxoCaixaDTO OrcamentoFluxoCaixa { get; set; }
        public NaturezaFinanceiraDTO NaturezaFinanceira { get; set; }
        public string Periodo { get; set; }
        public System.Nullable<decimal> ValorOrcado { get; set; }
        public System.Nullable<decimal> ValorRealizado { get; set; }
        public System.Nullable<decimal> TaxaVariacao { get; set; }
        public System.Nullable<decimal> ValorVariacao { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class VendaOrcamentoDetalheDTO {
        public VendaOrcamentoDetalheDTO() { }
        public int Id { get; set; }
        public VendaOrcamentoCabecalhoDTO VendaOrcamentoCabecalho { get; set; }
        public ProdutoDTO Produto { get; set; }
        public System.Nullable<decimal> Quantidade { get; set; }
        public System.Nullable<decimal> ValorUnitario { get; set; }
        public System.Nullable<decimal> ValorSubtotal { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<decimal> ValorTotal { get; set; }
    }
}

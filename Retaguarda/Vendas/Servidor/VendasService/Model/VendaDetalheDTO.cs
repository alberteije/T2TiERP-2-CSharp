using System;
using System.Text;
using System.Collections.Generic;


namespace VendasService.Model {
    
    public class VendaDetalheDTO {
        public VendaDetalheDTO() { }
        public int? Id { get; set; }
        public ProdutoDTO Produto { get; set; }
        public int? IdVendaCabecalho { get; set; }
        public System.Nullable<decimal> Quantidade { get; set; }
        public System.Nullable<decimal> ValorUnitario { get; set; }
        public System.Nullable<decimal> ValorSubtotal { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<decimal> ValorTotal { get; set; }
        public System.Nullable<decimal> TaxaComissao { get; set; }
        public System.Nullable<decimal> ValorComissao { get; set; }
    }
}

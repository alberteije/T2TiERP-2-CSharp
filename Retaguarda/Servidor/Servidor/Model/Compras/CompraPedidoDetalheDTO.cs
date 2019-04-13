using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class CompraPedidoDetalheDTO {
        public CompraPedidoDetalheDTO() { }
        public int Id { get; set; }
        public CompraPedidoDTO CompraPedido { get; set; }
        public ProdutoDTO Produto { get; set; }
        public System.Nullable<decimal> Quantidade { get; set; }
        public System.Nullable<decimal> ValorUnitario { get; set; }
        public System.Nullable<decimal> ValorSubtotal { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<decimal> ValorTotal { get; set; }
        public string CstCsosn { get; set; }
        public System.Nullable<int> Cfop { get; set; }
        public System.Nullable<decimal> BaseCalculoIcms { get; set; }
        public System.Nullable<decimal> ValorIcms { get; set; }
        public System.Nullable<decimal> ValorIpi { get; set; }
        public System.Nullable<decimal> AliquotaIcms { get; set; }
        public System.Nullable<decimal> AliquotaIpi { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PreVendaDetalheDTO {
        public PreVendaDetalheDTO() { }
        public int Id { get; set; }
        public int IdPreVendaCabecalho { get; set; }
        public ProdutoDTO Produto { get; set; }
        public System.Nullable<int> Item { get; set; }
        public System.Nullable<decimal> Quantidade { get; set; }
        public System.Nullable<decimal> ValorUnitario { get; set; }
        public System.Nullable<decimal> ValorTotal { get; set; }
        public string Cancelado { get; set; }
        public string GtinProduto { get; set; }
        public string NomeProduto { get; set; }
        public string UnidadeProduto { get; set; }
        public string EcfIcmsSt { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class DavDetalheDTO {
        public DavDetalheDTO() { }
        public int Id { get; set; }
        public ProdutoDTO Produto { get; set; }
        public int IdDavCabecalho { get; set; }
        public string NumeroDav { get; set; }
        public System.Nullable<System.DateTime> DataEmissao { get; set; }
        public System.Nullable<int> Item { get; set; }
        public System.Nullable<decimal> Quantidade { get; set; }
        public System.Nullable<decimal> ValorUnitario { get; set; }
        public System.Nullable<decimal> ValorTotal { get; set; }
        public string Cancelado { get; set; }
        public string MesclaProduto { get; set; }
        public string GtinProduto { get; set; }
        public string NomeProduto { get; set; }
        public string UnidadeProduto { get; set; }
        public string TotalizadorParcial { get; set; }
        public string Logss { get; set; }
    }
}

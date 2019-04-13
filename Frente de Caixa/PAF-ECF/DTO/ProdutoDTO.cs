using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class ProdutoDTO {
        public ProdutoDTO() { }
        public int Id { get; set; }
        public UnidadeProdutoDTO UnidadeProduto { get; set; }
        public string Gtin { get; set; }
        public string CodigoInterno { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string DescricaoPdv { get; set; }
        public System.Nullable<decimal> ValorVenda { get; set; }
        public System.Nullable<decimal> QuantidadeEstoque { get; set; }
        public System.Nullable<decimal> EstoqueMinimo { get; set; }
        public System.Nullable<decimal> EstoqueMaximo { get; set; }
        public string Iat { get; set; }
        public string Ippt { get; set; }
        public string Ncm { get; set; }
        public string TipoItemSped { get; set; }
        public System.Nullable<decimal> TaxaIpi { get; set; }
        public System.Nullable<decimal> TaxaIssqn { get; set; }
        public System.Nullable<decimal> TaxaPis { get; set; }
        public System.Nullable<decimal> TaxaCofins { get; set; }
        public System.Nullable<decimal> TaxaIcms { get; set; }
        public string Cst { get; set; }
        public string Csosn { get; set; }
        public string TotalizadorParcial { get; set; }
        public string EcfIcmsSt { get; set; }
        public System.Nullable<int> CodigoBalanca { get; set; }
        public string PafPSt { get; set; }
        public string Logss { get; set; }
    }
}

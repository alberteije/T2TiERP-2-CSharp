using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class EcfVendaDetalheDTO {
        public EcfVendaDetalheDTO() { }
        public int Id { get; set; }
        public ProdutoDTO Produto { get; set; }
        public int IdEcfVendaCabecalho { get; set; }
        public int Cfop { get; set; }
        public string Gtin { get; set; }
        public System.Nullable<int> Ccf { get; set; }
        public System.Nullable<int> Coo { get; set; }
        public string SerieEcf { get; set; }
        public System.Nullable<int> Item { get; set; }
        public System.Nullable<decimal> Quantidade { get; set; }
        public System.Nullable<decimal> ValorUnitario { get; set; }
        public System.Nullable<decimal> ValorTotal { get; set; }
        public System.Nullable<decimal> TotalItem { get; set; }
        public System.Nullable<decimal> BaseIcms { get; set; }
        public System.Nullable<decimal> TaxaIcms { get; set; }
        public System.Nullable<decimal> Icms { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> Desconto { get; set; }
        public System.Nullable<decimal> TaxaIssqn { get; set; }
        public System.Nullable<decimal> Issqn { get; set; }
        public System.Nullable<decimal> TaxaPis { get; set; }
        public System.Nullable<decimal> Pis { get; set; }
        public System.Nullable<decimal> TaxaCofins { get; set; }
        public System.Nullable<decimal> Cofins { get; set; }
        public System.Nullable<decimal> TaxaAcrescimo { get; set; }
        public System.Nullable<decimal> Acrescimo { get; set; }
        public System.Nullable<decimal> AcrescimoRateio { get; set; }
        public System.Nullable<decimal> DescontoRateio { get; set; }
        public string TotalizadorParcial { get; set; }
        public string Cst { get; set; }
        public string Cancelado { get; set; }
        public string MovimentaEstoque { get; set; }
        public string EcfIcmsSt { get; set; }
        public string Logss { get; set; }

        public System.Nullable<decimal> ValorImpostoFederal { get; set; }
        public System.Nullable<decimal> ValorImpostoEstadual { get; set; }
        public System.Nullable<decimal> ValorImpostoMunicipal { get; set; }
    }
}

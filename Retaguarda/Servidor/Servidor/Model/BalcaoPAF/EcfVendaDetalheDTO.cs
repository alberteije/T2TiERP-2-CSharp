using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class EcfVendaDetalheDTO {
        public EcfVendaDetalheDTO() { }
        public int Id { get; set; }
        public string NomeCaixa { get; set; }
        public System.Nullable<int> IdGeradoCaixa { get; set; }
        public System.Nullable<int> IdEmpresa { get; set; }
        public System.Nullable<int> IdEcfProduto { get; set; }
        public System.Nullable<int> IdEcfVendaCabecalho { get; set; }
        public System.Nullable<int> Cfop { get; set; }
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
        public System.Nullable<System.DateTime> DataSincronizacao { get; set; }
        public string HoraSincronizacao { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class NotaFiscalDetalheDTO {
        public NotaFiscalDetalheDTO() { }
        public int Id { get; set; }
        public int IdNotaFiscalCabecalho { get; set; }
        public ProdutoDTO Produto { get; set; }
        public int Cfop { get; set; }
        public System.Nullable<int> Item { get; set; }
        public System.Nullable<decimal> Quantidade { get; set; }
        public System.Nullable<decimal> ValorUnitario { get; set; }
        public System.Nullable<decimal> ValorTotal { get; set; }
        public System.Nullable<decimal> BaseIcms { get; set; }
        public System.Nullable<decimal> TaxaIcms { get; set; }
        public System.Nullable<decimal> Icms { get; set; }
        public System.Nullable<decimal> IcmsOutras { get; set; }
        public System.Nullable<decimal> IcmsIsento { get; set; }
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
        public System.Nullable<decimal> TaxaIpi { get; set; }
        public System.Nullable<decimal> Ipi { get; set; }
        public string Cancelado { get; set; }
        public string Cst { get; set; }
        public string MovimentaEstoque { get; set; }
        public string EcfIcmsSt { get; set; }
    }
}

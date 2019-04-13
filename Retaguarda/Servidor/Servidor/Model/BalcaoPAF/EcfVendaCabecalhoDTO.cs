using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class EcfVendaCabecalhoDTO {
        public EcfVendaCabecalhoDTO() { }
        public int Id { get; set; }
        public string NomeCaixa { get; set; }
        public System.Nullable<int> IdGeradoCaixa { get; set; }
        public System.Nullable<int> IdEmpresa { get; set; }
        public System.Nullable<int> IdCliente { get; set; }
        public System.Nullable<int> IdEcfFuncionario { get; set; }
        public System.Nullable<int> IdEcfMovimento { get; set; }
        public System.Nullable<int> IdEcfDav { get; set; }
        public System.Nullable<int> IdEcfPreVendaCabecalho { get; set; }
        public string SerieEcf { get; set; }
        public System.Nullable<int> Cfop { get; set; }
        public System.Nullable<int> Coo { get; set; }
        public System.Nullable<int> Ccf { get; set; }
        public System.Nullable<System.DateTime> DataVenda { get; set; }
        public string HoraVenda { get; set; }
        public System.Nullable<decimal> ValorVenda { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> Desconto { get; set; }
        public System.Nullable<decimal> TaxaAcrescimo { get; set; }
        public System.Nullable<decimal> Acrescimo { get; set; }
        public System.Nullable<decimal> ValorFinal { get; set; }
        public System.Nullable<decimal> ValorRecebido { get; set; }
        public System.Nullable<decimal> Troco { get; set; }
        public System.Nullable<decimal> ValorCancelado { get; set; }
        public System.Nullable<decimal> TotalProdutos { get; set; }
        public System.Nullable<decimal> TotalDocumento { get; set; }
        public System.Nullable<decimal> BaseIcms { get; set; }
        public System.Nullable<decimal> Icms { get; set; }
        public System.Nullable<decimal> IcmsOutras { get; set; }
        public System.Nullable<decimal> Issqn { get; set; }
        public System.Nullable<decimal> Pis { get; set; }
        public System.Nullable<decimal> Cofins { get; set; }
        public System.Nullable<decimal> AcrescimoItens { get; set; }
        public System.Nullable<decimal> DescontoItens { get; set; }
        public string StatusVenda { get; set; }
        public string NomeCliente { get; set; }
        public string CpfCnpjCliente { get; set; }
        public string CupomCancelado { get; set; }
        public string Logss { get; set; }
        public System.Nullable<System.DateTime> DataSincronizacao { get; set; }
        public string HoraSincronizacao { get; set; }
    }
}

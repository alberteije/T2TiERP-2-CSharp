using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class EcfNotaFiscalCabecalhoDTO {
        public EcfNotaFiscalCabecalhoDTO() { }
        public int Id { get; set; }
        public string NomeCaixa { get; set; }
        public System.Nullable<int> IdGeradoCaixa { get; set; }
        public System.Nullable<int> IdEmpresa { get; set; }
        public System.Nullable<int> IdEcfFuncionario { get; set; }
        public System.Nullable<int> IdCliente { get; set; }
        public string CpfCnpjCliente { get; set; }
        public System.Nullable<int> Cfop { get; set; }
        public string Numero { get; set; }
        public System.Nullable<System.DateTime> DataEmissao { get; set; }
        public string HoraEmissao { get; set; }
        public string Serie { get; set; }
        public string Subserie { get; set; }
        public System.Nullable<decimal> TotalProdutos { get; set; }
        public System.Nullable<decimal> TotalNf { get; set; }
        public System.Nullable<decimal> BaseIcms { get; set; }
        public System.Nullable<decimal> Icms { get; set; }
        public System.Nullable<decimal> IcmsOutras { get; set; }
        public System.Nullable<decimal> Issqn { get; set; }
        public System.Nullable<decimal> Pis { get; set; }
        public System.Nullable<decimal> Cofins { get; set; }
        public System.Nullable<decimal> Ipi { get; set; }
        public System.Nullable<decimal> TaxaAcrescimo { get; set; }
        public System.Nullable<decimal> Acrescimo { get; set; }
        public System.Nullable<decimal> AcrescimoItens { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> Desconto { get; set; }
        public System.Nullable<decimal> DescontoItens { get; set; }
        public string Cancelada { get; set; }
        public string TipoNota { get; set; }
        public System.Nullable<System.DateTime> DataSincronizacao { get; set; }
        public string HoraSincronizacao { get; set; }
    }
}

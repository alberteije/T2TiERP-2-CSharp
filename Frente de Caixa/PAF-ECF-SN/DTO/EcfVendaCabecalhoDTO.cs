using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class EcfVendaCabecalhoDTO {
        public EcfVendaCabecalhoDTO() 
        {
            ListaEcfVendaDetalhe = new List<EcfVendaDetalheDTO>();
            ListaEcfTotalTipoPagamento = new List<EcfTotalTipoPagamentoDTO>();
        }
        public int Id { get; set; }
        public ClienteDTO Cliente { get; set; }
        public EcfFuncionarioDTO EcfFuncionario { get; set; }
        public EcfMovimentoDTO EcfMovimento { get; set; }
        public System.Nullable<int> IdEcfDav { get; set; }
        public System.Nullable<int> IdEcfPreVendaCabecalho { get; set; }
        public string SerieEcf { get; set; }
        public int Cfop { get; set; }
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

        public IList<EcfVendaDetalheDTO> ListaEcfVendaDetalhe { get; set; }
        public IList<EcfTotalTipoPagamentoDTO> ListaEcfTotalTipoPagamento { get; set; }
    }
}

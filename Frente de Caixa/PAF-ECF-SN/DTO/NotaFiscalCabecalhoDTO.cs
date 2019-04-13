using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class NotaFiscalCabecalhoDTO {
        public NotaFiscalCabecalhoDTO() { }
        public int Id { get; set; }
        public EcfFuncionarioDTO EcfFuncionario { get; set; }
        public ClienteDTO Cliente { get; set; }
        public string CpfCnpjCliente { get; set; }
        public int Cfop { get; set; }
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

        public IList<NotaFiscalDetalheDTO> ListaNotaFiscalDetalhe { get; set; }

    }
}

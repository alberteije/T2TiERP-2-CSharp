using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class DavCabecalhoDTO {
        public DavCabecalhoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string NumeroDav { get; set; }
        public string NumeroEcf { get; set; }
        public System.Nullable<int> Ccf { get; set; }
        public System.Nullable<int> Coo { get; set; }
        public string NomeDestinatario { get; set; }
        public string CpfCnpjDestinatario { get; set; }
        public System.Nullable<System.DateTime> DataEmissao { get; set; }
        public string HoraEmissao { get; set; }
        public string Situacao { get; set; }
        public System.Nullable<decimal> TaxaAcrescimo { get; set; }
        public System.Nullable<decimal> Acrescimo { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> Desconto { get; set; }
        public System.Nullable<decimal> Subtotal { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public string Impresso { get; set; }
        public string Logss { get; set; }

        public IList<DavDetalheDTO> ListaDavDetalhe { get; set; }
    }
}

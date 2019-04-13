using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class VendaComissaoDTO {
        public VendaComissaoDTO() { }
        public int Id { get; set; }
        public VendedorDTO Vendedor { get; set; }
        public VendaCabecalhoDTO VendaCabecalho { get; set; }
        public System.Nullable<decimal> ValorVenda { get; set; }
        public string TipoContabil { get; set; }
        public System.Nullable<decimal> ValorComissao { get; set; }
        public string Situacao { get; set; }
        public System.Nullable<System.DateTime> DataLancamento { get; set; }
    }
}

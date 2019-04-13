using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FolhaLancamentoComissaoDTO {
        public FolhaLancamentoComissaoDTO() { }
        public int Id { get; set; }
        public VendedorDTO Vendedor { get; set; }
        public string Competencia { get; set; }
        public System.Nullable<System.DateTime> Vencimento { get; set; }
        public System.Nullable<decimal> BaseCalculo { get; set; }
        public System.Nullable<decimal> ValorComissao { get; set; }
    }
}

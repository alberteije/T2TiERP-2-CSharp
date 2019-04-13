using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class EcfChequeClienteDTO {
        public EcfChequeClienteDTO() { }
        public int Id { get; set; }
        public BancoDTO Banco { get; set; }
        public ClienteDTO Cliente { get; set; }
        public System.Nullable<int> IdEcfMovimento { get; set; }
        public System.Nullable<int> NumeroCheque { get; set; }
        public System.Nullable<System.DateTime> DataCheque { get; set; }
        public System.Nullable<decimal> ValorCheque { get; set; }
        public string Observacoes { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string TipoCheque { get; set; }
    }
}

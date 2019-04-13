using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class EcfSuprimentoDTO {
        public EcfSuprimentoDTO() { }
        public int Id { get; set; }

        public int IdGeradoCaixa { get; set; }
        public string NomeCaixa { get; set; }
        public System.Nullable<System.DateTime> DataSincronizacao { get; set; }
        public string HoraSincronizacao { get; set; }

        public int IdEcfMovimento { get; set; }
        public System.Nullable<System.DateTime> DataSuprimento { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class R06DTO {
        public R06DTO() { }
        public int Id { get; set; }

        public int IdGeradoCaixa { get; set; }
        public string NomeCaixa { get; set; }
        public System.Nullable<System.DateTime> DataSincronizacao { get; set; }
        public string HoraSincronizacao { get; set; }

        public int IdOperador { get; set; }
        public int IdImpressora { get; set; }
        public System.Nullable<int> IdEcfCaixa { get; set; }
        public string SerieEcf { get; set; }
        public System.Nullable<int> Coo { get; set; }
        public System.Nullable<int> Gnf { get; set; }
        public System.Nullable<int> Grg { get; set; }
        public System.Nullable<int> Cdc { get; set; }
        public string Denominacao { get; set; }
        public System.Nullable<System.DateTime> DataEmissao { get; set; }
        public string HoraEmissao { get; set; }
        public string Logss { get; set; }

        public IList<R07DTO> ListaR07 { get; set; }
    }
}

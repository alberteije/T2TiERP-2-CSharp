using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class R02DTO {
        public R02DTO() { }
        public int Id { get; set; }

        public int IdGeradoCaixa { get; set; }
        public string NomeCaixa { get; set; }
        public System.Nullable<System.DateTime> DataSincronizacao { get; set; }
        public string HoraSincronizacao { get; set; }

        public int IdOperador { get; set; }
        public int IdImpressora { get; set; }
        public System.Nullable<int> IdEcfCaixa { get; set; }
        public string SerieEcf { get; set; }
        public System.Nullable<int> Crz { get; set; }
        public System.Nullable<int> Coo { get; set; }
        public System.Nullable<int> Cro { get; set; }
        public System.Nullable<System.DateTime> DataMovimento { get; set; }
        public System.Nullable<System.DateTime> DataEmissao { get; set; }
        public string HoraEmissao { get; set; }
        public System.Nullable<decimal> VendaBruta { get; set; }
        public System.Nullable<decimal> GrandeTotal { get; set; }
        public string Logss { get; set; }

        public IList<R03DTO> ListaR03 { get; set; }

    }
}

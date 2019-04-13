using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class R03DTO {
        public R03DTO() { }
        public int Id { get; set; }

        public int IdGeradoCaixa { get; set; }
        public string NomeCaixa { get; set; }
        public System.Nullable<System.DateTime> DataSincronizacao { get; set; }
        public string HoraSincronizacao { get; set; }

        public int IdR02 { get; set; }
        public string SerieEcf { get; set; }
        public string TotalizadorParcial { get; set; }
        public System.Nullable<decimal> ValorAcumulado { get; set; }
        public System.Nullable<int> Crz { get; set; }
        public string Logss { get; set; }
    }
}

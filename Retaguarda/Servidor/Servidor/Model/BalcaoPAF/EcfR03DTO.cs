using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class EcfR03DTO {
        public EcfR03DTO() { }
        public int Id { get; set; }
        public string NomeCaixa { get; set; }
        public System.Nullable<int> IdGeradoCaixa { get; set; }
        public System.Nullable<int> IdEmpresa { get; set; }
        public System.Nullable<int> IdR02 { get; set; }
        public string SerieEcf { get; set; }
        public string TotalizadorParcial { get; set; }
        public System.Nullable<decimal> ValorAcumulado { get; set; }
        public System.Nullable<int> Crz { get; set; }
        public string Logss { get; set; }
        public System.Nullable<System.DateTime> DataSincronizacao { get; set; }
        public string HoraSincronizacao { get; set; }
    }
}

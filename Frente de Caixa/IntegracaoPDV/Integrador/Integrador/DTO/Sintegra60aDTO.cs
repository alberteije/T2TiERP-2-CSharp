using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class Sintegra60aDTO {
        public Sintegra60aDTO() { }
        public int Id { get; set; }

        public int IdGeradoCaixa { get; set; }
        public string NomeCaixa { get; set; }
        public System.Nullable<System.DateTime> DataSincronizacao { get; set; }
        public string HoraSincronizacao { get; set; }

        public int IdSintegra60m { get; set; }
        public string SituacaoTributaria { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
    }
}

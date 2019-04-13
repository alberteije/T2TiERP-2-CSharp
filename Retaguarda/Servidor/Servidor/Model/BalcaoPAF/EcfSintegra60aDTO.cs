using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class EcfSintegra60aDTO {
        public EcfSintegra60aDTO() { }
        public int Id { get; set; }
        public string NomeCaixa { get; set; }
        public System.Nullable<int> IdGeradoCaixa { get; set; }
        public System.Nullable<int> IdEmpresa { get; set; }
        public System.Nullable<int> IdSintegra60M { get; set; }
        public string SituacaoTributaria { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public System.Nullable<System.DateTime> DataSincronizacao { get; set; }
        public string HoraSincronizacao { get; set; }
    }
}

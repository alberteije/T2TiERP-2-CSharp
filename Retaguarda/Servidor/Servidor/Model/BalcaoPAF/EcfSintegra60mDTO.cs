using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class EcfSintegra60mDTO {
        public EcfSintegra60mDTO() { }
        public int Id { get; set; }
        public string NomeCaixa { get; set; }
        public System.Nullable<int> IdGeradoCaixa { get; set; }
        public System.Nullable<int> IdEmpresa { get; set; }
        public System.Nullable<System.DateTime> DataEmissao { get; set; }
        public string NumeroSerieEcf { get; set; }
        public System.Nullable<int> NumeroEquipamento { get; set; }
        public string ModeloDocumentoFiscal { get; set; }
        public System.Nullable<int> CooInicial { get; set; }
        public System.Nullable<int> CooFinal { get; set; }
        public System.Nullable<int> Crz { get; set; }
        public System.Nullable<int> Cro { get; set; }
        public System.Nullable<decimal> ValorVendaBruta { get; set; }
        public System.Nullable<decimal> ValorGrandeTotal { get; set; }
        public System.Nullable<System.DateTime> DataSincronizacao { get; set; }
        public string HoraSincronizacao { get; set; }
    }
}

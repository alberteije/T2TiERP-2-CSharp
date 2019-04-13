using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class Sintegra60mDTO {
        public Sintegra60mDTO() { }
        public int Id { get; set; }
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

        public IList<Sintegra60aDTO> Lista60A { get; set; }
    }

}

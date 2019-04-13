using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ViewSintegra60dDTO {
        public ViewSintegra60dDTO() { }
        public int Id { get; set; }
        public string Gtin { get; set; }
        public string Serie { get; set; }
        public System.Nullable<System.DateTime> DataEmissao { get; set; }
        public int IdMovimento { get; set; }
        public string EcfIcmsSt { get; set; }
        public System.Nullable<decimal> SomaQuantidade { get; set; }
        public System.Nullable<decimal> SomaItem { get; set; }
        public System.Nullable<decimal> SomaBaseIcms { get; set; }
        public System.Nullable<decimal> SomaIcms { get; set; }
    }
}

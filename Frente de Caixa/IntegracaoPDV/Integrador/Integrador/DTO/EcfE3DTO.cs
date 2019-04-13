using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class EcfE3DTO {
        public EcfE3DTO() { }
        public int Id { get; set; }
        public string SerieEcf { get; set; }
        public string MfAdicional { get; set; }
        public string TipoEcf { get; set; }
        public string MarcaEcf { get; set; }
        public string ModeloEcf { get; set; }
        public System.Nullable<System.DateTime> DataEstoque { get; set; }
        public string HoraEstoque { get; set; }
        public string Logss { get; set; }
    }
}

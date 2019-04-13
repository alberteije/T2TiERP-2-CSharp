using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class SimplesNacionalCabecalhoDTO {
        public SimplesNacionalCabecalhoDTO() { }
        public int Id { get; set; }
        public System.Nullable<System.DateTime> VigenciaInicial { get; set; }
        public System.Nullable<System.DateTime> VigenciaFinal { get; set; }
        public string Anexo { get; set; }
        public string Tabela { get; set; }
    }
}

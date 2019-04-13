using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class LogImportacaoDTO {
        public LogImportacaoDTO() { }
        public int Id { get; set; }
        public System.Nullable<System.DateTime> DataImportacao { get; set; }
        public string HoraImportacao { get; set; }
        public string Erro { get; set; }
        public string Registro { get; set; }
    }
}

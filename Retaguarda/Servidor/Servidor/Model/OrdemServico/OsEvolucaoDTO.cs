using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class OsEvolucaoDTO {
        public OsEvolucaoDTO() { }
        public int Id { get; set; }

        public OsAberturaDTO OsAbertura { get; set; }

        public System.Nullable<System.DateTime> DataRegistro { get; set; }
        public string HoraRegistro { get; set; }
        public string Observacao { get; set; }
        public string EnviarEmail { get; set; }
    }
}

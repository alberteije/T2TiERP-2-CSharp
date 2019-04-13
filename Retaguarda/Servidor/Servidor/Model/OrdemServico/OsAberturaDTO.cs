using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class OsAberturaDTO {
        public OsAberturaDTO() { }
        public int Id { get; set; }

        public OsStatusDTO OsStatus { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public ClienteDTO Cliente { get; set; }

        public string Numero { get; set; }
        public System.Nullable<System.DateTime> DataInicio { get; set; }
        public string HoraInicio { get; set; }
        public System.Nullable<System.DateTime> DataPrevisao { get; set; }
        public string HoraPrevisao { get; set; }
        public System.Nullable<System.DateTime> DataFim { get; set; }
        public string HoraFim { get; set; }
        public string NomeContato { get; set; }
        public string FoneContato { get; set; }
        public string ObservacaoCliente { get; set; }
        public string ObservacaoAbertura { get; set; }

    }
}

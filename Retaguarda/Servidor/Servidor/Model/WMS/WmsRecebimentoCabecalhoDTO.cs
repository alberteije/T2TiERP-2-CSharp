using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class WmsRecebimentoCabecalhoDTO {
        public WmsRecebimentoCabecalhoDTO() { }
        public int Id { get; set; }

        public WmsAgendamentoDTO WmsAgendamento { get; set; }

        public System.Nullable<System.DateTime> DataRecebimento { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public System.Nullable<int> VolumeRecebido { get; set; }
        public System.Nullable<decimal> PesoRecebido { get; set; }
        public string Inconsistencia { get; set; }
        public string Observacao { get; set; }
    }
}

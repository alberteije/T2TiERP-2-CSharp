using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class WmsAgendamentoDTO {
        public WmsAgendamentoDTO() { }
        public int Id { get; set; }

        public EmpresaDTO Empresa { get; set; }

        public System.Nullable<System.DateTime> DataOperacao { get; set; }
        public string HoraOperacao { get; set; }
        public string LocalOperacao { get; set; }
        public System.Nullable<int> QuantidadeVolume { get; set; }
        public System.Nullable<decimal> PesoTotalVolume { get; set; }
        public System.Nullable<int> QuantidadePessoa { get; set; }
        public System.Nullable<int> QuantidadeHora { get; set; }
    }
}

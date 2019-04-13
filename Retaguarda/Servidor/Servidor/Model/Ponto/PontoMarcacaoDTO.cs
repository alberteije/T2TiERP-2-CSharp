using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PontoMarcacaoDTO {
        public PontoMarcacaoDTO() { }
        public int Id { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public PontoRelogioDTO PontoRelogio { get; set; }
        public System.Nullable<int> Nsr { get; set; }
        public System.Nullable<System.DateTime> DataMarcacao { get; set; }
        public string HoraMarcacao { get; set; }
        public string TipoMarcacao { get; set; }
        public string TipoRegistro { get; set; }
        public string ParEntradaSaida { get; set; }
        public string Justificativa { get; set; }
    }
}

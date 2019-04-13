using System;
using System.Text;
using System.Collections.Generic;


namespace PontoService.Model {
    
    public class ViewPontoMarcacaoDTO {
        public ViewPontoMarcacaoDTO() { }
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public System.Nullable<int> IdPontoRelogio { get; set; }
        public System.Nullable<int> Nsr { get; set; }
        public System.Nullable<System.DateTime> DataMarcacao { get; set; }
        public string HoraMarcacao { get; set; }
        public string TipoMarcacao { get; set; }
        public string TipoRegistro { get; set; }
        public string ParEntradaSaida { get; set; }
        public string Justificativa { get; set; }
        public string PisNumero { get; set; }
        public string PessoaNome { get; set; }
        public string NumeroSerie { get; set; }
    }
}

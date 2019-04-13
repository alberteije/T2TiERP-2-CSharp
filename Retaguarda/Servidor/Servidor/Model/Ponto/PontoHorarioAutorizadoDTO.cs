using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PontoHorarioAutorizadoDTO {
        public PontoHorarioAutorizadoDTO() { }
        public int Id { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public System.Nullable<System.DateTime> DataHorario { get; set; }
        public string Tipo { get; set; }
        public string CargaHoraria { get; set; }
        public string Entrada01 { get; set; }
        public string Saida01 { get; set; }
        public string Entrada02 { get; set; }
        public string Saida02 { get; set; }
        public string Entrada03 { get; set; }
        public string Saida03 { get; set; }
        public string Entrada04 { get; set; }
        public string Saida04 { get; set; }
        public string Entrada05 { get; set; }
        public string Saida05 { get; set; }
        public string HoraFechamentoDia { get; set; }
    }
}

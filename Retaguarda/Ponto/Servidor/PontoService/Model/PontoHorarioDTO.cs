using System;
using System.Text;
using System.Collections.Generic;


namespace PontoService.Model {
    
    public class PontoHorarioDTO {
        public PontoHorarioDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Tipo { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string TipoTrabalho { get; set; }
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
        public string HoraInicioJornada { get; set; }
        public string HoraFimJornada { get; set; }
    }
}

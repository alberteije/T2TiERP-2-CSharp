using System;
using System.Text;
using System.Collections.Generic;


namespace PontoService.Model {
    
    public class PontoFechamentoJornadaDTO {
        public PontoFechamentoJornadaDTO() { }
        public int Id { get; set; }
        public PontoClassificacaoJornadaDTO PontoClassificacaoJornada { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public System.Nullable<System.DateTime> DataFechamento { get; set; }
        public string DiaSemana { get; set; }
        public string CodigoHorario { get; set; }
        public string CargaHorariaEsperada { get; set; }
        public string CargaHorariaDiurna { get; set; }
        public string CargaHorariaNoturna { get; set; }
        public string CargaHorariaTotal { get; set; }
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
        public string HoraExtra01 { get; set; }
        public System.Nullable<decimal> PercentualHoraExtra01 { get; set; }
        public string ModalidadeHoraExtra01 { get; set; }
        public string HoraExtra02 { get; set; }
        public System.Nullable<decimal> PercentualHoraExtra02 { get; set; }
        public string ModalidadeHoraExtra02 { get; set; }
        public string HoraExtra03 { get; set; }
        public System.Nullable<decimal> PercentualHoraExtra03 { get; set; }
        public string ModalidadeHoraExtra03 { get; set; }
        public string HoraExtra04 { get; set; }
        public System.Nullable<decimal> PercentualHoraExtra04 { get; set; }
        public string ModalidadeHoraExtra04 { get; set; }
        public string FaltaAtraso { get; set; }
        public string Compensar { get; set; }
        public string BancoHoras { get; set; }
        public string Observacao { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace FolhaService.Model {
    
    public class FeriasPeriodoAquisitivoDTO {
        public FeriasPeriodoAquisitivoDTO() { }
        public int Id { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public System.Nullable<System.DateTime> DataInicio { get; set; }
        public System.Nullable<System.DateTime> DataFim { get; set; }
        public string Situacao { get; set; }
        public System.Nullable<System.DateTime> LimiteParaGozo { get; set; }
        public string DescontarFaltas { get; set; }
        public string DesconsiderarAfastamento { get; set; }
        public System.Nullable<int> AfastamentoPrevidencia { get; set; }
        public System.Nullable<int> AfastamentoSemRemun { get; set; }
        public System.Nullable<int> AfastamentoComRemun { get; set; }
        public System.Nullable<int> DiasDireito { get; set; }
        public System.Nullable<int> DiasGozados { get; set; }
        public System.Nullable<int> DiasFaltas { get; set; }
        public System.Nullable<int> DiasRestantes { get; set; }
    }
}

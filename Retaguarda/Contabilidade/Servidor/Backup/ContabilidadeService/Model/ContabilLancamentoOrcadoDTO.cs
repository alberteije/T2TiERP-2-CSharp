using System;
using System.Text;
using System.Collections.Generic;


namespace ContabilidadeService.Model {
    
    public class ContabilLancamentoOrcadoDTO {
        public ContabilLancamentoOrcadoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public ContabilContaDTO ContabilConta { get; set; }
        public string Ano { get; set; }
        public System.Nullable<decimal> Janeiro { get; set; }
        public System.Nullable<decimal> Fevereiro { get; set; }
        public System.Nullable<decimal> Marco { get; set; }
        public System.Nullable<decimal> Abril { get; set; }
        public System.Nullable<decimal> Maio { get; set; }
        public System.Nullable<decimal> Junho { get; set; }
        public System.Nullable<decimal> Julho { get; set; }
        public System.Nullable<decimal> Agosto { get; set; }
        public System.Nullable<decimal> Setembro { get; set; }
        public System.Nullable<decimal> Outubro { get; set; }
        public System.Nullable<decimal> Novembro { get; set; }
        public System.Nullable<decimal> Dezembro { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace ConciliacaoContabilService.Model {
    
    public class ContabilLancamentoDetalheDTO {
        public ContabilLancamentoDetalheDTO() { }
        public int Id { get; set; }
        public int? IdContabilLancamentoCabecalho { get; set; }
        public ContabilContaDTO ContabilConta { get; set; }
        public ContabilHistoricoDTO ContabilHistorico { get; set; }
        public string Historico { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public string Tipo { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace ContabilidadeService.Model {
    
    public class ContabilLancamentoCabecalhoDTO {
        public ContabilLancamentoCabecalhoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public ContabilLoteDTO ContabilLote { get; set; }
        public System.Nullable<System.DateTime> DataLancamento { get; set; }
        public System.Nullable<System.DateTime> DataInclusao { get; set; }
        public string Tipo { get; set; }
        public string Liberado { get; set; }
        public System.Nullable<decimal> Valor { get; set; }

        public IList<ContabilLancamentoDetalheDTO> ListaContabilLancamentoDetalhe { get; set; }
    }
}

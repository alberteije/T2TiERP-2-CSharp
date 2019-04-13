using System;
using System.Text;
using System.Collections.Generic;


namespace ContabilidadeService.Model {
    
    public class ContabilFechamentoDTO {
        public ContabilFechamentoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public System.Nullable<System.DateTime> DataInicio { get; set; }
        public System.Nullable<System.DateTime> DataFim { get; set; }
        public string CriterioLancamento { get; set; }
    }
}

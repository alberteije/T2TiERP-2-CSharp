using System;
using System.Text;
using System.Collections.Generic;


namespace ContabilidadeService.Model {
    
    public class ContabilEncerramentoExeCabDTO {
        public ContabilEncerramentoExeCabDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public System.Nullable<System.DateTime> DataInicio { get; set; }
        public System.Nullable<System.DateTime> DataFim { get; set; }
        public System.Nullable<System.DateTime> DataInclusao { get; set; }
        public string Motivo { get; set; }

        public IList<ContabilEncerramentoExeDetDTO> ListaContabilEncerramentoExeDet { get; set; }
    }
}

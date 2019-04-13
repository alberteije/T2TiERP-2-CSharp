using System;
using System.Text;
using System.Collections.Generic;


namespace ContabilidadeService.Model {
    
    public class AidfAimdfDTO {
        public AidfAimdfDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public System.Nullable<int> Numero { get; set; }
        public System.Nullable<System.DateTime> DataValidade { get; set; }
        public System.Nullable<System.DateTime> DataAutorizacao { get; set; }
        public string NumeroAutorizacao { get; set; }
        public string FormularioDisponivel { get; set; }
    }
}

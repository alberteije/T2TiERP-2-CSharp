using System;
using System.Text;
using System.Collections.Generic;


namespace ContabilidadeService.Model {
    
    public class FapDTO {
        public FapDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public System.Nullable<decimal> Fap { get; set; }
        public System.Nullable<System.DateTime> DataInicial { get; set; }
        public System.Nullable<System.DateTime> DataFinal { get; set; }
    }
}

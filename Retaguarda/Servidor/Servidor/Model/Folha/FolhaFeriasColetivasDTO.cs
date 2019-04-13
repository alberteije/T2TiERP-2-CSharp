using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FolhaFeriasColetivasDTO {
        public FolhaFeriasColetivasDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public System.Nullable<System.DateTime> DataInicio { get; set; }
        public System.Nullable<System.DateTime> DataFim { get; set; }
        public System.Nullable<int> DiasGozo { get; set; }
        public System.Nullable<System.DateTime> AbonoPecuniarioInicio { get; set; }
        public System.Nullable<System.DateTime> AbonoPecuniarioFim { get; set; }
        public System.Nullable<int> DiasAbono { get; set; }
        public System.Nullable<System.DateTime> DataPagamento { get; set; }
    }
}

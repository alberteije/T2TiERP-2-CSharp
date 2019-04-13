using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ContabilLancamentoPadraoDTO {
        public ContabilLancamentoPadraoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Descricao { get; set; }
        public string Historico { get; set; }
        public System.Nullable<int> IdContaDebito { get; set; }
        public System.Nullable<int> IdContaCredito { get; set; }
    }
}

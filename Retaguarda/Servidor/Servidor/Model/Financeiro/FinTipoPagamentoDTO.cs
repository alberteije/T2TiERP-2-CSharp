using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FinTipoPagamentoDTO {
        public FinTipoPagamentoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
    }
}

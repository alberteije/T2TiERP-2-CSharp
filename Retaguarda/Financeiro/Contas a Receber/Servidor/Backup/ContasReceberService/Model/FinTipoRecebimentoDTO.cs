using System;
using System.Text;
using System.Collections.Generic;


namespace ContasReceberService.Model {
    
    public class FinTipoRecebimentoDTO {
        public FinTipoRecebimentoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
    }
}

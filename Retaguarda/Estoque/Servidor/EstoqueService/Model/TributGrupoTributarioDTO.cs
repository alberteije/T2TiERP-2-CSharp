using System;
using System.Text;
using System.Collections.Generic;


namespace EstoqueService.Model {
    
    public class TributGrupoTributarioDTO {
        public TributGrupoTributarioDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Descricao { get; set; }
        public string OrigemMercadoria { get; set; }
        public string Observacao { get; set; }
    }
}

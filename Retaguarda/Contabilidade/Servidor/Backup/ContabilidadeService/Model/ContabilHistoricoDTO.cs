using System;
using System.Text;
using System.Collections.Generic;


namespace ContabilidadeService.Model {
    
    public class ContabilHistoricoDTO {
        public ContabilHistoricoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Descricao { get; set; }
        public string Historico { get; set; }
        public string PedeComplemento { get; set; }
    }
}

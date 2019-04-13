using System;
using System.Text;
using System.Collections.Generic;


namespace ContabilidadeService.Model {
    
    public class ContabilLivroDTO {
        public ContabilLivroDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Descricao { get; set; }
        public string Competencia { get; set; }
        public string FormaEscrituracao { get; set; }

        public IList<ContabilTermoDTO> ListaContabilTermo { get; set; }
    }
}

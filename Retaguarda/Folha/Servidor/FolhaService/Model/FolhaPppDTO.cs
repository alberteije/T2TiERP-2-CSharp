using System;
using System.Text;
using System.Collections.Generic;


namespace FolhaService.Model {
    
    public class FolhaPppDTO {
        public FolhaPppDTO() { }
        public int Id { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public string Observacao { get; set; }

        public IList<FolhaPppCatDTO> ListaFolhaPppCat { get; set; }
        public IList<FolhaPppAtividadeDTO> ListaFolhaPppAtividade { get; set; }
        public IList<FolhaPppFatorRiscoDTO> ListaFolhaPppFatorRisco { get; set; }
        public IList<FolhaPppExameMedicoDTO> ListaFolhaPppExameMedico { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FolhaLancamentoCabecalhoDTO {
        public FolhaLancamentoCabecalhoDTO() { }
        public int Id { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public string Competencia { get; set; }
        public string Tipo { get; set; }
    }
}

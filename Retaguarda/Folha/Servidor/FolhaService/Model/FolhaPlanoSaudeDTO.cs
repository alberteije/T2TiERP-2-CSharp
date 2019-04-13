using System;
using System.Text;
using System.Collections.Generic;


namespace FolhaService.Model {
    
    public class FolhaPlanoSaudeDTO {
        public FolhaPlanoSaudeDTO() { }
        public int Id { get; set; }
        public OperadoraPlanoSaudeDTO OperadoraPlanoSaude { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public System.Nullable<System.DateTime> DataInicio { get; set; }
        public string Beneficiario { get; set; }
    }
}

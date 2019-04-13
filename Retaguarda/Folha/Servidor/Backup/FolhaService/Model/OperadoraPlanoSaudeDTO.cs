using System;
using System.Text;
using System.Collections.Generic;


namespace FolhaService.Model {
    
    public class OperadoraPlanoSaudeDTO {
        public OperadoraPlanoSaudeDTO() { }
        public int Id { get; set; }
        public ContabilContaDTO ContabilConta { get; set; }
        public string RegistroAns { get; set; }
        public string Nome { get; set; }
    }
}

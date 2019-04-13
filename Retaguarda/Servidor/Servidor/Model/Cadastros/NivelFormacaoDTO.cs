using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NivelFormacaoDTO {
        public NivelFormacaoDTO() { }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public System.Nullable<int> GrauInstrucaoCaged { get; set; }
        public System.Nullable<int> GrauInstrucaoSefip { get; set; }
        public System.Nullable<int> GrauInstrucaoRais { get; set; }
    }
}

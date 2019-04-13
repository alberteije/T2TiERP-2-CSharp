using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class TransportadoraDTO {
        public TransportadoraDTO() { }
        public int Id { get; set; }
        public PessoaDTO Pessoa { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
        public string Observacao { get; set; }
    }
}

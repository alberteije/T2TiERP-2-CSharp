using System;
using System.Text;
using System.Collections.Generic;


namespace ConciliacaoContabilService.Model {
    
    public class AgenciaBancoDTO {
        public AgenciaBancoDTO() { }
        public int Id { get; set; }
        public BancoDTO Banco { get; set; }
        public string Codigo { get; set; }
        public string Digito { get; set; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Uf { get; set; }
        public string Telefone { get; set; }
        public string Gerente { get; set; }
        public string Contato { get; set; }
        public string Observacao { get; set; }
    }
}

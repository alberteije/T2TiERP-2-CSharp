using System;
using System.Text;
using System.Collections.Generic;


namespace ContratosService.Model {
    
    public class EnderecoDTO {
        public EnderecoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public int? IdPessoa { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public System.Nullable<int> MunicipioIbge { get; set; }
        public string Uf { get; set; }
        public string Fone { get; set; }
        public string Fax { get; set; }
        public string Principal { get; set; }
        public string Entrega { get; set; }
        public string Cobranca { get; set; }
        public string Correspondencia { get; set; }
    }
}

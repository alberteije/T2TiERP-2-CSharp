using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class ClienteDTO {
        public ClienteDTO() { }
        public int Id { get; set; }
        public SituacaoClienteDTO SituacaoCliente { get; set; }
        public string Nome { get; set; }
        public string Fantasia { get; set; }
        public string Email { get; set; }
        public string CpfCnpj { get; set; }
        public string Rg { get; set; }
        public string OrgaoRg { get; set; }
        public System.Nullable<System.DateTime> DataEmissaoRg { get; set; }
        public string Sexo { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string TipoPessoa { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Celular { get; set; }
        public string Contato { get; set; }
        public System.Nullable<int> CodigoIbgeCidade { get; set; }
        public System.Nullable<int> CodigoIbgeUf { get; set; }
    }
}

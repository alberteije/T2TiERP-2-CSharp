using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class ViewNfceClienteDTO {
        public ViewNfceClienteDTO() { }
        public int Id { get; set; }
        public System.Nullable<int> IdOperacaoFiscal { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string OrgaoRg { get; set; }
        public System.Nullable<System.DateTime> DataEmissaoRg { get; set; }
        public string Sexo { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
        public int IdPessoa { get; set; }
        public int IdAtividadeForCli { get; set; }
        public int IdSituacaoForCli { get; set; }
        public System.Nullable<System.DateTime> Desde { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public System.Nullable<int> MunicipioIbge { get; set; }
        public string Uf { get; set; }
        public string Fone { get; set; }
    }
}

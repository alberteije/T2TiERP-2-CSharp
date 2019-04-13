using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class EcfContadorDTO {
        public EcfContadorDTO() { }
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string InscricaoCrc { get; set; }
        public string Fone { get; set; }
        public string Fax { get; set; }
        public string Logradouro { get; set; }
        public System.Nullable<int> Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public System.Nullable<int> CodigoMunicipio { get; set; }
        public string Uf { get; set; }
        public string Email { get; set; }
    }
}

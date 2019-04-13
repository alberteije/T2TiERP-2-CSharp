using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class EcfEmpresaDTO {
        public EcfEmpresaDTO() { }
        public int Id { get; set; }
        public System.Nullable<int> IdEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoEstadualSt { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string InscricaoJuntaComercial { get; set; }
        public System.Nullable<System.DateTime> DataInscJuntaComercial { get; set; }
        public string MatrizFilial { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
        public System.Nullable<System.DateTime> DataInicioAtividades { get; set; }
        public string Suframa { get; set; }
        public string Email { get; set; }
        public string ImagemLogotipo { get; set; }
        public string Crt { get; set; }
        public string TipoRegime { get; set; }
        public System.Nullable<decimal> AliquotaPis { get; set; }
        public System.Nullable<decimal> AliquotaCofins { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Fone { get; set; }
        public string Fax { get; set; }
        public string Contato { get; set; }
        public System.Nullable<int> CodigoIbgeCidade { get; set; }
        public System.Nullable<int> CodigoIbgeUf { get; set; }
    }
}

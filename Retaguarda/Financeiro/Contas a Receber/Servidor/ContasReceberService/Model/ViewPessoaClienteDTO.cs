using System;
using System.Text;
using System.Collections.Generic;


namespace ContasReceberService.Model {
    
    public class ViewPessoaClienteDTO {
        public ViewPessoaClienteDTO() { }
        public int Id { get; set; }
        public System.Nullable<int> IdOperacaoFiscal { get; set; }
        public int IdPessoa { get; set; }
        public int IdAtividadeForCli { get; set; }
        public int IdSituacaoForCli { get; set; }
        public System.Nullable<System.DateTime> Desde { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
        public string Observacao { get; set; }
        public string ContaTomador { get; set; }
        public string GeraFinanceiro { get; set; }
        public string IndicadorPreco { get; set; }
        public System.Nullable<decimal> PorcentoDesconto { get; set; }
        public string FormaDesconto { get; set; }
        public System.Nullable<decimal> LimiteCredito { get; set; }
        public string TipoFrete { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public System.Nullable<int> MunicipioIbge { get; set; }
        public string Uf { get; set; }
        public string Fone { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public string CpfCnpj { get; set; }
        public string RgIe { get; set; }
    }
}

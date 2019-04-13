using System;
using System.Text;
using System.Collections.Generic;


namespace AdministrativoService.Model {
    
    public class ViewPessoaFornecedorDTO {
        public ViewPessoaFornecedorDTO() { }
        public int Id { get; set; }
        public System.Nullable<int> IdContabilConta { get; set; }
        public int IdPessoa { get; set; }
        public int IdAtividadeForCli { get; set; }
        public int IdSituacaoForCli { get; set; }
        public System.Nullable<System.DateTime> Desde { get; set; }
        public string OptanteSimplesNacional { get; set; }
        public string Localizacao { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
        public string SofreRetencao { get; set; }
        public string ChequeNominalA { get; set; }
        public string Observacao { get; set; }
        public string ContaRemetente { get; set; }
        public System.Nullable<int> PrazoMedioEntrega { get; set; }
        public string GeraFaturamento { get; set; }
        public System.Nullable<int> NumDiasPrimeiroVencimento { get; set; }
        public System.Nullable<int> NumDiasIntervalo { get; set; }
        public System.Nullable<int> QuantidadeParcelas { get; set; }
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
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public string CpfCnpj { get; set; }
    }
}

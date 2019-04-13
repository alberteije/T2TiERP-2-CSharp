using System;
using System.Text;
using System.Collections.Generic;


namespace ContratosService.Model {
    
    public class PessoaFisicaDTO {
        public PessoaFisicaDTO() { }
        public int Id { get; set; }
        public PessoaDTO Pessoa { get; set; }
        public EstadoCivilDTO EstadoCivil { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string OrgaoRg { get; set; }
        public System.Nullable<System.DateTime> DataEmissaoRg { get; set; }
        public System.Nullable<System.DateTime> DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Naturalidade { get; set; }
        public string Nacionalidade { get; set; }
        public string Raca { get; set; }
        public string TipoSangue { get; set; }
        public string CnhNumero { get; set; }
        public string CnhCategoria { get; set; }
        public System.Nullable<System.DateTime> CnhVencimento { get; set; }
        public string TituloEleitoralNumero { get; set; }
        public System.Nullable<int> TituloEleitoralZona { get; set; }
        public System.Nullable<int> TituloEleitoralSecao { get; set; }
        public string ReservistaNumero { get; set; }
        public System.Nullable<int> ReservistaCategoria { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
    }
}

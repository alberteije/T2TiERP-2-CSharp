using System;
using System.Text;
using System.Collections.Generic;


namespace PatrimonioService.Model {
    
    public class ColaboradorDTO {
        public ColaboradorDTO() {
        }
        public int Id { get; set; }
        public PessoaDTO Pessoa { get; set; }
        public string Matricula { get; set; }
        public string Foto34 { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
        public System.Nullable<System.DateTime> DataAdmissao { get; set; }
        public System.Nullable<System.DateTime> VencimentoFerias { get; set; }
        public System.Nullable<System.DateTime> DataTransferencia { get; set; }
        public string FgtsOptante { get; set; }
        public System.Nullable<System.DateTime> FgtsDataOpcao { get; set; }
        public System.Nullable<int> FgtsConta { get; set; }
        public string PagamentoForma { get; set; }
        public string PagamentoBanco { get; set; }
        public System.Nullable<int> PagamentoAgencia { get; set; }
        public System.Nullable<int> PagamentoAgenciaDigito { get; set; }
        public System.Nullable<int> PagamentoConta { get; set; }
        public System.Nullable<int> PagamentoContaDigito { get; set; }
        public System.Nullable<System.DateTime> ExameMedicoUltimo { get; set; }
        public System.Nullable<System.DateTime> ExameMedicoVencimento { get; set; }
        public System.Nullable<System.DateTime> PisDataCadastro { get; set; }
        public string PisNumero { get; set; }
        public string PisBanco { get; set; }
        public System.Nullable<int> PisAgencia { get; set; }
        public System.Nullable<int> PisAgenciaDigito { get; set; }
        public string CtpsNumero { get; set; }
        public string CtpsSerie { get; set; }
        public System.Nullable<System.DateTime> CtpsDataExpedicao { get; set; }
        public string CtpsUf { get; set; }
        public string DescontoPlanoSaude { get; set; }
        public string SaiNaRais { get; set; }
        public string CategoriaSefip { get; set; }
        public string Observacao { get; set; }
        public System.Nullable<int> OcorrenciaSefip { get; set; }
        public System.Nullable<int> CodigoAdmissaoCaged { get; set; }
        public System.Nullable<int> CodigoDemissaoCaged { get; set; }
        public System.Nullable<int> CodigoDemissaoSefip { get; set; }
        public System.Nullable<System.DateTime> DataDemissao { get; set; }
        public string CodigoTurmaPonto { get; set; }
    }
}

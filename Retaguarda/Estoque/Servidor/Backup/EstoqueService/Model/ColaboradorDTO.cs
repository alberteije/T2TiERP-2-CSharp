using System.Collections.Generic; 
using System.Text; 
using System; 


namespace EstoqueService.Model {
    
    public class ColaboradorDTO {
        public ColaboradorDTO() {
        }
        public virtual int? id { get; set; }
        public virtual PessoaDTO pessoa { get; set; }
        public virtual string matricula { get; set; }
        public virtual string foto34 { get; set; }
        public virtual DateTime? dataCadastro { get; set; }
        public virtual DateTime? dataAdmissao { get; set; }
        public virtual DateTime? vencimentoFerias { get; set; }
        public virtual DateTime? dataTransferencia { get; set; }
        public virtual string fgtsOptante { get; set; }
        public virtual DateTime? fgtsDataOpcao { get; set; }
        public virtual int? fgtsConta { get; set; }
        public virtual string pagamentoForma { get; set; }
        public virtual string pagamentoBanco { get; set; }
        public virtual string pagamentoAgencia { get; set; }
        public virtual string pagamentoAgenciaDigito { get; set; }
        public virtual string pagamentoConta { get; set; }
        public virtual string pagamentoContaDigito { get; set; }
        public virtual DateTime? exameMedicoUltimo { get; set; }
        public virtual DateTime? exameMedicoVencimento { get; set; }
        public virtual DateTime? pisDataCadastro { get; set; }
        public virtual string pisNumero { get; set; }
        public virtual string pisBanco { get; set; }
        public virtual string pisAgencia { get; set; }
        public virtual string pisAgenciaDigito { get; set; }
        public virtual string ctpsNumero { get; set; }
        public virtual string ctpsSerie { get; set; }
        public virtual DateTime? ctpsDataExpedicao { get; set; }
        public virtual string ctpsUf { get; set; }
        public virtual string descontoPlanoSaude { get; set; }
        public virtual string saiNaRais { get; set; }
        public virtual string categoriaSefip { get; set; }
        public virtual string observacao { get; set; }
        public virtual int? ocorrenciaSefip { get; set; }
        public virtual int? codigoAdmissaoCaged { get; set; }
        public virtual int? codigoDemissaoCaged { get; set; }
        public virtual int? codigoDemissaoSefip { get; set; }
        public virtual DateTime? dataDemissao { get; set; }
        public virtual string codigoTurmaPonto { get; set; }
        public string nome {
            get {
                if (pessoa == null)
                    pessoa = new PessoaDTO();
                return pessoa.Nome;
            }
            set {
                if (pessoa == null)
                    pessoa = new PessoaDTO();

                pessoa.Nome = value; }
        }
    }
}

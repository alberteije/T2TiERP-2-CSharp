using System;
using System.Text;
using System.Collections.Generic;


namespace VendasService.Model {
    
    public class ClienteDTO {
        public ClienteDTO() {
        }
        public int Id { get; set; }
        public PessoaDTO Pessoa { get; set; }
        public AtividadeForCliDTO AtividadeForCli { get; set; }
        public SituacaoForCliDTO SituacaoForCli { get; set; }
        public System.Nullable<System.DateTime> Desde { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
        public string Observacao { get; set; }
        public string ContaTomador { get; set; }
        public string GeraFinanceiro { get; set; }
        public string IndicadorPreco { get; set; }
        public string PorcentoDesconto { get; set; }
        public string FormaDesconto { get; set; }
        public string LimiteCredito { get; set; }
        public string TipoFrete { get; set; }
    }
}

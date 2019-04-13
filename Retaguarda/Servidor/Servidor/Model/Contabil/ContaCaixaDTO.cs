using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ContaCaixaDTO {
        public ContaCaixaDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public AgenciaBancoDTO AgenciaBanco { get; set; }
        public string Codigo { get; set; }
        public string Digito { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public System.Nullable<decimal> LimiteCredito { get; set; }
        public string ClassificacaoContabilConta { get; set; }
    }
}

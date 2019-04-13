using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NaturezaFinanceiraDTO {
        public NaturezaFinanceiraDTO() { }
        public int Id { get; set; }
        public PlanoNaturezaFinanceiraDTO PlanoNaturezaFinanceira { get; set; }
        public ContabilContaDTO ContabilConta { get; set; }
        public string Classificacao { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string Aplicacao { get; set; }
        public string ApareceAPagar { get; set; }
        public string ApareceAReceber { get; set; }
    }
}

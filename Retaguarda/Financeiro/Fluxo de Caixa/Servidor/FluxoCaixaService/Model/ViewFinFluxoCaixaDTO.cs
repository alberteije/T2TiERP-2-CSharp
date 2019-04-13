using System;
using System.Text;
using System.Collections.Generic;


namespace FluxoCaixaService.Model {
    
    public class ViewFinFluxoCaixaDTO {
        public ViewFinFluxoCaixaDTO() { }
        public int Id { get; set; }
        public int IdContaCaixa { get; set; }
        public string NomeContaCaixa { get; set; }
        public string NomePessoa { get; set; }
        public System.Nullable<System.DateTime> DataLancamento { get; set; }
        public System.Nullable<System.DateTime> DataVencimento { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public string CodigoSituacao { get; set; }
        public string DescricaoSituacao { get; set; }
        public string Operacao { get; set; }
    }
}

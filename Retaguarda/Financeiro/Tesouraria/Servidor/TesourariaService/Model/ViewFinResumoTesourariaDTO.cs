using System;
using System.Text;
using System.Collections.Generic;


namespace TesourariaService.Model {
    
    public class ViewFinResumoTesourariaDTO {
        public ViewFinResumoTesourariaDTO() { }
        public System.Nullable<long> Id { get; set; }
        public int IdContaCaixa { get; set; }
        public string NomeContaCaixa { get; set; }
        public string NomePessoa { get; set; }
        public System.Nullable<System.DateTime> DataLancamento { get; set; }
        public System.Nullable<System.DateTime> DataPagoRecebido { get; set; }
        public string Historico { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public string DescricaoDocumentoOrigem { get; set; }
        public string Operacao { get; set; }

        public FechamentoCaixaBancoDTO fechamento { get; set; }
    }
}

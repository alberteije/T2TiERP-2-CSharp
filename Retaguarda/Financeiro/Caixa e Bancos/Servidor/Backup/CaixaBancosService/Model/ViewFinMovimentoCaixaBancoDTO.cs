using System;
using System.Text;
using System.Collections.Generic;


namespace CaixaBancosService.Model {
    
    public class ViewFinMovimentoCaixaBancoDTO {
        public ViewFinMovimentoCaixaBancoDTO() { }
        public int Id { get; set; }
        public int IdContaCaixa { get; set; }
        public string NomeContaCaixa { get; set; }
        public string NomePessoa { get; set; }
        public System.Nullable<System.DateTime> DataLancamento { get; set; }
        public System.Nullable<System.DateTime> DataPagoRecebido { get; set; }
        public string Historico { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public string DescricaoDocumentoOrigem { get; set; }
        public string Operacao { get; set; }
    }
}

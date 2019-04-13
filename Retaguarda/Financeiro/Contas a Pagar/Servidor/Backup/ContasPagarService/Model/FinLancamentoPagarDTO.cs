using System;
using System.Text;
using System.Collections.Generic;


namespace ContasPagarService.Model {
    
    public class FinLancamentoPagarDTO {
        public FinLancamentoPagarDTO() { }
        public int Id { get; set; }
        public FinDocumentoOrigemDTO FinDocumentoOrigem { get; set; }
        public ViewPessoaFornecedorDTO Fornecedor { get; set; }
        public string PagamentoCompartilhado { get; set; }
        public System.Nullable<int> QuantidadeParcela { get; set; }
        public System.Nullable<decimal> ValorTotal { get; set; }
        public System.Nullable<decimal> ValorAPagar { get; set; }
        public System.Nullable<System.DateTime> DataLancamento { get; set; }
        public string NumeroDocumento { get; set; }
        public string ImagemDocumento { get; set; }
        public System.Nullable<System.DateTime> PrimeiroVencimento { get; set; }
        public string CodigoModuloLcto { get; set; }
        public System.Nullable<int> IntervaloEntreParcelas { get; set; }

        public IList<FinParcelaPagarDTO> ListaFinParcelaPagar { get; set; }
        public IList<FinLctoPagarNtFinanceiraDTO> ListaNaturezaFinanceira { get; set; }

    }
}

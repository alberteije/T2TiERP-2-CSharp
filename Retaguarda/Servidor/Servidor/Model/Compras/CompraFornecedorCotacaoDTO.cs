using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class CompraFornecedorCotacaoDTO {
        public CompraFornecedorCotacaoDTO() { }
        public int Id { get; set; }
        public CompraCotacaoDTO CompraCotacao { get; set; }
        public FornecedorDTO Fornecedor { get; set; }
        public string PrazoEntrega { get; set; }
        public string CondicoesPagamento { get; set; }
        public System.Nullable<decimal> ValorSubtotal { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<decimal> Total { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace ComprasService.Model {
    
    public class CompraFornecedorCotacaoDTO {
        public CompraFornecedorCotacaoDTO() { }
        public int Id { get; set; }
        public int IdCompraCotacao { get; set; }
        public ViewPessoaFornecedorDTO Fornecedor { get; set; }
        public string PrazoEntrega { get; set; }
        public string VendaCondicoesPagamento { get; set; }
        public System.Nullable<decimal> ValorSubtotal { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<decimal> Total { get; set; }

        public IList<CompraCotacaoDetalheDTO> listaCotacaoCompraDetalhe { get; set; }
    }
}

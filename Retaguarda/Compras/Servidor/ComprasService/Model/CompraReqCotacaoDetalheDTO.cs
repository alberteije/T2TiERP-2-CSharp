using System;
using System.Text;
using System.Collections.Generic;


namespace ComprasService.Model {
    
    public class CompraReqCotacaoDetalheDTO {
        public CompraReqCotacaoDetalheDTO() { }
        public int Id { get; set; }
        public CompraCotacaoDTO CompraCotacao { get; set; }
        public CompraRequisicaoDetalheDTO CompraRequisicaoDetalhe { get; set; }
        public System.Nullable<decimal> QuantidadeCotada { get; set; }
    }
}

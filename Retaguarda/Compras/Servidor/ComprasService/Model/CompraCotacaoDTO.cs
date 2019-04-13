using System;
using System.Text;
using System.Collections.Generic;


namespace ComprasService.Model {
    
    public class CompraCotacaoDTO {
        public CompraCotacaoDTO() { }
        public int Id { get; set; }
        public System.Nullable<System.DateTime> DataCotacao { get; set; }
        public string Descricao { get; set; }
        public string Situacao { get; set; }

        public IList<CompraFornecedorCotacaoDTO> listaFornecedor { get; set; }
        public IList<CompraCotacaoDetalheDTO> listaCotacaoDetalhe { get; set; }

    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class WmsOrdemSeparacaoDetDTO {
        public WmsOrdemSeparacaoDetDTO() { }
        public int Id { get; set; }

        public WmsOrdemSeparacaoCabDTO WmsOrdemSeparacaoCab { get; set; }
        public ProdutoDTO Produto { get; set; }

        public System.Nullable<int> Quantidade { get; set; }
    }
}

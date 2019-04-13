using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class WmsRecebimentoDetalheDTO {
        public WmsRecebimentoDetalheDTO() { }
        public int Id { get; set; }
        
        public ProdutoDTO Produto { get; set; }
        public WmsRecebimentoCabecalhoDTO WmsRecebimentoCabecalho { get; set; }

        public System.Nullable<int> QuantidadeVolume { get; set; }
        public System.Nullable<int> QuantidadeItemPorVolume { get; set; }
        public System.Nullable<int> QuantidadeRecebida { get; set; }
        public string Destino { get; set; }
    }
}

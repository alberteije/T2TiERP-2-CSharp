using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PcpOpDetalheDTO {
        public PcpOpDetalheDTO() { }
        public int Id { get; set; }
        public ProdutoDTO Produto { get; set; }
        public PcpOpCabecalhoDTO PcpOpCabecalho { get; set; }
        public System.Nullable<decimal> QuantidadeProduzir { get; set; }
        public System.Nullable<decimal> QuantidadeProduzida { get; set; }
        public System.Nullable<decimal> QuantidadeEntregue { get; set; }
        public System.Nullable<decimal> CustoPrevisto { get; set; }
        public System.Nullable<decimal> CustoRealizado { get; set; }
    }
}

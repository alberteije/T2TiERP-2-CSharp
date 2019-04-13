using System;
using System.Text;
using System.Collections.Generic;


namespace EstoqueService.Model {
    
    public class NFeFaturaDTO {
        public NFeFaturaDTO() { }
        public int id { get; set; }
        public int idNFeCabecalho { get; set; }
        public string numero { get; set; }
        public System.Nullable<decimal> valorOriginal { get; set; }
        public System.Nullable<decimal> valorDesconto { get; set; }
        public System.Nullable<decimal> valorLiquido { get; set; }
    }
}

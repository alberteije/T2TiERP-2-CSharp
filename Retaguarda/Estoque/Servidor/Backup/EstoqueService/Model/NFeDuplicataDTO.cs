using System;
using System.Text;
using System.Collections.Generic;


namespace EstoqueService.Model {
    
    public class NFeDuplicataDTO {
        public NFeDuplicataDTO() { }
        public int id { get; set; }
        public int idNFeCabecalho { get; set; }
        public string numero { get; set; }
        public System.Nullable<System.DateTime> dataVencimento { get; set; }
        public System.Nullable<decimal> valor { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace EstoqueService.Model {
    
    public class NFeCupomFiscalDTO {
        public NFeCupomFiscalDTO() { }
        public int id { get; set; }
        public int idNFeCabecalho { get; set; }
        public string modeloDocumentoFiscal { get; set; }
        public System.Nullable<int> numeroOrdemEcf { get; set; }
        public System.Nullable<int> coo { get; set; }
        public System.Nullable<System.DateTime> dataEmissaoCupom { get; set; }
        public System.Nullable<int> numeroCaixa { get; set; }
        public string numeroSerieEcf { get; set; }
    }
}

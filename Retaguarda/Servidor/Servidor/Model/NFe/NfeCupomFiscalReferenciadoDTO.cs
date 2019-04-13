using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeCupomFiscalReferenciadoDTO {
        public NfeCupomFiscalReferenciadoDTO() { }
        public int Id { get; set; }
        public int IdNfeCabecalho { get; set; }
        public string ModeloDocumentoFiscal { get; set; }
        public System.Nullable<int> NumeroOrdemEcf { get; set; }
        public System.Nullable<int> Coo { get; set; }
        public System.Nullable<System.DateTime> DataEmissaoCupom { get; set; }
        public System.Nullable<int> NumeroCaixa { get; set; }
        public string NumeroSerieEcf { get; set; }
    }
}

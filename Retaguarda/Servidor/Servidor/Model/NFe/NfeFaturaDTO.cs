using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeFaturaDTO {
        public NfeFaturaDTO() { }
        public int Id { get; set; }
        public int IdNfeCabecalho { get; set; }
        public string Numero { get; set; }
        public System.Nullable<decimal> ValorOriginal { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<decimal> ValorLiquido { get; set; }
    }
}

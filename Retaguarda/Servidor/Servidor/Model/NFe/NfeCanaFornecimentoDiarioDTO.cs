using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeCanaFornecimentoDiarioDTO {
        public NfeCanaFornecimentoDiarioDTO() { }
        public int Id { get; set; }
        public NfeCanaDTO NfeCana { get; set; }
        public string Dia { get; set; }
        public System.Nullable<decimal> Quantidade { get; set; }
        public System.Nullable<decimal> QuantidadeTotalMes { get; set; }
        public System.Nullable<decimal> QuantidadeTotalAnterior { get; set; }
        public System.Nullable<decimal> QuantidadeTotalGeral { get; set; }
    }
}

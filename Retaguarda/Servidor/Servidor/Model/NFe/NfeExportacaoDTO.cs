using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeExportacaoDTO {
        public NfeExportacaoDTO() { }
        public int Id { get; set; }
        public int IdNfeDetalhe { get; set; }
        public System.Nullable<int> Drawback { get; set; }
        public System.Nullable<int> NumeroRegistro { get; set; }
        public string ChaveAcesso { get; set; }
        public System.Nullable<decimal> Quantidade { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeImportacaoDetalheDTO {
        public NfeImportacaoDetalheDTO() { }
        public int Id { get; set; }
        public NfeDeclaracaoImportacaoDTO NfeDeclaracaoImportacao { get; set; }
        public System.Nullable<int> NumeroAdicao { get; set; }
        public System.Nullable<int> NumeroSequencial { get; set; }
        public string CodigoFabricanteEstrangeiro { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<int> Drawback { get; set; }
    }
}

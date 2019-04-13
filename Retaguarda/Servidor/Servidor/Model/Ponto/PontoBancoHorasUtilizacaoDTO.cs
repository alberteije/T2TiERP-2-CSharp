using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PontoBancoHorasUtilizacaoDTO {
        public PontoBancoHorasUtilizacaoDTO() { }
        public int Id { get; set; }
        public PontoBancoHorasDTO PontoBancoHoras { get; set; }
        public System.Nullable<System.DateTime> DataUtilizacao { get; set; }
        public string QuantidadeUtilizada { get; set; }
        public string Observacao { get; set; }
    }
}

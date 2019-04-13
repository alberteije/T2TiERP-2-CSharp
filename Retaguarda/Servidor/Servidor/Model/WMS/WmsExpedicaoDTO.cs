using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class WmsExpedicaoDTO {
        public WmsExpedicaoDTO() { }
        public int Id { get; set; }

        public WmsOrdemSeparacaoDetDTO WmsOrdemSeparacaoDet {get; set;}
        public WmsArmazenamentoDTO WmsArmazenamento {get; set;}

        public System.Nullable<int> Quantidade { get; set; }
        public System.Nullable<System.DateTime> DataSaida { get; set; }
    }
}

using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class WmsArmazenamentoDTO {
        public WmsArmazenamentoDTO() { }
        public int Id { get; set; }

        public WmsCaixaDTO WmsCaixa { get; set; }
        public WmsRecebimentoDetalheDTO WmsRecebimentoDetalhe { get; set; }

        public System.Nullable<int> Quantidade { get; set; }
    }
}

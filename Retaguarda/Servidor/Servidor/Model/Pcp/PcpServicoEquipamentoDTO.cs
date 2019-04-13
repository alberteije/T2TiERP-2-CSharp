using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PcpServicoEquipamentoDTO {
        public PcpServicoEquipamentoDTO() { }
        public int Id { get; set; }
        public PcpServicoDTO PcpServico { get; set; }
        public PatrimBemDTO PatrimBem { get; set; }

    }
}

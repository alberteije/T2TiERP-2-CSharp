using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PcpServicoColaboradorDTO {
        public PcpServicoColaboradorDTO() { }
        public int Id { get; set; }
        public PcpServicoDTO PcpServico { get; set; }
        public ColaboradorDTO Colaborador { get; set; }

    }
}

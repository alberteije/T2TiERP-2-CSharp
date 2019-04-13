using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PcpInstrucaoDTO {
        public PcpInstrucaoDTO() { }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}

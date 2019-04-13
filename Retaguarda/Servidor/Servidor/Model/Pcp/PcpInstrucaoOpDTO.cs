using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PcpInstrucaoOpDTO {
        public PcpInstrucaoOpDTO() { }
        public int Id { get; set; }
        public PcpInstrucaoDTO PcpInstrucao { get; set; }
        public PcpOpCabecalhoDTO PcpOpCabecalho { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConciliacaoClient.OFX
{
    public class OFXContaDTO
    {
        public string codBanco { get; set; }
        public string conta { get; set; }
        public string tipo { get; set; }
        public IList<OFXTransacaoDTO> transacoes { get; set; }
    }
}

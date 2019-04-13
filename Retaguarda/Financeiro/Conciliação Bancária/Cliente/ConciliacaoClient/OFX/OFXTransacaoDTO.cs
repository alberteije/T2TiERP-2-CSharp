using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConciliacaoClient.OFX
{
    public class OFXTransacaoDTO
    {
        public string tipo { get; set; }
        public string data { get; set; }
        public string valor { get; set; }
        public string fitid { get; set; }
        public string numero { get; set; }
        public string historico { get; set; }
    }
}

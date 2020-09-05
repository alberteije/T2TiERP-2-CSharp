using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchWindow
{
    public class Coluna
    {
        public Coluna(string cabecalho, string propriedade)
        {
            this.Cabecalho = cabecalho;
            this.Propriedade = propriedade;
        }
        public string Cabecalho { get; set; }
        public string Propriedade { get; set; }
    }
}

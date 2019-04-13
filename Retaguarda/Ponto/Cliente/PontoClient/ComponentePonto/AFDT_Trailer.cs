using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentePonto
{
    public class AFDT_Trailer
    {
        public string Campo01 { get; set; } // Seqüencial do registro no arquivo.
        public string Campo02 { get; set; } // Tipo do registro, “9”.

        public AFDT_Trailer()
        {
        }

        public string gerarLinhaTexto()
        {
            ComponentePonto.NSR++;

            string retorno = "";

            retorno += Funcoes.LFill(ComponentePonto.NSR, 9);
            retorno += Funcoes.LFill("9");

            return retorno;
        }

    }
}

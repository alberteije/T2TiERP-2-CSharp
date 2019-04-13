using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentePonto
{
    public class AFD_Trailer
    {
        public string Campo01 { get; set; } // “999999999”.
        public string Campo02 { get; set; } // Quantidade de registros tipo “2” no arquivo.
        public string Campo03 { get; set; } // Quantidade de registros tipo “3” no arquivo.
        public string Campo04 { get; set; } // Quantidade de registros tipo “4” no arquivo.
        public string Campo05 { get; set; } // Quantidade de registros tipo “5” no arquivo.
        public string Campo06 { get; set; } // Tipo do registro, “9”.

        public AFD_Trailer()
        {
        }

        public string gerarLinhaTexto()
        {
            ComponentePonto.NSR++;

            string retorno = "";

            retorno += Funcoes.LFill("999999999");
            retorno += Funcoes.LFill("9");
            retorno += Funcoes.LFill(Campo03 == null ? "" : Campo03, 9);
            retorno += Funcoes.LFill(Campo04 == null ? "" : Campo04, 9);
            retorno += Funcoes.LFill(Campo05 == null ? "" : Campo05, 9);
            retorno += Funcoes.LFill("9");

            return retorno;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentePonto
{
    public class AFD_Registro4
    {
        public string Campo01 { get; set; } // NSR.
        public string Campo02 { get; set; } // Tipo do registro, “4”.
        public string Campo03 { get; set; } // Data antes do ajuste, no formato “ddmmaaaa”.
        public string Campo04 { get; set; } // Horário antes do ajuste, no formato “hhmm”.
        public string Campo05 { get; set; } // Data ajustada, no formato “ddmmaaaa”.
        public string Campo06 { get; set; } // Horário ajustado, no formato “hhmm”.

        public AFD_Registro4()
        {
        }

        public string gerarLinhaTexto()
        {
            ComponentePonto.NSR++;

            string retorno = "";

            retorno += Funcoes.LFill(ComponentePonto.NSR, 9);
            retorno += Funcoes.LFill("4");
            retorno += Funcoes.LFill(Campo03 == null ? "" : Campo03, 8);
            retorno += Funcoes.LFill(Campo04 == null ? "" : Campo04, 4);
            retorno += Funcoes.LFill(Campo05 == null ? "" : Campo05, 8);
            retorno += Funcoes.LFill(Campo06 == null ? "" : Campo06, 4);

            return retorno;
        }

    }
}

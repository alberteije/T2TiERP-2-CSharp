using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentePonto
{
    public class AFD_Registro3
    {
        public string Campo01 { get; set; } // NSR.
        public string Campo02 { get; set; } // tipo do registro, “3”.
        public string Campo03 { get; set; } // Data da marcação de ponto, no formato “ddmmaaaa”.
        public string Campo04 { get; set; } // Horário da gravação, no formato “hhmm”
        public string Campo05 { get; set; } // Número do PIS do empregado.

        public AFD_Registro3()
        {
        }

        public string gerarLinhaTexto()
        {
            ComponentePonto.NSR++;

            string retorno = "";

            retorno += Funcoes.LFill(ComponentePonto.NSR, 9);
            retorno += Funcoes.LFill("3");
            retorno += Funcoes.LFill(Campo03 == null ? "" : Campo03, 8);
            retorno += Funcoes.LFill(Campo04 == null ? "" : Campo04, 4);
            retorno += Funcoes.LFill(Campo05 == null ? "" : Campo05, 12);

            return retorno;
        }

    }
}

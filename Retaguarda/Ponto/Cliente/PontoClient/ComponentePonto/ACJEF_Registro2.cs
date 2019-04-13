using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentePonto
{
    public class ACJEF_Registro2
    {
        public string Campo01 { get; set; } // NSR.
        public string Campo02 { get; set; } // Tipo do registro, “2”.
        public string Campo03 { get; set; } // Código do Horário (CH), no formato “nnnn”.
        public string Campo04 { get; set; } // Entrada, no formato “hhmm”.
        public string Campo05 { get; set; } // Saída, no formato “hhmm”.
        public string Campo06 { get; set; } // Início intervalo, no formato “hhmm”.
        public string Campo07 { get; set; } // Fim intervalo, no formato “hhmm”.

        public ACJEF_Registro2()
        {
        }

        public string gerarLinhaTexto()
        {
            ComponentePonto.NSR++;

            string retorno = "";

            retorno += Funcoes.LFill(ComponentePonto.NSR, 9);
            retorno += Funcoes.LFill("2");
            retorno += Funcoes.LFill(Campo03 == null ? "" : Campo03, 4);
            retorno += Funcoes.LFill(Campo04 == null ? "" : Campo04, 4);
            retorno += Funcoes.LFill(Campo05 == null ? "" : Campo05, 4);
            retorno += Funcoes.RFill(Campo06 == null ? "" : Campo06, 4);
            retorno += Funcoes.LFill(Campo07 == null ? "" : Campo07, 4);

            return retorno;
        }

    }
}

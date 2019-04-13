using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentePonto
{
    public class AFD_Registro2
    {
        public string Campo01 { get; set; } // NSR.
        public string Campo02 { get; set; } // Tipo do registro, “2”.
        public string Campo03 { get; set; } // Data da gravação, no formata “ddmmaaaa”.
        public string Campo04 { get; set; } // Horário da gravação, no formato “hhmm”
        public string Campo05 { get; set; } // Tipo de identificador do empregador, “1” para CNPJ ou “2” para CPF.
        public string Campo06 { get; set; } // CNPJ ou CPF do empregador.
        public string Campo07 { get; set; } // CEI do empregador, quando existir.
        public string Campo08 { get; set; } // Razão social ou nome do empregador.
        public string Campo09 { get; set; } // Local de prestação de serviços.

        public AFD_Registro2()
        {
        }

        public string gerarLinhaTexto()
        {
            ComponentePonto.NSR++;

            string retorno = "";

            retorno += Funcoes.LFill(ComponentePonto.NSR, 9);
            retorno += Funcoes.LFill("2");
            retorno += Funcoes.LFill(Campo03 == null ? "" : Campo03, 8);
            retorno += Funcoes.LFill(Campo04 == null ? "" : Campo04, 4);
            retorno += Funcoes.LFill(Campo05 == null ? "" : Campo05, 1);
            retorno += Funcoes.RFill(Campo06 == null ? "" : Campo06, 14);
            retorno += Funcoes.LFill(Campo07 == null ? "" : Campo07, 12);
            retorno += Funcoes.LFill(Campo08 == null ? "" : Campo08, 150);
            retorno += Funcoes.LFill(Campo09 == null ? "" : Campo09, 100);

            return retorno;
        }

    }
}

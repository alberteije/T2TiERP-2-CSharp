using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentePonto
{
    public class AFD_Cabecalho
    {
        public string Campo01 { get; set; } // “000000000”.
        public string Campo02 { get; set; } // Tipo do registro, “1”.
        public string Campo03 { get; set; } // Tipo de identificador do empregador, “1” para CNPJ ou “2” para CPF.
        public string Campo04 { get; set; } // CNPJ ou CPF do empregador.
        public string Campo05 { get; set; } // CEI do empregador, quando existir.
        public string Campo06 { get; set; } // Razão social ou nome do empregador.
        public string Campo07 { get; set; } // Número de fabricação do REP.
        public string Campo08 { get; set; } // Data inicial dos registros no arquivo, no formato “ddmmaaaa”.
        public string Campo09 { get; set; } // Data final dos registros no arquivo, no formato “ddmmaaaa”.
        public string Campo10 { get; set; } // Data de geração do arquivo, no formato “ddmmaaaa”.
        public string Campo11 { get; set; } // Horário da geração do arquivo, no formato “hhmm”.

        public AFD_Cabecalho()
        {
        }

        public string gerarLinhaTexto()
        {
            ComponentePonto.NSR++;

            string retorno = "";

            retorno += Funcoes.LFill("000000000");
            retorno += Funcoes.LFill("1");
            retorno += Funcoes.LFill(Campo03 == null ? "" : Campo03, 1);
            retorno += Funcoes.LFill(Campo04 == null ? "" : Campo04, 14);
            retorno += Funcoes.LFill(Campo05 == null ? "" : Campo05, 12);
            retorno += Funcoes.RFill(Campo06 == null ? "" : Campo06, 150);
            retorno += Funcoes.LFill(Campo07 == null ? "" : Campo07, 17);
            retorno += Funcoes.LFill(Campo08 == null ? "" : Campo08, 8);
            retorno += Funcoes.LFill(Campo09 == null ? "" : Campo09, 8);
            retorno += Funcoes.LFill(Campo10 == null ? "" : Campo10, 8);
            retorno += Funcoes.LFill(Campo10 == null ? "" : Campo11, 4);

            return retorno;
        }

    }
}

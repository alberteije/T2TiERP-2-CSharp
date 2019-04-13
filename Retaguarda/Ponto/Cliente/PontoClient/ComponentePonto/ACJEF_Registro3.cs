using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentePonto
{
    public class ACJEF_Registro3
    {
        public string Campo01 { get; set; } // NSR.
        public string Campo02 { get; set; } // tipo do registro, “3”.
        public string Campo03 { get; set; } // Número do PIS do empregado.
        public string Campo04 { get; set; } // Data de início da jornada, no formato “ddmmaaaa”.
        public string Campo05 { get; set; } // Primeiro horário de entrada da jornada, no formato “hhmm”.
        public string Campo06 { get; set; } // Código do horário (CH) previsto para a jornada, no formato “nnnn”.
        public string Campo07 { get; set; } // Horas diurnas não extraordinárias, no formato “hhmm”.
        public string Campo08 { get; set; } // Horas noturnas não extraordinárias, no formato “hhmm”.
        public string Campo09 { get; set; } // Horas extras 1, no formato “hhmm”.
        public string Campo10 { get; set; } // Percentual do adicional de horas extras 1, onde as 3 primeiras posições indicam a parte inteira e a seguinte a fração decimal.
        public string Campo11 { get; set; } // Modalidade da hora extra 1, assinalado com “D” se as horas extras forem diurnas e “N” se forem noturnas.
        public string Campo12 { get; set; } // Horas extras 2, no formato “hhmm”.
        public string Campo13 { get; set; } // Percentual do adicional de horas extras 2, onde as 3 primeiras posições indicam a parte inteira e a seguinte a fração decimal.
        public string Campo14 { get; set; } // Modalidade da hora extra 2, assinalado com “D” se as horas extras forem diurnas e “N” se forem noturnas.
        public string Campo15 { get; set; } // Horas extras 3, no formato “hhmm”.
        public string Campo16 { get; set; } // Percentual do adicional de horas extras 3, onde as 3 primeiras posições indicam a parte inteira e a seguinte a fração decimal.
        public string Campo17 { get; set; } // Modalidade da hora extra 3, assinalado com “D” se as horas extras forem diurnas e “N” se forem noturnas.
        public string Campo18 { get; set; } // Horas extras 4, no formato “hhmm”.
        public string Campo19 { get; set; } // Percentual do adicional de horas extras 4, onde as 3 primeiras posições indicam a parte inteira e a seguinte a fração decimal.
        public string Campo20 { get; set; } // Modalidade da hora extra 4, assinalado com “D” se as horas extras forem diurnas e “N” se forem noturnas.
        public string Campo21 { get; set; } // Horas de faltas e/ou atrasos.
        public string Campo22 { get; set; } // Sinal de horas para compensar. “1” se for horas a maior e “2” se for horas a menor.
        public string Campo23 { get; set; } // Saldo de horas para compensar no formato “hhmm”.

        public ACJEF_Registro3()
        {
        }

        public string gerarLinhaTexto()
        {
            ComponentePonto.NSR++;

            string retorno = "";

            retorno += Funcoes.LFill(ComponentePonto.NSR, 9);
            retorno += Funcoes.LFill("3");
            retorno += Funcoes.LFill(Campo03 == null ? "" : Campo03, 12);
            retorno += Funcoes.LFill(Campo04 == null ? "" : Campo04, 8);
            retorno += Funcoes.LFill(Campo05 == null ? "" : Campo05, 4);
            retorno += Funcoes.RFill(Campo06 == null ? "" : Campo06, 4);
            retorno += Funcoes.LFill(Campo07 == null ? "" : Campo07, 4);
            retorno += Funcoes.LFill(Campo08 == null ? "" : Campo08, 4);
            retorno += Funcoes.LFill(Campo09 == null ? "" : Campo09, 4);
            retorno += Funcoes.LFill(Campo10 == null ? "" : Campo10, 4);
            retorno += Funcoes.LFill(Campo11 == null ? "" : Campo11, 1);
            retorno += Funcoes.LFill(Campo12 == null ? "" : Campo12, 4);
            retorno += Funcoes.LFill(Campo13 == null ? "" : Campo13, 4);
            retorno += Funcoes.LFill(Campo14 == null ? "" : Campo14, 1);
            retorno += Funcoes.LFill(Campo15 == null ? "" : Campo15, 4);
            retorno += Funcoes.LFill(Campo16 == null ? "" : Campo16, 4);
            retorno += Funcoes.LFill(Campo17 == null ? "" : Campo17, 1);
            retorno += Funcoes.LFill(Campo18 == null ? "" : Campo18, 4);
            retorno += Funcoes.LFill(Campo19 == null ? "" : Campo19, 4);
            retorno += Funcoes.LFill(Campo20 == null ? "" : Campo20, 1);
            retorno += Funcoes.LFill(Campo21 == null ? "" : Campo21, 4);
            retorno += Funcoes.LFill(Campo22 == null ? "" : Campo22, 1);
            retorno += Funcoes.LFill(Campo23 == null ? "" : Campo23, 4);

            return retorno;
        }

    }
}

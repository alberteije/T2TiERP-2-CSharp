using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponenteFolha
{
    public class FolhaSefipRegistroTipo90
    {
        public string TipoRegistro { get; set; } // 2 N -  Campo obrigatório.  Sempre “90”.
        public string MarcaFinalRegistro { get; set; } // 51 AN - Campo obrigatório. De 3 a 53 deve ser “9”.
        /// Brancos 306 AN - Campo obrigatório. Preencher com brancos.
        /// Final de Linha 1 AN - Campo obrigatório. Deve ser uma constante “*” para marcar fim de linha.

        public FolhaSefipRegistroTipo90()
        {
        }

        public string gerarLinhaTexto()
        {
            ComponenteFolha.NSR++;

            string retorno = "";

            retorno += Funcoes.LFill("90");
            retorno += Funcoes.LFill("9", 51);
            retorno += Funcoes.LFill(" ", 306);
            retorno += Funcoes.LFill("*");

            return retorno;
        }

    }
}

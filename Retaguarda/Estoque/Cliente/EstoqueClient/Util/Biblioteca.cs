using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstoqueClient.Util
{
    public class Biblioteca
    {
        public static string DigitoModulo11(string chave)
        {
            int soma = 0; // Vai guardar a Soma
            int mod = -1; // Vai guardar o Resto da divisão
            int dv = -1;  // Vai guardar o DigitoVerificador
            int pesso = 2; // vai guardar o pesso de multiplicacao

            //percorrendo cada caracter da chave da direita para esquerda para fazer os calculos com o pesso
            for (int i = chave.Length - 1; i != -1; i--)
            {
                int ch = Convert.ToInt32(chave[i].ToString());
                soma += ch * pesso;
                //sempre que for 9 voltamos o pesso a 2
                if (pesso < 9)
                    pesso += 1;
                else
                    pesso = 2;
            }

            //Agora que tenho a soma vamos pegar o resto da divisão por 11
            mod = soma % 11;
            //Aqui temos uma regrinha, se o resto da divisão for 0 ou 1 então o dv vai ser 0
            if (mod == 0 || mod == 1)
                dv = 0;
            else
                dv = 11 - mod;

            return dv.ToString();
        }
    }
}

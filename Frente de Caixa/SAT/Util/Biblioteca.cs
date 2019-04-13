/********************************************************************************
Title: T2TiNFCe
Description: Biblioteca de fun??es.

The MIT License

Copyright: Copyright (C) 2015 T2Ti.COM

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

       The author may be contacted at:
           t2ti.com@gmail.com

@author T2Ti.COM
@version 1.0
********************************************************************************/


using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace NFCe.Util
{

    public static class Biblioteca
    {

        public static string QuotedStr(string pValor)
        {
            return "'" + pValor + "'";
        }


        public static string VerificaNULL(string Texto, int Tipo)
        {
            switch (Tipo)
            {
                case 0:
                    if (Texto.Trim() == "")
                        return "NULL";
                    else
                        return Texto.Trim();
                case 1:
                    if (Texto.Trim() == "")
                        return "NULL";
                    else
                        return Biblioteca.QuotedStr(Texto.Trim());
                case 2:
                    if (Texto.Trim() == "")
                        return "";
                    else
                        return (Texto.Trim());
                default:
                    return "";
            }
        }


        //  Valida o CNPJ digitado 
        public static bool ValidaCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }


        //  Valida o CPF digitado 
        public static bool ValidaCPF(string cpf)
        {
            // Caso coloque todos os numeros iguais
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        //  Valida a UF digitada 
        public static bool ValidaEstado(string Dado)
        {
            const string Estados = "SPMGRJRSSCPRESDFMTMSGOTOBASEALPBPEMARNCEPIPAAMAPFNACRRRO"; int Posicao;
            bool Result;

            Result = true;
            if (Dado != "")
            {
                Posicao = Estados.IndexOf(Dado.ToUpper());
                if ((Posicao == 0) || ((Posicao % 2) == 0))
                {
                    Result = false;
                }
            }
            return Result;
        }


        public static string MD5File(string file)
        {
            using (FileStream stream = File.OpenRead(file))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] checksum = md5.ComputeHash(stream);
                return (BitConverter.ToString(checksum)).Replace("-", string.Empty);
            }
        }


        public static string MD5String(string texto)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] byteArray = Encoding.ASCII.GetBytes(texto);

            byteArray = md5.ComputeHash(byteArray);

            StringBuilder hashedValue = new StringBuilder();

            foreach (byte b in byteArray)
            {
                hashedValue.Append(b.ToString("x2"));
            }

            return hashedValue.ToString();
        }


        public static decimal TruncaValor(decimal Value, int Casas)
        {
            /*
            string sValor;
            int nPos;

            // Transforma o valor em string
            sValor = Value.ToString();

            // Verifica se possui ponto decimal
            nPos = sValor.IndexOf(",");
            if (nPos > 0)
            {
                sValor = sValor.Substring(0, nPos + Casas + 1);
            }

            return Convert.ToDecimal(sValor);
             * */
            return Value;
        }

        public static decimal TruncaValor(decimal? Value, int Casas)
        {
            string sValor;
            int nPos;

            // Transforma o valor em string
            sValor = Value.ToString();

            // Verifica se possui ponto decimal
            nPos = sValor.IndexOf(",");
            if (nPos > 0)
            {
                sValor = sValor.Substring(0, nPos + Casas);
            }

            return Convert.ToDecimal(sValor);
        }

        public static string FormataFloat(string Tipo, decimal Valor)
        {
            int i;
            string Mascara;

            Mascara = "0.";

            if (Tipo == "Q")
            {
                for (i = 1; i <= Constantes.DECIMAIS_QUANTIDADE; i++)
                    Mascara = Mascara + "0";
            }
            else if (Tipo == "V")
            {
                for (i = 1; i <= Constantes.DECIMAIS_VALOR; i++)
                    Mascara = Mascara + "0";
            }

            return Convert.ToDecimal(Valor).ToString(Mascara);
        }

        public static string FormataFloat(string Tipo, decimal? Valor)
        {
            int i;
            string Mascara;

            Mascara = "0.";

            if (Tipo == "Q")
            {
                for (i = 1; i <= Constantes.DECIMAIS_QUANTIDADE; i++)
                    Mascara = Mascara + "0";
            }
            else if (Tipo == "V")
            {
                for (i = 1; i <= Constantes.DECIMAIS_VALOR; i++)
                    Mascara = Mascara + "0";
            }

            return Convert.ToDecimal(Valor).ToString(Mascara);
        }

        public static string DevolveConteudoDelimitado(string Delimidador, string Linha)
        {
            int PosBarra;
            string Result;

            PosBarra = Linha.IndexOf(Delimidador);
            Result = (Linha.Substring(PosBarra - 1, 1)).Replace("[#]", "|");
            Linha = Linha.Remove(0, PosBarra);
            return Result;
        }

        public static string TiraPontos(string Str)
        {
            int i;
            string xStr;
            string Result;

            xStr = "";
            for (i = 1; i <= Str.Trim().Length; i++)
                if (("/-.)(,".IndexOf(Str.Substring(1, i)) == 0)) xStr = xStr + Str[i];

            xStr = xStr.Replace(" ", "");

            Result = xStr;
            return Result;
        }


        public static DateTime TextoParaData(string pData)
        {
            int Dia, Mes, Ano;
            System.DateTime Result;

            if ((pData != "") && (pData != "0000-00-00"))
            {
                Dia = Convert.ToInt32(pData.Substring(2, 9));
                Mes = Convert.ToInt32(pData.Substring(2, 6));
                Ano = Convert.ToInt32(pData.Substring(4, 1));
                Result = new DateTime(Ano, Mes, Dia);
            }
            else
            {
                Result = new DateTime();
            }
            return Result;
        }


        public static string DataParaTexto(DateTime pData)
        {
            return pData.ToString("YYYY-MM-DD");
        }


        public static string Encripta(string pChave)
        {
            string chaveCriptografada;
            Byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(pChave);
            chaveCriptografada = Convert.ToBase64String(b);
            return chaveCriptografada;
        }


        public static string Desencripta(string pChave)
        {
            string chaveDecriptografada;
            Byte[] b = Convert.FromBase64String(pChave);
            chaveDecriptografada = System.Text.ASCIIEncoding.ASCII.GetString(b);
            return chaveDecriptografada;
        }

        
        public static bool AssinarComOpenSsl(string pNomeArquivo)
        {
            try
            {
                string ArquivoChavePrivada = Application.StartupPath + "\\priv_key.pem";
                if (!File.Exists(ArquivoChavePrivada))
                {
                    MessageBox.Show("Chave privada não encontrada.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (!File.Exists(pNomeArquivo))
                {
                    MessageBox.Show("Arquivo solicitado para assinatura não existe.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                string ArquivoAssinatura = Application.StartupPath + "\\assinatura.txt";

                System.Diagnostics.Process.Start("openssl.exe", "dgst -md5 -sign " + ArquivoChavePrivada + " -out " + ArquivoAssinatura + " -hex " + pNomeArquivo);

                string DadosAssinatura = "";
                StreamReader LeituraArquivo = new StreamReader(ArquivoAssinatura);
                while (!LeituraArquivo.EndOfStream)
                {
                    DadosAssinatura = LeituraArquivo.ReadLine();
                }
                LeituraArquivo.Close();

                string Assinatura = "EAD" + DadosAssinatura.Substring(DadosAssinatura.IndexOf("=") + 1).Trim() + "\r\n";

                StreamWriter EscritaArquivo = File.AppendText(pNomeArquivo);
                EscritaArquivo.Write(Assinatura);
                EscritaArquivo.Close();

                return true;
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
                return false;
            }
        }

        /// <summary>
        /// Get substring of specified number of characters on the right.
        /// </summary>
        public static string Right(this string value, int length)
        {
            if (String.IsNullOrEmpty(value)) return string.Empty;

            return value.Length <= length ? value : value.Substring(value.Length - length);
        }


        public static string Modulo11(string chave)
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

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace EstoqueService.Util
{
    public static class Biblioteca
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


    }
}
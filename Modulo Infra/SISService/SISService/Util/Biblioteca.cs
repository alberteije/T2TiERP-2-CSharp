using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SISService.Util
{

    public static class Biblioteca
    {

        public static string QuotedStr(string pValor)
        {
            return "'" + pValor + "'";
        }


        public static string VerificaNULL(string texto, int tipo)
        {
            switch (tipo)
            {
                case 0:
                    if (texto.Trim() == "")
                        return "NULL";
                    else
                        return texto.Trim();
                case 1:
                    if (texto.Trim() == "")
                        return "NULL";
                    else
                        return Biblioteca.QuotedStr(texto.Trim());
                case 2:
                    if (texto.Trim() == "")
                        return "";
                    else
                        return (texto.Trim());
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

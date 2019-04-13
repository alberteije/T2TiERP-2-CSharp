using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace ConciliacaoClient.OFX
{
    public class OFXImport
    {
        private string ofx;
        public OFXContaDTO import(string nomeArquivo)
        {
            OFXContaDTO resultado = new OFXContaDTO();

            using (FileStream fileStream = new FileStream(nomeArquivo, FileMode.Open, FileAccess.Read))
            {
                ofx = new StreamReader(fileStream, Encoding.Default).ReadToEnd();

                resultado.codBanco = getValor("<BANKID>");
                resultado.conta = getValor("<ACCTID>");
                resultado.tipo = getValor("<ACCTTYPE>");

                resultado.transacoes = new List<OFXTransacaoDTO>();

                int indCursor = 0;
                int ind = 0;
                 while (ind >= 0)
                {
                    ind = ofx.IndexOf("<STMTTRN>", indCursor);

                    if (ind > 0)
                    {
                        OFXTransacaoDTO trans = new OFXTransacaoDTO();
                        trans.tipo = getValor("<TRNTYPE>", ind);
                        trans.data = getValor("<DTPOSTED>", ind);
                        trans.valor = getValor("<TRNAMT>", ind);
                        trans.fitid = getValor("<FITID>", ind);
                        trans.historico = getValor("<MEMO>", ind);
                        trans.numero = getValor("<CHECKNUM>", ind);

                        resultado.transacoes.Add(trans);
                        indCursor = ind + 1;
                    }
                }
            }

            return resultado;
        }

        private string getValor(string elemento, int indice)
        {
            string resultado = null;

            int ind = ofx.IndexOf(elemento,indice);
            resultado = Regex.Split(ofx.Substring(ind + elemento.Length), "\r\n")[0];
            return resultado.Trim();
        }
        private string getValor(string elemento)
        {
            return getValor(elemento, 0);
        }

    }
}

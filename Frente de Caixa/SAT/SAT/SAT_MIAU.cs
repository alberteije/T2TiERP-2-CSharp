using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SAT
{
    public static class SAT_MIAU
    {
        public static void ConverterNFCeParaSAT(string arquivo)
        {

            StreamReader sr = new StreamReader(arquivo);
            StringBuilder sb = new StringBuilder();

            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                if (s.IndexOf("NFe") > -1)
                {
                    s = s.Replace("NFe", "CFe");
                }
                if (s.IndexOf("infNFe") > -1)
                {
                    s = s.Replace("infNFe", "infCFe");
                }
                if (s.IndexOf("versao") > -1)
                {
                    s = s.Replace("versao", "versaoDadosEnt");
                }
                if (s.IndexOf("3.10") > -1)
                {
                    s = s.Replace("3.10", "0.06");
                }
                if (s.IndexOf("<cUF>53</cUF>") > -1)
                {
                    s = s.Replace("<cUF>53</cUF>", "<CNPJ>11111111111111</CNPJ>");
                }
                if (s.IndexOf("<mod>65</mod>") > -1)
                {
                    s = s.Replace("<mod>65</mod>", "<signAC>eije1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111</signAC>");
                }
                if (s.IndexOf("<natOp>VENDA</natOp>") > -1)
                {
                    s = s.Replace("<natOp>VENDA</natOp>", "<numeroCaixa>001</numeroCaixa>");
                }
                if (s.IndexOf("<CNPJ>10793118000178</CNPJ>") > -1)
                {
                    s = s.Replace("<CNPJ>10793118000178</CNPJ>", "<CNPJ>11111111111111</CNPJ>");
                }
                if (s.IndexOf("<CNPJ>10793118000178</CNPJ>") > -1)
                {
                    s = s.Replace("<CNPJ>10793118000178</CNPJ>", "<CNPJ>11111111111111</CNPJ>");
                }
                if (s.IndexOf("<IE>0751990400114</IE>") > -1)
                {
                    s = s.Replace("<IE>0751990400114</IE>", "<IE>111111111111</IE><IM>123123</IM><cRegTribISSQN>1</cRegTribISSQN><indRatISSQN>N</indRatISSQN>");
                }
                if (s.IndexOf("<pag>") > -1)
                {
                    s = s.Replace("<pag>", "<pgto><MP>");
                }
                if (s.IndexOf("tPag") > -1)
                {
                    s = s.Replace("tPag", "cMP");
                }
                if (s.IndexOf("vPag") > -1)
                {
                    s = s.Replace("vPag", "vMP");
                }
                if (s.IndexOf("</pag>") > -1)
                {
                    s = s.Replace("</pag>", "</MP></pgto>");
                }
                if (s.IndexOf("<nItemPed>0</nItemPed>") > -1)
                {
                    s = s.Replace("<nItemPed>0</nItemPed>", "<indRegra>A</indRegra>");
                }
                if (s.IndexOf("00000000</vUnCom>") > -1)
                {
                    s = s.Replace("00000000</vUnCom>", "</vUnCom>");
                }
                if (s.IndexOf("<vTotTrib>") > -1)
                {
                    s = s.Replace("<vTotTrib>", "<vItem12741>");
                }
                if (s.IndexOf("</vTotTrib>") > -1)
                {
                    s = s.Replace("</vTotTrib>", "</vItem12741><PIS><PISSN><CST>49</CST></PISSN></PIS><COFINS><COFINSSN><CST>49</CST></COFINSSN></COFINS>");
                }
                sb.AppendLine(s);
            }
            sr.Close();

            StreamWriter sw = new StreamWriter(arquivo);
            sw.Write(sb);

            sw.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT
{
    public static class TratarRetornoSAT
    {
        public static String TratarRetornoConsultarSAT(String retorno)
        {
            String[] camposRetorno = retorno.Split('|');
            return camposRetorno[2];
        }

        public static Dictionary<string, string> retornoVenda(String retorno) 
        {
            // Exercício: Mapeie os códigos de alertas e mensagens que erro que podem retornar do SAT e trate-os

            Dictionary<string, string> map = new Dictionary<string, string>();

            String[] camposRetorno = new String[13];
            camposRetorno[0] = "numeroSessao";
            camposRetorno[1] = "codigoRetorno";
            camposRetorno[2] = "codigoAlerta";
            camposRetorno[3] = "mensagem";
            camposRetorno[4] = "codigoReferencia";
            camposRetorno[5] = "mensagemSefaz";
            camposRetorno[6] = "arquivoCFe";
            camposRetorno[7] = "timeStamp";
            camposRetorno[8] = "chaveConsulta";
            camposRetorno[9] = "valorTotalCFe";
            camposRetorno[10] = "cpfCnpj";
            camposRetorno[11] = "assinaturaQRCode";

            String[] resultado = retorno.Split('|');
        
            for (int i = 0; i < resultado.Length; i++) {
                if (i == 6) {
                    map.Add(camposRetorno[i], Base64Decode(resultado[i].Replace("\n", "")));
                } else {
                    map.Add(camposRetorno[i], resultado[i]);
                }
            }

            if (map[camposRetorno[1]] == "06000")
            { 
                map.Add("autorizado", "S");
            }
            else
            {
                map.Add("autorizado", "N");
            }

            return map;
        }

        public static String TratarRetornoStatusOperacional(String retorno)
        {
            String[] camposRetorno = retorno.Split('|');
            // Exercício: 
                    // O campo ULTIMO_CFe não está sendo retornado pelo emulador.
                    // Verificar se existe na documentação do SAT/Emulador se há alguma informação a respeito.

            String resultado = "";
            if (camposRetorno.Length == 28)
            {
                resultado = "NSERIE.........: " + camposRetorno[5] + System.Environment.NewLine
                        + "LAN_MAC........: " + camposRetorno[8] + System.Environment.NewLine
                        + "STATUS_LAN.....: " + camposRetorno[13] + System.Environment.NewLine
                        + "NIVEL_BATERIA..: " + camposRetorno[14] + System.Environment.NewLine
                        + "MT_TOTAL.......: " + camposRetorno[15] + System.Environment.NewLine
                        + "MT_USADA.......: " + camposRetorno[16] + System.Environment.NewLine
                        + "DH_ATUAL.......: " + camposRetorno[17] + System.Environment.NewLine
                        + "VER_SB.........: " + camposRetorno[18] + System.Environment.NewLine
                        + "VER_LAYOUT.....: " + camposRetorno[19] + System.Environment.NewLine
                        + "ULTIMO_CFe.....: " + camposRetorno[20] + System.Environment.NewLine
                        + "LISTA_INICIAL..: " + camposRetorno[21] + System.Environment.NewLine
                        + "LISTA_FINAL....: " + camposRetorno[22] + System.Environment.NewLine
                        + "DH_CFe.........: " + camposRetorno[23] + System.Environment.NewLine
                        + "DH_ULTIMA......: " + camposRetorno[24] + System.Environment.NewLine
                        + "CERT_EMISSAO...: " + camposRetorno[25] + System.Environment.NewLine
                        + "CERT_VENCIMENTO: " + camposRetorno[26] + System.Environment.NewLine
                        + "ESTADO_OPERACAO: " + camposRetorno[27] + System.Environment.NewLine
                        + "MSG SEFAZ......: " + camposRetorno[4];
            }
            else
            {
                resultado = "NSERIE.........: " + camposRetorno[5] + System.Environment.NewLine
                        + "LAN_MAC........: " + camposRetorno[8] + System.Environment.NewLine
                        + "STATUS_LAN.....: " + camposRetorno[13] + System.Environment.NewLine
                        + "NIVEL_BATERIA..: " + camposRetorno[14] + System.Environment.NewLine
                        + "MT_TOTAL.......: " + camposRetorno[15] + System.Environment.NewLine
                        + "MT_USADA.......: " + camposRetorno[16] + System.Environment.NewLine
                        + "DH_ATUAL.......: " + camposRetorno[17] + System.Environment.NewLine
                        + "VER_SB.........: " + camposRetorno[18] + System.Environment.NewLine
                        + "VER_LAYOUT.....: " + camposRetorno[19] + System.Environment.NewLine
                        + "LISTA_INICIAL..: " + camposRetorno[20] + System.Environment.NewLine
                        + "LISTA_FINAL....: " + camposRetorno[21] + System.Environment.NewLine
                        + "DH_CFe.........: " + camposRetorno[22] + System.Environment.NewLine
                        + "DH_ULTIMA......: " + camposRetorno[23] + System.Environment.NewLine
                        + "CERT_EMISSAO...: " + camposRetorno[24] + System.Environment.NewLine
                        + "CERT_VENCIMENTO: " + camposRetorno[25] + System.Environment.NewLine
                        + "ESTADO_OPERACAO: " + camposRetorno[26] + System.Environment.NewLine
                        + "MSG SEFAZ......: " + camposRetorno[4];
            }

            return resultado;
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }

    
}

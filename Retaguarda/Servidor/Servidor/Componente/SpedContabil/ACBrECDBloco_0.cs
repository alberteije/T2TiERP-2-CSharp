using System.Collections.Generic;

namespace ProjetoSpedContabil
{

    public class TRegistro0000
    {
        public System.DateTime DT_INI { get; set; }       // / Data inicial das informa??es contidas no arquivo
        public System.DateTime DT_FIN { get; set; }       // / Data final das informa??es contidas no arquivo
        public string NOME { get; set; }        // / Nome empresarial do empres?rio ou sociedade empres?ria.
        public string CNPJ { get; set; }        // / N?mero de inscri??o do empres?rio ou sociedade empres?ria no CNPJ.
        public string UF { get; set; }          // / Sigla da unidade da federa??o do empres?rio ou sociedade empres?ria.
        public string IE { get; set; }          // / Inscri??o Estadual do empres?rio ou sociedade empres?ria.
        public string COD_MUN { get; set; }     // / C?digo do munic?pio do domic?lio fiscal do empres?rio ou sociedade empres?ria, conforme tabela do IBGE - Instituto Brasileiro de Geografia e Estat?stica.
        public string IM { get; set; }          // / Inscri??o Municipal do empres?rio ou sociedade empres?ria.
        public string IND_SIT_ESP { get; set; } // / Indicador de situa??o especial (conforme tabela publicada pelo Sped).
        public string IND_SIT_INI_PER { get; set; } // / Indicador de situa??o no in?cio do per?odo (conforme tabela publicada pelo Sped).
        public string IND_NIRE { get; set; }        // / Indicador de exist?ncia de NIRE
        public string IND_FIN_ESC { get; set; }     // / Indicador de finalidade da escritura??o
        public string COD_HASH_SUB { get; set; }    // / Hash da escritura??o substitu?da.
        public string NIRE_SUBST { get; set; }      // / NIRE da escritura??o substitu?da.
        public string IND_EMP_GRD_PRT { get; set; } // / Indicador de empresa de grande porte:
        public string TIP_ECD { get; set; }         // / Indicador do tipo de ECD: 0 ? ECD de empresa n?o participante de SCP como s?cio ostensivo. 1 ? ECD de empresa participante de SCP como s?cio ostensivo. 2 ? ECD da SCP.
        public string COD_SCP { get; set; }         // / Identifica??o da SCP.
        public string IDENT_MF { get; set; }        // / Identifica??o de Moeda Funcional    
    }


    // / Registro 0001 - ABERTURA DO BLOCO 0
    public class TRegistro0001
    {
    }

    // / Rregistro 0007 ? ESCRITURA??O CONT?BIL DESCENTRALIZADA
    public class TRegistro0007
    {
        public string COD_ENT_REF { get; set; } // / C?digo da institui??o respons?vel pela administra??o do cadastro (conforme tabela publicada pelo Sped).
        public string COD_INSCR { get; set; }   // / C?digo cadastral do empres?rio ou sociedade empres?ria na institui??o identificada no campo 02.
    }


    // / Registro 0007 - Lista
    public class TRegistro0007List
    {
        public List<TRegistro0007> Registro0007List { get; set; }
    }


    // / Rregistro 0020 ? OUTRAS INSCRI??ES CADASTRAIS DO EMPRES?RIO OU
    // /                  SOCIEDADE EMPRES?RIA
    public class TRegistro0020
    {
        public int IND_DEC { get; set; }        // / Indicador de descentraliza??o: 0 - escritura??o da matriz; 1 - escritura??o da filial.
        public string CNPJ { get; set; }        // / N?mero de inscri??o do empres?rio ou sociedade empres?ria no CNPJ da matriz ou da filial.
        public string UF { get; set; }          // / Sigla da unidade da federa??o da matriz ou da filial.
        public string IE { get; set; }          // / Inscri??o estadual da matriz ou da filial.
        public string COD_MUN { get; set; }     // / C?digo do munic?pio do domic?lio da matriz ou da filial.
        public string IM { get; set; }          // / N?mero de Inscri??o Municipal da matriz ou da filial.
        public string NIRE { get; set; }        // / N?mero de Identifica??o do Registro de Empresas da matriz ou da filial na Junta Comercial.
    }

    // / Registro 0020 - Lista
    public class TRegistro0020List
    {
        public List<TRegistro0020> Registro0020List { get; set; }
    }


    // / Rregistro 0035 ? IDENTIFICA??O DAS SCP
    public class TRegistro0035
    {
        public string COD_SCP { get; set; }   // / Identifica??o da SCP (CNPJ ? art. 52 da Instru??o Normativa RFB no 1.470, de 30 de maio de 2014)
        public string NOME_SCP { get; set; }  // / Nome da SCP
    }


    // / Registro 0035 - Lista  
    public class TRegistro0035List
    {
        public List<TRegistro0035> Registro0035List { get; set; }
    }


    // / Rregistro 0150 ?  TABELA DE CADASTRO DO PARTICIPANTE
    public class TRegistro0150
    {
        public string COD_PART { get; set; }    // / C?digo de identifica??o do participante:
        public string NOME { get; set; }        // / Nome pessoal ou empresarial:
        public string COD_PAIS { get; set; }    // / C?digo do pa?s do participante:
        public string CNPJ { get; set; }        // / CNPJ do participante:
        public string CPF { get; set; }         // / CPF do participante na unidade da federa??o do destinat?rio:
        public string NIT { get; set; }         // / N?mero de Identifica??o do Trabalhador, Pis, Pasep, SUS.
        public string UF { get; set; }          // / Sigla da unidade da federa??o do participante.
        public string IE { get; set; }          // / Inscri??o Estadual do participante:
        public string IE_ST { get; set; }       // / Inscri??o Estadual do participante na unidade da federa??o do destinat?rio, na condi??o de contribuinte substituto
        public int COD_MUN { get; set; }        // / C?digo do munic?pio:
        public string IM { get; set; }          // / Inscri??o Municipal do participante.
        public string SUFRAMA { get; set; }     // / N?mero de inscri??o na Suframa:
    }


    // / Registro 0990 - ENCERRAMENTO DO BLOCO 0
    public class TRegistro0990
    {
        public int QTD_LIN_0 { get; set; } // / Quantidade total de linhas do Bloco 0
    }


}

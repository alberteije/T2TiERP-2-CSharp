using System;

namespace ProjetoSpedContabil
{

    // / TBLOCO_0 - Abertura, Identifica??o e Refer?ncias  
    public class TBloco_0
    {
        public TRegistro0000 FRegistro0000;      /// BLOCO 0 - Registro0000
        public TRegistro0001 FRegistro0001;      /// BLOCO 0 - Registro0001
        public TRegistro0007List FRegistro0007;  /// BLOCO 0 - Lista de Registro0007
        public TRegistro0020List FRegistro0020;  /// BLOCO 0 - Lista de Registro0020
        public TRegistro0035List FRegistro0035;  /// BLOCO 0 - Lista de Registro0035
        public TRegistro0990 FRegistro0990;      /// BLOCO 0 - FRegistro0990
        public int FRegistro0180Count;


        public bool Assigned(Object o)
        {
            return o != null;
        }


        //  TBloco_0 

        public TBloco_0()
        {
            FRegistro0000 = new TRegistro0000();
            FRegistro0001 = new TRegistro0001();
            FRegistro0007 = new TRegistro0007List();
            FRegistro0020 = new TRegistro0020List();
            FRegistro0035 = new TRegistro0035List();
            FRegistro0990 = new TRegistro0990();

            FRegistro0990.QTD_LIN_0 = 0;
            FRegistro0180Count = 0;
        }

        public void LimpaRegistros()
        {/*
            FRegistro0007.Registro0007List.Clear();
            FRegistro0020.Registro0020List.Clear();
            FRegistro0035.Registro0035List.Clear();

            FRegistro0990.QTD_LIN_0 = 0;
            FRegistro0180Count = 0;
        */}

        public string WriteRegistro0000()
        {
            string retorno = "";

            if (Assigned(FRegistro0000))
            {

                retorno = Funcoes.LFill("0000") +
                     Funcoes.LFill("LECD") +
                     Funcoes.LFill(FRegistro0000.DT_INI.ToString()) +
                     Funcoes.LFill(FRegistro0000.DT_FIN.ToString()) +
                     Funcoes.LFill(FRegistro0000.NOME) +
                     Funcoes.LFill(FRegistro0000.CNPJ) +
                     Funcoes.LFill(FRegistro0000.UF) +
                     Funcoes.LFill(FRegistro0000.IE) +
                     Funcoes.LFill(FRegistro0000.COD_MUN) +
                     //Funcoes.LFill(FRegistro0000.IM) +
                     Funcoes.LFill(FRegistro0000.IND_SIT_ESP) +
                     //Funcoes.LFill(FRegistro0000.IND_SIT_INI_PER) +
                     //Funcoes.LFill(FRegistro0000.IND_NIRE) +
                     //Funcoes.LFill(FRegistro0000.IND_FIN_ESC) +
                     //Funcoes.LFill(FRegistro0000.COD_HASH_SUB) +
                     //Funcoes.LFill(FRegistro0000.NIRE_SUBST) +
                     //Funcoes.LFill(FRegistro0000.IND_EMP_GRD_PRT) +
                     //Funcoes.LFill(FRegistro0000.TIP_ECD) +
                     //Funcoes.LFill(FRegistro0000.COD_SCP) +
                     Funcoes.LFill("");//FRegistro0000.IDENT_MF);
            }

            // /
            FRegistro0990.QTD_LIN_0 = FRegistro0990.QTD_LIN_0 + 1;

            return retorno;

        }



        public string WriteRegistro0001()
        {
            string retorno = "";


            if (Assigned(FRegistro0001))
            {
                retorno = Funcoes.LFill("00011");
                // /
                FRegistro0990.QTD_LIN_0 = FRegistro0990.QTD_LIN_0 + 1;
            }
            return retorno;
        }



        public void WriteRegistro0007()
        {/*
		            retorno = Funcoes.LFill("0007") +
		                Funcoes.LFill(COD_ENT_REF) +
		                Funcoes.LFill(COD_INSCR)
		                );
		        FRegistro0990.QTD_LIN_0 = FRegistro0990.QTD_LIN_0 + 1;
		*/
        }



        public void WriteRegistro0020()
        {/*

		            retorno = Funcoes.LFill("0020") +
		                Funcoes.LFill(IND_DEC, 1) +
		                Funcoes.LFill(CNPJ) +
		                Funcoes.LFill(UF) +
		                Funcoes.LFill(IE) +
		                Funcoes.LFill(COD_MUN, 7) +
		                Funcoes.LFill(IM) +
		                Funcoes.LFill(NIRE, 11)
		                );
		        }
		        FRegistro0990.QTD_LIN_0 = FRegistro0990.QTD_LIN_0 + 1;
		*/
        }



        public void WriteRegistro0035()
        {/*
		 
		           
		            retorno = Funcoes.LFill("0035") +
		                Funcoes.LFill(COD_SCP) +
		                Funcoes.LFill(NOME_SCP)
						);
		        }
		        FRegistro0990.QTD_LIN_0 = FRegistro0990.QTD_LIN_0 + 1;

		*/
        }


        public void WriteRegistro0150()
        {/*
		            retorno = Funcoes.LFill("0150") +
		                Funcoes.LFill(COD_PART) +
		                Funcoes.LFill(NOME) +
		                Funcoes.LFill(COD_PAIS, 5) +
		                Funcoes.LFill(CNPJ) +
		                Funcoes.LFill(CPF) +
		                Funcoes.LFill(NIT, 11) +
		                Funcoes.LFill(UF) +
		                Funcoes.LFill(IE) +
		                Funcoes.LFill(IE_ST) +
		                Funcoes.LFill(COD_MUN, 7) +
		                Funcoes.LFill(IM) +
		                Funcoes.LFill(SUFRAMA, 9)
		                );
		
		        FRegistro0990.QTD_LIN_0 = FRegistro0990.QTD_LIN_0 + 1;
		*/
        }

        public string WriteRegistro0990()
        {
            string strLinha = "";
            if (Assigned(FRegistro0990))
            {
                FRegistro0990.QTD_LIN_0 = FRegistro0990.QTD_LIN_0 + 1;
                // /
                strLinha = Funcoes.LFill("0990") +
                          Funcoes.LFill(FRegistro0990.QTD_LIN_0, 0);

            }
            return strLinha;
        }
    }


}

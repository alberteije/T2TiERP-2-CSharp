using System;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    #region Enumerado

    public enum EnumEspecieDocumento_Santander
    {
        DuplicataMercantil = 2,
        DuplicataServico = 4,
        LetraCambio353 = 7,
        LetraCambio008 = 30,
        NotaPromissoria = 12,
        NotaPromissoriaRural = 13,
        Recibo = 17,
        ApoliceSeguro = 20,
        Cheque = 97,
        NotaPromissoariaDireta = 98
         //02   DM - DUPLICATA MERCANTIL                 
         //04   DS - DUPLICATA DE SERVICO                
         //07	LC - LETRA DE CÂMBIO (SOMENTE PARA BANCO 353)
         //30	LC - LETRA DE CÂMBIO (SOMENTE PARA BANCO 008)
         //12   NP - NOTA PROMISSORIA                    
         //13	NR - NOTA PROMISSORIA RURAL 
         //17   RC - RECIBO                              
         //20   AP – APOLICE DE SEGURO                   
         //97	CH – CHEQUE
         //98	ND - NOTA PROMISSORIA DIRETA
    }

    #endregion

    public class EspecieDocumento_Santander : AbstractEspecieDocumento, IEspecieDocumento
    {
        #region Construtores

        public EspecieDocumento_Santander()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        public EspecieDocumento_Santander(int codigo)
        {
            try
            {
                this.carregar(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        #endregion

        #region Metodos Privados

        private void carregar(int idCodigo)
        {
            try
            {
                this.Banco = new Banco_Santander();

                switch ((EnumEspecieDocumento_Santander)idCodigo)
                {
                    case EnumEspecieDocumento_Santander.DuplicataMercantil:
                        this.Codigo = (int)EnumEspecieDocumento_Sudameris.DuplicataMercantil;
                        this.Especie = "Duplicata Mercantil";
                        this.Sigla = "DM";
                        break;
                    case EnumEspecieDocumento_Santander.DuplicataServico:
                        this.Codigo = (int)EnumEspecieDocumento_Sudameris.DuplicataServico;
                        this.Especie = "Duplicata de Serviço";
                        this.Sigla = "DS";
                        break;
                    case EnumEspecieDocumento_Santander.Recibo:
                        this.Codigo = (int)EnumEspecieDocumento_Sudameris.Recibo;
                        this.Especie = "Recibo";
                        this.Sigla = "R";
                        break;
                    case EnumEspecieDocumento_Santander.LetraCambio353:
                        this.Codigo = (int)EnumEspecieDocumento_Santander.LetraCambio353;
                        this.Especie = "Letra de Câmbio (Somente para o banco 353)";
                        this.Sigla = "LS";
                        break;
                    case EnumEspecieDocumento_Santander.LetraCambio008:
                        this.Codigo = (int)EnumEspecieDocumento_Santander.LetraCambio008;
                        this.Especie = "Letra de Câmbio (Somente para o banco 008)";
                        this.Sigla = "LS";
                        break;
                    case EnumEspecieDocumento_Santander.ApoliceSeguro:
                        this.Codigo = (int)EnumEspecieDocumento_Santander.ApoliceSeguro;
                        this.Especie = "Apôlice de Seguro";
                        this.Sigla = "AP";
                        break;
                    case EnumEspecieDocumento_Santander.NotaPromissoariaDireta:
                        this.Codigo = (int)EnumEspecieDocumento_Santander.NotaPromissoariaDireta;
                        this.Especie = "Nota Promissória Direta";
                        this.Sigla = "ND";
                        break;
                    case EnumEspecieDocumento_Santander.NotaPromissoria:
                        this.Codigo = (int)EnumEspecieDocumento_Santander.NotaPromissoria;
                        this.Especie = "Nota Promissória";
                        this.Sigla = "NP";
                        break;
                    case EnumEspecieDocumento_Santander.NotaPromissoriaRural:
                        this.Codigo = (int)EnumEspecieDocumento_Santander.NotaPromissoriaRural;
                        this.Especie = "Nota Promissória Rural";
                        this.Sigla = "NR";
                        break;
                    case EnumEspecieDocumento_Santander.Cheque:
                        this.Codigo = (int)EnumEspecieDocumento_Santander.Cheque;
                        this.Especie = "Cheque";
                        this.Sigla = "CH";
                        break;
                    default:
                        this.Codigo = 0;
                        this.Especie = "";
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        public static EspeciesDocumento CarregaTodas()
        {
            EspeciesDocumento especiesDocumento = new EspeciesDocumento();

            foreach (EnumEspecieDocumento_Santander item in Enum.GetValues(typeof(EnumEspecieDocumento_Santander)))
                especiesDocumento.Add(new EspecieDocumento_Santander((int)item));

            return especiesDocumento;
        }

        #endregion
    }
}

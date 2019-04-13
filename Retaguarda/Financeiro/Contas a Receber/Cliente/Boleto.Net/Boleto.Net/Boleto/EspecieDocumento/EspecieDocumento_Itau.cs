using System;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    #region Enumerado

    public enum EnumEspecieDocumento_Itau
    {
        DuplicataMercantil = 1,
        NotaPromissoria = 2,
        NotaSeguro = 3,
        MensalidadeEscolar = 4,
        Recibo = 5,
        Contrato = 6,
        Cosseguros = 7,
        DuplicataServico = 8,
        LetraCambio = 9,
        NotaDebito = 13,
        DocumentoDivida = 15,
        EncargosCondominais = 16,
        Diversos = 99,
    }

    #endregion

    public class EspecieDocumento_Itau : AbstractEspecieDocumento, IEspecieDocumento
    {
        #region Construtores

        public EspecieDocumento_Itau()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        public EspecieDocumento_Itau(int codigo)
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
                this.Banco = new Banco_Itau();

                switch ((EnumEspecieDocumento_Itau)idCodigo)
                {
                    case EnumEspecieDocumento_Itau.DuplicataMercantil:
                        this.Codigo = (int)EnumEspecieDocumento_Itau.DuplicataMercantil;
                        this.Especie = "Duplicata mercantil";
                        this.Sigla = "DM";
                        break;
                    case EnumEspecieDocumento_Itau.NotaPromissoria:
                        this.Codigo = (int)EnumEspecieDocumento_Itau.NotaPromissoria;
                        this.Especie = "Nota promissória";
                        this.Sigla = "NP";
                        break;
                    case EnumEspecieDocumento_Itau.NotaSeguro:
                        this.Codigo = (int)EnumEspecieDocumento_Itau.NotaSeguro;
                        this.Especie = "Nota de seguro";
                        this.Sigla = "NS";
                        break;
                    case EnumEspecieDocumento_Itau.MensalidadeEscolar:
                        this.Codigo = (int)EnumEspecieDocumento_Itau.MensalidadeEscolar;
                        this.Especie = "Mensalidade escolar";
                        this.Sigla = "ME";
                        break;
                    case EnumEspecieDocumento_Itau.Recibo:
                        this.Codigo = (int)EnumEspecieDocumento_Itau.Recibo;
                        this.Especie = "Recibo";
                        this.Sigla = "NS";
                        break;
                    case EnumEspecieDocumento_Itau.Contrato:
                        this.Codigo = (int)EnumEspecieDocumento_Itau.Contrato;
                        this.Sigla = "C";
                        this.Especie = "Contrato";
                        break;
                    case EnumEspecieDocumento_Itau.Cosseguros:
                        this.Codigo = (int)EnumEspecieDocumento_Itau.Cosseguros;
                        this.Sigla = "CS";
                        this.Especie = "Cosseguros";
                        break;
                    case EnumEspecieDocumento_Itau.DuplicataServico:
                        this.Codigo = (int)EnumEspecieDocumento_Itau.DuplicataServico;
                        this.Sigla = "DS";
                        this.Especie = "Duplicata de serviço";
                        break;
                    case EnumEspecieDocumento_Itau.LetraCambio:
                        this.Codigo = (int)EnumEspecieDocumento_Itau.LetraCambio;
                        this.Sigla = "LC";
                        this.Especie = "Letra de câmbio";
                        break;
                    case EnumEspecieDocumento_Itau.NotaDebito:
                        this.Codigo = (int)EnumEspecieDocumento_Itau.NotaDebito;
                        this.Sigla = "ND";
                        this.Especie = "Nota de débito";
                        break;
                    case EnumEspecieDocumento_Itau.DocumentoDivida:
                        this.Codigo = (int)EnumEspecieDocumento_Itau.DocumentoDivida;
                        this.Sigla = "DD";
                        this.Especie = "Documento de dívida";
                        break;
                    case EnumEspecieDocumento_Itau.EncargosCondominais:
                        this.Codigo = (int)EnumEspecieDocumento_Itau.EncargosCondominais;
                        this.Sigla = "EC";
                        this.Especie = "Encargos condominais";
                        break;
                    case EnumEspecieDocumento_Itau.Diversos:
                        this.Codigo = (int)EnumEspecieDocumento_Itau.Diversos;
                        this.Especie = "Diversos";
                        break;
                    default:
                        this.Codigo = 0;
                        this.Especie = "( Selecione )";
                        this.Sigla = "";
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

            foreach (EnumEspecieDocumento_Itau item in Enum.GetValues(typeof(EnumEspecieDocumento_Itau)))
                especiesDocumento.Add(new EspecieDocumento_Itau((int)item));

            return especiesDocumento;
        }

        #endregion
    }
}

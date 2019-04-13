using System;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    #region Enumerado

    public enum EnumEspecieDocumento_Sudameris
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

    public class EspecieDocumento_Sudameris: AbstractEspecieDocumento, IEspecieDocumento
    {
        #region Construtores 

		public EspecieDocumento_Sudameris()
		{
			try
			{
			}
			catch (Exception ex)
			{
                throw new Exception("Erro ao carregar objeto", ex);
			}
		}

        public EspecieDocumento_Sudameris(int codigo)
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
                this.Banco = new Banco_Sudameris();

                switch ((EnumEspecieDocumento_Sudameris)idCodigo)
                {
                    case  EnumEspecieDocumento_Sudameris.DuplicataMercantil:
                        this.Codigo = (int)EnumEspecieDocumento_Sudameris.DuplicataMercantil;
                        this.Especie = "Duplicata mercantil";
                        this.Sigla = "DM";
                        break;
                    case EnumEspecieDocumento_Sudameris.NotaPromissoria:
                        this.Codigo = (int)EnumEspecieDocumento_Sudameris.NotaPromissoria;
                        this.Especie = "Nota promissória";
                        this.Sigla = "NP";
                        break;
                    case EnumEspecieDocumento_Sudameris.NotaSeguro:
                        this.Codigo = (int)EnumEspecieDocumento_Sudameris.NotaSeguro;
                        this.Especie = "Nota de seguro";
                        this.Sigla = "NS";
                        break;
                    case EnumEspecieDocumento_Sudameris.MensalidadeEscolar:
                        this.Codigo = (int)EnumEspecieDocumento_Sudameris.MensalidadeEscolar;
                        this.Especie = "Mensalidade escolar";
                        this.Sigla = "ME";
                        break;
                    case EnumEspecieDocumento_Sudameris.Recibo:
                        this.Codigo = (int)EnumEspecieDocumento_Sudameris.Recibo;
                        this.Especie = "Recibo";
                        this.Sigla = "R";
                        break;
                    case EnumEspecieDocumento_Sudameris.Contrato:
                        this.Codigo = (int)EnumEspecieDocumento_Sudameris.Contrato;
                        this.Especie = "Contrato";
                        this.Sigla = "C";
                        break;
                    case EnumEspecieDocumento_Sudameris.Cosseguros:
                        this.Codigo = (int)EnumEspecieDocumento_Sudameris.Cosseguros;
                        this.Especie = "Cosseguros";
                        this.Sigla = "CS";
                        break;
                    case EnumEspecieDocumento_Sudameris.DuplicataServico:
                        this.Codigo = (int)EnumEspecieDocumento_Sudameris.DuplicataServico;
                        this.Especie = "Duplicata de serviço";
                        this.Sigla = "DS";
                        break;
                    case EnumEspecieDocumento_Sudameris.LetraCambio:
                        this.Codigo = (int)EnumEspecieDocumento_Sudameris.LetraCambio;
                        this.Especie = "Letra de câmbio";
                        this.Sigla = "LC";
                        break;
                    case EnumEspecieDocumento_Sudameris.NotaDebito:
                        this.Codigo = (int)EnumEspecieDocumento_Sudameris.NotaDebito;
                        this.Especie = "Nota de débito";
                        this.Sigla = "ND";
                        break;
                    case EnumEspecieDocumento_Sudameris.DocumentoDivida:
                        this.Codigo = (int)EnumEspecieDocumento_Sudameris.DocumentoDivida;
                        this.Especie = "Documento de dívida";
                        this.Sigla = "DD";
                        break;
                    case EnumEspecieDocumento_Sudameris.EncargosCondominais:
                        this.Codigo = (int)EnumEspecieDocumento_Sudameris.EncargosCondominais;
                        this.Especie = "Encargos condominais";
                        this.Sigla = "EC";
                        break;
                    case EnumEspecieDocumento_Sudameris.Diversos:
                        this.Codigo = (int)EnumEspecieDocumento_Sudameris.Diversos;
                        this.Especie = "Diversos";
                        this.Sigla = "D";
                        break;
                    default:
                        this.Codigo = 0;
                        this.Especie = "( Selecione )";
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

            foreach (EnumEspecieDocumento_Sudameris item in Enum.GetValues(typeof(EnumEspecieDocumento_Sudameris)))
                especiesDocumento.Add(new EspecieDocumento_Sudameris((int)item));

            return especiesDocumento;
        }

        #endregion
    }
}

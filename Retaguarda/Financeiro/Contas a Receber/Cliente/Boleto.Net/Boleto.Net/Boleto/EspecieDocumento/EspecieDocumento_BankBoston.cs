using System;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    #region Enumerado

    public enum EnumEspecieDocumento_BankBoston
    {
        DuplicataMercantil = 1,
        DuplicataServico = 2,
        NotaSeguro = 3,
        ReciboEscolar = 4,
        ReciboAssociacao = 5,
        ReciboCondominio = 6,
        NotaDebito = 7,
        Outros = 8,
    }

    #endregion 

    public class EspecieDocumento_BankBoston: AbstractEspecieDocumento, IEspecieDocumento
    {
        #region Construtores 

		public EspecieDocumento_BankBoston()
		{
			try
			{
			}
			catch (Exception ex)
			{
                throw new Exception("Erro ao carregar objeto", ex);
			}
		}

        public EspecieDocumento_BankBoston(int codigo)
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

        private void carregar(int Codigo)
        {
            try
            {
                this.Banco = new Banco_BankBoston();

                switch ((EnumEspecieDocumento_BankBoston)Codigo)
                {
                    case  EnumEspecieDocumento_BankBoston.DuplicataMercantil:
                        this.Codigo = (int)EnumEspecieDocumento_BankBoston.DuplicataMercantil;
                        this.Sigla = "DM";
                        this.Especie = "Duplicata mercantil";
                        break;
                    case EnumEspecieDocumento_BankBoston.DuplicataServico:
                        this.Codigo = (int)EnumEspecieDocumento_BankBoston.DuplicataServico;
                        this.Sigla = "DS";
                        this.Especie = "Duplicata de serviço";
                        break;
                    case EnumEspecieDocumento_BankBoston.NotaSeguro:
                        this.Codigo = (int)EnumEspecieDocumento_BankBoston.NotaSeguro;
                        this.Sigla = "NS";
                        this.Especie = "Nota de seguro";
                        break;
                    case EnumEspecieDocumento_BankBoston.ReciboEscolar:
                        this.Codigo = (int)EnumEspecieDocumento_BankBoston.ReciboEscolar;
                        this.Sigla = "RE";
                        this.Especie = "Reciboescolar";
                        break;
                    case EnumEspecieDocumento_BankBoston.ReciboAssociacao:
                        this.Codigo = (int)EnumEspecieDocumento_BankBoston.ReciboAssociacao;
                        this.Sigla = "RS";
                        this.Especie = "Recibo Associação";
                        break;
                    case EnumEspecieDocumento_BankBoston.ReciboCondominio:
                        this.Codigo = (int)EnumEspecieDocumento_BankBoston.ReciboCondominio;
                        this.Sigla = "RC";
                        this.Especie = "Contrato";
                        break;
                    case EnumEspecieDocumento_BankBoston.NotaDebito:
                        this.Codigo = (int)EnumEspecieDocumento_BankBoston.NotaDebito;
                        this.Sigla = "ND";
                        this.Especie = "Nota débito";
                        break;
                    case EnumEspecieDocumento_BankBoston.Outros:
                        this.Codigo = (int)EnumEspecieDocumento_BankBoston.Outros;
                        this.Sigla = "OT";
                        this.Especie = "Outros";
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

            foreach (EnumEspecieDocumento_BankBoston item in Enum.GetValues(typeof(EnumEspecieDocumento_BankBoston)))
                especiesDocumento.Add(new EspecieDocumento_BankBoston((int)item));

            return especiesDocumento;
        }

        #endregion
    }
}

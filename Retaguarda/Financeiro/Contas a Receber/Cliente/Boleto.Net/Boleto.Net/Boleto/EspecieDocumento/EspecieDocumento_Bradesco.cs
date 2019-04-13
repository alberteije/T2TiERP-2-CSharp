using System;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    #region Enumerado

    public enum EnumEspecieDocumento_Bradesco
    {
        DuplicataMercantil = 1,
        NotaPromissoria = 2,
        NotaSeguro = 3,
        CobrancaSeriada = 4,
        Recibo = 5,
        LetraCambio = 10,
        NotaDebito = 11,
        DuplicataServico = 12,
        Outros = 99,
    }

    #endregion

    public class EspecieDocumento_Bradesco : AbstractEspecieDocumento, IEspecieDocumento
    {
        #region Construtores

        public EspecieDocumento_Bradesco()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        public EspecieDocumento_Bradesco(int codigo)
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
                this.Banco = new Banco_Bradesco();

                switch ((EnumEspecieDocumento_Bradesco)idCodigo)
                {
                    case EnumEspecieDocumento_Bradesco.DuplicataMercantil:
                        this.Codigo = (int)EnumEspecieDocumento_Bradesco.DuplicataMercantil;
                        this.Especie = "Duplicata mercantil";
                        this.Sigla = "DM";
                        break;
                    case EnumEspecieDocumento_Bradesco.NotaPromissoria:
                        this.Codigo = (int)EnumEspecieDocumento_Bradesco.NotaPromissoria;
                        this.Especie = "Nota promissória";
                        this.Sigla = "NP";
                        break;
                    case EnumEspecieDocumento_Bradesco.NotaSeguro:
                        this.Codigo = (int)EnumEspecieDocumento_Bradesco.NotaSeguro;
                        this.Especie = "Nota de seguro";
                        this.Sigla = "NS";
                        break;
                    case EnumEspecieDocumento_Bradesco.CobrancaSeriada:
                        this.Codigo = (int)EnumEspecieDocumento_Bradesco.CobrancaSeriada;
                        this.Especie = "Cobrança seriada";
                        this.Sigla = "CS";
                        break;
                    case EnumEspecieDocumento_Bradesco.Recibo:
                        this.Codigo = (int)EnumEspecieDocumento_Bradesco.Recibo;
                        this.Especie = "Recibo";
                        this.Sigla = "RC";
                        break;
                    case EnumEspecieDocumento_Bradesco.LetraCambio:
                        this.Codigo = (int)EnumEspecieDocumento_Bradesco.LetraCambio;
                        this.Sigla = "LC";
                        this.Especie = "Letra de câmbio";
                        break;
                    case EnumEspecieDocumento_Bradesco.NotaDebito:
                        this.Codigo = (int)EnumEspecieDocumento_Bradesco.NotaDebito;
                        this.Sigla = "ND";
                        this.Especie = "Nota de débito";
                        break;
                    case EnumEspecieDocumento_Bradesco.DuplicataServico:
                        this.Codigo = (int)EnumEspecieDocumento_Bradesco.DuplicataServico;
                        this.Sigla = "DS";
                        this.Especie = "Duplicata de serviço";
                        break;
                    case EnumEspecieDocumento_Bradesco.Outros:
                        this.Codigo = (int)EnumEspecieDocumento_Bradesco.Outros;
                        this.Especie = "Outros";
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
            try
            {
                EspeciesDocumento alEspeciesDocumento = new EspeciesDocumento();

                EspecieDocumento_Bradesco obj;

                obj = new EspecieDocumento_Bradesco((int)EnumEspecieDocumento_Bradesco.DuplicataMercantil);
                alEspeciesDocumento.Add(obj);

                obj = new EspecieDocumento_Bradesco((int)EnumEspecieDocumento_Bradesco.NotaPromissoria);
                alEspeciesDocumento.Add(obj);

                obj = new EspecieDocumento_Bradesco((int)EnumEspecieDocumento_Bradesco.NotaSeguro);
                alEspeciesDocumento.Add(obj);

                obj = new EspecieDocumento_Bradesco((int)EnumEspecieDocumento_Bradesco.CobrancaSeriada);
                alEspeciesDocumento.Add(obj);

                obj = new EspecieDocumento_Bradesco((int)EnumEspecieDocumento_Bradesco.Recibo);
                alEspeciesDocumento.Add(obj);

                obj = new EspecieDocumento_Bradesco((int)EnumEspecieDocumento_Bradesco.LetraCambio);
                alEspeciesDocumento.Add(obj);

                obj = new EspecieDocumento_Bradesco((int)EnumEspecieDocumento_Bradesco.NotaDebito);
                alEspeciesDocumento.Add(obj);

                obj = new EspecieDocumento_Bradesco((int)EnumEspecieDocumento_Bradesco.DuplicataServico);
                alEspeciesDocumento.Add(obj);

                obj = new EspecieDocumento_Bradesco((int)EnumEspecieDocumento_Bradesco.Outros);
                alEspeciesDocumento.Add(obj);

                return alEspeciesDocumento;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar objetos", ex);
            }
        }

        #endregion
    }
}
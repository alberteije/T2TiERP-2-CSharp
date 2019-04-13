using System;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    #region Enumerado

    public enum EnumEspecieDocumento_Real
    {
        Cheque = 1,
        DuplicataMercantil = 2,
        DuplicataMercantilIndicacao = 3,
        DuplicataServico = 4,
        DuplicataServiçoIndicacao = 5,
        DuplicataRural = 6,
        LetraCambio = 7,
        NotaCreditoComercial = 8,
        NotaCreditoExportacao = 9,
        NotaCreditoIndustrial = 10,
        NotaCreditoRural = 11,
        NotaPromissoria = 12,
        NotaPromissoriaRural = 13,
        TriplicataMercantil = 14,
        TriplicataServico = 15,
        NotaSeguro = 16,
        Recibo = 17,
        Fatura = 18,
        NotaDebito = 19,
        ApoliceSeguro = 20,
        MensalidadeEscolar = 21,
        ParcelaConsorcio = 22,
        IdentificacaoTituloAceitoNaoAceito = 23,
    }

    #endregion

    public class EspecieDocumento_Real : AbstractEspecieDocumento, IEspecieDocumento
    {
        #region Construtores

        public EspecieDocumento_Real()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        public EspecieDocumento_Real(int codigo)
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
                this.Banco = new Banco_Real();

                  switch ((EnumEspecieDocumento_Real)idCodigo)
                {
                   case EnumEspecieDocumento_Real.IdentificacaoTituloAceitoNaoAceito:
                        this.Codigo = (int)EnumEspecieDocumento_Real.IdentificacaoTituloAceitoNaoAceito;
                        this.Especie = "Identificação de Título Aceito / Não Aceito";
                        this.Sigla = "C016";
                        break;
                    case EnumEspecieDocumento_Real.ParcelaConsorcio:
                        this.Codigo = (int)EnumEspecieDocumento_Real.ParcelaConsorcio;
                        this.Especie = "Parcela de Consórcio";
                        this.Sigla = "PC";
                        break;
                    case EnumEspecieDocumento_Real.MensalidadeEscolar:
                        this.Codigo = (int)EnumEspecieDocumento_Real.MensalidadeEscolar;
                        this.Especie = "Mensalidade Escolar";
                        this.Sigla = "ME";
                        break;
                    case EnumEspecieDocumento_Real.ApoliceSeguro:
                        this.Codigo = (int)EnumEspecieDocumento_Real.ApoliceSeguro;
                        this.Especie = "Apólice de Seguro";
                        this.Sigla = "AP";
                        break;
                    case EnumEspecieDocumento_Real.NotaDebito:
                        this.Codigo = (int)EnumEspecieDocumento_Real.NotaDebito;
                        this.Especie = "Nota de Débito";
                        this.Sigla = "ND";
                        break;
                    case EnumEspecieDocumento_Real.Fatura:
                        this.Codigo = (int)EnumEspecieDocumento_Real.Fatura;
                        this.Especie = "Fatura";
                        this.Sigla = "FAT";
                        break;
                    case EnumEspecieDocumento_Real.NotaSeguro:
                        this.Codigo = (int)EnumEspecieDocumento_Real.NotaSeguro;
                        this.Especie = "Nota de Seguro";
                        this.Sigla = "NS";
                        break;
                    case EnumEspecieDocumento_Real.TriplicataMercantil:
                        this.Codigo = (int)EnumEspecieDocumento_Real.TriplicataMercantil;
                        this.Especie = "Triplicata Mercantil";
                        this.Sigla = "TM";
                        break;
                    case EnumEspecieDocumento_Real.TriplicataServico:
                        this.Codigo = (int)EnumEspecieDocumento_Real.TriplicataServico;
                        this.Especie = "Triplicata de Serviço";
                        this.Sigla = "TS";
                        break;
                    case EnumEspecieDocumento_Real.NotaPromissoriaRural:
                        this.Codigo = (int)EnumEspecieDocumento_Real.NotaPromissoriaRural;
                        this.Especie = "Nota Promissória Rural";
                        this.Sigla = "NPR";
                        break;
                    case EnumEspecieDocumento_Real.NotaCreditoRural:
                        this.Codigo = (int)EnumEspecieDocumento_Real.NotaCreditoRural;
                        this.Especie = "Nota de Crédito Rural";
                        this.Sigla = "NCR";
                        break;
                    case EnumEspecieDocumento_Real.NotaCreditoExportacao:
                        this.Codigo = (int)EnumEspecieDocumento_Real.NotaCreditoExportacao;
                        this.Especie = "Nota de Crédito a Exportação";
                        this.Sigla = "NCE";
                        break;
                    case EnumEspecieDocumento_Real.NotaCreditoIndustrial:
                        this.Codigo = (int)EnumEspecieDocumento_Real.NotaCreditoIndustrial;
                        this.Especie = "Nota de Crédito Industrial";
                        this.Sigla = "NCI";
                        break;
                    case EnumEspecieDocumento_Real.NotaCreditoComercial:
                        this.Codigo = (int)EnumEspecieDocumento_Real.NotaCreditoComercial;
                        this.Especie = "Nota de Crédito Comercial";
                        this.Sigla = "NCC";
                        break;
                    case EnumEspecieDocumento_Real.Cheque:
                        this.Codigo = (int)EnumEspecieDocumento_Real.Cheque;
                        this.Especie = "Cheque";
                        this.Sigla = "CH";
                        break;
                    case EnumEspecieDocumento_Real.DuplicataMercantil:
                        this.Codigo = (int)EnumEspecieDocumento_Real.DuplicataMercantil;
                        this.Especie = "Duplicata mercantil";
                        this.Sigla = "DM";
                        break;
                    case EnumEspecieDocumento_Real.DuplicataMercantilIndicacao:
                        this.Codigo = (int)EnumEspecieDocumento_Real.DuplicataMercantilIndicacao;
                        this.Especie = "Duplicata Mercantil p/ Indicação";
                        this.Sigla = "DMI";
                        break;
                    case EnumEspecieDocumento_Real.DuplicataServico:
                        this.Codigo = (int)EnumEspecieDocumento_Real.DuplicataServico;
                        this.Especie = "Duplicata Serviço";
                        this.Sigla = "DS";
                        break;
                    case EnumEspecieDocumento_Real.DuplicataServiçoIndicacao:
                        this.Codigo = (int)EnumEspecieDocumento_Real.DuplicataServiçoIndicacao;
                        this.Especie = "Duplicata Serviços p/ Indicação";
                        this.Sigla = "DSI";
                        break;
                    case EnumEspecieDocumento_Real.DuplicataRural:
                        this.Codigo = (int)EnumEspecieDocumento_Real.DuplicataRural;
                        this.Especie = "Duplicata Rural";
                        this.Sigla = "DR";
                        break;
                    case EnumEspecieDocumento_Real.NotaPromissoria:
                        this.Codigo = (int)EnumEspecieDocumento_Real.NotaPromissoria;
                        this.Especie = "Nota promissória";
                        this.Sigla = "NP";
                        break;
                    case EnumEspecieDocumento_Real.Recibo:
                        this.Codigo = (int)EnumEspecieDocumento_Real.Recibo;
                        this.Especie = "Recibo";
                        this.Sigla = "NS";
                        break;
                    case EnumEspecieDocumento_Real.LetraCambio:
                        this.Codigo = (int)EnumEspecieDocumento_Real.LetraCambio;
                        this.Sigla = "LC";
                        this.Especie = "Letra de câmbio";
                        break;
                    default:
                        this.Codigo = 0;
                        this.Especie = "";
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

            foreach (EnumEspecieDocumento_Real item in Enum.GetValues(typeof(EnumEspecieDocumento_Real)))
                especiesDocumento.Add(new EspecieDocumento_Real((int)item));

            return especiesDocumento;
        }

        #endregion
    }
}

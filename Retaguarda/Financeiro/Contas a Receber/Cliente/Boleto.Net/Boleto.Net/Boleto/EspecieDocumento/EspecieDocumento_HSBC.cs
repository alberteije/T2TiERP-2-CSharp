using System;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    #region Enumerado

    public enum EnumEspecieDocumento_HSBC
    {
        Cheque = 1, //CH – CHEQUE
        DuplicataMercantil = 2, //DM – DUPLICATA MERCANTIL
        DuplicataMercantilIndicacao = 3, //DMI – DUPLICATA MERCANTIL P/ INDICAÇÃO
        DuplicataServico = 4, //DS –  DUPLICATA DE SERVIÇO
        DuplicataServicoIndicacao = 5, //DSI –  DUPLICATA DE SERVIÇO P/ INDICAÇÃO
        DuplicataRural = 6, //DR – DUPLICATA RURAL
        LetraCambio = 7, //LC – LETRA DE CAMBIO
        NotaCreditoComercial = 8, //NCC – NOTA DE CRÉDITO COMERCIAL
        NotaCreditoExportacao = 9, //NCE – NOTA DE CRÉDITO A EXPORTAÇÃO
        NotaCreditoIndustrial = 10, //NCI – NOTA DE CRÉDITO INDUSTRIAL
        NotaCreditoRural = 11, //NCR – NOTA DE CRÉDITO RURAL
        NotaPromissoria = 12, //NP – NOTA PROMISSÓRIA
        NotaPromissoriaRural = 13, //NPR –NOTA PROMISSÓRIA RURAL
        TriplicataMercantil = 14, //TM – TRIPLICATA MERCANTIL
        TriplicataServico = 15, //TS –  TRIPLICATA DE SERVIÇO
        NotaSeguro = 16, //NS – NOTA DE SEGURO
        Recibo = 17, //RC – RECIBO
        Fatura = 18, //FAT – FATURA
        NotaDebito = 19, //ND –  NOTA DE DÉBITO
        ApoliceSeguro = 20, //AP –  APÓLICE DE SEGURO
        MensalidadeEscolar = 21, //ME – MENSALIDADE ESCOLAR
        ParcelaConsorcio = 22, //PC –  PARCELA DE CONSÓRCIO
        NotaFiscal = 23, //NF-Nota Fiscal
        DocumentoDivida = 24, //DD-Documento de Dívida
        Outros = 99 //Outros
    }

    #endregion

    public class EspecieDocumento_HSBC : AbstractEspecieDocumento, IEspecieDocumento
    {
        #region Construtores

        public EspecieDocumento_HSBC()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        public EspecieDocumento_HSBC(int codigo)
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
                this.Banco = new Banco_Brasil();

                switch ((EnumEspecieDocumento_HSBC)idCodigo)
                {
                    case EnumEspecieDocumento_HSBC.Cheque:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.Cheque;
                        this.Especie = "CHEQUE";
                        this.Sigla = "CH";
                        break;
                    case EnumEspecieDocumento_HSBC.DuplicataMercantil:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.DuplicataMercantil;
                        this.Especie = "DUPLICATA MERCANTIL";
                        this.Sigla = "DM";
                        break;
                    case EnumEspecieDocumento_HSBC.DuplicataMercantilIndicacao:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.DuplicataMercantilIndicacao;
                        this.Especie = "DUPLICATA MERCANTIL P/ INDICAÇÃO";
                        this.Sigla = "DMI";
                        break;
                    case EnumEspecieDocumento_HSBC.DuplicataServico:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.DuplicataServico;
                        this.Especie = "DUPLICATA DE SERVIÇO";
                        this.Sigla = "DS";
                        break;
                    case EnumEspecieDocumento_HSBC.DuplicataServicoIndicacao:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.DuplicataServicoIndicacao;
                        this.Especie = "DUPLICATA DE SERVIÇO P/ INDICAÇÃO";
                        this.Sigla = "DSI";
                        break;
                    case EnumEspecieDocumento_HSBC.DuplicataRural:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.DuplicataRural;
                        this.Especie = "DUPLICATA RURAL";
                        this.Sigla = "DR";
                        break;
                    case EnumEspecieDocumento_HSBC.LetraCambio:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.LetraCambio;
                        this.Especie = "LETRA DE CAMBIO";
                        this.Sigla = "LC";
                        break;
                    case EnumEspecieDocumento_HSBC.NotaCreditoComercial:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.NotaCreditoComercial;
                        this.Especie = "NOTA DE CRÉDITO COMERCIAL";
                        this.Sigla = "NCC";
                        break;
                    case EnumEspecieDocumento_HSBC.NotaCreditoExportacao:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.NotaCreditoExportacao;
                        this.Especie = "NOTA DE CRÉDITO A EXPORTAÇÃO";
                        this.Sigla = "NCE";
                        break;
                    case EnumEspecieDocumento_HSBC.NotaCreditoIndustrial:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.NotaCreditoIndustrial;
                        this.Especie = "NOTA DE CRÉDITO INDUSTRIAL";
                        this.Sigla = "NCI";
                        break;
                    case EnumEspecieDocumento_HSBC.NotaCreditoRural:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.NotaCreditoRural;
                        this.Especie = "NOTA DE CRÉDITO RURAL";
                        this.Sigla = "NCR";
                        break;
                    case EnumEspecieDocumento_HSBC.NotaPromissoria:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.NotaPromissoria;
                        this.Especie = "NOTA PROMISSÓRIA";
                        this.Sigla = "NP";
                        break;
                    case EnumEspecieDocumento_HSBC.NotaPromissoriaRural:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.NotaPromissoriaRural;
                        this.Especie = "NOTA PROMISSÓRIA RURAL";
                        this.Sigla = "NPR";
                        break;
                    case EnumEspecieDocumento_HSBC.TriplicataMercantil:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.TriplicataMercantil;
                        this.Especie = "TRIPLICATA MERCANTIL";
                        this.Sigla = "TM";
                        break;
                    case EnumEspecieDocumento_HSBC.TriplicataServico:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.TriplicataServico;
                        this.Especie = "TRIPLICATA DE SERVIÇO";
                        this.Sigla = "TS";
                        break;
                    case EnumEspecieDocumento_HSBC.NotaSeguro:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.NotaSeguro;
                        this.Especie = "NOTA DE SEGURO";
                        this.Sigla = "NS";
                        break;
                    case EnumEspecieDocumento_HSBC.Recibo:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.Recibo;
                        this.Especie = "RECIBO";
                        this.Sigla = "RC";
                        break;
                    case EnumEspecieDocumento_HSBC.Fatura:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.Fatura;
                        this.Especie = "FATURA";
                        this.Sigla = "FAT";
                        break;
                    case EnumEspecieDocumento_HSBC.NotaDebito:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.NotaDebito;
                        this.Especie = "NOTA DE DÉBITO";
                        this.Sigla = "ND";
                        break;
                    case EnumEspecieDocumento_HSBC.ApoliceSeguro:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.ApoliceSeguro;
                        this.Especie = "APÓLICE DE SEGURO";
                        this.Sigla = "AP";
                        break;
                    case EnumEspecieDocumento_HSBC.MensalidadeEscolar:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.MensalidadeEscolar;
                        this.Especie = "MENSALIDADE ESCOLAR";
                        this.Sigla = "ME";
                        break;
                    case EnumEspecieDocumento_HSBC.ParcelaConsorcio:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.ParcelaConsorcio;
                        this.Especie = "PARCELA DE CONSÓRCIO";
                        this.Sigla = "PC";
                        break;
                    case EnumEspecieDocumento_HSBC.NotaFiscal:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.NotaFiscal;
                        this.Especie = "NOTA FISCAL";
                        this.Sigla = "NF";
                        break;
                    case EnumEspecieDocumento_HSBC.DocumentoDivida:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.DocumentoDivida;
                        this.Especie = "DOCUMENTO DE DIVIDA";
                        this.Sigla = "DD";
                        break;
                    case EnumEspecieDocumento_HSBC.Outros:
                        this.Codigo = (int)EnumEspecieDocumento_HSBC.Outros;
                        this.Especie = "OUTROS";
                        this.Sigla = "OUTROS";
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
            try
            {
                EspeciesDocumento alEspeciesDocumento = new EspeciesDocumento();

                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.Cheque));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.DuplicataMercantil));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.DuplicataMercantilIndicacao));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.DuplicataServico));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.DuplicataServicoIndicacao));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.DuplicataRural));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.LetraCambio));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.NotaCreditoComercial));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.NotaCreditoExportacao));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.NotaCreditoIndustrial));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.NotaCreditoRural));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.NotaPromissoria));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.NotaPromissoriaRural));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.TriplicataMercantil));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.TriplicataServico));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.NotaSeguro));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.Recibo));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.Fatura));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.NotaDebito));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.ApoliceSeguro));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.MensalidadeEscolar));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.ParcelaConsorcio));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.NotaFiscal));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.DocumentoDivida));
                alEspeciesDocumento.Add(new EspecieDocumento_HSBC((int)EnumEspecieDocumento_HSBC.Outros));

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

using System;
using System.Collections.Generic;
using ACBrFramework.Sped;
using System.IO;
using NHibernate;
using Servidor.NHibernate;
using System.Collections;
using Servidor.Util;
using Servidor.Model;


namespace Servidor.DAL
{

    public class SpedFiscalDAL
    {
        private static string ArquivoLog = "C:\\teste\\LogSped.txt";
        public ACBrFramework.Sped.ACBrSpedFiscal ACBrSpedFiscal { get; set; }

        private EmpresaDTO Empresa;
        private int VersaoLeiaute, FinalidadeArquivo, PerfilApresentacao, IdEmpresa, IdContador, Inventario;
        private String DataInicial, DataFinal;
        private ISession Session;

        String consultaSql = "";

        public SpedFiscalDAL()
        {
            ACBrSpedFiscal = new ACBrFramework.Sped.ACBrSpedFiscal();

            ACBrSpedFiscal.Arquivo = "";
            ACBrSpedFiscal.CurMascara = "#0.00";
            ACBrSpedFiscal.Delimitador = "|";
            ACBrSpedFiscal.DT_FIN = new System.DateTime(1899, 12, 30, 0, 0, 0, 0);
            ACBrSpedFiscal.DT_INI = new System.DateTime(1899, 12, 30, 0, 0, 0, 0);
            ACBrSpedFiscal.LinhasBuffer = 1000;
            ACBrSpedFiscal.Path = "C:\\T2Ti\\Arquivos\\";
            ACBrSpedFiscal.Arquivo = "SpedFiscal.txt";
            ACBrSpedFiscal.TrimString = true;
            ACBrSpedFiscal.OnError += new System.EventHandler<ACBrFramework.Sped.ErrorEventArgs>(ACBrSpedFiscal_OnError);
        }

        private void ACBrSpedFiscal_OnError(object sender, ACBrFramework.Sped.ErrorEventArgs e)
        {
            File.AppendAllText(ArquivoLog, DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString() + ":\t" + e.MsgErro + Environment.NewLine);
        }


        #region BLOCO 0: ABERTURA, IDENTIFICAÇÃO E REFERÊNCIAS
        public void GerarBloco0()
        {

            EmpresaDTO Empresa = new EmpresaDAL(Session).SelectId(IdEmpresa);
            ContadorDTO Contador = new NHibernateDAL<ContadorDTO>(Session).SelectId<ContadorDTO>(IdContador);

            consultaSql = "from ViewSpedNfeEmitenteDTO emitente where Id in (Select cab.Fornecedor.Id from NfeCabecalhoDTO as cab where cab.DataHoraEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal) + ")";
            IList<ViewSpedNfeEmitenteDTO> ListaEmitente = new NHibernateDAL<ViewSpedNfeEmitenteDTO>(Session).SelectListaSql<ViewSpedNfeEmitenteDTO>(consultaSql);

            consultaSql = "from ViewSpedNfeDestinatarioDTO destinatario where Id in (Select cab.Cliente.Id from NfeCabecalhoDTO as cab where cab.DataHoraEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal) + ")";
            IList<ViewSpedNfeDestinatarioDTO> ListaDestinatario = new NHibernateDAL<ViewSpedNfeDestinatarioDTO>(Session).SelectListaSql<ViewSpedNfeDestinatarioDTO>(consultaSql);

            consultaSql = "from ViewSpedNfeItemDTO item where Id in (Select det.Produto.Id from NfeDetalheDTO as det inner join det.NfeCabecalho as cab where cab.DataHoraEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal) + ")";
            IList<ViewSpedNfeItemDTO> ListaProduto = new NHibernateDAL<ViewSpedNfeItemDTO>(Session).SelectListaSql<ViewSpedNfeItemDTO>(consultaSql);

            consultaSql = "from ProdutoAlteracaoItemDTO item where item.DataInicial BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
            IList<ProdutoAlteracaoItemDTO> ListaProdutoAlterado = new NHibernateDAL<ProdutoAlteracaoItemDTO>(Session).SelectListaSql<ProdutoAlteracaoItemDTO>(consultaSql);

            IList<TributOperacaoFiscalDTO> ListaOperacaoFiscal = new NHibernateDAL<TributOperacaoFiscalDTO>(Session).Select(new TributOperacaoFiscalDTO());

            var bloco0 = ACBrSpedFiscal.Bloco_0;

            // Registro 0000: ABERTURA DO ARQUIVO DIGITAL E IDENTIFICAÇÃO DA ENTIDADE
            var Registro0000 = bloco0.Registro0000;

            Registro0000.COD_VER = (ACBrFramework.Sped.VersaoLeiaute)VersaoLeiaute;
            Registro0000.COD_FIN = (ACBrFramework.Sped.CodFinalidade)FinalidadeArquivo;
            Registro0000.IND_PERFIL = (ACBrFramework.Sped.Perfil)PerfilApresentacao;

            Registro0000.NOME = Empresa.RazaoSocial;
            Registro0000.CNPJ = Empresa.Cnpj;
            Registro0000.CPF = "";
            Registro0000.UF = Empresa.EnderecoPrincipal.Uf;
            Registro0000.IE = Empresa.InscricaoEstadual;
            Registro0000.COD_MUN = Empresa.CodigoIbgeCidade.Value;
            Registro0000.IM = Empresa.InscricaoMunicipal;
            Registro0000.SUFRAMA = Empresa.Suframa;
            Registro0000.IND_ATIV = ACBrFramework.Sped.Atividade.Outros;


            // Registro 0001: ABERTURA DO BLOCO 0
            var Registro0001 = bloco0.Registro0001;
            Registro0001.IND_MOV = IndicadorMovimento.ComDados;


            // Registro 0005: DADOS COMPLEMENTARES DA ENTIDADE
            var Registro0005 = Registro0001.Registro0005;
            Registro0005.FANTASIA = Empresa.NomeFantasia;
            Registro0005.CEP = Empresa.EnderecoPrincipal.Cep;
            Registro0005.ENDERECO = Empresa.EnderecoPrincipal.Logradouro;
            Registro0005.NUM = Empresa.EnderecoPrincipal.Numero;
            Registro0005.COMPL = Empresa.EnderecoPrincipal.Complemento;
            Registro0005.BAIRRO = Empresa.ListaEndereco[0].Bairro;
            Registro0005.FONE = Empresa.ListaEndereco[0].Fone;
            Registro0005.FAX = Empresa.ListaEndereco[0].Fone;
            Registro0005.EMAIL = Empresa.Email;

            // REGISTRO 0015: DADOS DO CONTRIBUINTE SUBSTITUTO
            //{ Não Implementado }


            // REGISTRO 0100: DADOS DO CONTABILISTA
            var Registro0100 = Registro0001.Registro0100;
            Registro0100.NOME = Contador.Nome;
            Registro0100.CPF = Contador.Cpf;
            Registro0100.CRC = Contador.InscricaoCrc;
            Registro0100.CNPJ = Contador.Cnpj;
            Registro0100.CEP = Contador.Cep;
            Registro0100.ENDERECO = Contador.Logradouro;
            Registro0100.NUM = Contador.Numero;
            Registro0100.COMPL = Contador.Complemento;
            Registro0100.BAIRRO = Contador.Bairro;
            Registro0100.FONE = Contador.Fone;
            Registro0100.FAX = Contador.Fax;
            Registro0100.EMAIL = Contador.Email;
            Registro0100.COD_MUN = Contador.MunicipioIbge.Value;


            // REGISTRO 0150: TABELA DE CADASTRO DO PARTICIPANTE
            foreach (ViewSpedNfeEmitenteDTO Emitente in ListaEmitente)
            {
                var Registro0150 = new Registro0150();

                Registro0150.COD_PART = "F" + Emitente.Id;
                Registro0150.NOME = Emitente.RazaoSocial;
                Registro0150.COD_PAIS = "01058";
                Registro0150.CNPJ = Emitente.CpfCnpj;
                Registro0150.CPF = Emitente.CpfCnpj;
                Registro0150.IE = Emitente.InscricaoEstadual;
                Registro0150.COD_MUN = Emitente.CodigoMunicipio;
                Registro0150.SUFRAMA = Emitente.Suframa;
                Registro0150.ENDERECO = Emitente.Logradouro;
                Registro0150.NUM = Emitente.Numero;
                Registro0150.COMPL = Emitente.Complemento;
                Registro0150.BAIRRO = Emitente.Bairro;

                Registro0001.Registro0150.Add(Registro0150);
            }

            foreach (ViewSpedNfeDestinatarioDTO Destinatario in ListaDestinatario)
            {
                var Registro0150 = new Registro0150();

                Registro0150.COD_PART = "C" + Destinatario.Id;
                Registro0150.NOME = Destinatario.RazaoSocial;
                Registro0150.COD_PAIS = "01058";
                Registro0150.CNPJ = Destinatario.CpfCnpj;
                Registro0150.CPF = Destinatario.CpfCnpj;
                Registro0150.IE = Destinatario.InscricaoEstadual;
                Registro0150.COD_MUN = Destinatario.CodigoMunicipio;
                Registro0150.SUFRAMA = Destinatario.Suframa;
                Registro0150.ENDERECO = Destinatario.Logradouro;
                Registro0150.NUM = Destinatario.Numero;
                Registro0150.COMPL = Destinatario.Complemento;
                Registro0150.BAIRRO = Destinatario.Bairro;

                Registro0001.Registro0150.Add(Registro0150);
            }

            // REGISTRO 0175: ALTERAÇÃO DA TABELA DE CADASTRO DE PARTICIPANTE
            //{ Não Implementado }


            //REGISTRO 0200: TABELA DE IDENTIFICAÇÃO DO ITEM (PRODUTO E SERVIÇOS)
            ArrayList ListaSiglaUnidade = new ArrayList();
            List<UnidadeProdutoDTO> ListaUnidade = new List<UnidadeProdutoDTO>();
            foreach (ViewSpedNfeItemDTO Produto in ListaProduto)
            {
                var Registro0200 = new Registro0200();

                Registro0200.COD_ITEM = Convert.ToString(Produto.Id);
                Registro0200.DESCR_ITEM = Produto.Nome;
                Registro0200.COD_BARRA = Produto.Gtin;
      			// TEM QUE PREENCHER PARA INFORMAR NO 0205 
                Registro0200.COD_ANT_ITEM = "";
                Registro0200.UNID_INV = Convert.ToString(Produto.IdUnidadeProduto);
                Registro0200.TIPO_ITEM = (TipoItem)Convert.ToInt32(Produto.TipoItemSped);
                Registro0200.COD_NCM = Produto.Ncm;
                Registro0200.EX_IPI = Produto.ExTipi;
                Registro0200.COD_GEN = Produto.Ncm.Substring(2, 1);
                Registro0200.COD_LST = Produto.CodigoLst;
                Registro0200.ALIQ_ICMS = Produto.AliquotaIcmsPaf;

                if (ListaSiglaUnidade.IndexOf(Produto.IdUnidadeProduto) == -1)
                {
                    ListaSiglaUnidade.Add(Convert.ToString(Produto.IdUnidadeProduto));
                    UnidadeProdutoDTO Unidade = new UnidadeProdutoDTO();
                    Unidade.Id = Produto.IdUnidadeProduto;
                    Unidade.Sigla = Produto.Sigla;
                    ListaUnidade.Add(Unidade);

                    // REGISTRO 0220: FATORES DE CONVERSÃO DE UNIDADES
                    consultaSql = "from UnidadeConversaoDTO where Produto.Id=" + Produto.Id + " and UnidadeProduto.Id=" + Produto.IdUnidadeProduto;
                    UnidadeConversaoDTO UnidadeConversao = new NHibernateDAL<UnidadeConversaoDTO>(Session).SelectObjetoSql<UnidadeConversaoDTO>(consultaSql);
                    if (UnidadeConversao != null)
                    {
                        var Registro0220 = new Registro0220();
                        Registro0220.UNID_CONV = Convert.ToString(UnidadeConversao.UnidadeProduto.Id);
                        Registro0220.FAT_CONV = UnidadeConversao.FatorConversao;

                        Registro0200.Registro0220.Add(Registro0220);
                    }
                }

                Registro0001.Registro0200.Add(Registro0200);
            }


            // REGISTRO 0190: IDENTIFICAÇÃO DAS UNIDADES DE MEDIDA
            foreach (UnidadeProdutoDTO Unidade in ListaUnidade)
            {
                var Registro0190 = new Registro0190();
                Registro0190.UNID = Convert.ToString(Unidade.Id);
                Registro0190.DESCR = Unidade.Sigla;
                Registro0001.Registro0190.Add(Registro0190);
            }


            // REGISTRO 0205: ALTERAÇÃO DO ITEM
            foreach (ProdutoAlteracaoItemDTO ProdutoAlterado in ListaProdutoAlterado)
            {
                var Registro0205 = new Registro0205();
                Registro0205.DESCR_ANT_ITEM = ProdutoAlterado.Nome;
                Registro0205.DT_INI = ProdutoAlterado.DataInicial.Value;
                Registro0205.DT_FIN = ProdutoAlterado.DataFinal.Value;
                Registro0205.COD_ANT_ITEM = ProdutoAlterado.Codigo;
            }

            // REGISTRO 0206: CÓDIGO DE PRODUTO CONFORME TABELA PUBLICADA PELA ANP (COMBUSTÍVEIS)
            //{ Não Implementado }

            // REGISTRO 0210: CONSUMO ESPECÍFICO PADRONIZADO
            //{ Não Implementado }

            // REGISTRO 0300: CADASTRO DE BENS OU COMPONENTES DO ATIVO IMOBILIZADO
            // REGISTRO 0305: INFORMAÇÃO SOBRE A UTILIZAÇÃO DO BEM
            //{ Não Implementado - versão 1.0 não possui controle CIAP }

            // REGISTRO 0400: TABELA DE NATUREZA DA OPERAÇÃO/PRESTAÇÃO
            foreach (TributOperacaoFiscalDTO OperacaoFiscal in ListaOperacaoFiscal)
            {
                var Registro0400 = new Registro0400();
                Registro0400.COD_NAT = Convert.ToString(OperacaoFiscal.Id);
                Registro0400.DESCR_NAT = OperacaoFiscal.DescricaoNaNf;
            }

            // REGISTRO 0450: TABELA DE INFORMAÇÃO COMPLEMENTAR DO DOCUMENTO FISCAL
            //{ Não Implementado }

            // REGISTRO 0460: TABELA DE OBSERVAÇÕES DO LANÇAMENTO FISCAL
            //{ Não Implementado }

            // REGISTRO 0500: PLANO DE CONTAS CONTÁBEIS
            //{ Não Implementado }

            // REGISTRO 0600: CENTRO DE CUSTOS
            //{ Não Implementado }
        }
        #endregion

        #region BLOCO C: DOCUMENTOS FISCAIS I - MERCADORIAS (ICMS/IPI)
        public void GerarBlocoC()
        {
            int i = 0;
            int j = 0;

            consultaSql = "from EcfNotaFiscalCabecalhoDTO where DataEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
            IList<EcfNotaFiscalCabecalhoDTO> ListaNF2Cabecalho = new NHibernateDAL<EcfNotaFiscalCabecalhoDTO>(Session).SelectListaSql<EcfNotaFiscalCabecalhoDTO>(consultaSql);

            consultaSql = "from EcfNotaFiscalCabecalhoDTO where Cancelada='S' and DataEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
            IList<EcfNotaFiscalCabecalhoDTO> ListaNF2CabecalhoCanceladas = new NHibernateDAL<EcfNotaFiscalCabecalhoDTO>(Session).SelectListaSql<EcfNotaFiscalCabecalhoDTO>(consultaSql);

            consultaSql = "from NfeCabecalhoDTO where DataHoraEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
            IList<NfeCabecalhoDTO> ListaNFeCabecalho = new NHibernateDAL<NfeCabecalhoDTO>(Session).SelectListaSql<NfeCabecalhoDTO>(consultaSql);

            var BlocoC = ACBrSpedFiscal.Bloco_C;

            // REGISTRO C001: ABERTURA DO BLOCO C
            var RegistroC001 = BlocoC.RegistroC001;
            RegistroC001.IND_MOV = IndicadorMovimento.ComDados;


            // / ///////////
            //  Perfil A  //
            // / ///////////
            if (PerfilApresentacao == 0)
            {
                if (ListaNFeCabecalho != null)
                {
                    foreach (NfeCabecalhoDTO NFeCabecalho in ListaNFeCabecalho)
                    {
                        i++;

                        // REGISTRO C100: NOTA FISCAL (CÓDIGO 01), NOTA FISCAL AVULSA (CÓDIGO 1B), NOTA FISCAL DE PRODUTOR (CÓDIGO 04), NF-e (CÓDIGO 55) e NFC-e (CÓDIGO 65)
                        var RegistroC100 = new RegistroC100();
                        RegistroC100.IND_OPER = (TipoOperacao)Convert.ToInt32(NFeCabecalho.TipoOperacao);
                        RegistroC100.IND_EMIT = Emitente.EmissaoPropria;

                        if (NFeCabecalho.Cliente != null)
                            RegistroC100.COD_PART = "C" + NFeCabecalho.Cliente.Id;
                        else
                            RegistroC100.COD_PART = "F" + NFeCabecalho.Fornecedor.Id;

                        RegistroC100.COD_MOD = NFeCabecalho.CodigoModelo;

                        if (NFeCabecalho.StatusNota == 0)
                            RegistroC100.COD_SIT = SituacaoDocto.Regular;
                        else
                            RegistroC100.COD_SIT = SituacaoDocto.Cancelado;

                        RegistroC100.SER = NFeCabecalho.Serie;
                        RegistroC100.NUM_DOC = NFeCabecalho.Numero;
                        RegistroC100.CHV_NFE = NFeCabecalho.ChaveAcesso;
                        RegistroC100.DT_DOC = NFeCabecalho.DataHoraEmissao.Value;
                        RegistroC100.DT_E_S = NFeCabecalho.DataHoraEntradaSaida.Value;
                        RegistroC100.VL_DOC = NFeCabecalho.ValorTotal.Value;
                        RegistroC100.IND_PGTO = TipoPagamento.Vista;
                        RegistroC100.VL_DESC = NFeCabecalho.ValorDesconto.Value;
                        RegistroC100.VL_ABAT_NT = 0;
                        RegistroC100.VL_MERC = NFeCabecalho.ValorTotalProdutos.Value;

                        NfeTransporteDTO Transporte = new NHibernateDAL<NfeTransporteDTO>(Session).SelectId<NfeTransporteDTO>(1);

                        if (Transporte != null)
                            RegistroC100.IND_FRT = TipoFrete.PorContaEmitente; //Transporte.ModalidadeFrete;
                        else
                            RegistroC100.IND_FRT = TipoFrete.SemCobrancaFrete;

                        RegistroC100.VL_FRT = NFeCabecalho.ValorFrete.Value;
                        RegistroC100.VL_SEG = NFeCabecalho.ValorSeguro.Value;
                        RegistroC100.VL_OUT_DA = NFeCabecalho.ValorDespesasAcessorias.Value;
                        RegistroC100.VL_BC_ICMS = NFeCabecalho.BaseCalculoIcms.Value;
                        RegistroC100.VL_ICMS = NFeCabecalho.ValorIcms.Value;
                        RegistroC100.VL_BC_ICMS_ST = NFeCabecalho.BaseCalculoIcmsSt.Value;
                        RegistroC100.VL_ICMS_ST = NFeCabecalho.ValorIcmsSt.Value;
                        RegistroC100.VL_IPI = NFeCabecalho.ValorIpi.Value;
                        RegistroC100.VL_PIS = NFeCabecalho.ValorPis.Value;
                        RegistroC100.VL_COFINS = NFeCabecalho.ValorCofins.Value;
                        RegistroC100.VL_PIS_ST = 0;
                        RegistroC100.VL_COFINS_ST = 0;
                        RegistroC001.RegistroC100.Add(RegistroC100);


                        // REGISTRO C105: OPERAÇÕES COM ICMS ST RECOLHIDO PARA UF DIVERSA DO DESTINATÁRIO DO DOCUMENTO FISCAL (CÓDIGO 55).
                        //{ Não Implementado }

                        // REGISTRO C110: INFORMAÇÃO COMPLEMENTAR DA NOTA FISCAL (CÓDIGO 01, 1B, 04 e 55).
                        //{ Não Implementado }

                        // REGISTRO C111: PROCESSO REFERENCIADO
                        //{ Não Implementado }

                        // REGISTRO C112: DOCUMENTO DE ARRECADAÇÃO REFERENCIADO.
                        //{ Não Implementado }

                        // REGISTRO C113: DOCUMENTO FISCAL REFERENCIADO.
                        //{ Não Implementado }


                        // REGISTRO C114: CUPOM FISCAL REFERENCIADO
                        //{ Não Implementado }

                        // REGISTRO C115: LOCAL DA COLETA E/OU ENTREGA (CÓDIGO 01, 1B E 04).
                        //{ Não Implementado }

                        // REGISTRO C116: CUPOM FISCAL ELETRÔNICO REFERENCIADO
                        //{ Não Implementado }

                        // REGISTRO C120: COMPLEMENTO DE DOCUMENTO - OPERAÇÕES DE IMPORTAÇÃO (CÓDIGOS 01 e 55).
                        //{ Não Implementado }

                        // REGISTRO C130: ISSQN, IRRF E PREVIDÊNCIA SOCIAL.
                        //{ Não Implementado }

                        // REGISTRO C140: FATURA (CÓDIGO 01)
                        //{ Não Implementado }

                        // REGISTRO C141: VENCIMENTO DA FATURA (CÓDIGO 01).
                        //{ Não Implementado }

                        // REGISTRO C160: VOLUMES TRANSPORTADOS (CÓDIGO 01 E 04) - EXCETO COMBUSTÍVEIS.
                        //{ Não Implementado }

                        // REGISTRO C165: OPERAÇÕES COM COMBUSTÍVEIS (CÓDIGO 01).
                        //{ Não Implementado }


                        // REGISTRO C170: ITENS DO DOCUMENTO (CÓDIGO 01, 1B, 04 e 55).
                        consultaSql = "from ViewSpedNfeDetalheDTO where IdNfeCabecalho = " + NFeCabecalho.Id;
                        IList<ViewSpedNfeDetalheDTO> ListaNFeDetalhe = new NHibernateDAL<ViewSpedNfeDetalheDTO>(Session).SelectListaSql<ViewSpedNfeDetalheDTO>(consultaSql);
                        if (ListaNFeDetalhe != null)
                        {
                            foreach (ViewSpedNfeDetalheDTO NFeDetalhe in ListaNFeDetalhe)
                            {
                                j++;

                                var RegistroC170 = new RegistroC170();
                                RegistroC170.NUM_ITEM = Convert.ToString(NFeDetalhe.NumeroItem);
                                RegistroC170.COD_ITEM = NFeDetalhe.Gtin;
                                RegistroC170.DESCR_COMPL = NFeDetalhe.NomeProduto;
                                RegistroC170.QTD = NFeDetalhe.QuantidadeComercial;
                                RegistroC170.UNID = Convert.ToString(NFeDetalhe.IdUnidadeProduto);
                                RegistroC170.VL_ITEM = NFeDetalhe.ValorTotal;
                                RegistroC170.VL_DESC = NFeDetalhe.ValorDesconto;
                                RegistroC170.IND_MOV = MovimentacaoFisica.Sim;
                                RegistroC170.CST_ICMS = NFeDetalhe.CstIcms;
                                RegistroC170.CFOP = Convert.ToString(NFeDetalhe.Cfop);
                                RegistroC170.COD_NAT = Convert.ToString(NFeDetalhe.IdTributOperacaoFiscal);
                                RegistroC170.VL_BC_ICMS = NFeDetalhe.BaseCalculoIcms;
                                RegistroC170.ALIQ_ICMS = NFeDetalhe.AliquotaIcms;
                                RegistroC170.VL_ICMS = NFeDetalhe.ValorIcms;
                                RegistroC170.VL_BC_ICMS_ST = NFeDetalhe.ValorBaseCalculoIcmsSt;
                                RegistroC170.ALIQ_ST = NFeDetalhe.AliquotaIcmsSt;
                                RegistroC170.VL_ICMS_ST = NFeDetalhe.ValorIcmsSt;
                                RegistroC170.IND_APUR = ApuracaoIPI.Mensal;
                                RegistroC170.CST_IPI = NFeDetalhe.CstIpi;
                                RegistroC170.COD_ENQ = NFeDetalhe.EnquadramentoIpi;
                                RegistroC170.VL_BC_IPI = NFeDetalhe.ValorBaseCalculoIpi;
                                RegistroC170.ALIQ_IPI = NFeDetalhe.AliquotaIpi;
                                RegistroC170.VL_IPI = NFeDetalhe.ValorIpi;
                                RegistroC170.CST_PIS = NFeDetalhe.CstPis;
                                RegistroC170.VL_BC_PIS = NFeDetalhe.ValorBaseCalculoPis;
                                RegistroC170.ALIQ_PIS_PERC = NFeDetalhe.AliquotaPisPercentual;
                                RegistroC170.QUANT_BC_PIS = NFeDetalhe.QuantidadeVendidaPis;
                                RegistroC170.ALIQ_PIS_R = NFeDetalhe.AliquotaPisReais;
                                RegistroC170.VL_PIS = NFeDetalhe.ValorPis;
                                RegistroC170.CST_COFINS = NFeDetalhe.CstCofins;
                                RegistroC170.VL_BC_COFINS = NFeDetalhe.BaseCalculoCofins;
                                RegistroC170.ALIQ_COFINS_PERC = NFeDetalhe.AliquotaCofinsPercentual;
                                RegistroC170.QUANT_BC_COFINS = NFeDetalhe.QuantidadeVendidaCofins;
                                RegistroC170.ALIQ_COFINS_R = NFeDetalhe.AliquotaCofinsReais;
                                RegistroC170.VL_COFINS = NFeDetalhe.ValorCofins;
                                RegistroC170.COD_CTA = "";
                                RegistroC100.RegistroC170.Add(RegistroC170);
                            }
                        }

                        // REGISTRO C171: ARMAZENAMENTO DE COMBUSTIVEIS (código 01, 55).
                        //{ Não Implementado }

                        // REGISTRO C172: OPERAÇÕES COM ISSQN (CÓDIGO 01)
                        //{ Não Implementado }

                        // REGISTRO C173: OPERAÇÕES COM MEDICAMENTOS (CÓDIGO 01 e 55).
                        //{ Não Implementado }

                        // REGISTRO C174: OPERAÇÕES COM ARMAS DE FOGO (CÓDIGO 01).
                        //{ Não Implementado }

                        // REGISTRO C175: OPERAÇÕES COM VEÍCULOS NOVOS (CÓDIGO 01 e 55).
                        //{ Não Implementado }

                        // REGISTRO C176: RESSARCIMENTO DE ICMS EM OPERAÇÕES COM SUBSTITUIÇÃO TRIBUTÁRIA (CÓDIGO 01, 55).
                        //{ Não Implementado }

                        // REGISTRO C177: OPERAÇÕES COM PRODUTOS SUJEITOS A SELO DE CONTROLE IPI.
                        //{ Não Implementado }

                        // REGISTRO C178: OPERAÇÕES COM PRODUTOS SUJEITOS À TRIBUTAÇÀO DE IPI POR UNIDADE OU QUANTIDADE DE PRODUTO.
                        //{ Não Implementado }

                        // REGISTRO C179: INFORMAÇÕES COMPLEMENTARES ST (CÓDIGO 01).
                        //{ Não Implementado }

                        // REGISTRO C190: REGISTRO ANALÍTICO DO DOCUMENTO (CÓDIGO 01, 1B, 04 ,55 e 65).
                        consultaSql = "from ViewSpedC190DTO where Id = " + NFeCabecalho.Id;
                        IList<ViewSpedC190DTO> ListaNFeAnalitico = new NHibernateDAL<ViewSpedC190DTO>(Session).SelectListaSql<ViewSpedC190DTO>(consultaSql);
                        if (ListaNFeAnalitico != null)
                        {
                            foreach (ViewSpedC190DTO NFeAnalitico in ListaNFeAnalitico)
                            {
                                j++;

                                var RegistroC190 = new RegistroC190();
                                RegistroC190.CST_ICMS = NFeAnalitico.CstIcms;
                                RegistroC190.CFOP = Convert.ToString(NFeAnalitico.Cfop);
                                RegistroC190.ALIQ_ICMS = NFeAnalitico.AliquotaIcms.Value;
                                RegistroC190.VL_OPR = NFeAnalitico.SomaValorOperacao.Value;
                                RegistroC190.VL_BC_ICMS = NFeAnalitico.SomaBaseCalculoIcms.Value;
                                RegistroC190.VL_ICMS = NFeAnalitico.SomaValorIcms.Value;
                                RegistroC190.VL_BC_ICMS_ST = NFeAnalitico.SomaBaseCalculoIcmsSt.Value;
                                RegistroC190.VL_ICMS_ST = NFeAnalitico.SomaValorIcmsSt.Value;
                                RegistroC190.VL_RED_BC = NFeAnalitico.SomaVlRedBc.Value;
                                RegistroC190.VL_IPI = NFeAnalitico.SomaValorIpi.Value;
                                RegistroC190.COD_OBS = "";
                                RegistroC100.RegistroC190.Add(RegistroC190);
                            }
                        }

                        // REGISTRO C195: OBSERVAÇOES DO LANÇAMENTO FISCAL (CÓDIGO 01, 1B E 55)
                        //{ Não Implementado }

                        // REGISTRO C197: OUTRAS OBRIGAÇÕES TRIBUTÁRIAS, AJUSTES E INFORMAÇÕES DE VALORES PROVENIENTES DE DOCUMENTO FISCAL.
                        //{ Não Implementado }
                    }
                }



                if (ListaNF2Cabecalho != null)
                {
                    foreach (EcfNotaFiscalCabecalhoDTO NF2Cabecalho in ListaNF2Cabecalho)
                    {
                        i++;

                        // REGISTRO C350: NOTA FISCAL DE VENDA A CONSUMIDOR (CÓDIGO 02)
                        var RegistroC350 = new RegistroC350();
                        RegistroC350.SER = NF2Cabecalho.Serie;
                        RegistroC350.SUB_SER = NF2Cabecalho.Subserie;
                        RegistroC350.NUM_DOC = NF2Cabecalho.Numero;
                        RegistroC350.DT_DOC = NF2Cabecalho.DataEmissao.Value;
                        RegistroC350.CNPJ_CPF = NF2Cabecalho.CpfCnpjCliente;
                        RegistroC350.VL_MERC = NF2Cabecalho.TotalProdutos.Value;
                        RegistroC350.VL_DOC = NF2Cabecalho.TotalNf.Value;
                        RegistroC350.VL_DESC = NF2Cabecalho.Desconto.Value;
                        RegistroC350.VL_PIS = NF2Cabecalho.Pis.Value;
                        RegistroC350.VL_COFINS = NF2Cabecalho.Cofins.Value;
                        RegistroC350.COD_CTA = "";
                        RegistroC001.RegistroC350.Add(RegistroC350);


                        // REGISTRO C370: ITENS DO DOCUMENTO (CÓDIGO 02)
                        consultaSql = "from ViewSpedC370DTO where DataEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
                        IList<ViewSpedC370DTO> ListaC370 = new NHibernateDAL<ViewSpedC370DTO>(Session).SelectListaSql<ViewSpedC370DTO>(consultaSql);
                        if (ListaC370 != null)
                        {
                            foreach (ViewSpedC370DTO C370 in ListaC370)
                            {
                                j++;

                                var RegistroC370 = new RegistroC370();
                                RegistroC370.NUM_ITEM = Convert.ToString(C370.Item);
                                RegistroC370.COD_ITEM = Convert.ToString(C370.IdProduto);
                                RegistroC370.QTD = C370.Quantidade;
                                RegistroC370.UNID = Convert.ToString(C370.IdUnidadeProduto);
                                RegistroC370.VL_ITEM = C370.ValorTotal;
                                RegistroC370.VL_DESC = C370.Desconto;
                                RegistroC001.RegistroC350[i].RegistroC370.Add(RegistroC370);
                            }
                        }


                        // REGISTRO C390: REGISTRO ANALÍTICO DAS NOTAS FISCAIS DE VENDA A CONSUMIDOR (CÓDIGO 02)
                        consultaSql = "from ViewSpedC390DTO where DataEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
                        IList<ViewSpedC390DTO> ListaC390 = new NHibernateDAL<ViewSpedC390DTO>(Session).SelectListaSql<ViewSpedC390DTO>(consultaSql);
                        if (ListaC390 != null)
                        {
                            foreach (ViewSpedC390DTO C390 in ListaC390)
                            {
                                j++;

                                var RegistroC390 = new RegistroC390();
                                RegistroC390.CST_ICMS = C390.Cst;
                                RegistroC390.CFOP = Convert.ToString(C390.Cfop);
                                RegistroC390.ALIQ_ICMS = C390.TaxaIcms;
                                RegistroC390.VL_OPR = C390.SomaItem;
                                RegistroC390.VL_BC_ICMS = C390.SomaBaseIcms;
                                RegistroC390.VL_ICMS = C390.SomaIcms;
                                RegistroC390.VL_RED_BC = C390.SomaIcmsOutras;
                                RegistroC001.RegistroC350[i].RegistroC390.Add(RegistroC390);
                            }
                        }

                    }
                }
            }



            // / ///////////
            //  Perfil B  //
            // / ///////////
            if (PerfilApresentacao == 1)
            {

                // REGISTRO C300: RESUMO DIÁRIO DAS NOTAS FISCAIS DE VENDA A CONSUMIDOR (CÓDIGO 02)
                consultaSql = "from ViewSpedC300DTO where DataEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
                IList<ViewSpedC300DTO> ListaC300 = new NHibernateDAL<ViewSpedC300DTO>(Session).SelectListaSql<ViewSpedC300DTO>(consultaSql);
                if (ListaC300 != null)
                {
                    foreach (ViewSpedC300DTO C300 in ListaC300)
                    {
                        i++;

                        var RegistroC300 = new RegistroC300();
                        RegistroC300.COD_MOD = "2";
                        RegistroC300.SER = C300.Serie;
                        RegistroC300.SUB = C300.Subserie;
                        RegistroC300.DT_DOC = C300.DataEmissao;
                        RegistroC300.VL_DOC = C300.SomaTotalNf;
                        RegistroC300.VL_PIS = C300.SomaPis;
                        RegistroC300.VL_COFINS = C300.SomaCofins;
                        RegistroC300.COD_CTA = "";
                        RegistroC001.RegistroC300.Add(RegistroC300);

                        // REGISTRO C310: DOCUMENTOS CANCELADOS DE NOTAS FISCAIS DE VENDA A CONSUMIDOR (CÓDIGO 02).
                        if (ListaNF2CabecalhoCanceladas != null)
                        {
                            foreach (EcfNotaFiscalCabecalhoDTO NF2CabecalhoCancelada in ListaNF2CabecalhoCanceladas)
                            {
                                var RegistroC310 = new RegistroC310();
                                RegistroC310.NUM_DOC_CANC = NF2CabecalhoCancelada.Numero;
                                RegistroC001.RegistroC300[i].RegistroC310.Add(RegistroC310);
                            }
                        }

                        // REGISTRO C320: REGISTRO ANALÍTICO DO RESUMO DIÁRIO DAS NOTAS FISCAIS DE VENDA A CONSUMIDOR (CÓDIGO 02). ---> igual ao C390
                        consultaSql = "from ViewSpedC390DTO where DataEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
                        IList<ViewSpedC390DTO> ListaC390 = new NHibernateDAL<ViewSpedC390DTO>(Session).SelectListaSql<ViewSpedC390DTO>(consultaSql);
                        if (ListaC390 != null)
                        {
                            foreach (ViewSpedC390DTO C390 in ListaC390)
                            {
                                j++;

                                var RegistroC320 = new RegistroC320();
                                RegistroC320.CST_ICMS = C390.Cst;
                                RegistroC320.CFOP = Convert.ToString(C390.Cfop);
                                RegistroC320.ALIQ_ICMS = C390.TaxaIcms;
                                RegistroC320.VL_OPR = C390.SomaItem;
                                RegistroC320.VL_BC_ICMS = C390.SomaBaseIcms;
                                RegistroC320.VL_ICMS = C390.SomaIcms;
                                RegistroC320.VL_RED_BC = C390.SomaIcmsOutras;
                                RegistroC001.RegistroC300[i].RegistroC320.Add(RegistroC320);


                                // REGISTRO C321: ITENS DO RESUMO DIÁRIO DOS DOCUMENTOS (CÓDIGO 02).
                                consultaSql = "from ViewSpedC321DTO where DataEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
                                IList<ViewSpedC321DTO> ListaC321 = new NHibernateDAL<ViewSpedC321DTO>(Session).SelectListaSql<ViewSpedC321DTO>(consultaSql);
                                if (ListaC321 != null)
                                {
                                    foreach (ViewSpedC321DTO C321 in ListaC321)
                                    {
                                        var RegistroC321 = new RegistroC321();

                                        RegistroC321.COD_ITEM = Convert.ToString(C321.IdProduto);
                                        RegistroC321.QTD = C321.SomaQuantidade;
                                        RegistroC321.UNID = C321.DescricaoUnidade;
                                        RegistroC321.VL_ITEM = C321.SomaItem;
                                        RegistroC321.VL_DESC = C321.SomaDesconto;
                                        RegistroC321.VL_BC_ICMS = C321.SomaBaseIcms;
                                        RegistroC321.VL_ICMS = C321.SomaIcms;
                                        RegistroC321.VL_PIS = C321.SomaPis;
                                        RegistroC321.VL_COFINS = C321.SomaCofins;
                                        RegistroC001.RegistroC300[i].RegistroC320[j].RegistroC321.Add(RegistroC321);
                                    }
                                }
                            }
                        }

                    }
                }

            } //  if PerfilApresentacao = 1 then



            // / //////////////////
            //  Ambos os Perfis  //
            // / //////////////////
            IList<EcfImpressoraDTO> ListaImpressora = new NHibernateDAL<EcfImpressoraDTO>(Session).Select(new EcfImpressoraDTO());
            if (ListaImpressora != null)
            {
                foreach (EcfImpressoraDTO Impressora in ListaImpressora)
                {
                    // REGISTRO C400: EQUIPAMENTO ECF (CÓDIGO 02, 2D e 60).
                    var RegistroC400 = new RegistroC400();
                    RegistroC400.COD_MOD = Impressora.ModeloDocumentoFiscal;
                    RegistroC400.ECF_MOD = Impressora.Modelo;
                    RegistroC400.ECF_FAB = Impressora.Serie;
                    RegistroC400.ECF_CX = Convert.ToString(Impressora.Numero);
                    RegistroC001.RegistroC400.Add(RegistroC400);

                    // verifica se existe movimento no periodo para aquele ECF
                    consultaSql = "from EcfR02DTO where IdImpressora=" + Impressora.Id + " and DataEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
                    IList<EcfR02DTO> ListaR02 = new NHibernateDAL<EcfR02DTO>(Session).SelectListaSql<EcfR02DTO>(consultaSql);
                    if (ListaR02 != null)
                    {
                        // REGISTRO C405: REDUÇÃO Z (CÓDIGO 02, 2D e 60).
                        foreach (EcfR02DTO R02 in ListaR02)
                        {
                            var RegistroC405 = new RegistroC405();
                            RegistroC405.DT_DOC = Convert.ToDateTime(R02.DataMovimento);
                            RegistroC405.CRO = R02.Cro.Value;
                            RegistroC405.CRZ = R02.Crz.Value;
                            RegistroC405.NUM_COO_FIN = R02.Coo.Value;
                            RegistroC405.GT_FIN = R02.GrandeTotal.Value;
                            RegistroC405.VL_BRT = R02.VendaBruta.Value;
                            RegistroC400.RegistroC405.Add(RegistroC405);

                            // REGISTRO C410: PIS E COFINS TOTALIZADOS NO DIA (CÓDIGO 02 e 2D).
                            //{ Não Implementado }

                            consultaSql = "from EcfR03DTO where IdR02=" + R02.Id;
                            IList<EcfR03DTO> ListaR03 = new NHibernateDAL<EcfR03DTO>(Session).SelectListaSql<EcfR03DTO>(consultaSql);
                            if (ListaR03 != null)
                            {
                                foreach (EcfR03DTO R03 in ListaR03)
                                {
                                    // REGISTRO C420: REGISTRO DOS TOTALIZADORES PARCIAIS DA REDUÇÃO Z (COD 02, 2D e 60).
                                    var RegistroC420 = new RegistroC420();
                                    if (R03.TotalizadorParcial.Length == 8)
                                        RegistroC420.COD_TOT_PAR = R03.TotalizadorParcial.Substring(R03.TotalizadorParcial.Length, 2);
                                    else
                                        RegistroC420.COD_TOT_PAR = R03.TotalizadorParcial;
                                    RegistroC420.VLR_ACUM_TOT = R03.ValorAcumulado.Value;
                                    if (RegistroC420.COD_TOT_PAR.Trim().Length == 7)
                                        RegistroC420.NR_TOT = Convert.ToInt32(RegistroC420.COD_TOT_PAR.Substring(2, 1));
                                    else
                                        RegistroC420.NR_TOT = 0;
                                    RegistroC405.RegistroC420.Add(RegistroC420);


                                    if (PerfilApresentacao == 1)
                                    {
                                        consultaSql = "from ViewSpedC425DTO where DataVenda BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
                                        IList<ViewSpedC425DTO> ListaC425 = new NHibernateDAL<ViewSpedC425DTO>(Session).SelectListaSql<ViewSpedC425DTO>(consultaSql);
                                        if (ListaC425 != null)
                                        {
                                            // REGISTRO C425: RESUMO DE ITENS DO MOVIMENTO DIÁRIO (CÓDIGO 02 e 2D).
                                            foreach (ViewSpedC425DTO C425 in ListaC425)
                                            {
                                                var RegistroC425 = new RegistroC425();

                                                RegistroC425.COD_ITEM = Convert.ToString(C425.IdEcfProduto);
                                                RegistroC425.UNID = Convert.ToString(C425.DescricaoUnidade);
                                                RegistroC425.QTD = C425.SomaQuantidade;
                                                RegistroC425.VL_ITEM = C425.SomaItem;
                                                RegistroC425.VL_PIS = C425.SomaPis;
                                                RegistroC425.VL_COFINS = C425.SomaCofins;
                                                RegistroC420.RegistroC425.Add(RegistroC425);
                                            }
                                        }
                                    }
                                }
                            }

                            //  se tiver o perfil A, gera o C460 com C470
                            if (PerfilApresentacao == 0)
                            {
                                consultaSql = "from EcfVendaCabecalhoDTO where DataEmissao BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
                                IList<EcfVendaCabecalhoDTO> ListaR04 = new NHibernateDAL<EcfVendaCabecalhoDTO>(Session).SelectListaSql<EcfVendaCabecalhoDTO>(consultaSql);
                                if (ListaR04 != null)
                                {
                                    foreach (EcfVendaCabecalhoDTO R04 in ListaR04)
                                    {
                                        // REGISTRO C460: DOCUMENTO FISCAL EMITIDO POR ECF (CÓDIGO 02, 2D e 60).
                                        var RegistroC460 = new RegistroC460();
                                        RegistroC460.COD_MOD = "2D";
                                        if (R04.StatusVenda == "C")
                                            RegistroC460.COD_SIT = SituacaoDocto.Cancelado;
                                        else
                                            RegistroC460.COD_SIT = SituacaoDocto.Regular;

                                        if (RegistroC460.COD_SIT == SituacaoDocto.Regular)
                                        {
                                            RegistroC460.DT_DOC = R04.DataVenda.Value;
                                            RegistroC460.VL_DOC = R04.ValorFinal.Value;
                                            RegistroC460.VL_PIS = R04.Pis.Value;
                                            RegistroC460.VL_PIS = R04.Cofins.Value;
                                            RegistroC460.CPF_CNPJ = R04.CpfCnpjCliente;
                                            RegistroC460.NOM_ADQ = R04.NomeCliente;
                                        }
                                        RegistroC460.NUM_DOC = Convert.ToString(R04.Coo);
                                        RegistroC405.RegistroC460.Add(RegistroC460);

                                        // REGISTRO C465: COMPLEMENTO DO CUPOM FISCAL ELETRÔNICO EMITIDO POR ECF – CF-e-ECF (CÓDIGO 60).
                                        //{ Não Implementado }

                                        if (RegistroC460.COD_SIT == SituacaoDocto.Regular)
                                        {
                                            // REGISTRO C470: ITENS DO DOCUMENTO FISCAL EMITIDO POR ECF (CÓDIGO 02 e 2D).
                                            consultaSql = "from EcfVendaDetalheDTO where IdEcfVendaCabecalho=" + R04.Id;
                                            IList<EcfVendaDetalheDTO> ListaR05 = new NHibernateDAL<EcfVendaDetalheDTO>(Session).SelectListaSql<EcfVendaDetalheDTO>(consultaSql);
                                            if (ListaR05 != null)
                                            {
                                                foreach (EcfVendaDetalheDTO R05 in ListaR05)
                                                {
                                                    var RegistroC470 = new RegistroC470();
                                                    RegistroC470.COD_ITEM = Convert.ToString(R05.IdEcfProduto);
                                                    RegistroC470.QTD = R05.Quantidade.Value;
                                                    ProdutoDTO Produto = new NHibernateDAL<ProdutoDTO>(Session).SelectId<ProdutoDTO>(R05.IdEcfProduto.Value);
                                                    RegistroC470.UNID = Convert.ToString(Produto.UnidadeProduto.Id);
                                                    RegistroC470.VL_ITEM = R05.TotalItem.Value;
                                                    RegistroC470.CST_ICMS = R05.Cst;
                                                    RegistroC470.CFOP = Convert.ToString(R05.Cfop);
                                                    RegistroC470.ALIQ_ICMS = R05.TaxaIcms.Value;
                                                    RegistroC470.VL_PIS = R05.Pis.Value;
                                                    RegistroC470.VL_COFINS = R05.Cofins.Value;
                                                    RegistroC460.RegistroC470.Add(RegistroC470);

                                                }
                                            }
                                        }

                                    }
                                }
                            }

                            // REGISTRO C490: REGISTRO ANALÍTICO DO MOVIMENTO DIÁRIO (CÓDIGO 02, 2D e 60).
                            consultaSql = "from ViewSpedC490DTO where DataVenda BETWEEN " + Biblioteca.QuotedStr(DataInicial) + " and " + Biblioteca.QuotedStr(DataFinal);
                            IList<ViewSpedC490DTO> ListaC490 = new NHibernateDAL<ViewSpedC490DTO>(Session).SelectListaSql<ViewSpedC490DTO>(consultaSql);
                            if (ListaC490 != null)
                            {
                                foreach (ViewSpedC490DTO C490 in ListaC490)
                                {
                                    var RegistroC490 = new RegistroC490();

                                    RegistroC490.CST_ICMS = C490.Cst;
                                    RegistroC490.CFOP = Convert.ToString(C490.Cfop);
                                    RegistroC490.ALIQ_ICMS = C490.TaxaIcms;
                                    RegistroC490.VL_OPR = C490.SomaItem;
                                    RegistroC490.VL_BC_ICMS = C490.SomaBaseIcms;
                                    RegistroC490.VL_ICMS = C490.SomaIcms;
                                    RegistroC405.RegistroC490.Add(RegistroC490);
                                }
                            }

                            // REGISTRO C495: RESUMO MENSAL DE ITENS DO ECF POR ESTABELECIMENTO (CÓDIGO 02 e 2D).
                            //{ Não Implementado }

                        }

                    }
                }
            }

            // REGISTRO C500: NOTA FISCAL/CONTA DE ENERGIA ELÉTRICA (CÓDIGO 06), NOTA FISCAL/CONTA DE FORNECIMENTO D'ÁGUA CANALIZADA (CÓDIGO 29) E NOTA FISCAL CONSUMO FORNECIMENTO DE GÁS (CÓDIGO 28).
            // REGISTRO C510: ITENS DO DOCUMENTO NOTA FISCAL/CONTA ENERGIA ELÉTRICA (CÓDIGO 06), NOTA FISCAL/CONTA DE FORNECIMENTO D'ÁGUA CANALIZADA (CÓDIGO 29) E NOTA FISCAL/CONTA DE FORNECIMENTO DE GÁS (CÓDIGO 28).
            // REGISTRO C590: REGISTRO ANALÍTICO DO DOCUMENTO - NOTA FISCAL/CONTA DE ENERGIA ELÉTRICA (CÓDIGO 06), NOTA FISCAL/CONTA DE FORNECIMENTO D'ÁGUA CANALIZADA (CÓDIGO 29) E NOTA FISCAL CONSUMO FORNECIMENTO DE GÁS (CÓDIGO 28).
            // REGISTRO C600: CONSOLIDAÇÃO DIÁRIA DE NOTAS FISCAIS/CONTAS DE ENERGIA ELÉTRICA (CÓDIGO 06), NOTA FISCAL/CONTA DE FORNECIMENTO D'ÁGUA CANALIZADA (CÓDIGO 29) E NOTA FISCAL/CONTA DE FORNECIMENTO DE GÁS (CÓDIGO 28) (EMPRESAS NÃO OBRIGADAS AO CONVÊNIO ICMS 115/03).
            // REGISTRO C601: DOCUMENTOS CANCELADOS - CONSOLIDAÇÃO DIÁRIA DE NOTAS FISCAIS/CONTAS DE ENERGIA ELÉTRICA (CÓDIGO 06), NOTA FISCAL/CONTA DE FORNECIMENTO D'ÁGUA CANALIZADA (CÓDIGO 29) E NOTA FISCAL/CONTA DE FORNECIMENTO DE GÁS (CÓDIGO 28)
            // REGISTRO C610: ITENS DO DOCUMENTO CONSOLIDADO (CÓDIGO 06), NOTA FISCAL/CONTA DE FORNECIMENTO D'ÁGUA CANALIZADA (CÓDIGO 29) E NOTA FISCAL/CONTA DE FORNECIMENTO DE GÁS (CÓDIGO 28) (EMPRESAS NÃO OBRIGADAS AO CONVÊNIO ICMS 115/03).
            // REGISTRO C690: REGISTRO ANALÍTICO DOS DOCUMENTOS (NOTAS FISCAIS/CONTAS DE ENERGIA ELÉTRICA (CÓDIGO 06), NOTA FISCAL/CONTA DE FORNECIMENTO D’ÁGUA CANALIZADA (CÓDIGO 29) E NOTA FISCAL/CONTA DE FORNECIMENTO DE GÁS (CÓDIGO 28)
            // REGISTRO C700: CONSOLIDAÇÃO DOS DOCUMENTOS NF/CONTA ENERGIA ELÉTRICA (CÓD 06), EMITIDAS EM VIA ÚNICA (EMPRESAS OBRIGADAS À ENTREGA DO ARQUIVO PREVISTO NO CONVÊNIO ICMS 115/03) E NOTA FISCAL/CONTA DE FORNECIMENTO DE GÁS CANALIZADO (CÓDIGO 28)
            // REGISTRO C790: REGISTRO ANALÍTICO DOS DOCUMENTOS (CÓDIGOS 06 e 28).
            // REGISTRO C791: REGISTRO DE INFORMAÇÕES DE ST POR UF (COD 06)
            //{ Não Implementados }

            // REGISTRO C800: CUPOM FISCAL ELETRÔNICO (CÓDIGO 59)
            // REGISTRO C850: REGISTRO ANALÍTICO DO CF-E (CODIGO 59)
            // REGISTRO C860: IDENTIFICAÇÃO DO EQUIPAMENTO SAT-CF-E
            // REGISTRO C890: RESUMO DIÁRIO DO CF-E (CÓDIGO 59) POR EQUIPAMENTO SATCF-E
		    // {SERÃO IMPLEMENTADOS QUANDO O SAT FOR CONSTRUIDO}

        }
        #endregion

        #region BLOCO E: APURAÇÃO DO ICMS E DO IPI
        public void GerarBlocoE()
        {
            var BlocoE = ACBrSpedFiscal.Bloco_E;

            // REGISTRO E001: ABERTURA DO BLOCO E
            var RegistroE001 = BlocoE.RegistroE001;
            RegistroE001.IND_MOV = IndicadorMovimento.ComDados;

            // REGISTRO E100: PERÍODO DA APURAÇÃO DO ICMS.
            var RegistroE100 = new RegistroE100();
            RegistroE100.DT_INI = Convert.ToDateTime(DataInicial);
            RegistroE100.DT_FIN = Convert.ToDateTime(DataFinal);

            // REGISTRO E110: APURAÇÃO DO ICMS – OPERAÇÕES PRÓPRIAS.
            consultaSql = "from FiscalApuracaoIcmsDTO where Competencia=" + Biblioteca.QuotedStr(System.DateTime.Parse(DataInicial).ToString("MM/yyyy"));
            FiscalApuracaoIcmsDTO ApuracaoIcms = new NHibernateDAL<FiscalApuracaoIcmsDTO>(Session).SelectObjetoSql<FiscalApuracaoIcmsDTO>(consultaSql);
            if (ApuracaoIcms != null)
            {

                var RegistroE110 = RegistroE100.RegistroE110;

                RegistroE110.VL_TOT_DEBITOS = ApuracaoIcms.ValorTotalDebito.Value;
                RegistroE110.VL_AJ_DEBITOS = ApuracaoIcms.ValorAjusteDebito.Value;
                RegistroE110.VL_TOT_AJ_DEBITOS = ApuracaoIcms.ValorTotalAjusteDebito.Value;
                RegistroE110.VL_ESTORNOS_CRED = ApuracaoIcms.ValorEstornoCredito.Value;
                RegistroE110.VL_TOT_CREDITOS = ApuracaoIcms.ValorTotalCredito.Value;
                RegistroE110.VL_AJ_CREDITOS = ApuracaoIcms.ValorAjusteCredito.Value;
                RegistroE110.VL_TOT_AJ_CREDITOS = ApuracaoIcms.ValorTotalAjusteCredito.Value;
                RegistroE110.VL_ESTORNOS_DEB = ApuracaoIcms.ValorEstornoDebito.Value;
                RegistroE110.VL_SLD_CREDOR_ANT = ApuracaoIcms.ValorSaldoCredorAnterior.Value;
                RegistroE110.VL_SLD_APURADO = ApuracaoIcms.ValorSaldoApurado.Value;
                RegistroE110.VL_TOT_DED = ApuracaoIcms.ValorTotalDeducao.Value;
                RegistroE110.VL_ICMS_RECOLHER = ApuracaoIcms.ValorIcmsRecolher.Value;
                RegistroE110.VL_SLD_CREDOR_TRANSPORTAR = ApuracaoIcms.ValorSaldoCredorTransp.Value;
                RegistroE110.DEB_ESP = ApuracaoIcms.ValorDebitoEspecial.Value;

                var RegistroE116 = new RegistroE116();
                RegistroE116.COD_OR = "000";
                RegistroE116.VL_OR = ApuracaoIcms.ValorIcmsRecolher.Value;
                RegistroE116.DT_VCTO = Convert.ToDateTime(DataFinal); 
                RegistroE116.COD_REC = "1";
                RegistroE116.NUM_PROC = "";
                RegistroE116.PROC = "";
                RegistroE116.TXT_COMPL = "";
                RegistroE116.MES_REF = "";
            }
        }
        #endregion

        #region BLOCO H: INVENTÁRIO FÍSICO
        public void GerarBlocoH()
        {
            var BlocoH = ACBrSpedFiscal.Bloco_H;

            // REGISTRO H001: ABERTURA DO BLOCO H
            var RegistroH001 = BlocoH.RegistroH001;
            if (Inventario == 0)
                RegistroH001.IND_MOV = IndicadorMovimento.SemDados;
            else
                RegistroH001.IND_MOV = IndicadorMovimento.ComDados;

            IList<ProdutoDTO> ListaProduto = new NHibernateDAL<ProdutoDTO>(Session).Select(new ProdutoDTO());
            decimal TotalGeral = 0;

            for (int i = 0; i < ListaProduto.Count; i++)
            {
                TotalGeral = TotalGeral + ListaProduto[i].QuantidadeEstoque.Value *ListaProduto[i].ValorCompra.Value;
            }


            // REGISTRO H005: TOTAIS DO INVENTÁRIO
            var RegistroH005 = new RegistroH005();

            RegistroH005.DT_INV = Convert.ToDateTime(DataFinal);
            RegistroH005.VL_INV = TotalGeral;
            RegistroH005.MOT_INV = MotivoInventario.FinalPeriodo;

            // REGISTRO H010: INVENTÁRIO.
            foreach (ProdutoDTO Produto in ListaProduto)
            {
                var RegistroH010 = new RegistroH010();
                RegistroH010.COD_ITEM = Convert.ToString(Produto.Id);
                RegistroH010.UNID = Convert.ToString(Produto.UnidadeProduto.Id);
                RegistroH010.QTD = Produto.QuantidadeEstoque.Value;
                RegistroH010.VL_UNIT = Produto.ValorCompra.Value;
                RegistroH010.VL_ITEM = RegistroH010.QTD * RegistroH010.VL_UNIT;
                RegistroH010.IND_PROP = PosseItem.Informante;
            }

            // REGISTRO H020: Informação complementar do Inventário.
            //{ Não Implementado }

        }
        #endregion

        #region BLOCO 1: OUTRAS INFORMAÇÕES
        public void GerarBloco1()
        {
            var Bloco1 = ACBrSpedFiscal.Bloco_1;

            // REGISTRO 1001: ABERTURA DO BLOCO 1
            var Registro1001 = Bloco1.Registro1001;
            Registro1001.IND_MOV = IndicadorMovimento.ComDados;

            // REGISTRO 1010: OBRIGATORIEDADE DE REGISTROS DO BLOCO 1
            var Registro1010 = new Registro1010();
            Registro1010.IND_EXP = "N";        //1100
            Registro1010.IND_CCRF = "N";       //1200
            Registro1010.IND_COMB = "N";       //1300
            Registro1010.IND_USINA = "N";      //1390
            Registro1010.IND_VA = "N";         //1400
            Registro1010.IND_EE = "N";         //1500
            Registro1010.IND_CART = "N";       //1600
            Registro1010.IND_FORM = "N";       //1700
            Registro1010.IND_AER = "N";        //1800
        }
        #endregion

        #region Gerar Arquivo
        public bool GerarArquivoSpedFiscal(string pDataIni, string pDataFim, int pVersao, int pFinalidade, int pPerfil, int pIdEmpresa, int pInventario, int pIdContador)
        {
            VersaoLeiaute = pVersao;
            FinalidadeArquivo = pFinalidade;
            PerfilApresentacao = pPerfil;
            DataInicial = System.DateTime.Parse(pDataIni).ToString("yyyy-MM-dd");
            DataFinal = System.DateTime.Parse(pDataFim).ToString("yyyy-MM-dd");
            IdEmpresa = pIdEmpresa;
            Inventario = pInventario;
            IdContador = pIdContador;

            ACBrSpedFiscal.DT_INI = Convert.ToDateTime(pDataIni);
            ACBrSpedFiscal.DT_FIN = Convert.ToDateTime(pDataFim);

            using (Session = NHibernateHelper.GetSessionFactory().OpenSession())
            {
                GerarBloco0();
                GerarBlocoC();
                
                // BLOCO D: DOCUMENTOS FISCAIS II - SERVIÇOS (ICMS).
                // Bloco de registros dos dados relativos à emissão ou ao recebimento de documentos fiscais que acobertam as prestações de serviços de comunicação, transporte intermunicipal e interestadual.
                //{ Não Implementado }

                GerarBlocoE();

                // BLOCO G – CONTROLE DO CRÉDITO DE ICMS DO ATIVO PERMANENTE CIAP
                //{ Não Implementado }

                if (Inventario > 0)
                    GerarBlocoH();

                GerarBloco1();
            }

            ACBrSpedFiscal.SaveFileTXT();
            return true;
        }
        #endregion

    }

}

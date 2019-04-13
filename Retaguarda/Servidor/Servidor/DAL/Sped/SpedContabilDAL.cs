using System;
using System.Collections.Generic;
using ACBrFramework.Sped;
using System.IO;
using NHibernate;
using Servidor.NHibernate;
using System.Collections;
using Servidor.Model;
using ProjetoSpedContabil;
using Servidor.Util;


namespace Servidor.DAL
{

    public class SpedContabilDAL
    {

        #region Informações Importantes
        /*
        Fonte: Manual de Orientação da ECD

        São previstas as seguintes formas de escrituração:
        G - Diário Geral;
        R - Diário com Escrituração Resumida (vinculado a livro auxiliar);
        A - Diário Auxiliar;
        Z - Razão Auxiliar; e
        B - Livro de Balancetes Diários e Balanços.

          - Todas as empresas devem utilizar o livro Diário contemplando todos os fatos contábeis. Este livro é
            classificado, no Sped Contábil, como G - Livro Diário (completo, sem escrituração auxiliar).
            É o livro Diário que independe de qualquer outro. Portanto, ele não pode coexistir, em relação a um mesmo
            período, com quaisquer dos outros livros (R, A, Z ou B).

          - R - Livro Diário com Escrituração Resumida (com escrituração auxiliar): É o livro Diário que contem
            escrituração resumida, nos termos do § 1o do art. 1.184 do Código Civil, acima transcrito. Ele obriga a
            existência de livros auxiliares (A ou Z) e não pode coexistir, em relação a um mesmo período, com os livros G
            e B.

          - A - Livro Diário Auxiliar ao Diário com Escrituração Resumida: É o livro auxiliar previsto no nos termos do
            § 1o do art. 1.184 do Código Civil supramencionado, contendo os lançamentos individualizados das operações
            lançadas no Diário com Escrituração Resumida.

          - Z – Razão Auxiliar (Livro Contábil Auxiliar conforme leiaute definido pelo titular da escrituração): O livro Z
            um livro auxiliar a ser utilizado quando o leiaute do livro Diário Auxiliar não se mostrar adequado. É uma
            “tabela” onde o titular da escrituração define cada coluna e seu conteúdo.

          - B - Livro Balancetes Diários e Balanços: Somente o Banco Central regulamentou a utilização deste livro e,
            praticamente, só é encontrado em instituições financeiras. A legislação não obsta a utilização concomitante do
            livro “Balancetes Diários e Balanços” e de livros auxiliares. Existe a controvérsia sobre a obrigatoriedade de
            autenticação, pelas empresas não regulamentadas pelo Banco Central, das fichas de lançamento, conforme
            estabelecido no art. 1.181 do Código Civil, transcrito abaixo:
            Art. 1.181. Salvo disposição especial de lei, os livros obrigatórios e, se for o caso, as fichas, antes de postos
            em uso, devem ser autenticados no Registro Público de Empresas Mercantis.

          - Seção 1.7. Regras de Convivência entre os Livros Abrangidos pelo Sped Contábil

            A escrituração G, Diário Geral, não pode conviver com nenhuma outra escrituração no mesmo período, ou
            seja, as escriturações principais (G, R ou B) não podem coexistir.
            A escrituração G não possui livros auxiliares (A ou Z), e, consequentemente, não pode conviver com esses
            tipos de escrituração.
            A escrituração resumida R pode conviver com os livros auxiliares (A ou Z).
            O livro de balancetes e balanços diários B pode conviver com os livros auxiliares (A ou Z).
        */
        #endregion


        private static string path = "C:\\teste\\LogSped.txt";
        public TACBrSPEDContabil ACBrSpedContabil { get; set; }

        private EmpresaDTO Empresa;
        private int FormaEscrituracao, LayoutVersao, IdEmpresa;
        private String DataInicial, DataFinal, Arquivo, FiltroLocal;
        private ISession Session;

        public SpedContabilDAL()
        {
            ACBrSpedContabil = new TACBrSPEDContabil();
            /*
            ACBrSpedContabil.Arquivo = "";
            ACBrSpedContabil.CurMascara = "#0.00";
            ACBrSpedContabil.Delimitador = "|";
            ACBrSpedContabil.DT_FIN = new System.DateTime(1899, 12, 30, 0, 0, 0, 0);
            ACBrSpedContabil.DT_INI = new System.DateTime(1899, 12, 30, 0, 0, 0, 0);
            ACBrSpedContabil.LinhasBuffer = 1000;
            ACBrSpedContabil.Path = "C:\\T2Ti\\Arquivos\\";
            ACBrSpedContabil.Arquivo = "SpedContabil.txt";
            ACBrSpedContabil.TrimString = true;
            ACBrSpedContabil.OnError += new System.EventHandler<ACBrFramework.Sped.ErrorEventArgs>(ACBrSpedContabil_OnError);
             */
        }

        #region Bloco 0 - Abertura, Identificação e Referências
        public void GerarBloco0()
        {
            EmpresaDTO Empresa = new EmpresaDAL(Session).SelectId(IdEmpresa);

            ACBrSpedContabil.Bloco_0.LimpaRegistros();
            // REGISTRO 0000: ABERTURA DO ARQUIVO DIGITAL E IDENTIFICAÇÃO DO EMPRESÁRIO OU DA SOCIEDADE EMPRESÁRIA
            ACBrSpedContabil.Bloco_0.FRegistro0000.DT_INI = new System.DateTime(1899, 12, 30, 0, 0, 0, 0); //Biblioteca.TextoParaData(DataInicial);
            ACBrSpedContabil.Bloco_0.FRegistro0000.DT_FIN = new System.DateTime(1899, 12, 30, 0, 0, 0, 0); //Biblioteca.TextoParaData(DataFinal);

            ACBrSpedContabil.Bloco_0.FRegistro0000.NOME = Empresa.RazaoSocial;
            ACBrSpedContabil.Bloco_0.FRegistro0000.CNPJ = Empresa.Cnpj;
            ACBrSpedContabil.Bloco_0.FRegistro0000.UF = Empresa.EnderecoPrincipal.Uf;
            ACBrSpedContabil.Bloco_0.FRegistro0000.IE = Empresa.InscricaoEstadual;
            ACBrSpedContabil.Bloco_0.FRegistro0000.COD_MUN = Empresa.CodigoIbgeCidade.ToString();
            ACBrSpedContabil.Bloco_0.FRegistro0000.IM = Empresa.InscricaoMunicipal;
            ACBrSpedContabil.Bloco_0.FRegistro0000.IND_SIT_ESP = "";

            // REGISTRO 0001: ABERTURA DO BLOCO 0
            // ACBrSpedContabil.Bloco_0.FRegistro0001.IND_DAD = 0; // bloco com dados informados = 0 | sem dados inf = 1

            // REGISTRO 0007: OUTRAS INSCRIÇÕES CADASTRAIS DA PESSOA JURÍDICA
            //{ Implementado a critério do Participante do T2Ti ERP }

            // REGISTRO 0020: ESCRITURAÇÃO CONTÁBIL DESCENTRALIZADA
            //{ Implementado a critério do Participante do T2Ti ERP - Para o treinamento a escrituração será centralizada }

            // REGISTRO 0150: TABELA DE CADASTRO DO PARTICIPANTE
            //{ Implementado a critério do Participante do T2Ti ERP }

            // REGISTRO 0180: IDENTIFICAÇÃO DO RELACIONAMENTO COM O PARTICIPANTE
            //{ Implementado a critério do Participante do T2Ti ERP }
        }
        #endregion

        #region Bloco I - Lançamentos Contábeis
        public void GerarBlocoI()
        {
            /*
              Credito = 0;
              Debito = 0;
              SaldoAnterior = 0;
              Niveis = TStringList.Create;
              ACBrSpedContabil.Bloco_I.LimpaRegistros;

              using ACBrSpedContabil.Bloco_I do
              {
                // REGISTRO I001: ABERTURA DO BLOCO I
                RegistroI001.IND_DAD = 0;

                // REGISTRO I010: IDENTIFICAÇÃO DA ESCRITURAÇÃO CONTÁBIL
                case FormaEscrituracao of
                  0:
                    RegistroI010.IND_ESC = "G";
                  1:
                    RegistroI010.IND_ESC = "R";
                  2:
                    RegistroI010.IND_ESC = "A";
                  3:
                    RegistroI010.IND_ESC = "B";
                  4:
                    RegistroI010.IND_ESC = "Z";
                };
                EscrituracaoForma = RegistroI010.IND_ESC;

                case VersaoLayout of
                  0:
                    RegistroI010.COD_VER_LC = "1.00";
                  1:
                    RegistroI010.COD_VER_LC = "2.00";
                };

                // REGISTRO I012: LIVROS AUXILIARES AO DIÁRIO
                { Implementado a critério do Participante do T2Ti ERP }

                // REGISTRO I015: IDENTIFICAÇÃO DAS CONTAS DA ESCRITURAÇÃO RESUMIDA A QUE SE REFERE A ESCRITURAÇÃO AUXILIAR
                { Implementado a critério do Participante do T2Ti ERP }

                // REGISTRO I020: CAMPOS ADICIONAIS
                { Implementado a critério do Participante do T2Ti ERP }

                // REGISTRO I030: TERMO DE ABERTURA
                ContabilLivro = TT2TiORM.ConsultarUmObjeto<TContabilLivroVO>("FORMA_ESCRITURACAO = " + QuotedStr(EscrituracaoForma) +  " and COMPETENCIA=" + QuotedStr(FormatDateTime("MM/YYYY", TextoParaData(DataInicial))), False);
                if Assigned(ContabilLivro) then
                {
                  TermoLivro = TT2TiORM.ConsultarUmObjeto<TContabilTermoVO>("ID_CONTABIL_LIVRO=" + IntToStr(ContabilLivro.Id) + " and ABERTURA_ENCERRAMENTO=" + QuotedStr("A"), False);
                  RegistroCartorio = TT2TiORM.ConsultarUmObjeto<TRegistroCartorioVO>("ID_EMPRESA=" + IntToStr(Sessao(SessaoAtual).IdEmpresa), False);

                  using RegistroI030 do
                  {
                    NUM_ORD = TermoLivro.NumeroRegistro;
                    NAT_LIVR = ContabilLivro.Descricao;
                    QTD_LIN = ACBrSpedContabil.Bloco_9.Registro9999.QTD_LIN;
                    NOME = Empresa.RazaoSocial;
                    NIRE = RegistroCartorio.NIRE;
                    CNPJ = Empresa.CNPJ;
                    DT_ARQ = RegistroCartorio.DataRegistro;
                    DESC_MUN = Empresa.Lista}erecoVO.Items[0].Cidade;
                  };
                };


                // REGISTRO I050: PLANO DE CONTAS
                PlanoConta = TT2TiORM.ConsultarUmObjeto<TPlanoContaVO>("ID_EMPRESA=" + IntToStr(Sessao(SessaoAtual).IdEmpresa), False);
                if Assigned(PlanoConta) then
                {
                  ListaPlanoConta = TT2TiORM.Consultar<TContabilContaVO>("ID_PLANO_CONTA=" + IntToStr(PlanoConta.Id), False);
                  if assigned(ListaPlanoConta) then
                  {
                    for i = 0 to ListaPlanoConta.Count - 1 do
                    {
                      using RegistroI050.New do
                      {
                        DT_ALT = TContabilContaVO(ListaPlanoConta.Items[i]).DataInclusao;
                        COD_NAT = TContabilContaVO(ListaPlanoConta.Items[i]).CodigoEfd;
                        IND_CTA = TContabilContaVO(ListaPlanoConta.Items[i]).Tipo;
                        Split(".", TContabilContaVO(ListaPlanoConta.Items[i]).Classificacao, Niveis);
                        NIVEL = IntToStr(Niveis.Count);
                        COD_CTA = TContabilContaVO(ListaPlanoConta.Items[i]).Classificacao;
                        COD_CTA_SUP = "";
                        CTA = TContabilContaVO(ListaPlanoConta.Items[i]).Descricao;

                        // REGISTRO I051: PLANO DE CONTAS REFERENCIAL
                        {
                        Observação: A partir da versão 3.X e alterações posteriores do PVA do Sped Contábil, não haverá o plano de
                        contas referencial da RFB . Portanto, para as empresas que utilizavam esse plano, não será necessário o preenchimento
                        do registro I051.

                        Fonte: Manual de Orientação da ECD
                        }
                      };
                    };
                  };
                };

                // REGISTRO I052: INDICAÇÃO DOS CÓDIGOS DE AGLUTINAÇÃO
                { Implementado a critério do Participante do T2Ti ERP }


                // REGISTRO I075: TABELA DE HISTÓRICO PADRONIZADO
                ListaHistorico = TT2TiORM.Consultar<TContabilHistoricoVO>("ID_EMPRESA=" + IntToStr(Sessao(SessaoAtual).IdEmpresa), False);
                if assigned(ListaHistorico) then
                {
                  for i = 0 to ListaHistorico.Count - 1 do
                  {
                    using RegistroI075.New do
                    {
                      COD_HIST = IntToStr(TContabilHistoricoVO(ListaHistorico.Items[i]).Id);
                      DESCR_HIST = TContabilHistoricoVO(ListaHistorico.Items[i]).Historico;
                    };
                  };
                };

                // REGISTRO I100: CENTRO DE CUSTOS
                { Implementado a critério do Participante do T2Ti ERP }

                // REGISTRO I150: SALDOS PERIÓDICOS – IDENTIFICAÇÃO DO PERÍODO
                using RegistroI150.New do
                {
                  DT_INI = TextoParaData(DataInicial);
                  DT_FIN = TextoParaData(DataFinal);

                  // REGISTRO I151: Hash dos Arquivos que Contêm as Fichas de Lançamento Utilizadas no Período
                  { Implementado a critério do Participante do T2Ti ERP }

                  // REGISTRO I155: DETALHE DOS SALDOS PERIÓDICOS
                  using RegistroI155.New do
                  {
                    for i = 0 to ListaPlanoConta.Count - 1 do
                    {
                      // Saldo Anterior
                      FiltroLocal = "MES_ANO=" + QuotedStr(PeriodoAnterior(FormatDateTime("MM/YYYY", TextoParaData(DataInicial)))) + " and TIPO=" + QuotedStr("C");
                      RegistroI155C = TT2TiORM.ConsultarUmObjeto<TViewSpedI155VO>(FiltroLocal, False);
                      if Assigned(RegistroI155C) then
                        Credito = RegistroI155C.SomaValor
                      else
                        Credito = 0;

                      FiltroLocal = "MES_ANO=" + QuotedStr(PeriodoAnterior(FormatDateTime("MM/YYYY", TextoParaData(DataInicial)))) + " and TIPO=" + QuotedStr("D");
                      RegistroI155D = TT2TiORM.ConsultarUmObjeto<TViewSpedI155VO>(FiltroLocal, False);
                      if Assigned(RegistroI155D) then
                        Debito = RegistroI155D.SomaValor
                      else
                        Debito = 0;

                      SaldoAnterior = Credito - Debito;

                      COD_CTA = TContabilContaVO(ListaPlanoConta.Items[i]).Classificacao;
                      COD_CCUS = "";
                      VL_SLD_INI = SaldoAnterior;

                      if SaldoAnterior < 0 then
                        IND_DC_INI = "D"
                      else
                        IND_DC_INI = "C";

                      // Saldo Atual
                      FiltroLocal = "MES_ANO=" + QuotedStr(FormatDateTime("MM/YYYY", TextoParaData(DataInicial))) + " and TIPO=" + QuotedStr("C");
                      RegistroI155C = TT2TiORM.ConsultarUmObjeto<TViewSpedI155VO>(FiltroLocal, False);
                      if Assigned(RegistroI155C) then
                        Credito = RegistroI155C.SomaValor
                      else
                        Credito = 0;

                      FiltroLocal = "MES_ANO=" + QuotedStr(FormatDateTime("MM/YYYY", TextoParaData(DataInicial))) + " and TIPO=" + QuotedStr("D");
                      RegistroI155D = TT2TiORM.ConsultarUmObjeto<TViewSpedI155VO>(FiltroLocal, False);
                      if Assigned(RegistroI155D) then
                        Debito = RegistroI155D.SomaValor
                      else
                        Debito = 0;

                      VL_DEB = Debito;
                      VL_CRED = Credito;
                      VL_SLD_FIN = Credito - Debito;

                      if (Credito - Debito) < 0 then
                        IND_DC_FIN = "D"
                      else
                        IND_DC_FIN = "C";

                      // REGISTRO I157: TRANSFERÊNCIA DE SALDOS DE PLANO DE CONTAS ANTERIOR
                      { Implementado a critério do Participante do T2Ti ERP }
                    };
                  };
                };

                // REGISTRO I200: LANÇAMENTO CONTÁBIL
                FiltroLocal = "ID_EMPRESA=" + IntToStr(Sessao(SessaoAtual).IdEmpresa) + " and (DATA_LANCAMENTO BETWEEN " + QuotedStr(DataInicial) + " and " + QuotedStr(DataFinal) + ")";
                ListaLancamentoCabecalho = TT2TiORM.Consultar<TContabilLancamentoCabecalhoVO>(FiltroLocal, False);
                if assigned(ListaLancamentoCabecalho) then
                {
                  for i = 0 to ListaLancamentoCabecalho.Count - 1 do
                  {
                    using RegistroI200.New do
                    {
                      NUM_LCTO = IntToStr(TContabilLancamentoCabecalhoVO(ListaLancamentoCabecalho.Items[i]).Id);
                      DT_LCTO = TContabilLancamentoCabecalhoVO(ListaLancamentoCabecalho.Items[i]).DataLancamento;
                      VL_LCTO = TContabilLancamentoCabecalhoVO(ListaLancamentoCabecalho.Items[i]).Valor;
                      IND_LCTO = "N";

                      // REGISTRO I250: PARTIDAS DO LANÇAMENTO
                      ListaLancamentoDetalhe = TT2TiORM.Consultar<TContabilLancamentoDetalheVO>("ID_CONTABIL_LANCAMENTO_CAB=" + NUM_LCTO, False);
                      if assigned(ListaLancamentoDetalhe) then
                      {
                        for j = 0 to ListaLancamentoDetalhe.Count - 1 do
                        {
                          using RegistroI250.New do
                          {
                            ContaContabil = TT2TiORM.ConsultarUmObjeto<TContabilContaVO>("ID=" + IntToStr(TContabilLancamentoDetalheVO(ListaLancamentoDetalhe.Items[i]).IdContabilConta), False);

                            COD_CTA = ContaContabil.Classificacao;
                            VL_DC = TContabilLancamentoDetalheVO(ListaLancamentoDetalhe.Items[i]).Valor;
                            IND_DC = TContabilLancamentoDetalheVO(ListaLancamentoDetalhe.Items[i]).Tipo;
                            COD_HIST_PAD = IntToStr(TContabilLancamentoDetalheVO(ListaLancamentoDetalhe.Items[i]).IdContabilHistorico);
                            HIST = TContabilLancamentoDetalheVO(ListaLancamentoDetalhe.Items[i]).Historico;
                          };
                        };
                      };
                    };
                  };
                };

                // REGISTRO I300: BALANCETES DIÁRIOS – IDENTIFICAÇÃO DA DATA
                // REGISTRO I310: DETALHES DO BALANCETE DIÁRIO
                { Implementados a critério do Participante do T2Ti ERP }

                // REGISTRO I350: SALDOS DAS CONTAS DE RESULTADO ANTES DO ENCERRAMENTO – IDENTIFICAÇÃO DA DATA
                // REGISTRO I355: DETALHES DOS SALDOS DAS CONTAS DE RESULTADO ANTES DO ENCERRAMENTO
                { Implementados a critério do Participante do T2Ti ERP }

                // REGISTRO I500: PARÂMETROS DE IMPRESSÃO E VISUALIZAÇÃO DO LIVRO RAZÃO AUXILIAR COM LEIAUTE PARAMETRIZÁVEL
                // REGISTRO I510: DEFINIÇÃO DE CAMPOS DO LIVRO RAZÃO AUXILIAR COM LEIAUTE PARAMETRIZÁVEL
                // REGISTRO I550: DETALHES DO LIVRO AUXILIAR COM LEIAUTE PARAMETRIZÁVEL
                // REGISTRO I555: TOTAIS NO LIVRO AUXILIAR COM LEIAUTE PARAMETRIZÁVEL
                { Implementados a critério do Participante do T2Ti ERP }
              };
            */
        }

        #endregion

        #region Bloco J - Demonstrações Contábeis
        public void GerarBlocoJ()
        {
            /*
              ACBrSpedContabil.Bloco_J.LimpaRegistros;

              using ACBrSpedContabil.Bloco_J do
              {
                // REGISTRO J001: ABERTURA DO BLOCO J
                RegistroJ001.IND_DAD = 0;

                // REGISTRO J005: DEMONSTRAÇÕES CONTÁBEIS
                { Implementado a critério do Participante do T2Ti ERP }

                // REGISTRO J100: BALANÇO PATRIMONIAL
                { Implementado a critério do Participante do T2Ti ERP }

                //REGISTRO J150: DEMONSTRAÇÃO DO RESULTADO DO EXERCÍCIO
                { Implementado a critério do Participante do T2Ti ERP }
                ListaDreDetalhe = TT2TiORM.Consultar<TContabilDreDetalheVO>("ID>0", False);
                if assigned(ListaDreDetalhe) then
                {
                  for i = 0 to ListaDreDetalhe.Count - 1 do
                  {
                  };
                };

                // REGISTRO J200: TABELA DE HISTÓRICO DE FATOS CONTÁBEIS QUE MODIFICAM A CONTA LUCROS ACUMULADOS OU A CONTA PREJUÍZOS ACUMULADOS OU TODO O PATRIMÔNIO LÍQUIDO
                // REGISTRO J210: DLPA – DEMONSTRAÇÃO DE LUCROS OU PREJUÍZOS ACUMULADOS/DMPL – DEMONSTRAÇÃO DE MUTAÇÕES DO PATRIMÔNIO LÍQUIDO
                // REGISTRO J215: FATO CONTÁBIL QUE ALTERA A CONTA LUCROS ACUMULADOS OU A CONTA PREJUÍZOS ACUMULADOS OU TODO O PATRIMÔNIO LÍQUIDO
                { Implementados a critério do Participante do T2Ti ERP }

                // REGISTRO J310: DEMONSTRAÇÃO DO FLUXO DE CAIXA
                { Implementado a critério do Participante do T2Ti ERP }

                // REGISTRO J410: DEMONSTRAÇÃO DO VALOR ADICIONADO
                { Implementado a critério do Participante do T2Ti ERP }

                // REGISTRO J800: OUTRAS INFORMAÇÕES
                { Implementado a critério do Participante do T2Ti ERP }

                // REGISTRO J900: TERMO DE ENCERRAMENTO
                ContabilLivro = TT2TiORM.ConsultarUmObjeto<TContabilLivroVO>("FORMA_ESCRITURACAO = " + QuotedStr(EscrituracaoForma) +  " and COMPETENCIA=" + QuotedStr(FormatDateTime("MM/YYYY", TextoParaData(DataInicial))), False);
                if Assigned(ContabilLivro) then
                {
                  TermoLivro = TT2TiORM.ConsultarUmObjeto<TContabilTermoVO>("ID_CONTABIL_LIVRO=" + IntToStr(ContabilLivro.Id) + " and ABERTURA_ENCERRAMENTO=" + QuotedStr("E"), False);
                  RegistroCartorio = TT2TiORM.ConsultarUmObjeto<TRegistroCartorioVO>("ID_EMPRESA=" + IntToStr(Sessao(SessaoAtual).IdEmpresa), False);

                  using RegistroJ900 do
                  {
                    NUM_ORD = TermoLivro.NumeroRegistro;
                    NAT_LIVRO = ContabilLivro.Descricao;
                    QTD_LIN = ACBrSpedContabil.Bloco_9.Registro9999.QTD_LIN;
                    NOME = Empresa.RazaoSocial;
                    DT_INI_ESCR = TermoLivro.EscrituracaoInicio;
                    DT_FIN_ESCR = TermoLivro.EscrituracaoFim;
                  };
                };

                // REGISTRO J930: IDENTIFICAÇÃO DOS SIGNATÁRIOS DA ESCRITURAÇÃO
                Contador = TT2TiORM.ConsultarUmObjeto<TContadorVO>("ID=1", True);
                using RegistroJ930.New do
                {
                  IDENT_NOM = Contador.PessoaNome;
                  IDENT_CPF = Contador.PessoaVO.PessoaFisicaVO.Cpf;
                  IDENT_QUALIF = "Contador";
                  COD_ASSIN = "900";
                  IND_CRC = Contador.InscricaoCrc;
                };
              };
            */
        }
        
        #endregion

        #region Gerar Arquivo
        public bool GerarArquivoSpedContabil(string pDataIni, string pDataFim, int pFormaEscrituracao, int pLayoutVersao, int pIdEmpresa)
        {
            
            DataInicial = pDataIni;
            DataFinal = pDataFim;
            IdEmpresa = pIdEmpresa;

            using (Session = NHibernateHelper.GetSessionFactory().OpenSession())
            {
                GerarBloco0();
                GerarBlocoI();
                GerarBlocoJ();
            }

            ACBrSpedContabil.SaveFileTXT();
            return true;
        }
        #endregion

    }

}

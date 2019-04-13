/* *******************************************************************************
  Title: T2TiPDV
  Description: VO relacionado à tabela ECF_CONFIGURACAO

  The MIT License

  Copyright: Copyright (C) 2014 T2Ti.COM

  Permission is hereby granted, free of charge, to any person
  obtaining a copy of this software and associated documentation
  files (the "Software"), to deal in the Software without
  restriction, including without limitation the rights to use,
  copy, modify, merge, publish, distribute, sublicense, and/or sell
  copies of the Software, and to permit persons to whom the
  Software is furnished to do so, subject to the following
  conditions:

  The above copyright notice and this permission notice shall be
  included in all copies or substantial portions of the Software.

  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
  EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
  OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
  NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
  HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
  WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
  FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
  OTHER DEALINGS IN THE SOFTWARE.

  The author may be contacted at:
  t2ti.com@gmail.com

  @author Albert Eije
  @version 1.0
  ******************************************************************************* */


using System;

namespace ConfiguraPAFECF.VO
{


    public class ConfiguracaoVO
    {


        private int FID;
        private int FID_ECF_IMPRESSORA;
        private int FID_ECF_RESOLUCAO;
        private int FID_ECF_CAIXA;
        private int FID_ECF_EMPRESA;
        private string FMENSAGEM_CUPOM;
        private string FPORTA_ECF;
        private string FIP_SERVIDOR;
        private string FIP_SITEF;
        private string FTIPO_TEF;
        private string FTITULO_TELA_CAIXA;
        private string FCAMINHO_IMAGEM_PRODUTOS;
        private string FCAMINHO_IMAGENS_MARKETING;
        private string FCAMINHO_IMAGENS_LAYOUT;
        private string FCOR_JANELAS_INTERNAS;
        private string FMARKETING_ATIVO;
        private int FCFOP_ECF;
        private int FCFOP_NF2;
        private int FTIMEOUT_ECF;
        private int FINTERVALO_ECF;
        private string FDESCRICAO_SUPRIMENTO;
        private string FDESCRICAO_SANGRIA;
        private int FTEF_TIPO_GP;
        private int FTEF_TEMPO_ESPERA;
        private int FTEF_ESPERA_STS;
        private int FTEF_NUMERO_VIAS;
        private int FDECIMAIS_QUANTIDADE;
        private int FDECIMAIS_VALOR;
        private int FBITS_POR_SEGUNDO;
        private int FQTDE_MAXIMA_CARTOES;
        private string FPESQUISA_PARTE;
        private string FCONFIGURACAO_BALANCA;
        private string FPARAMETROS_DIVERSOS;
        private int FULTIMA_EXCLUSAO;
        private string FLAUDO;
        private string FINDICE_GERENCIAL;
        private DateTime FDATA_ATUALIZACAO_ESTOQUE;
        private string FSINCRONIZADO;

        private ResolucaoVO FResolucaoVO;
        private ImpressoraVO FImpressoraVO;

        private string FModeloImpressora;
        private string FNomeCaixa;

        private string FBalancaIdentificadorBalanca;
        private int FBalancaModelo;
        private int FBalancaHandShaking;
        private int FBalancaParity;
        private int FBalancaStopBits;
        private int FBalancaDataBits;
        private int FBalancaBaudRate;
        private string FBalancaPortaSerial;
        private int FBalancaTimeOut;
        private string FBalancaTipoConfiguracaoBalanca;

        private int FPedeCPFCupom;
        private int FUsaIntegracao;
        private int FTimerIntegracao;
        private int FGavetaDinheiro;
        private int FSinalInvertido;
        private int FQtdeMaximaParcelas;
        private int FImprimeParcelas;
        private int FTecladoReduzido;

        private int FGerencialX;
        private int FMeiosDePagamento;
        private int FDavEmitidos;
        private int FIdentificacaoPaf;
        private int FParametrosDeConfiguracao;
        private int FRelatorio;

        private int FUsaLeitorSerial;
        private string FPortaLeitorSerial;
        private string FBaudLeitorSerial;
        private string FSufixoLeitorSerial;
        private string FIntervaloLeitorSerial;
        private DateTime FDataLeitorSerial;
        private int FParidadeLeitorSerial;
        private int FHardFlowLeitorSerial;
        private int FSoftFlowLeitorSerial;
        private int FHandShakeLeitorSerial;
        private int FStopLeitorSerial;
        private int FFilaLeitorSerial;
        private int FExcluiSufixoLeitorSerial;
        private int FLancamentoNotasManuais;
        private string FNumSerieECF;



        public int Id
        {
            get
            {
                return FID;
            }
            set
            {
                FID = value;
            }
        }


        public int IdImpressora
        {
            get
            {
                return FID_ECF_IMPRESSORA;
            }
            set
            {
                FID_ECF_IMPRESSORA = value;
            }
        }


        public int IdResolucao
        {
            get
            {
                return FID_ECF_RESOLUCAO;
            }
            set
            {
                FID_ECF_RESOLUCAO = value;
            }
        }


        public int IdCaixa
        {
            get
            {
                return FID_ECF_CAIXA;
            }
            set
            {
                FID_ECF_CAIXA = value;
            }
        }


        public int IdEmpresa
        {
            get
            {
                return FID_ECF_EMPRESA;
            }
            set
            {
                FID_ECF_EMPRESA = value;
            }
        }


        public String MensagemCupom
        {
            get
            {
                return FMENSAGEM_CUPOM;
            }
            set
            {
                FMENSAGEM_CUPOM = value;
            }
        }


        public String PortaECF
        {
            get
            {
                return FPORTA_ECF;
            }
            set
            {
                FPORTA_ECF = value;
            }
        }


        public String IpServidor
        {
            get
            {
                return FIP_SERVIDOR;
            }
            set
            {
                FIP_SERVIDOR = value;
            }
        }


        public String IpSitef
        {
            get
            {
                return FIP_SITEF;
            }
            set
            {
                FIP_SITEF = value;
            }
        }


        public String TipoTEF
        {
            get
            {
                return FTIPO_TEF;
            }
            set
            {
                FTIPO_TEF = value;
            }
        }


        public String TituloTelaCaixa
        {
            get
            {
                return FTITULO_TELA_CAIXA;
            }
            set
            {
                FTITULO_TELA_CAIXA = value;
            }
        }


        public String CaminhoImagensProdutos
        {
            get
            {
                return FCAMINHO_IMAGEM_PRODUTOS;
            }
            set
            {
                FCAMINHO_IMAGEM_PRODUTOS = value;
            }
        }


        public String CaminhoImagensMarketing
        {
            get
            {
                return FCAMINHO_IMAGENS_MARKETING;
            }
            set
            {
                FCAMINHO_IMAGENS_MARKETING = value;
            }
        }


        public String CaminhoImagensLayout
        {
            get
            {
                return FCAMINHO_IMAGENS_LAYOUT;
            }
            set
            {
                FCAMINHO_IMAGENS_LAYOUT = value;
            }
        }


        public String CorJanelasInternas
        {
            get
            {
                return FCOR_JANELAS_INTERNAS;
            }
            set
            {
                FCOR_JANELAS_INTERNAS = value;
            }
        }


        public String MarketingAtivo
        {
            get
            {
                return FMARKETING_ATIVO;
            }
            set
            {
                FMARKETING_ATIVO = value;
            }
        }


        public int CFOPECF
        {
            get
            {
                return FCFOP_ECF;
            }
            set
            {
                FCFOP_ECF = value;
            }
        }


        public int CFOPNF2
        {
            get
            {
                return FCFOP_NF2;
            }
            set
            {
                FCFOP_NF2 = value;
            }
        }


        public int TimeOutECF
        {
            get
            {
                return FTIMEOUT_ECF;
            }
            set
            {
                FTIMEOUT_ECF = value;
            }
        }


        public int IntervaloECF
        {
            get
            {
                return FINTERVALO_ECF;
            }
            set
            {
                FINTERVALO_ECF = value;
            }
        }


        public String DescricaoSuprimento
        {
            get
            {
                return FDESCRICAO_SUPRIMENTO;
            }
            set
            {
                FDESCRICAO_SUPRIMENTO = value;
            }
        }


        public String DescricaoSangria
        {
            get
            {
                return FDESCRICAO_SANGRIA;
            }
            set
            {
                FDESCRICAO_SANGRIA = value;
            }
        }


        public int TEFTipoGP
        {
            get
            {
                return FTEF_TIPO_GP;
            }
            set
            {
                FTEF_TIPO_GP = value;
            }
        }


        public int TEFTempoEspera
        {
            get
            {
                return FTEF_TEMPO_ESPERA;
            }
            set
            {
                FTEF_TEMPO_ESPERA = value;
            }
        }


        public int TEFEsperaSTS
        {
            get
            {
                return FTEF_ESPERA_STS;
            }
            set
            {
                FTEF_ESPERA_STS = value;
            }
        }


        public int TEFNumeroVias
        {
            get
            {
                return FTEF_NUMERO_VIAS;
            }
            set
            {
                FTEF_NUMERO_VIAS = value;
            }
        }


        public int DecimaisQuantidade
        {
            get
            {
                return FDECIMAIS_QUANTIDADE;
            }
            set
            {
                FDECIMAIS_QUANTIDADE = value;
            }
        }


        public int DecimaisValor
        {
            get
            {
                return FDECIMAIS_VALOR;
            }
            set
            {
                FDECIMAIS_VALOR = value;
            }
        }


        public int BitsPorSegundo
        {
            get
            {
                return FBITS_POR_SEGUNDO;
            }
            set
            {
                FBITS_POR_SEGUNDO = value;
            }
        }


        public int QuantidadeMaximaCartoes
        {
            get
            {
                return FQTDE_MAXIMA_CARTOES;
            }
            set
            {
                FQTDE_MAXIMA_CARTOES = value;
            }
        }


        public String PesquisaParte
        {
            get
            {
                return FPESQUISA_PARTE;
            }
            set
            {
                FPESQUISA_PARTE = value;
            }
        }


        public String ConfiguracaoBalanca
        {
            get
            {
                return FCONFIGURACAO_BALANCA;
            }
            set
            {
                FCONFIGURACAO_BALANCA = value;
            }
        }


        public String ParametrosDiversos
        {
            get
            {
                return FPARAMETROS_DIVERSOS;
            }
            set
            {
                FPARAMETROS_DIVERSOS = value;
            }
        }


        public int UltimaExclusao
        {
            get
            {
                return FULTIMA_EXCLUSAO;
            }
            set
            {
                FULTIMA_EXCLUSAO = value;
            }
        }


        public String Laudo
        {
            get
            {
                return FLAUDO;
            }
            set
            {
                FLAUDO = value;
            }
        }


        public String IndiceGerencial
        {
            get
            {
                return FINDICE_GERENCIAL;
            }
            set
            {
                FINDICE_GERENCIAL = value;
            }
        }


        public DateTime DataAtualizacaoEstoque
        {
            get
            {
                return FDATA_ATUALIZACAO_ESTOQUE;
            }
            set
            {
                FDATA_ATUALIZACAO_ESTOQUE = value;
            }
        }


        public String Sincronizado
        {
            get
            {
                return FSINCRONIZADO;
            }
            set
            {
                FSINCRONIZADO = value;
            }
        }


        public ResolucaoVO ResolucaoVO
        {
            get
            {
                return FResolucaoVO;
            }
            set
            {
                FResolucaoVO = value;
            }
        }

        public ImpressoraVO ImpressoraVO
        {
            get
            {
                return FImpressoraVO;
            }
            set
            {
                FImpressoraVO = value;
            }
        }

        public String ModeloImpressora
        {
            get
            {
                return FModeloImpressora;
            }
            set
            {
                FModeloImpressora = value;
            }
        }


        public String NomeCaixa
        {
            get
            {
                return FNomeCaixa;
            }
            set
            {
                FNomeCaixa = value;
            }
        }



        public String BalancaIdentificadorBalanca
        {
            get
            {
                return FBalancaIdentificadorBalanca;
            }
            set
            {
                FBalancaIdentificadorBalanca = value;
            }
        }


        public int BalancaModelo
        {
            get
            {
                return FBalancaModelo;
            }
            set
            {
                FBalancaModelo = value;
            }
        }


        public int BalancaHandShaking
        {
            get
            {
                return FBalancaHandShaking;
            }
            set
            {
                FBalancaHandShaking = value;
            }
        }


        public int BalancaParity
        {
            get
            {
                return FBalancaParity;
            }
            set
            {
                FBalancaParity = value;
            }
        }


        public int BalancaStopBits
        {
            get
            {
                return FBalancaStopBits;
            }
            set
            {
                FBalancaStopBits = value;
            }
        }


        public int BalancaDataBits
        {
            get
            {
                return FBalancaDataBits;
            }
            set
            {
                FBalancaDataBits = value;
            }
        }


        public int BalancaBaudRate
        {
            get
            {
                return FBalancaBaudRate;
            }
            set
            {
                FBalancaBaudRate = value;
            }
        }


        public String BalancaPortaSerial
        {
            get
            {
                return FBalancaPortaSerial;
            }
            set
            {
                FBalancaPortaSerial = value;
            }
        }


        public int BalancaTimeOut
        {
            get
            {
                return FBalancaTimeOut;
            }
            set
            {
                FBalancaTimeOut = value;
            }
        }


        public String BalancaTipoConfiguracaoBalanca
        {
            get
            {
                return FBalancaTipoConfiguracaoBalanca;
            }
            set
            {
                FBalancaTipoConfiguracaoBalanca = value;
            }
        }



        public int PedeCPFCupom
        {
            get
            {
                return FPedeCPFCupom;
            }
            set
            {
                FPedeCPFCupom = value;
            }
        }


        public int UsaIntegracao
        {
            get
            {
                return FUsaIntegracao;
            }
            set
            {
                FUsaIntegracao = value;
            }
        }


        public int TimerIntegracao
        {
            get
            {
                return FTimerIntegracao;
            }
            set
            {
                FTimerIntegracao = value;
            }
        }


        public int GavetaDinheiro
        {
            get
            {
                return FGavetaDinheiro;
            }
            set
            {
                FGavetaDinheiro = value;
            }
        }


        public int SinalInvertido
        {
            get
            {
                return FSinalInvertido;
            }
            set
            {
                FSinalInvertido = value;
            }
        }


        public int QtdeMaximaParcelas
        {
            get
            {
                return FQtdeMaximaParcelas;
            }
            set
            {
                FQtdeMaximaParcelas = value;
            }
        }


        public int ImprimeParcelas
        {
            get
            {
                return FImprimeParcelas;
            }
            set
            {
                FImprimeParcelas = value;
            }
        }


        public int TecladoReduzido
        {
            get
            {
                return FTecladoReduzido;
            }
            set
            {
                FTecladoReduzido = value;
            }
        }



        public int GerencialX
        {
            get
            {
                return FGerencialX;
            }
            set
            {
                FGerencialX = value;
            }
        }


        public int MeiosDePagamento
        {
            get
            {
                return FMeiosDePagamento;
            }
            set
            {
                FMeiosDePagamento = value;
            }
        }


        public int DavEmitidos
        {
            get
            {
                return FDavEmitidos;
            }
            set
            {
                FDavEmitidos = value;
            }
        }


        public int IdentificacaoPaf
        {
            get
            {
                return FIdentificacaoPaf;
            }
            set
            {
                FIdentificacaoPaf = value;
            }
        }


        public int ParametrosDeConfiguracao
        {
            get
            {
                return FParametrosDeConfiguracao;
            }
            set
            {
                FParametrosDeConfiguracao = value;
            }
        }


        public int Relatorio
        {
            get
            {
                return FRelatorio;
            }
            set
            {
                FRelatorio = value;
            }
        }



        public int UsaLeitorSerial
        {
            get
            {
                return FUsaLeitorSerial;
            }
            set
            {
                FUsaLeitorSerial = value;
            }
        }


        public String PortaLeitorSerial
        {
            get
            {
                return FPortaLeitorSerial;
            }
            set
            {
                FPortaLeitorSerial = value;
            }
        }


        public String BaudLeitorSerial
        {
            get
            {
                return FBaudLeitorSerial;
            }
            set
            {
                FBaudLeitorSerial = value;
            }
        }


        public String SufixoLeitorSerial
        {
            get
            {
                return FSufixoLeitorSerial;
            }
            set
            {
                FSufixoLeitorSerial = value;
            }
        }


        public String IntervaloLeitorSerial
        {
            get
            {
                return FIntervaloLeitorSerial;
            }
            set
            {
                FIntervaloLeitorSerial = value;
            }
        }


        public DateTime DataLeitorSerial
        {
            get
            {
                return FDataLeitorSerial;
            }
            set
            {
                FDataLeitorSerial = value;
            }
        }


        public int ParidadeLeitorSerial
        {
            get
            {
                return FParidadeLeitorSerial;
            }
            set
            {
                FParidadeLeitorSerial = value;
            }
        }


        public int HardFlowLeitorSerial
        {
            get
            {
                return FHardFlowLeitorSerial;
            }
            set
            {
                FHardFlowLeitorSerial = value;
            }
        }


        public int SoftFlowLeitorSerial
        {
            get
            {
                return FSoftFlowLeitorSerial;
            }
            set
            {
                FSoftFlowLeitorSerial = value;
            }
        }


        public int HandShakeLeitorSerial
        {
            get
            {
                return FHandShakeLeitorSerial;
            }
            set
            {
                FHandShakeLeitorSerial = value;
            }
        }


        public int StopLeitorSerial
        {
            get
            {
                return FStopLeitorSerial;
            }
            set
            {
                FStopLeitorSerial = value;
            }
        }


        public int FilaLeitorSerial
        {
            get
            {
                return FFilaLeitorSerial;
            }
            set
            {
                FFilaLeitorSerial = value;
            }
        }


        public int ExcluiSufixoLeitorSerial
        {
            get
            {
                return FExcluiSufixoLeitorSerial;
            }
            set
            {
                FExcluiSufixoLeitorSerial = value;
            }
        }


        public int LancamentoNotasManuais
        {
            get
            {
                return FLancamentoNotasManuais;
            }
            set
            {
                FLancamentoNotasManuais = value;
            }
        }


        public String NumSerieECF
        {
            get
            {
                return FNumSerieECF;
            }
            set
            {
                FNumSerieECF = value;
            }
        }


    }

}
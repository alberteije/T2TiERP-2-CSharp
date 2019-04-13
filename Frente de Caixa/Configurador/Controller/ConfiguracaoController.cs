/********************************************************************************
Title: T2TiPDV
Description: Classe de controle da configuração

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
********************************************************************************/


using System;
using System.Collections.Generic;
using ConfiguraPAFECF.VO;
using ConfiguraPAFECF.Util;
using FirebirdSql.Data.FirebirdClient;

namespace ConfiguraPAFECF.Controller
{

    public class ConfiguracaoController
    {
        private FbConnection conexao;
        private FbCommand comando;
        private FbDataReader Leitor;
        public string ConsultaSQL;

        public ConfiguracaoController()
        {
            conexao = dbConnection.conectar();
        }


        public ConfiguracaoVO PegaConfiguracao()
        {
            ConfiguracaoVO Configuracao = new ConfiguracaoVO();
            ImpressoraVO Impressora = new ImpressoraVO();
            Configuracao.ImpressoraVO = Impressora;
            ResolucaoVO Resolucao = new ResolucaoVO();
            Configuracao.ResolucaoVO = Resolucao;

            ConsultaSQL = "select " +
                        " C.ID_ECF_IMPRESSORA, " +
                        " C.ID_ECF_RESOLUCAO, " +
                        " C.ID_ECF_CAIXA, " +
                        " C.ID_ECF_EMPRESA, " +
                        " C.MENSAGEM_CUPOM, " +
                        " C.PORTA_ECF, " +
                        " C.IP_SERVIDOR, " +
                        " C.IP_SITEF, " +
                        " C.TIPO_TEF, " +
                        " C.TITULO_TELA_CAIXA, " +
                        " C.CAMINHO_IMAGENS_PRODUTOS, " +
                        " C.CAMINHO_IMAGENS_MARKETING, " +
                        " C.CAMINHO_IMAGENS_LAYOUT, " +
                        " C.COR_JANELAS_INTERNAS, " +
                        " C.MARKETING_ATIVO, " +
                        " C.CFOP_ECF, " +
                        " C.CFOP_NF2, " +
                        " C.TIMEOUT_ECF, " +
                        " C.INTERVALO_ECF, " +
                        " C.DESCRICAO_SUPRIMENTO, " +
                        " C.DESCRICAO_SANGRIA, " +
                        " C.TEF_TIPO_GP, " +
                        " C.TEF_TEMPO_ESPERA, " +
                        " C.TEF_ESPERA_STS, " +
                        " C.TEF_NUMERO_VIAS, " +
                        " C.DECIMAIS_QUANTIDADE, " +
                        " C.DECIMAIS_VALOR, " +
                        " C.BITS_POR_SEGUNDO, " +
                        " C.QUANTIDADE_MAXIMA_CARTOES, " +
                        " C.PESQUISA_PARTE, " +
                        " C.ULTIMA_EXCLUSAO, " +
                        " C.LAUDO, " +
                        " C.DATA_ATUALIZACAO_ESTOQUE, " +
                        " R.RESOLUCAO_TELA, " +
                        " R.LARGURA, " +
                        " R.ALTURA, " +
                        " R.IMAGEM_TELA, " +
                        " R.IMAGEM_MENU, " +
                        " R.IMAGEM_SUBMENU, " +
                        " R.HOTTRACK_COLOR, " +
                        " R.ITEM_STYLE_FONT_NAME, " +
                        " R.ITEM_STYLE_FONT_COLOR, " +
                        " R.ITEM_SEL_STYLE_COLOR, " +
                        " R.LABEL_TOTAL_GERAL_FONT_COLOR, " +
                        " R.ITEM_STYLE_FONT_STYLE," +
                        " R.EDITS_COLOR, " +
                        " R.EDITS_FONT_COLOR, " +
                        " R.EDITS_DISABLED_COLOR, " +
                        " R.EDITS_FONT_NAME, " +
                        " R.EDITS_FONT_STYLE, " +
                        " (select nome from ECF_CAIXA where ECF_CAIXA.id=c.ID_ECF_CAIXA) AS NOME_CAIXA," +
                        " I.MODELO_ACBR, " +
                        " I.SERIE " +
                        "from " +
                        " ECF_RESOLUCAO R, ECF_CONFIGURACAO C, ECF_IMPRESSORA I " +
                        "where " +
                        " C.ID_ECF_RESOLUCAO=R.ID and C.ID_ECF_IMPRESSORA=I.ID";

            try
            {
                comando = new FbCommand(ConsultaSQL, conexao);
                Leitor = comando.ExecuteReader();
                if (Leitor.Read())
                {

                    Configuracao.IdImpressora = Convert.ToInt32(Leitor["ID_ECF_IMPRESSORA"]);
                    Configuracao.IdCaixa = Convert.ToInt32(Leitor["ID_ECF_CAIXA"]);
                    Configuracao.IdEmpresa = Convert.ToInt32(Leitor["ID_ECF_EMPRESA"]);
                    Configuracao.MensagemCupom = Convert.ToString(Leitor["MENSAGEM_CUPOM"]);
                    Configuracao.PortaECF = Convert.ToString(Leitor["PORTA_ECF"]);
                    Configuracao.IpServidor = Convert.ToString(Leitor["IP_SERVIDOR"]);
                    Configuracao.IpSitef = Convert.ToString(Leitor["IP_SITEF"]);
                    Configuracao.TipoTEF = Convert.ToString(Leitor["TIPO_TEF"]);
                    Configuracao.TituloTelaCaixa = Convert.ToString(Leitor["TITULO_TELA_CAIXA"]);
                    Configuracao.CaminhoImagensProdutos = Convert.ToString(Leitor["CAMINHO_IMAGENS_PRODUTOS"]);
                    Configuracao.CaminhoImagensMarketing = Convert.ToString(Leitor["CAMINHO_IMAGENS_MARKETING"]);
                    Configuracao.CaminhoImagensLayout = Convert.ToString(Leitor["CAMINHO_IMAGENS_LAYOUT"]);
                    Configuracao.CorJanelasInternas = Convert.ToString(Leitor["COR_JANELAS_INTERNAS"]);
                    Configuracao.MarketingAtivo = Convert.ToString(Leitor["MARKETING_ATIVO"]);
                    Configuracao.CFOPECF = Convert.ToInt32(Leitor["CFOP_ECF"]);
                    Configuracao.CFOPNF2 = Convert.ToInt32(Leitor["CFOP_NF2"]);
                    Configuracao.TimeOutECF = Convert.ToInt32(Leitor["TIMEOUT_ECF"]);
                    Configuracao.IntervaloECF = Convert.ToInt32(Leitor["INTERVALO_ECF"]);
                    Configuracao.DescricaoSuprimento = Convert.ToString(Leitor["DESCRICAO_SUPRIMENTO"]);
                    Configuracao.DescricaoSangria = Convert.ToString(Leitor["DESCRICAO_SANGRIA"]);
                    Configuracao.TEFTipoGP = Convert.ToInt32(Leitor["TEF_TIPO_GP"]);
                    Configuracao.TEFTempoEspera = Convert.ToInt32(Leitor["TEF_TEMPO_ESPERA"]);
                    Configuracao.TEFEsperaSTS = Convert.ToInt32(Leitor["TEF_ESPERA_STS"]);
                    Configuracao.TEFNumeroVias = Convert.ToInt32(Leitor["TEF_NUMERO_VIAS"]);
                    Configuracao.DecimaisQuantidade = Convert.ToInt32(Leitor["DECIMAIS_QUANTIDADE"]);
                    Configuracao.DecimaisValor = Convert.ToInt32(Leitor["DECIMAIS_VALOR"]);
                    Configuracao.BitsPorSegundo = Convert.ToInt32(Leitor["BITS_POR_SEGUNDO"]);
                    Configuracao.QuantidadeMaximaCartoes = Convert.ToInt32(Leitor["QUANTIDADE_MAXIMA_CARTOES"]);
                    Configuracao.PesquisaParte = Convert.ToString(Leitor["PESQUISA_PARTE"]);
                    Configuracao.UltimaExclusao = Convert.ToInt32(Leitor["ULTIMA_EXCLUSAO"]);
                    Configuracao.Laudo = Convert.ToString(Leitor["LAUDO"]);
                    Configuracao.DataAtualizacaoEstoque = (DateTime)(Leitor["DATA_ATUALIZACAO_ESTOQUE"]);

                    Configuracao.ResolucaoVO.ResolucaoTela = Convert.ToString(Leitor["RESOLUCAO_TELA"]);
                    Configuracao.ResolucaoVO.Largura = Convert.ToInt32(Leitor["LARGURA"]);
                    Configuracao.ResolucaoVO.Altura = Convert.ToInt32(Leitor["ALTURA"]);
                    Configuracao.ResolucaoVO.ImagemTela = Convert.ToString(Leitor["IMAGEM_TELA"]);
                    Configuracao.ResolucaoVO.ImagemMenu = Convert.ToString(Leitor["IMAGEM_MENU"]);
                    Configuracao.ResolucaoVO.ImagemSubMenu = Convert.ToString(Leitor["IMAGEM_SUBMENU"]);
                    Configuracao.ResolucaoVO.HotTrackColor = Convert.ToString(Leitor["HOTTRACK_COLOR"]);
                    Configuracao.ResolucaoVO.ItemStyleFontName = Convert.ToString(Leitor["ITEM_STYLE_FONT_NAME"]);
                    Configuracao.ResolucaoVO.ItemStyleFontColor = Convert.ToString(Leitor["ITEM_STYLE_FONT_COLOR"]);
                    Configuracao.ResolucaoVO.ItemSelStyleColor = Convert.ToString(Leitor["ITEM_SEL_STYLE_COLOR"]);
                    Configuracao.ResolucaoVO.LabelTotalGeralFontColor = Convert.ToString(Leitor["LABEL_TOTAL_GERAL_FONT_COLOR"]);
                    Configuracao.ResolucaoVO.ItemStyleFontStyle = Convert.ToString(Leitor["ITEM_STYLE_FONT_STYLE"]);
                    Configuracao.ResolucaoVO.EditColor = Convert.ToString(Leitor["EDITS_COLOR"]);
                    Configuracao.ResolucaoVO.EditFontColor = Convert.ToString(Leitor["EDITS_FONT_COLOR"]);
                    Configuracao.ResolucaoVO.EditDisabledColor = Convert.ToString(Leitor["EDITS_DISABLED_COLOR"]);
                    Configuracao.ResolucaoVO.EditFontName = Convert.ToString(Leitor["EDITS_FONT_NAME"]);
                    Configuracao.ResolucaoVO.EditFontStyle = Convert.ToString(Leitor["EDITS_FONT_STYLE"]);

                    Configuracao.NomeCaixa = Convert.ToString(Leitor["NOME_CAIXA"]);
                    Configuracao.ModeloImpressora = Convert.ToString(Leitor["MODELO_ACBR"]);
                    Configuracao.NumSerieECF = Convert.ToString(Leitor["SERIE"]);

                    return Configuracao;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
                return null;
            }
            finally
            {
                if (Leitor != null)
                    Leitor.Close();
            }
        }

        public List<PosicaoComponentesVO> VerificaPosicaoTamanho()
        {
            List<PosicaoComponentesVO> listaPosicoes = new List<PosicaoComponentesVO>();
            ConsultaSQL =
                    " select "
                    + "P.ID,"
                    + "P.NOME, "
                    + "P.ALTURA, "
                    + "P.LARGURA, "
                    + "P.TOPO, "
                    + "P.ESQUERDA, "
                    + "P.TAMANHO_FONTE, "
                    + "P.TEXTO, "
                    + "C.ID_ECF_RESOLUCAO "
                    + " from "
                    + "ECF_POSICAO_COMPONENTES P, ECF_CONFIGURACAO C "
                    + " where "
                    + "P.ID_ECF_RESOLUCAO=C.ID_ECF_RESOLUCAO";
            try
            {
                comando = new FbCommand(ConsultaSQL, conexao);
                Leitor = comando.ExecuteReader();

                while (Leitor.Read())
                {
                    PosicaoComponentesVO PosicaoComponentes = new PosicaoComponentesVO();

                    PosicaoComponentes.Id = Convert.ToInt32(Leitor["ID"]);
                    PosicaoComponentes.NomeComponente = Leitor["NOME"].ToString();
                    PosicaoComponentes.Altura = Convert.ToInt32(Leitor["ALTURA"]);
                    PosicaoComponentes.Largura = Convert.ToInt32(Leitor["LARGURA"]);
                    PosicaoComponentes.Topo = Convert.ToInt32(Leitor["TOPO"]);
                    PosicaoComponentes.Esquerda = Convert.ToInt32(Leitor["ESQUERDA"]);
                    PosicaoComponentes.TamanhoFonte = Convert.ToInt32(Leitor["TAMANHO_FONTE"]);
                    PosicaoComponentes.TextoComponente = Leitor["TEXTO"].ToString();

                    listaPosicoes.Add(PosicaoComponentes);
                }
                return listaPosicoes;
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
                return null;
            }
            finally
            {
                if (Leitor != null)
                    Leitor.Close();
            }
        }


        public void GravarPosicaoComponentes(List<PosicaoComponentesVO> pListaPosicaoComponentes)
        {
            ConsultaSQL =
              "update ECF_POSICAO_COMPONENTES set " +
              " NOME = ?pNOME, " +
              " ALTURA = ?pALTURA, " +
              " LARGURA = ?pLARGURA, " +
              " TOPO = ?pTOPO, " +
              " ESQUERDA = ?pESQUERDA, " +
              " TAMANHO_FONTE = ?pTAMANHO_FONTE, " +
              " TEXTO = ?pTEXTO " +
              " where ID_ECF_RESOLUCAO = ?pID_ECF_RESOLUCAO and NOME = ?pNOME";

            try
            {
                for (int i = 0; i <= pListaPosicaoComponentes.Count - 1; i++)
                {
                    comando = new FbCommand(ConsultaSQL, conexao);

                    comando.Parameters.AddWithValue("?pNOME", pListaPosicaoComponentes[i].NomeComponente);
                    comando.Parameters.AddWithValue("?pALTURA", pListaPosicaoComponentes[i].Altura);
                    comando.Parameters.AddWithValue("?pLARGURA", pListaPosicaoComponentes[i].Largura);
                    comando.Parameters.AddWithValue("?pTOPO", pListaPosicaoComponentes[i].Topo);
                    comando.Parameters.AddWithValue("?pESQUERDA", pListaPosicaoComponentes[i].Esquerda);
                    comando.Parameters.AddWithValue("?pTAMANHO_FONTE", pListaPosicaoComponentes[i].TamanhoFonte);
                    comando.Parameters.AddWithValue("?pTEXTO", pListaPosicaoComponentes[i].TextoComponente);
                    comando.Parameters.AddWithValue("?pID_ECF_RESOLUCAO", pListaPosicaoComponentes[i].IdResolucao);

                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
            finally
            {
                if (Leitor != null)
                    Leitor.Close();
            }
        }


    }

}
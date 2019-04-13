using System;
using System.Collections.Generic;
using System.Web.UI;
using BoletoNet;
using Microsoft.VisualBasic;

[assembly: WebResource("BoletoNet.Imagens.237.jpg", "image/jpg")]

namespace BoletoNet
{
    /// <author>  
    /// Eduardo Frare
    /// Stiven 
    /// </author>    
    internal class Banco_Bradesco : AbstractBanco, IBanco
    {
        private string _dacNossoNumero = string.Empty;
        private int _dacBoleto = 0;

        /// <summary>
        /// Classe responsavel em criar os campos do Banco Banco_Bradesco.
        /// </summary>
        internal Banco_Bradesco()
        {
            this.Codigo = 237;
            this.Digito = 2;
            this.Nome = "Bradesco";
        }

        #region IBanco Members

        /// <summary>
        /// A linha digitável será composta por cinco campos:
        ///      1º campo
        ///          composto pelo código de Banco, código da moeda, as cinco primeiras posições do campo 
        ///          livre e o dígito verificador deste campo;
        ///      2º campo
        ///          composto pelas posições 6ª a 15ª do campo livre e o dígito verificador deste campo;
        ///      3º campo
        ///          composto pelas posições 16ª a 25ª do campo livre e o dígito verificador deste campo;
        ///      4º campo
        ///          composto pelo dígito verificador do código de barras, ou seja, a 5ª posição do código de 
        ///          barras;
        ///      5º campo
        ///          Composto pelo fator de vencimento com 4(quatro) caracteres e o valor do documento com 10(dez) caracteres, sem separadores e sem edição.
        /// 
        /// </summary>
        public override void FormataLinhaDigitavel(Boleto boleto)
        {

            //BBBMC.CCCCD1 CCCCC.CCCCCD2 CCCCC.CCCCCD3 D4 FFFFVVVVVVVVVV


            #region Campo 1

            string Grupo1 = string.Empty;

            string BBB = boleto.CodigoBarra.Codigo.Substring(0, 3);
            string M = boleto.CodigoBarra.Codigo.Substring(3, 1);
            string CCCCC = boleto.CodigoBarra.Codigo.Substring(19, 5);
            string D1 = Mod10(BBB + M + CCCCC).ToString();

            Grupo1 = string.Format("{0}{1}{2}.{3}{4} ", BBB, M, CCCCC.Substring(0, 1), CCCCC.Substring(1, 4), D1);


            #endregion Campo 1

            #region Campo 2

            string Grupo2 = string.Empty;

            string CCCCCCCCCC2 = boleto.CodigoBarra.Codigo.Substring(24, 10);
            string D2 = Mod10(CCCCCCCCCC2).ToString();

            Grupo2 = string.Format("{0}.{1}{2} ", CCCCCCCCCC2.Substring(0, 5), CCCCCCCCCC2.Substring(5, 5), D2);

            #endregion Campo 2

            #region Campo 3

            string Grupo3 = string.Empty;

            string CCCCCCCCCC3 = boleto.CodigoBarra.Codigo.Substring(34, 10);
            string D3 = Mod10(CCCCCCCCCC3).ToString();

            Grupo3 = string.Format("{0}.{1}{2} ", CCCCCCCCCC3.Substring(0, 5), CCCCCCCCCC3.Substring(5, 5), D3);


            #endregion Campo 3

            #region Campo 4

            string Grupo4 = string.Empty;

            string D4 = _dacBoleto.ToString();

            Grupo4 = string.Format("{0} ", D4);

            #endregion Campo 4

            #region Campo 5

            string Grupo5 = string.Empty;

            //string FFFF = boleto.CodigoBarra.Codigo.Substring(5, 4);//FatorVencimento(boleto).ToString() ;
            string FFFF = FatorVencimento(boleto).ToString();

            //if (boleto.Carteira == "06" && !Utils.DataValida(boleto.DataVencimento))
            //    FFFF = "0000";

            string VVVVVVVVVV = boleto.ValorBoleto.ToString("f").Replace(",", "").Replace(".", "");
            VVVVVVVVVV = Utils.FormatCode(VVVVVVVVVV, 10);

            //if (Utils.ToInt64(VVVVVVVVVV) == 0)
            //    VVVVVVVVVV = "000";

            Grupo5 = string.Format("{0}{1}", FFFF, VVVVVVVVVV);

            #endregion Campo 5

            boleto.CodigoBarra.LinhaDigitavel = Grupo1 + Grupo2 + Grupo3 + Grupo4 + Grupo5;

        }

        /// <summary>
        /// 
        ///   *******
        /// 
        ///	O código de barra para cobrança contém 44 posições dispostas da seguinte forma:
        ///    01 a 03 - 3 - Identificação  do  Banco
        ///    04 a 04 - 1 - Código da Moeda
        ///    05 a 05 – 1 - Dígito verificador do Código de Barras
        ///    06 a 09 - 4 - Fator de vencimento
        ///    10 a 19 - 10 - Valor
        ///    20 a 44 – 25 - Campo Livre
        /// 
        ///   *******
        /// 
        /// </summary>
        /// 
        public override void FormataCodigoBarra(Boleto boleto)
        {
            string valorBoleto = boleto.ValorBoleto.ToString("f").Replace(",", "").Replace(".", "");
            valorBoleto = Utils.FormatCode(valorBoleto, 10);

            if (boleto.Carteira == "02" || boleto.Carteira == "03" || boleto.Carteira == "09")
            {
                boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}", Codigo.ToString(), boleto.Moeda,
                FatorVencimento(boleto), valorBoleto, FormataCampoLivre(boleto));
            }
            else if (boleto.Carteira == "06")
            {
                if (boleto.ValorBoleto == 0)
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}0000{2}{3}", Codigo.ToString(), boleto.Moeda,
                        valorBoleto, FormataCampoLivre(boleto));
                }
                else
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}", Codigo.ToString(), boleto.Moeda,
                        FatorVencimento(boleto), valorBoleto, FormataCampoLivre(boleto));
                }

            }


            _dacBoleto = Mod11(boleto.CodigoBarra.Codigo, 9);

            boleto.CodigoBarra.Codigo = Strings.Left(boleto.CodigoBarra.Codigo, 4) + _dacBoleto + Strings.Right(boleto.CodigoBarra.Codigo, 39);
        }


        ///<summary>
        /// Campo Livre
        ///    20 a 23 -  4 - Agência Cedente (Sem o digito verificador,completar com zeros a esquerda quandonecessário)
        ///    24 a 25 -  2 - Carteira
        ///    26 a 36 - 11 - Número do Nosso Número(Sem o digito verificador)
        ///    37 a 43 -  7 - Conta do Cedente (Sem o digito verificador,completar com zeros a esquerda quando necessário)
        ///    44 a 44	- 1 - Zero            
        ///</summary>
        public string FormataCampoLivre(Boleto boleto)
        {

            string FormataCampoLivre = string.Format("{0}{1}{2}{3}{4}", boleto.Cedente.ContaBancaria.Agencia, boleto.Carteira,
                                            boleto.NossoNumero, boleto.Cedente.ContaBancaria.Conta, "0");

            return FormataCampoLivre;
        }


        public override void FormataNumeroDocumento(Boleto boleto)
        {
            throw new NotImplementedException("Função ainda não implementada.");
        }


        public override void FormataNossoNumero(Boleto boleto)
        {
            boleto.NossoNumero = string.Format("{0}/{1}-{2}", boleto.Carteira, boleto.NossoNumero,
                                            Mod11Bradesco(boleto.Carteira + boleto.NossoNumero, 7));
        }


        public override void ValidaBoleto(Boleto boleto)
        {
            if (boleto.Carteira != "02" && boleto.Carteira != "03" && boleto.Carteira != "06" && boleto.Carteira != "09")
                throw new NotImplementedException("Carteira não implementada. Carteiras implementadas 02, 03, 06, 09.");

            //O valor é obrigatório para a carteira 03
            if (boleto.Carteira == "03")
            {
                if (boleto.ValorBoleto == 0)
                    throw new NotImplementedException("Para a carteira 03, o valor do boleto não pode ser igual a zero");
            }

            //O valor é obrigatório para a carteira 09
            if (boleto.Carteira == "09")
            {
                if (boleto.ValorBoleto == 0)
                    throw new NotImplementedException("Para a carteira 09, o valor do boleto não pode ser igual a zero");
            }
            //else if (boleto.Carteira == "06")
            //{
            //    boleto.ValorBoleto = 0;
            //}

            //Verifica se o nosso número é válido
            if (boleto.NossoNumero.Length > 11)
                throw new NotImplementedException("A quantidade de dígitos do nosso número, são 11 números.");
            else if (boleto.NossoNumero.Length < 11)
                boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 11);

            //Verificar se a Agencia esta correta
            if (boleto.Cedente.ContaBancaria.Agencia.Length > 4)
                throw new NotImplementedException("A quantidade de dígitos da Agência " + boleto.Cedente.ContaBancaria.Agencia + ", são de 4 números.");
            else if (boleto.Cedente.ContaBancaria.Agencia.Length < 4)
                boleto.Cedente.ContaBancaria.Agencia = Utils.FormatCode(boleto.Cedente.ContaBancaria.Agencia, 4);

            //Verificar se a Conta esta correta
            if (boleto.Cedente.ContaBancaria.Conta.Length > 7)
                throw new NotImplementedException("A quantidade de dígitos da Conta " + boleto.Cedente.ContaBancaria.Conta + ", são de 07 números.");
            else if (boleto.Cedente.ContaBancaria.Conta.Length < 7)
                boleto.Cedente.ContaBancaria.Conta = Utils.FormatCode(boleto.Cedente.ContaBancaria.Conta, 7);


            //Atribui o nome do banco ao local de pagamento
            boleto.LocalPagamento += Nome + "";


            //Verifica se data do processamento é valida
            if (boleto.DataProcessamento.ToString("dd/MM/yyyy") == "01/01/0001")
                boleto.DataProcessamento = DateTime.Now;


            //Verifica se data do documento é valida
            if (boleto.DataDocumento.ToString("dd/MM/yyyy") == "01/01/0001")
                boleto.DataDocumento = DateTime.Now;

            boleto.QuantidadeMoeda = 0;

            //Atribui o nome do banco ao local de pagamento
            boleto.LocalPagamento = "PAGÁVEL PREFERENCIALMENTE NAS AGÊNCIAS DO BRADESCO";

            FormataCodigoBarra(boleto);
            FormataLinhaDigitavel(boleto);
            FormataNossoNumero(boleto);
        }
        #endregion IBanco Members

        /// <summary>
        /// Verifica o tipo de ocorrência para o arquivo remessa
        /// </summary>
        public string Ocorrencia(string codigo)
        {
            switch (codigo)
            {
                case "02":
                    return "02-Entrada Confirmada";
                case "03":
                    return "03-Entrada Rejeitada";
                case "06":
                    return "06-Liquidação  normal";
                case "09":
                    return "09-Baixado Automaticamente via Arquivo";
                case "10":
                    return "10-Baixado conforme instruções da Agência";
                case "11":
                    return "11-Em Ser - Arquivo de Títulos pendentes";
                case "12":
                    return "12-Abatimento Concedido";
                case "13":
                    return "13-Abatimento Cancelado";
                case "14":
                    return "14-Vencimento Alterado";
                case "15":
                    return "15-Liquidação em Cartório";
                case "17":
                    return "17-Liquidação após baixa ou Título não registrado";
                case "18":
                    return "18-Acerto de Depositária";
                case "19":
                    return "19-Confirmação Recebimento Instrução de Protesto";
                case "20":
                    return "20-Confirmação Recebimento Instrução Sustação de Protesto";
                case "21":
                    return "21-Acerto do Controle do Participante";
                case "23":
                    return "22-Entrada do Título em Cartório";
                case "24":
                    return "23-Entrada rejeitada por CEP Irregular";
                case "27":
                    return "27-Baixa Rejeitada";
                case "28":
                    return "28-Débito de tarifas/custas";
                case "30":
                    return "30-Alteração de Outros Dados Rejeitados";
                case "32":
                    return "32-Instrução Rejeitada";
                case "33":
                    return "33-Confirmação Pedido Alteração Outros Dados";
                case "34":
                    return "34-Retirado de Cartório e Manutenção Carteira";
                case "35":
                    return "35-Desagendamento ) débito automático";
                case "68":
                    return "68-Acerto dos dados ) rateio de Crédito";
                case "69":
                    return "69-Cancelamento dos dados ) rateio";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Verifica o código do motivo da rejeição informada pelo banco
        /// </summary>
        public string MotivoRejeicao(string codigo)
        {
            switch (codigo)
            {
                case "02":
                    return "02-Código do registro detalhe inválido";
                case "03":
                    return "03-Código da ocorrência inválida";
                case "04":
                    return "04-Código de ocorrência não permitida para a carteira";
                case "05":
                    return "05-Código de ocorrência não numérico";
                case "07":
                    return "07-Agência/conta/Digito - Inválido";
                case "08":
                    return "08-Nosso número inválido";
                case "09":
                    return "09-Nosso número duplicado";
                case "10":
                    return "10-Carteira inválida";
                case "16":
                    return "16-Data de vencimento inválida";
                case "18":
                    return "18-Vencimento fora do prazo de operação";
                case "20":
                    return "19-Valor do Título inválido";
                case "21":
                    return "21-Espécie do Título inválida";
                case "22":
                    return "22-Espécie não permitida para a carteira";
                case "24":
                    return "24-Data de emissão inválida";
                case "38":
                    return "38-Prazo para protesto inválido";
                case "44":
                    return "44-Agência Cedente não prevista";
                case "50":
                    return "50-CEP irregular - Banco Correspondente";
                case "63":
                    return "63-Entrada para Título já cadastrado";
                case "68":
                    return "68-Débito não agendado - erro nos dados de remessa";
                case "69":
                    return "69-Débito não agendado - Sacado não consta no cadastro de autorizante";
                case "70":
                    return "70-Débito não agendado - Cedente não autorizado pelo Sacado";
                case "71":
                    return "71-Débito não agendado - Cedente não participa da modalidade de débito automático";
                case "72":
                    return "72-Débito não agendado - Código de moeda diferente de R$";
                case "73":
                    return "73-Débito não agendado - Data de vencimento inválida";
                case "74":
                    return "74-Débito não agendado - Conforme seu pedido, Título não registrado";
                case "75":
                    return "75-Débito não agendado - Tipo de número de inscrição do debitado inválido";
                default:
                    return "";
            }
        }

        private string Mod11Bradesco(string seq, int b)
        {
            #region Trecho do manual layout_cobranca_port.pdf do BRADESCO
            /* 
            Para o cálculo do dígito, será necessário acrescentar o número da carteira à esquerda antes do Nosso Número, 
            e aplicar o módulo 11, com base 7.
            Multiplicar cada algarismo que compõe o número pelo seu respectivo multiplicador (PESO).
            Os multiplicadores(PESOS) variam de 2 a 7.
            O primeiro dígito da direita para a esquerda deverá ser multiplicado por 2, o segundo por 3 e assim sucessivamente.
             
              Carteira   Nosso Numero
                ______   _________________________________________
                1    9   0   0   0   0   0   0   0   0   0   0   2
                x    x   x   x   x   x   x   x   x   x   x   x   x
                2    7   6   5   4   3   2   7   6   5   4   3   2
                =    =   =   =   =   =   =   =   =   =   =   =   =
                2 + 63 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 4 = 69

            O total da soma deverá ser dividido por 11: 69 / 11 = 6 tendo como resto = 3
            A diferença entre o divisor e o resto, será o dígito de autoconferência: 11 - 3 = 8 (dígito de auto-conferência)
            
            Se o resto da divisão for “1”, desprezar o cálculo de subtração e considerar o dígito como “P”. 
            Se o resto da divisão for “0”, desprezar o cálculo de subtração e considerar o dígito como “0”.
            */
            #endregion

            /* Variáveis
             * -------------
             * s - Soma
             * p - Peso
             * b - Base
             * r - Resto
             */

            int s = 0, p = 2;

            for (int i = seq.Length; i > 0; i--)
            {
                s = s + (Convert.ToInt32(Microsoft.VisualBasic.Strings.Mid(seq, i, 1)) * p);
                if (p == b)
                    p = 2;
                else
                    p = p + 1;
            }

            int r = (s % 11);

            if (r == 0)
                return "0";
            else if (r == 1)
                return "P";
            else
                return (11 - r).ToString();
        }

        public override DetalheRetorno LerDetalheRetornoCNAB400(string registro)
        {
            try
            {
                DetalheRetorno detalhe = new DetalheRetorno(registro);

                //Tipo de Inscrição Empresa
                detalhe.CodigoInscricao = Utils.ToInt32(registro.Substring(1, 2));
                //Nº Inscrição da Empresa
                detalhe.NumeroInscricao = registro.Substring(3, 14);

                //Identificação da Empresa Cedente no Banco
                detalhe.Agencia = Utils.ToInt32(registro.Substring(24, 6));
                detalhe.Conta = Utils.ToInt32(registro.Substring(30, 7));
                detalhe.DACConta = Utils.ToInt32(registro.Substring(36, 1));

                //Nº Controle do Participante
                detalhe.NumeroControle = registro.Substring(37, 25);
                //Identificação do Título no Banco
                detalhe.NossoNumero = registro.Substring(70, 12);
                detalhe.DACNossoNumero = Utils.ToInt32(registro.Substring(81, 1));
                //Carteira
                detalhe.Carteira = registro.Substring(107, 1);
                //Identificação de Ocorrência
                detalhe.CodigoOcorrencia = Utils.ToInt32(registro.Substring(108, 2));

                //Número do Documento
                detalhe.NumeroDocumento = registro.Substring(116, 10);
                //Identificação do Título no Banco
                detalhe.IdentificacaoTitulo = registro.Substring(126, 20);

                //Valor do Título
                double valorTitulo = Convert.ToInt64(registro.Substring(152, 13));
                detalhe.ValorTitulo = valorTitulo / 100;
                //Banco Cobrador
                detalhe.CodigoBanco = Utils.ToInt32(registro.Substring(165, 3));
                //Agência Cobradora
                detalhe.AgenciaCobradora = Utils.ToInt32(registro.Substring(168, 5));
                //Espécie do Título
                detalhe.Especie = Utils.ToInt32(registro.Substring(173, 2));
                //Despesas de cobrança para os Códigos de Ocorrência (Valor Despesa)
                double valorDespesa = Convert.ToUInt64(registro.Substring(175, 13));
                detalhe.ValorDespesa = valorDespesa / 100;
                //Outras despesas Custas de Protesto (Valor Outras Despesas)
                double valorOutrasDespesas = Convert.ToUInt64(registro.Substring(188, 13));
                detalhe.ValorOutrasDespesas = valorOutrasDespesas / 100;
                // IOF
                double iof = Convert.ToUInt64(registro.Substring(214, 13));
                detalhe.IOF = iof / 100;
                //Abatimento Concedido sobre o Título (Valor Abatimento Concedido)
                double valorAbatimento = Convert.ToUInt64(registro.Substring(227, 13));
                detalhe.ValorAbatimento = valorAbatimento / 100;
                //Desconto Concedido (Valor Desconto Concedido)
                double valorDesconto = Convert.ToUInt64(registro.Substring(240, 13));
                detalhe.Descontos = valorDesconto / 100;
                //Valor Pago
                double valorPago = Convert.ToUInt64(registro.Substring(253, 13));
                detalhe.ValorPago = valorPago / 100;
                //Juros Mora
                double jurosMora = Convert.ToUInt64(registro.Substring(266, 13));
                detalhe.JurosMora = jurosMora / 100;
                //Outros Créditos
                double outrosCreditos = Convert.ToUInt64(registro.Substring(279, 13));
                detalhe.OutrosCreditos = outrosCreditos / 100;
                //Motivo do Código de Ocorrência 19 (Confirmação de Instrução de Protesto)
                detalhe.MotivoCodigoOcorrencia = registro.Substring(294, 1);

                //Data Ocorrência no Banco
                int dataOcorrencia = Utils.ToInt32(registro.Substring(110, 6));
                detalhe.DataOcorrencia = Utils.ToDateTime(dataOcorrencia.ToString("##-##-##"));
                //Data Vencimento do Título
                int dataVencimento = Utils.ToInt32(registro.Substring(146, 6));
                detalhe.DataVencimento = Utils.ToDateTime(dataVencimento.ToString("##-##-##"));
                // Data do Crédito
                int dataCredito = Utils.ToInt32(registro.Substring(295, 6));
                detalhe.DataCredito = Utils.ToDateTime(dataCredito.ToString("##-##-##"));

                //Origem Pagamento
                detalhe.OrigemPagamento = registro.Substring(301, 3);

                //Motivos das Rejeições para os Códigos de Ocorrência
                detalhe.MotivosRejeicao = registro.Substring(318, 10);
                //Número do Cartório
                detalhe.NumeroCartorio = Utils.ToInt32(registro.Substring(365, 2));
                //Número do Protocolo
                detalhe.NumeroProtocolo = registro.Substring(365, 2);
                //Nome do Sacado
                detalhe.NomeSacado = "";

                detalhe.NumeroSequencial = Utils.ToInt32(registro.Substring(394, 6));

                return detalhe;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ler detalhe do arquivo de RETORNO / CNAB 400.", ex);
            }
        }

        #region Seygi gerando remessa
        /// <summary>
        /// HEADER do arquivo CNAB
        /// Gera o HEADER do arquivo remessa de acordo com o lay-out informado
        /// </summary>
        public override string GerarHeaderRemessa(string numeroConvenio, Cedente cedente, TipoArquivo tipoArquivo)
        {
            try
            {
                string _header = " ";

                base.GerarHeaderRemessa("0", cedente, tipoArquivo);

                switch (tipoArquivo)
                {

                    case TipoArquivo.CNAB240:
                        _header = GerarHeaderRemessaCNAB240();
                        break;
                    case TipoArquivo.CNAB400:
                        _header = GerarHeaderRemessaCNAB400(int.Parse(numeroConvenio), cedente);
                        break;
                    case TipoArquivo.Outro:
                        throw new Exception("Tipo de arquivo inexistente.");
                }

                return _header;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do HEADER do arquivo de REMESSA.", ex);
            }
        }

        public string GerarHeaderRemessaCNAB240()
        {
            throw new NotImplementedException("Função não implementada.");
        }

        public string GerarHeaderRemessaCNAB400(int numeroConvenio, Cedente cedente)
        {
            try
            {
                string complemento = new string(' ', 277);
                string _header;

                _header = "01REMESSA01COBRANCA       ";
                _header += Utils.FitStringLength(cedente.Codigo.ToString(), 20, 20, '0', 0, true, true, true);
                _header += Utils.FitStringLength(cedente.Nome, 30, 30, ' ', 0, true, true, false).ToUpper();
                _header += "237";
                _header += "BRADESCO       ";
                _header += DateTime.Now.ToString("ddMMyy");
                _header += "        ";
                _header += "MX";
                _header += Utils.FitStringLength(numeroConvenio.ToString(), 7, 7, '0', 0, true, true, true);
                _header += complemento;
                _header += "000001";

                _header = Utils.SubstituiCaracteresEspeciais(_header);

                return _header;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar HEADER do arquivo de remessa do CNAB400.", ex);
            }
        }

        # region DETALHE

        /// <summary>
        /// DETALHE do arquivo CNAB
        /// Gera o DETALHE do arquivo remessa de acordo com o lay-out informado
        /// </summary>
        public override string GerarDetalheRemessa(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                string _detalhe = " ";

                base.GerarDetalheRemessa(boleto, numeroRegistro, tipoArquivo);

                switch (tipoArquivo)
                {
                    case TipoArquivo.CNAB240:
                        _detalhe = GerarDetalheRemessaCNAB240();
                        break;
                    case TipoArquivo.CNAB400:
                        _detalhe = GerarDetalheRemessaCNAB400(boleto, numeroRegistro, tipoArquivo);
                        break;
                    case TipoArquivo.Outro:
                        throw new Exception("Tipo de arquivo inexistente.");
                }

                return _detalhe;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do DETALHE arquivo de REMESSA.", ex);
            }
        }

        public string GerarDetalheRemessaCNAB240()
        {
            throw new NotImplementedException("Função não implementada.");
        }

        public string GerarDetalheRemessaCNAB400(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                base.GerarDetalheRemessa(boleto, numeroRegistro, tipoArquivo);

                // USO DO BANCO - Identificação da operação no Banco (posição 87 a 107)
                string identificaOperacaoBanco = new string(' ', 10);
                string nrDeControle = new string(' ', 25);
                string mensagem = new string(' ', 12);
                string mensagem2 = new string(' ', 60);

                string usoBanco = new string(' ', 10);
                string _detalhe;
                //detalhe                           (tamanho,tipo) A= Alfanumerico, N= Numerico
                _detalhe = "1"; //Identificação do Registro         (1, N)

                //Parte Não Necessaria - Parte de dados do Sacado
                _detalhe += "00000"; //Agencia de Debito            (5, N) Não Usado
                _detalhe += " "; //Dig da Agencia                   (1, A) Não Usado
                _detalhe += "00000"; //Razao da Conta Corrente      (5, N) Não Usado
                _detalhe += "0000000"; //Conta Corrente             (7, N) Não Usado
                _detalhe += " "; //Dig da Conta Corrente            (1, A) Não Usado

                //Identificação da Empresa Cedente no Banco (17, A)
                _detalhe += "0";
                _detalhe += Utils.FitStringLength(boleto.Carteira, 3, 3, '0', 0, true, true, true); // Codigo da carteira (3)
                _detalhe += Utils.FitStringLength(boleto.Cedente.ContaBancaria.Agencia, 5, 5, '0', 0, true, true, true); //N da agencia(5)
                _detalhe += Utils.FitStringLength(boleto.Cedente.ContaBancaria.Conta, 7, 7, '0', 0, true, true, true); //Conta Corrente(7)
                _detalhe += Utils.FitStringLength(boleto.Cedente.ContaBancaria.DigitoConta, 1, 1, '0', 0, true, true, true);//D da conta(1)
                _detalhe += nrDeControle; //Nº Cont. do Part.       (25, A) Em Branco
                _detalhe += "237"; //Código do Banco                (3, N)
                _detalhe += "00000"; //Zeros                        (5, N)

                ////Identificação do Título no Banco (12, A)
                _detalhe += Utils.FitStringLength(boleto.NossoNumero, 11, 11, '0', 0, true, true, true); //Nosso Numero (11)
                _detalhe += Mod11Bradesco(boleto.Carteira + boleto.NossoNumero, 7); // Digito de Auto Conferencia do Nosso Número (01)

                _detalhe += "0000000000"; //Desconto Bonificação por dia (10, N)

                // 1 = Banco emite e Processa o registro
                // 2 = Cliente emite e o Banco somente processa
                _detalhe += "2"; //Condição para Emissão da Papeleta de Cobrança(1, N)
                _detalhe += "N"; //Ident. se emite papeleta para Débito Automático (1, A)
                _detalhe += identificaOperacaoBanco; //Identificação da Operação do Banco (10, A) Em Branco

                //Indicador de Rateio de Crédito (1, A)
                //Somente deverá ser preenchido com a Letra “R”, se a Empresa participa da rotina 
                // de rateio de crédito, caso não participe, informar Branco.
                _detalhe += " ";

                //Endereçamento para Aviso do Débito Automático em Conta Corrente (1, N)
                //1 = emite aviso, e assume o endereço do Sacado constante do Arquivo-Remessa;
                //2 = não emite aviso;
                //diferente de 1 ou 2 = emite e assume o endereço do cliente debitado, constante do nosso cadastro.
                _detalhe += "2";

                _detalhe += "  "; //Branco (2, A)

                //Identificação ocorrência(2, N)
                /*
                * 01..Remessa
                02..Pedido de baixa
                04..Concessão de abatimento
                05..Cancelamento de abatimento concedido
                06..Alteração de vencimento
                07..Alteração do controle do participante
                08..Alteração de seu número
                09..Pedido de protesto
                18..Sustar protesto e baixar Título
                19..Sustar protesto e manter em carteira
                31..Alteração de outros dados
                35..Desagendamento do débito automático
                68..Acerto nos dados do rateio de Crédito
                69..Cancelamento do rateio de crédito.
                */
                _detalhe += "01";

                _detalhe += Utils.Right(boleto.NumeroDocumento, 10, '0', true); //Nº do Documento (10, A)
                _detalhe += boleto.DataVencimento.ToString("ddMMyy"); //Data do Vencimento do Título (10, N) DDMMAA

                //Valor do Título (13, N)
                _detalhe += Utils.FitStringLength(Convert.ToString(boleto.ValorBoleto * 100), 13, 13, '0', 0, true, true, true);

                _detalhe += "000"; //Banco Encarregado da Cobrança (3, N)
                _detalhe += "00000"; //Agência Depositária (5, N)

                /*Espécie de Título (2,N)
                * 01-Duplicata
                02-Nota Promissória
                03-Nota de Seguro
                04-Cobrança Seriada
                05-Recibo
                10-Letras de Câmbio
                11-Nota de Débito
                12-Duplicata de Serv.
                99-Outros
                */
                _detalhe += "99";

                _detalhe += "N"; //Identificação (1, A) A – aceito; N - não aceito
                _detalhe += boleto.DataProcessamento.ToString("ddMMyy"); //Data da emissão do Título (6, N) DDMMAA
                _detalhe += "00"; //1ª instrução (2, N) Caso Queira colocar um cod de uma instrução. ver no Manual caso nao coloca 00
                _detalhe += "00"; //2ª instrução (2, N) Caso Queira colocar um cod de uma instrução. ver no Manual caso nao coloca 00

                // Valor a ser cobrado por Dia de Atraso (13, N)
                _detalhe += Utils.FitStringLength(Convert.ToString(boleto.JurosMora * 100), 13, 13, '0', 0, true, true, true);

                //Data Limite P/Concessão de Desconto (06, N)
                if (boleto.DataDesconto.ToString("dd/MM/yyyy") == "01/01/0001")
                {
                    _detalhe += "000000"; //Caso nao tenha data de vencimento
                }
                else
                {
                    _detalhe += boleto.DataDesconto.ToString("ddMMyy");
                }

                //Valor do Desconto (13, N)
                _detalhe += Utils.FitStringLength(Convert.ToString(boleto.ValorDesconto * 100), 13, 13, '0', 0, true, true, true);

                //Valor do IOF (13, N)
                _detalhe += Utils.FitStringLength(Convert.ToString(boleto.IOF * 100), 13, 13, '0', 0, true, true, true);

                //Valor do Abatimento a ser concedido ou cancelado (13, N)
                _detalhe += Utils.FitStringLength(Convert.ToString(boleto.Abatimento * 100), 13, 13, '0', 0, true, true, true);

                /*Identificação do Tipo de Inscrição do Sacado (02, N)
                *01-CPF
                02-CNPJ
                03-PIS/PASEP
                98-Não tem
                99-Outros 
                00-Outros 
                */
                _detalhe += "00";

                //Nº Inscrição do Sacado (14, N)
                string cpf_Cnpj = boleto.Sacado.CPFCNPJ.Replace("/", "").Replace(".", "").Replace("-", "");
                _detalhe += Utils.FitStringLength(cpf_Cnpj, 14, 14, '0', 0, true, true, true);

                //Nome do Sacado (40, A)
                _detalhe += Utils.FitStringLength(boleto.Sacado.Nome, 40, 40, ' ', 0, true, true, false);

                //Endereço Completo (40, A)
                _detalhe += Utils.FitStringLength(boleto.Sacado.Endereco.End, 40, 40, ' ', 0, true, true, false);

                //1ª Mensagem (12, A)
                /*Campo livre para uso da Empresa. A mensagem enviada nesse campo será impressa
                somente no boleto e não será confirmada no Arquivo Retorno.
                */
                _detalhe += Utils.FitStringLength(mensagem, 12, 12, ' ', 0, true, true, false);

                //CEP (5, N) + Sufixo do CEP (3, N) Total (8, N)
                _detalhe += Utils.FitStringLength(boleto.Sacado.Endereco.CEP.Replace("-", ""), 8, 8, '0', 0, true, true, true);

                //Sacador|Avalista ou 2ª Mensagem (60, A)
                _detalhe += Utils.FitStringLength(mensagem, 60, 60, ' ', 0, true, true, false);

                //Nº Seqüencial do Registro (06, N)
                _detalhe += Utils.FitStringLength(numeroRegistro.ToString(), 6, 6, '0', 0, true, true, true);

                //if (boleto.Cedente.CPFCNPJ.Length <= 11)
                //    _detalhe += "03";
                //else
                //    _detalhe += "04";
                //_detalhe += Utils.FitStringLength(boleto.Sacado.CPFCNPJ.ToString(), 14, 14, '0', 0, true, true, true);
                //_detalhe += Utils.FitStringLength(boleto.Cedente.ContaBancaria.Agencia.ToString(), 4, 4, '0', 0, true, true, true);
                //_detalhe += "00";
                //_detalhe += Utils.FitStringLength(boleto.Cedente.ContaBancaria.Conta.ToString(), 5, 5, '0', 0, true, true, true);
                //_detalhe += Utils.FitStringLength(boleto.Cedente.ContaBancaria.DigitoConta.ToString(), 1, 1, ' ', 0, true, true, false);
                //_detalhe += "    "; // Complemento do registro - 4 posições em branco

                //// Código da instrução/alegação a ser cancelada

                //// Deve ser preenchido na remessa somente quando utilizados, na posição 109-110, os códigos de ocorrência 35 – 
                //// Cancelamento de Instrução e 38 – Cedente não concorda com alegação do sacado. Para os demais códigos de 
                //// ocorrência este campo deverá ser preenchido com zeros. 
                ////Obs.: No arquivo retorno será informado o mesmo código da instrução cancelada, e para o cancelamento de alegação 
                //// de sacado não há retorno da informação.

                //// Por enquanto o objetivo é apenas gerar o arquivo de remessa e não utilizar o arquivo para enviar instruções
                //// para títulos que já estão no banco, portanto o campo será preenchido com zeros.
                //_detalhe += "0000";

                ////_detalhe += nrDocumento; // Utils.FitStringLength(boleto.NumeroDocumento, 25, 25, ' ', 0, true, true, false); //Identificação do título na empresa
                //_detalhe += Utils.FitStringLength(boleto.NossoNumero, 8, 8, '0', 0, true, true, true);
                //// Quantidade de moeda variável - Preencher com zeros se a moeda for REAL
                //// O manual do Banco ITAÚ não diz como preencher caso a moeda não seja o REAL
                //if (boleto.Moeda == 9)
                //    _detalhe += "0000000000000";

                //_detalhe += Utils.FitStringLength(boleto.Carteira, 3, 3, '0', 0, true, true, true);
                //_detalhe += Utils.FitStringLength(identificaOperacaoBanco, 21, 21, ' ', 0, true, true, true);
                //// Código da carteira
                //if (boleto.Moeda == 9)
                //    _detalhe += "I"; //O código da carteira só muda para dois tipos, quando a cobrança for em dólar

                //_detalhe += "01"; // Identificação da ocorrência - 01 REMESSA
                //_detalhe += Utils.FitStringLength(boleto.NumeroDocumento, 10, 10, ' ', 0, true, true, false);
                //_detalhe += boleto.DataVencimento.ToString("ddMMyy");
                //_detalhe += Utils.FitStringLength(Convert.ToString(boleto.ValorBoleto * 100), 13, 13, '0', 0, true, true, true);
                //_detalhe += "341";
                //_detalhe += "00000"; // Agência onde o título será cobrado - no arquivo de remessa, preencher com ZEROS

                //_detalhe += Utils.FitStringLength(EspecieDocumento.ValidaCodigo(boleto.EspecieDocumento).ToString(), 2, 2, '0', 0, true, true, true);
                //_detalhe += "N"; // Identificação de título, Aceito ou Não aceito

                ////A data informada neste campo deve ser a mesma data de emissão do título de crédito 
                ////(Duplicata de Serviço / Duplicata Mercantil / Nota Fiscal, etc), que deu origem a esta Cobrança. 
                ////Existindo divergência, na existência de protesto, a documentação poderá não ser aceita pelo Cartório.
                //_detalhe += boleto.DataDocumento.ToString("ddMMyy");

                //if (boleto.Instrucoes.Count > 1)
                //    _detalhe += Utils.FitStringLength(boleto.Instrucoes[0].Codigo.ToString(), 2, 2, '0', 0, true, true, true);

                //if (boleto.Instrucoes.Count > 2)
                //    _detalhe += Utils.FitStringLength(boleto.Instrucoes[1].Codigo.ToString(), 2, 2, '0', 0, true, true, true);
                //else
                //    _detalhe += "  ";

                //// Juros de 1 dia
                ////Se o cliente optar pelo padrão do Banco Itaú ou solicitar o cadastramento permanente na conta corrente, 
                ////não haverá a necessidade de informar esse valor.
                ////Caso seja expresso em moeda variável, deverá ser preenchido com cinco casas decimais.

                //_detalhe += "0000000000000";

                //// Data limite para desconto
                //_detalhe += boleto.DataVencimento.ToString("ddMMyy");
                //_detalhe += Utils.FitStringLength(boleto.ValorDesconto.ToString(), 13, 13, '0', 0, true, true, true);
                //_detalhe += "0000000000000"; // Valor do IOF
                //_detalhe += "0000000000000"; // Valor do Abatimento

                //if (boleto.Cedente.CPFCNPJ.Length > 11)
                //    _detalhe += "01";  // CPF
                //else
                //    _detalhe += "02"; // CNPJ

                //_detalhe += Utils.FitStringLength(boleto.Sacado.CPFCNPJ, 14, 14, '0', 0, true, true, true).ToUpper();
                //_detalhe += Utils.FitStringLength(boleto.Sacado.Nome, 30, 30, ' ', 0, true, true, false);
                //_detalhe += usoBanco;
                //_detalhe += Utils.FitStringLength((boleto.Sacado.Endereco.End + " " + boleto.Sacado.Endereco.Numero + " - " + boleto.Sacado.Endereco.Complemento), 40, 40, ' ', 0, true, true, true).ToUpper();
                //_detalhe += Utils.FitStringLength(boleto.Sacado.Endereco.Bairro, 12, 12, ' ', 0, true, true, false).ToUpper();
                //_detalhe += Utils.FitStringLength(boleto.Sacado.Endereco.CEP, 8, 8, ' ', 0, true, true, false).ToUpper(); ;
                //_detalhe += Utils.FitStringLength(boleto.Sacado.Endereco.Cidade, 15, 15, ' ', 0, true, true, false).ToUpper();
                //_detalhe += Utils.FitStringLength(boleto.Sacado.Endereco.UF, 2, 2, ' ', 0, true, true, false).ToUpper();
                //// SACADOR/AVALISTA
                //// Normalmente deve ser preenchido com o nome do sacador/avalista. Alternativamente este campo poderá 
                //// ter dois outros usos:
                //// a) 2o e 3o descontos: para de operar com mais de um desconto(depende de cadastramento prévio do 
                //// indicador 19.0 pelo Banco Itaú, conforme item 5)
                //// b) Mensagens ao sacado: se utilizados as instruções 93 ou 94 (Nota 11), transcrever a mensagem desejada
                //_detalhe += Utils.FitStringLength(boleto.Sacado.Nome, 30, 30, ' ', 0, true, true, false).ToUpper();
                //_detalhe += "    "; // Complemento do registro
                //_detalhe += boleto.DataVencimento.ToString("ddMMyy");
                //// PRAZO - Quantidade de DIAS - ver nota 11(A) - depende das instruções de cobrança 
                //_detalhe += "00";
                //_detalhe += " "; // Complemento do registro
                //_detalhe += Utils.FitStringLength(numeroRegistro.ToString(), 6, 6, '0', 0, true, true, true);

                _detalhe = Utils.SubstituiCaracteresEspeciais(_detalhe);

                return _detalhe;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar DETALHE do arquivo CNAB400.", ex);
            }
        }

        # endregion DETALHE

        # region TRAILER

        /// <summary>
        /// TRAILER do arquivo CNAB
        /// Gera o TRAILER do arquivo remessa de acordo com o lay-out informado
        /// </summary>
        public override string GerarTrailerRemessa(int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                string _trailer = " ";

                base.GerarTrailerRemessa(numeroRegistro, tipoArquivo);

                switch (tipoArquivo)
                {
                    case TipoArquivo.CNAB240:
                        _trailer = GerarTrailerRemessa240();
                        break;
                    case TipoArquivo.CNAB400:
                        _trailer = GerarTrailerRemessa400(numeroRegistro);
                        break;
                    case TipoArquivo.Outro:
                        throw new Exception("Tipo de arquivo inexistente.");
                }

                return _trailer;

            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public string GerarTrailerRemessa240()
        {
            throw new NotImplementedException("Função não implementada.");
        }

        public string GerarTrailerRemessa400(int numeroRegistro)
        {
            try
            {
                string complemento = new string(' ', 393);
                string _trailer;

                _trailer = "9";
                _trailer += complemento;
                _trailer += Utils.FitStringLength(numeroRegistro.ToString(), 6, 6, '0', 0, true, true, true); // Número sequencial do registro no arquivo.

                _trailer = Utils.SubstituiCaracteresEspeciais(_trailer);

                return _trailer;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do registro TRAILER do arquivo de REMESSA.", ex);
            }
        }

        # endregion

        #endregion Seygi Gerando Remessa
    }
}

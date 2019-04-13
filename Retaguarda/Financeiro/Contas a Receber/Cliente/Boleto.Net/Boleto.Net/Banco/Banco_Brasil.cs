
using System;
using System.Web.UI;
using Microsoft.VisualBasic;

[assembly: WebResource("BoletoNet.Imagens.001.jpg", "image/jpg")]
namespace BoletoNet
{
    /// <summary>
    /// Classe referente ao Banco do Brasil
    /// </summary>
    internal class Banco_Brasil : AbstractBanco, IBanco
    {

        #region Variáveis

        private string _dacNossoNumero = string.Empty;
        private int _dacBoleto = 0;

        #endregion

        #region Construtores

        internal Banco_Brasil()
        {
            try
            {
                this.Codigo = 1;
                this.Digito = 9;
                this.Nome = "Banco do Brasil";
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao instanciar objeto.", ex);
            }
        }
        #endregion

        #region Métodos de Instância

        /// <summary>
        /// Validações particulares do Banco do Brasil
        /// </summary>
        public override void ValidaBoleto(Boleto boleto)
        {
            if (string.IsNullOrEmpty(boleto.Carteira))
                throw new NotImplementedException("Carteira não informada. Utilize a carteira 16, 17, 17-019, 18, 18-019, 18-027, 18-035 ou 18-140.");

            //Verifica as carteiras implementadas
            if (!boleto.Carteira.Equals("16") &
                !boleto.Carteira.Equals("17") &
                !boleto.Carteira.Equals("17-019") &
                !boleto.Carteira.Equals("18") &
                !boleto.Carteira.Equals("18-019") &
                !boleto.Carteira.Equals("18-027") &
                !boleto.Carteira.Equals("18-035") &
                !boleto.Carteira.Equals("18-140"))

                throw new NotImplementedException("Carteira não informada. Utilize a carteira 16, 17, 17-019, 18, 18-019, 18-027, 18-035 ou 18-140.");

            //Verifica se o nosso número é válido
            if (Utils.ToString(boleto.NossoNumero) == string.Empty)
                throw new NotImplementedException("Nosso número inválido");

            #region Carteira 16
            //Carteira 18 com nosso número de 11 posições
            if (boleto.Carteira.Equals("16"))
            {
                if (!boleto.TipoModalidade.Equals("21"))
                {
                    if (boleto.NossoNumero.Length > 11)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 11 de posições para o nosso número", boleto.Carteira));

                    if (boleto.Cedente.Convenio.ToString().Length == 6)
                        boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 11));
                    else
                        boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 11);
                }
                else
                {
                    if (boleto.Cedente.Convenio.ToString().Length != 6)
                        throw new NotImplementedException(string.Format("Para a carteira {0} e o tipo da modalidade 21, o número do convênio são de 6 posições", boleto.Carteira));

                    boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 17);
                }
            }
            #endregion Carteira 16

            #region Carteira 17
            //Carteira 17
            if (boleto.Carteira.Equals("17"))
            {
                switch (boleto.Cedente.Convenio.ToString().Length)
                {
                    //O BB manda como padrão 7 posições, mas é possível solicitar um convênio com 6 posições na carteira 17
                    case 6:
                        if (boleto.NossoNumero.Length > 12)
                            throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 12 de posições para o nosso número", boleto.Carteira));
                        boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 12);
                        break;
                    case 7:
                        if (boleto.NossoNumero.Length > 17)
                            throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 10 de posições para o nosso número", boleto.Carteira));
                        boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 10));
                        break;
                    default:
                        throw new NotImplementedException(string.Format("Para a carteira {0}, o número do convênio deve ter 6 ou 7 posições", boleto.Carteira));
                }
            }
            #endregion Carteira 17

            #region Carteira 17-019
            //Carteira 17, com variação 019
            if (boleto.Carteira.Equals("17-019"))
            {
                /*
                 * Convênio de 7 posições
                 * Nosso Número com 17 posições
                 */
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    if (boleto.NossoNumero.Length > 10)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 10 de posições para o nosso número", boleto.Carteira));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 10));
                }
                /*
                 * Convênio de 6 posições
                 * Nosso Número com 11 posições
                 */
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    //Nosso Número com 17 posições
                    if ((boleto.Cedente.Codigo.ToString().Length + boleto.NossoNumero.Length) > 11)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 11 de posições para o nosso número. Onde o nosso número é formado por CCCCCCNNNNN-X: C -> número do convênio fornecido pelo Banco, N -> seqüencial atribuído pelo cliente e X -> dígito verificador do “Nosso-Número”.", boleto.Carteira));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 5));
                }
                /*
                  * Convênio de 4 posições
                  * Nosso Número com 11 posições
                  */
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    if (boleto.NossoNumero.Length > 7)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 7 de posições para o nosso número [{1}]", boleto.Carteira, boleto.NossoNumero));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 7));
                }
                else
                    boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 11);
            }
            #endregion Carteira 17-019

            #region Carteira 18
            //Carteira 18 com nosso número de 11 posições
            if (boleto.Carteira.Equals("18"))
                boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 11);
            #endregion Carteira 18

            #region Carteira 18-019
            //Carteira 18, com variação 019
            if (boleto.Carteira.Equals("18-019"))
            {
                /*
                 * Convênio de 7 posições
                 * Nosso Número com 17 posições
                 */
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    if (boleto.NossoNumero.Length > 10)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 10 de posições para o nosso número", boleto.Carteira));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 10));
                }
                /*
                 * Convênio de 6 posições
                 * Nosso Número com 11 posições
                 */
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    //Modalidades de Cobrança Sem Registro – Carteira 16 e 18
                    //Nosso Número com 17 posições
                    if (!boleto.TipoModalidade.Equals("21"))
                    {
                        if ((boleto.Cedente.Codigo.ToString().Length + boleto.NossoNumero.Length) > 11)
                            throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 11 de posições para o nosso número. Onde o nosso número é formado por CCCCCCNNNNN-X: C -> número do convênio fornecido pelo Banco, N -> seqüencial atribuído pelo cliente e X -> dígito verificador do “Nosso-Número”.", boleto.Carteira));

                        boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 5));
                    }
                    else
                    {
                        if (boleto.Cedente.Convenio.ToString().Length != 6)
                            throw new NotImplementedException(string.Format("Para a carteira {0} e o tipo da modalidade 21, o número do convênio são de 6 posições", boleto.Carteira));

                        boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 17);
                    }
                }
                /*
                  * Convênio de 4 posições
                  * Nosso Número com 11 posições
                  */
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    if (boleto.NossoNumero.Length > 7)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 7 de posições para o nosso número [{1}]", boleto.Carteira, boleto.NossoNumero));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 7));
                }
                else
                    boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 11);
            }
            #endregion Carteira 18-019


            //Para atender o cliente Fiemg foi adaptado no código na variação 18-027 as variações 18-035 e 18-140
            #region Carteira 18-027
            //Carteira 18, com variação 019
            if (boleto.Carteira.Equals("18-027"))
            {
                /*
                 * Convênio de 7 posições
                 * Nosso Número com 17 posições
                 */
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    if (boleto.NossoNumero.Length > 10)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 10 de posições para o nosso número", boleto.Carteira));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 10));
                }
                /*
                 * Convênio de 6 posições
                 * Nosso Número com 11 posições
                 */
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    //Modalidades de Cobrança Sem Registro – Carteira 16 e 18
                    //Nosso Número com 17 posições
                    if (!boleto.TipoModalidade.Equals("21"))
                    {
                        if ((boleto.Cedente.Codigo.ToString().Length + boleto.NossoNumero.Length) > 11)
                            throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 11 de posições para o nosso número. Onde o nosso número é formado por CCCCCCNNNNN-X: C -> número do convênio fornecido pelo Banco, N -> seqüencial atribuído pelo cliente e X -> dígito verificador do “Nosso-Número”.", boleto.Carteira));

                        boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 5));
                    }
                    else
                    {
                        if (boleto.Cedente.Convenio.ToString().Length != 6)
                            throw new NotImplementedException(string.Format("Para a carteira {0} e o tipo da modalidade 21, o número do convênio são de 6 posições", boleto.Carteira));

                        boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 17);
                    }
                }
                /*
                  * Convênio de 4 posições
                  * Nosso Número com 11 posições
                  */
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    if (boleto.NossoNumero.Length > 7)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 7 de posições para o nosso número [{1}]", boleto.Carteira, boleto.NossoNumero));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 7));
                }
                else
                    boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 11);
            }
            #endregion Carteira 18-027

            #region Carteira 18-035
            //Carteira 18, com variação 019
            if (boleto.Carteira.Equals("18-035"))
            {
                /*
                 * Convênio de 7 posições
                 * Nosso Número com 17 posições
                 */
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    if (boleto.NossoNumero.Length > 10)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 10 de posições para o nosso número", boleto.Carteira));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 10));
                }
                /*
                 * Convênio de 6 posições
                 * Nosso Número com 11 posições
                 */
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    //Modalidades de Cobrança Sem Registro – Carteira 16 e 18
                    //Nosso Número com 17 posições
                    if (!boleto.TipoModalidade.Equals("21"))
                    {
                        if ((boleto.Cedente.Codigo.ToString().Length + boleto.NossoNumero.Length) > 11)
                            throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 11 de posições para o nosso número. Onde o nosso número é formado por CCCCCCNNNNN-X: C -> número do convênio fornecido pelo Banco, N -> seqüencial atribuído pelo cliente e X -> dígito verificador do “Nosso-Número”.", boleto.Carteira));

                        boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 5));
                    }
                    else
                    {
                        if (boleto.Cedente.Convenio.ToString().Length != 6)
                            throw new NotImplementedException(string.Format("Para a carteira {0} e o tipo da modalidade 21, o número do convênio são de 6 posições", boleto.Carteira));

                        boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 17);
                    }
                }
                /*
                  * Convênio de 4 posições
                  * Nosso Número com 11 posições
                  */
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    if (boleto.NossoNumero.Length > 7)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 7 de posições para o nosso número [{1}]", boleto.Carteira, boleto.NossoNumero));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 7));
                }
                else
                    boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 11);
            }
            #endregion Carteira 18-035

            #region Carteira 18-140
            //Carteira 18, com variação 019
            if (boleto.Carteira.Equals("18-140"))
            {
                /*
                 * Convênio de 7 posições
                 * Nosso Número com 17 posições
                 */
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    if (boleto.NossoNumero.Length > 10)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 10 de posições para o nosso número", boleto.Carteira));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 10));
                }
                /*
                 * Convênio de 6 posições
                 * Nosso Número com 11 posições
                 */
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    //Modalidades de Cobrança Sem Registro – Carteira 16 e 18
                    //Nosso Número com 17 posições
                    if (!boleto.TipoModalidade.Equals("21"))
                    {
                        if ((boleto.Cedente.Codigo.ToString().Length + boleto.NossoNumero.Length) > 11)
                            throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 11 de posições para o nosso número. Onde o nosso número é formado por CCCCCCNNNNN-X: C -> número do convênio fornecido pelo Banco, N -> seqüencial atribuído pelo cliente e X -> dígito verificador do “Nosso-Número”.", boleto.Carteira));

                        boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 5));
                    }
                    else
                    {
                        if (boleto.Cedente.Convenio.ToString().Length != 6)
                            throw new NotImplementedException(string.Format("Para a carteira {0} e o tipo da modalidade 21, o número do convênio são de 6 posições", boleto.Carteira));

                        boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 17);
                    }
                }
                /*
                  * Convênio de 4 posições
                  * Nosso Número com 11 posições
                  */
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    if (boleto.NossoNumero.Length > 7)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade máxima são de 7 de posições para o nosso número [{1}]", boleto.Carteira, boleto.NossoNumero));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 7));
                }
                else
                    boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 11);
            }
            #endregion Carteira 18-140


            #region Agência e Conta Corrente
            //Verificar se a Agencia esta correta
            if (boleto.Cedente.ContaBancaria.Agencia.Length > 4)
                throw new NotImplementedException("A quantidade de dígitos da Agência " + boleto.Cedente.ContaBancaria.Agencia + ", são de 4 números.");
            else if (boleto.Cedente.ContaBancaria.Agencia.Length < 4)
                boleto.Cedente.ContaBancaria.Agencia = Utils.FormatCode(boleto.Cedente.ContaBancaria.Agencia, 4);

            //Verificar se a Conta esta correta
            if (boleto.Cedente.ContaBancaria.Conta.Length > 8)
                throw new NotImplementedException("A quantidade de dígitos da Conta " + boleto.Cedente.ContaBancaria.Conta + ", são de 8 números.");
            else if (boleto.Cedente.ContaBancaria.Conta.Length < 8)
                boleto.Cedente.ContaBancaria.Conta = Utils.FormatCode(boleto.Cedente.ContaBancaria.Conta, 8);
            #endregion Agência e Conta Corrente

            //Atribui o nome do banco ao local de pagamento
            boleto.LocalPagamento += Nome + "";

            //Verifica se data do processamento é valida
            if (boleto.DataProcessamento.ToString("dd/MM/yyyy") == "01/01/0001")
                boleto.DataProcessamento = DateTime.Now;

            //Verifica se data do documento é valida
            if (boleto.DataDocumento.ToString("dd/MM/yyyy") == "01/01/0001")
                boleto.DataDocumento = DateTime.Now;

            boleto.QuantidadeMoeda = 0;

            FormataCodigoBarra(boleto);
            FormataLinhaDigitavel(boleto);
            FormataNossoNumero(boleto);
        }

        # endregion

        private string LimparCarteira(string carteira)
        {
            return carteira.Split('-')[0];
        }

        #region Métodos de formatação do boleto

        public override void FormataCodigoBarra(Boleto boleto)
        {
            string valorBoleto = boleto.ValorBoleto.ToString("f").Replace(",", "").Replace(".", "");
            valorBoleto = Utils.FormatCode(valorBoleto, 10);

            #region Carteira 16
            if (boleto.Carteira.Equals("16"))
            {
                if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    if (boleto.TipoModalidade.Equals("21"))
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.Cedente.Convenio,
                            boleto.NossoNumero,
                            "21");
                }
                else
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        boleto.NossoNumero,
                        boleto.Cedente.ContaBancaria.Agencia,
                        boleto.Cedente.ContaBancaria.Conta,
                        boleto.Carteira);
                }
            }
            #endregion Carteira 16

            #region Carteira 17
            if (boleto.Carteira.Equals("17"))
            {
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        "000000",
                        boleto.NossoNumero,
                        Utils.FormatCode(LimparCarteira(boleto.Carteira), 2));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        Strings.Mid(boleto.NossoNumero, 1, 11),
                        boleto.Cedente.ContaBancaria.Agencia,
                        boleto.Cedente.ContaBancaria.Conta,
                        boleto.Carteira);
                }
                else
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        boleto.NossoNumero,
                        boleto.Cedente.ContaBancaria.Agencia,
                        boleto.Cedente.ContaBancaria.Conta,
                        boleto.Carteira);
                }
            }
            #endregion Carteira 17

            #region Carteira 17-019
            if (boleto.Carteira.Equals("17-019"))
            {
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    #region Especificação Convênio 7 posições
                    /*
                    Posição     Tamanho     Picture     Conteúdo
                    01 a 03         03      9(3)            Código do Banco na Câmara de Compensação = ‘001’
                    04 a 04         01      9(1)            Código da Moeda = '9'
                    05 a 05         01      9(1)            DV do Código de Barras (Anexo 10)
                    06 a 09         04      9(04)           Fator de Vencimento (Anexo 8)
                    10 a 19         10      9(08)           V(2) Valor
                    20 a 25         06      9(6)            Zeros
                    26 a 42         17      9(17)           Nosso-Número, sem o DV
                    26 a 32         9       (7)             Número do Convênio fornecido pelo Banco (CCCCCCC)
                    33 a 42         9       (10)            Complemento do Nosso-Número, sem DV (NNNNNNNNNN)
                    43 a 44         02      9(2)            Tipo de Carteira/Modalidade de Cobrança
                     */
                    #endregion Especificação Convênio 7 posições

                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        "000000",
                        boleto.NossoNumero,
                        Utils.FormatCode(LimparCarteira(boleto.Carteira), 2));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.NossoNumero,
                            boleto.Cedente.ContaBancaria.Agencia,
                            boleto.Cedente.ContaBancaria.Conta,
                            LimparCarteira(boleto.Carteira));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        boleto.NossoNumero,
                        boleto.Cedente.ContaBancaria.Agencia,
                        boleto.Cedente.ContaBancaria.Conta,
                        LimparCarteira(boleto.Carteira));
                }
            }
            #endregion Carteira 17-019

            #region Carteira 18
            if (boleto.Carteira.Equals("18"))
            {
                boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                    Utils.FormatCode(Codigo.ToString(), 3),
                    boleto.Moeda,
                    FatorVencimento(boleto),
                    valorBoleto,
                    boleto.NossoNumero,
                    boleto.Cedente.ContaBancaria.Agencia,
                    boleto.Cedente.ContaBancaria.Conta,
                    boleto.Carteira);
            }
            #endregion Carteira 18

            #region Carteira 18-019
            if (boleto.Carteira.Equals("18-019"))
            {
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    #region Especificação Convênio 7 posições
                    /*
                    Posição     Tamanho     Picture     Conteúdo
                    01 a 03         03      9(3)            Código do Banco na Câmara de Compensação = ‘001’
                    04 a 04         01      9(1)            Código da Moeda = '9'
                    05 a 05         01      9(1)            DV do Código de Barras (Anexo 10)
                    06 a 09         04      9(04)           Fator de Vencimento (Anexo 8)
                    10 a 19         10      9(08)           V(2) Valor
                    20 a 25         06      9(6)            Zeros
                    26 a 42         17      9(17)           Nosso-Número, sem o DV
                    26 a 32         9       (7)             Número do Convênio fornecido pelo Banco (CCCCCCC)
                    33 a 42         9       (10)            Complemento do Nosso-Número, sem DV (NNNNNNNNNN)
                    43 a 44         02      9(2)            Tipo de Carteira/Modalidade de Cobrança
                     */
                    #endregion Especificação Convênio 7 posições

                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        "000000",
                        boleto.NossoNumero,
                        Utils.FormatCode(LimparCarteira(boleto.Carteira), 2));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    if (boleto.TipoModalidade.Equals("21"))
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.Cedente.Convenio,
                            boleto.NossoNumero,
                            "21");
                    else
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.NossoNumero,
                            boleto.Cedente.ContaBancaria.Agencia,
                            boleto.Cedente.ContaBancaria.Conta,
                            LimparCarteira(boleto.Carteira));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        boleto.NossoNumero,
                        boleto.Cedente.ContaBancaria.Agencia,
                        boleto.Cedente.ContaBancaria.Conta,
                        LimparCarteira(boleto.Carteira));
                }
            }
            #endregion Carteira 18-019

            //Para atender o cliente Fiemg foi adptado no código na variação 18-027 as variações 18-035 e 18-140
            #region Carteira 18-027
            if (boleto.Carteira.Equals("18-027"))
            {
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    #region Especificação Convênio 7 posições
                    /*
                    Posição     Tamanho     Picture     Conteúdo
                    01 a 03         03      9(3)            Código do Banco na Câmara de Compensação = ‘001’
                    04 a 04         01      9(1)            Código da Moeda = '9'
                    05 a 05         01      9(1)            DV do Código de Barras (Anexo 10)
                    06 a 09         04      9(04)           Fator de Vencimento (Anexo 8)
                    10 a 19         10      9(08)           V(2) Valor
                    20 a 25         06      9(6)            Zeros
                    26 a 42         17      9(17)           Nosso-Número, sem o DV
                    26 a 32         9       (7)             Número do Convênio fornecido pelo Banco (CCCCCCC)
                    33 a 42         9       (10)            Complemento do Nosso-Número, sem DV (NNNNNNNNNN)
                    43 a 44         02      9(2)            Tipo de Carteira/Modalidade de Cobrança
                     */
                    #endregion Especificação Convênio 7 posições

                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto).ToString("0000"),
                        valorBoleto,
                        "000000",
                        boleto.NossoNumero,
                        Utils.FormatCode(LimparCarteira(boleto.Carteira), 2));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    if (boleto.TipoModalidade.Equals("21"))
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.Cedente.Convenio,
                            boleto.NossoNumero,
                            "21");
                    else
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.NossoNumero,
                            boleto.Cedente.ContaBancaria.Agencia,
                            boleto.Cedente.ContaBancaria.Conta,
                            LimparCarteira(boleto.Carteira));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        boleto.NossoNumero,
                        boleto.Cedente.ContaBancaria.Agencia,
                        boleto.Cedente.ContaBancaria.Conta,
                        LimparCarteira(boleto.Carteira));
                }
            }
            #endregion Carteira 18-027

            #region Carteira 18-035
            if (boleto.Carteira.Equals("18-035"))
            {
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    #region Especificação Convênio 7 posições
                    /*
                    Posição     Tamanho     Picture     Conteúdo
                    01 a 03         03      9(3)            Código do Banco na Câmara de Compensação = ‘001’
                    04 a 04         01      9(1)            Código da Moeda = '9'
                    05 a 05         01      9(1)            DV do Código de Barras (Anexo 10)
                    06 a 09         04      9(04)           Fator de Vencimento (Anexo 8)
                    10 a 19         10      9(08)           V(2) Valor
                    20 a 25         06      9(6)            Zeros
                    26 a 42         17      9(17)           Nosso-Número, sem o DV
                    26 a 32         9       (7)             Número do Convênio fornecido pelo Banco (CCCCCCC)
                    33 a 42         9       (10)            Complemento do Nosso-Número, sem DV (NNNNNNNNNN)
                    43 a 44         02      9(2)            Tipo de Carteira/Modalidade de Cobrança
                     */
                    #endregion Especificação Convênio 7 posições

                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto).ToString("0000"),
                        valorBoleto,
                        "000000",
                        boleto.NossoNumero,
                        Utils.FormatCode(LimparCarteira(boleto.Carteira), 2));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    if (boleto.TipoModalidade.Equals("21"))
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.Cedente.Convenio,
                            boleto.NossoNumero,
                            "21");
                    else
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.NossoNumero,
                            boleto.Cedente.ContaBancaria.Agencia,
                            boleto.Cedente.ContaBancaria.Conta,
                            LimparCarteira(boleto.Carteira));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        boleto.NossoNumero,
                        boleto.Cedente.ContaBancaria.Agencia,
                        boleto.Cedente.ContaBancaria.Conta,
                        LimparCarteira(boleto.Carteira));
                }
            }
            #endregion Carteira 18-035

            #region Carteira 18-140
            if (boleto.Carteira.Equals("18-140"))
            {
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    #region Especificação Convênio 7 posições
                    /*
                    Posição     Tamanho     Picture     Conteúdo
                    01 a 03         03      9(3)            Código do Banco na Câmara de Compensação = ‘001’
                    04 a 04         01      9(1)            Código da Moeda = '9'
                    05 a 05         01      9(1)            DV do Código de Barras (Anexo 10)
                    06 a 09         04      9(04)           Fator de Vencimento (Anexo 8)
                    10 a 19         10      9(08)           V(2) Valor
                    20 a 25         06      9(6)            Zeros
                    26 a 42         17      9(17)           Nosso-Número, sem o DV
                    26 a 32         9       (7)             Número do Convênio fornecido pelo Banco (CCCCCCC)
                    33 a 42         9       (10)            Complemento do Nosso-Número, sem DV (NNNNNNNNNN)
                    43 a 44         02      9(2)            Tipo de Carteira/Modalidade de Cobrança
                     */
                    #endregion Especificação Convênio 7 posições

                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto).ToString("0000"),
                        valorBoleto,
                        "000000",
                        boleto.NossoNumero,
                        Utils.FormatCode(LimparCarteira(boleto.Carteira), 2));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    if (boleto.TipoModalidade.Equals("21"))
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.Cedente.Convenio,
                            boleto.NossoNumero,
                            "21");
                    else
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.NossoNumero,
                            boleto.Cedente.ContaBancaria.Agencia,
                            boleto.Cedente.ContaBancaria.Conta,
                            LimparCarteira(boleto.Carteira));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        boleto.NossoNumero,
                        boleto.Cedente.ContaBancaria.Agencia,
                        boleto.Cedente.ContaBancaria.Conta,
                        LimparCarteira(boleto.Carteira));
                }
            }
            #endregion Carteira 18-140
            _dacBoleto = Mod11(boleto.CodigoBarra.Codigo, 9);

            boleto.CodigoBarra.Codigo = Strings.Left(boleto.CodigoBarra.Codigo, 4) + _dacBoleto + Strings.Right(boleto.CodigoBarra.Codigo, 39);
        }

        public override void FormataLinhaDigitavel(Boleto boleto)
        {
            string cmplivre = string.Empty;
            string campo1 = string.Empty;
            string campo2 = string.Empty;
            string campo3 = string.Empty;
            string campo4 = string.Empty;
            string campo5 = string.Empty;
            long icampo5 = 0;
            int digitoMod = 0;

            /*
            Campos 1 (AAABC.CCCCX):
            A = Código do Banco na Câmara de Compensação “001”
            B = Código da moeda "9" (*)
            C = Posição 20 a 24 do código de barras
            X = DV que amarra o campo 1 (Módulo 10, contido no Anexo 7)
             */

            cmplivre = Strings.Mid(boleto.CodigoBarra.Codigo, 20, 25);

            campo1 = Strings.Left(boleto.CodigoBarra.Codigo, 4) + Strings.Mid(cmplivre, 1, 5);
            digitoMod = Mod10(campo1);
            campo1 = campo1 + digitoMod.ToString();
            campo1 = Strings.Mid(campo1, 1, 5) + "." + Strings.Mid(campo1, 6, 5);
            /*
            Campo 2 (DDDDD.DDDDDY)
            D = Posição 25 a 34 do código de barras
            Y = DV que amarra o campo 2 (Módulo 10, contido no Anexo 7)
             */
            campo2 = Strings.Mid(cmplivre, 6, 10);
            digitoMod = Mod10(campo2);
            campo2 = campo2 + digitoMod.ToString();
            campo2 = Strings.Mid(campo2, 1, 5) + "." + Strings.Mid(campo2, 6, 6);


            /*
            Campo 3 (EEEEE.EEEEEZ)
            E = Posição 35 a 44 do código de barras
            Z = DV que amarra o campo 3 (Módulo 10, contido no Anexo 7)
             */
            campo3 = Strings.Mid(cmplivre, 16, 10);
            digitoMod = Mod10(campo3);
            campo3 = campo3 + digitoMod;
            campo3 = Strings.Mid(campo3, 1, 5) + "." + Strings.Mid(campo3, 6, 6);

            /*
            Campo 4 (K)
            K = DV do Código de Barras (Módulo 11, contido no Anexo 10)
             */
            campo4 = Strings.Mid(boleto.CodigoBarra.Codigo, 5, 1);

            /*
            Campo 5 (UUUUVVVVVVVVVV)
            U = Fator de Vencimento ( Anexo 10)
            V = Valor do Título (*)
             */
            icampo5 = Convert.ToInt64(Strings.Mid(boleto.CodigoBarra.Codigo, 6, 14));

            if (icampo5 == 0)
                campo5 = "000";
            else
                campo5 = icampo5.ToString();

            boleto.CodigoBarra.LinhaDigitavel = campo1 + "  " + campo2 + "  " + campo3 + "  " + campo4 + "  " + campo5;
        }

        /// <summary>
        /// Formata o nosso número para ser mostrado no boleto.
        /// </summary>
        /// <remarks>
        /// Última a atualização por Transis em 26/09/2011
        /// </remarks>
        /// <param name="boleto"></param>
        public override void FormataNossoNumero(Boleto boleto)
        {
            if (boleto.Carteira.Equals("18-019"))
                boleto.NossoNumero = string.Format("{0}/{1}", LimparCarteira(boleto.Carteira), boleto.NossoNumero);
            else if (boleto.Carteira.Equals("17-019"))
                boleto.NossoNumero = string.Format("{0}/{1}", LimparCarteira(boleto.Carteira), boleto.NossoNumero);
            else if (boleto.Carteira.Equals("18-027"))
                boleto.NossoNumero = string.Format("{0}", boleto.NossoNumero);
            //Para atender o cliente Fiemg foi adptado no código na variação 18-027 as variações 18-035 e 18-140
            else if (boleto.Carteira.Equals("18-035"))
                boleto.NossoNumero = string.Format("{0}", boleto.NossoNumero);
            else if (boleto.Carteira.Equals("18-140"))
                boleto.NossoNumero = string.Format("{0}", boleto.NossoNumero);
            //somente monta o digito verificador no nosso numero se o convenio tiver 6 posições
            else if (boleto.Cedente.Convenio.ToString().Length == 6)
                boleto.NossoNumero = string.Format("{0}/{1}-{2}", LimparCarteira(boleto.Carteira), boleto.NossoNumero, Mod11BancoBrasil(boleto.NossoNumero));
            else
                boleto.NossoNumero = string.Format("{0}", boleto.NossoNumero);
        }


        public override void FormataNumeroDocumento(Boleto boleto)
        {
        }

        # endregion

        # region Métodos de geração do arquivo remessa CNAB240

        # region HEADER

        /// <summary>
        /// HEADER do arquivo CNAB
        /// Gera o HEADER do arquivo remessa de acordo com o lay-out informado
        /// </summary>
        public override string GerarHeaderRemessa(string numeroConvenio, Cedente cedente, TipoArquivo tipoArquivo, int numeroArquivoRemessa)
        {
            try
            {
                string _header = " ";

                base.GerarHeaderRemessa(numeroConvenio, cedente, tipoArquivo, numeroArquivoRemessa);

                switch (tipoArquivo)
                {

                    case TipoArquivo.CNAB240:
                        _header = GerarHeaderRemessaCNAB240(cedente);
                        break;
                    case TipoArquivo.CNAB400:
                        _header = GerarHeaderRemessaCNAB400(cedente);
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

        // HEADER ARQUIVO REMESSA CNAB240
        public string GerarHeaderRemessaCNAB240(Cedente cedente)
        {
            try
            {
                string _brancos20 = new string(' ', 20);
                string _brancos10 = new string(' ', 10);
                string _header;

                _header = "00100000         ";
                if (cedente.CPFCNPJ.Length <= 11)
                    _header += "1";
                else
                    _header += "2";
                _header += Utils.FitStringLength(cedente.CPFCNPJ, 14, 14, '0', 0, true, true, true);
                _header += _brancos20;
                _header += Utils.FitStringLength(cedente.ContaBancaria.Agencia, 5, 5, '0', 0, true, true, true);
                _header += Utils.FitStringLength(cedente.ContaBancaria.DigitoAgencia, 1, 1, ' ', 0, true, true, false);
                _header += Utils.FitStringLength(cedente.ContaBancaria.Conta, 12, 12, '0', 0, true, true, true);
                _header += Utils.FitStringLength(cedente.ContaBancaria.DigitoConta, 1, 1, ' ', 0, true, true, false);
                _header += " "; // DÍGITO VERIFICADOR DA AG./CONTA
                _header += Utils.FitStringLength(cedente.Nome, 30, 30, ' ', 0, true, true, false);
                _header += Utils.FitStringLength("BANCO DO BRASIL S.A.", 30, 30, ' ', 0, true, true, false);
                _header += _brancos10;
                _header += "1";
                _header += DateTime.Now.ToString("ddMMyyyy");
                _header += DateTime.Now.ToString("hhMMss");
                // NÚMERO SEQUENCIAL DO ARQUIVO *EVOLUIR UM NÚMERO A CADA HEADER DE ARQUIVO
                _header += "000001";
                // Campo não criticado pelo sistema, informar ZEROS ou nº da versão do layout do arquivo que foi utilizado
                // para a formatação dos campos.
                // Como não sei onde pegar esse nº, deixei como padrão.
                _header += "000";
                _header += "00000";
                _header += _brancos20;
                _header += _brancos20;
                _header += _brancos10;
                _header += "    ";
                _header += "000  ";
                _header += _brancos10;

                _header = Utils.SubstituiCaracteresEspeciais(_header);

                return _header;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do HEADER DE ARQUIVO do arquivo de REMESSA.", ex);
            }
        }
        // HEADER ARQUIVO REMESSA CNAB400
        public string GerarHeaderRemessaCNAB400(Cedente cedente)
        {
            try
            {
                throw new NotImplementedException("Funçao não implementada!");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do HEADER do arquivo de REMESSA.", ex);
            }
        }

        # endregion

        # region HEADER DE LOTE

        /// <summary>
        /// HEADER DE LOTE do arquivo CNAB
        /// Gera o HEADER de Lote do arquivo remessa de acordo com o lay-out informado
        /// </summary>
        public override string GerarHeaderLoteRemessa(string numeroConvenio, Cedente cedente, int numeroArquivoRemessa, TipoArquivo tipoArquivo)
        {
            try
            {
                string header = " ";

                base.GerarHeaderLoteRemessa(numeroConvenio, cedente, numeroArquivoRemessa, tipoArquivo);

                switch (tipoArquivo)
                {
                    case TipoArquivo.CNAB240:
                        header = GerarHeaderLoteRemessaCNAB240(numeroConvenio, cedente, numeroArquivoRemessa);
                        break;
                    case TipoArquivo.CNAB400:
                        header = "";
                        break;
                    case TipoArquivo.Outro:
                        throw new Exception("Tipo de arquivo inexistente.");
                }

                return header;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do HEADER DO LOTE do arquivo de REMESSA.", ex);
            }
        }

        // HEADER DE LOTE REMESSA CNAB240
        private string GerarHeaderLoteRemessaCNAB240(string numeroConvenio, Cedente cedente, int numeroArquivoRemessa)
        {
            try
            {
                string _brancos40 = new string(' ', 40);
                string _brancos33 = new string(' ', 33);
                string _headerLote;

                _headerLote = "00100011R0100";
                // Campo não criticado pelo sistema, informar ZEROS ou nº da versão do layout do arquivo que foi utilizado
                // para a formatação dos campos.
                // Como não sei onde pegar esse nº, deixei como padrão.
                _headerLote += "020";
                _headerLote += " ";

                if (cedente.CPFCNPJ.Length <= 11)
                    _headerLote += "1";
                else
                    _headerLote += "2";

                _headerLote += Utils.FitStringLength(cedente.CPFCNPJ, 15, 15, '0', 0, true, true, true);
                _headerLote += Utils.FitStringLength(numeroConvenio, 9, 9, '0', 0, true, true, true);
                _headerLote += "0014";
                // O Código da carteira é dividida em 2 partes:
                // - nº da carteira 9(02)
                // - variação (se houver) 9(03)
                if (cedente.Carteira.Length == 2)
                    _headerLote += cedente.Carteira.ToString() + "000  ";
                else
                    _headerLote += cedente.Carteira.Replace("-", "") + "  ";

                _headerLote += Utils.FitStringLength(cedente.ContaBancaria.Agencia, 5, 5, '0', 0, true, true, true);
                _headerLote += Utils.FitStringLength(cedente.ContaBancaria.DigitoAgencia, 1, 1, '0', 0, true, true, true);
                _headerLote += Utils.FitStringLength(cedente.ContaBancaria.Conta, 12, 12, '0', 0, true, true, true);
                _headerLote += Utils.FitStringLength(cedente.ContaBancaria.DigitoConta, 1, 1, '0', 0, true, true, true);
                // Dígito verificador  da Agência/Conta.  Campo não tratado pelo BB.  Informar ESPAÇO ou ZERO.
                _headerLote += "0";
                _headerLote += Utils.FitStringLength(cedente.Nome, 30, 30, ' ', 0, true, true, false);
                _headerLote += _brancos40;
                _headerLote += _brancos40;
                // Campo não tratado pelo BB. Sugerem utilizar nº sequencial para controle da empresa.  Não especifica se é controle de arquivo.
                // Em todo caso, coloquei o nº sequencial do arquivo remessa.
                _headerLote += Utils.FitStringLength(numeroArquivoRemessa.ToString(), 8, 8, '0', 0, true, true, true);
                _headerLote += DateTime.Now.ToString("ddMMyyyy");
                _headerLote += "00000000";
                _headerLote += _brancos33;

                _headerLote = Utils.SubstituiCaracteresEspeciais(_headerLote);

                return _headerLote;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do HEADER DE LOTE do arquivo de REMESSA.", ex);
            }
        }

        # endregion

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
                        _detalhe = GerarDetalheRemessaCNAB240(boleto, numeroRegistro, tipoArquivo);
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

        public override string GerarDetalheSegmentoPRemessa(Boleto boleto, int numeroRegistro, string numeroConvenio)
        {
            try
            {
                string _segmentoP;
                string _nossoNumero;

                _segmentoP = "00100013";
                _segmentoP += Utils.FitStringLength(numeroRegistro.ToString(), 5, 5, '0', 0, true, true, true);
                _segmentoP += "P 01";
                _segmentoP += Utils.FitStringLength(boleto.Cedente.ContaBancaria.Agencia, 5, 5, '0', 0, true, true, true);
                _segmentoP += Utils.FitStringLength(boleto.Cedente.ContaBancaria.DigitoAgencia, 1, 1, '0', 0, true, true, true);
                _segmentoP += Utils.FitStringLength(boleto.Cedente.ContaBancaria.Conta, 12, 12, '0', 0, true, true, true);
                _segmentoP += Utils.FitStringLength(boleto.Cedente.ContaBancaria.DigitoConta, 1, 1, '0', 0, true, true, true);
                // Dígito verificador  da Agência/Conta.  Campo não tratado pelo BB.  Informar ESPAÇO ou ZERO.
                _segmentoP += "0";

                //=====================================================================================================
                //Ajustes efetuados de acordo com manual Julho/2011 - Retirado por jsoda - em 11/05/2012
                //
                //int totalCaracteres = numeroConvenio.Length - 9;
                //_segmentoP += numeroConvenio.Substring(0, totalCaracteres);

                //_nossoNumero = Utils.FitStringLength(boleto.NumeroDocumento, 10, 10, '0', 0, true, true, true);
                //int _total = numeroConvenio.Substring(0, totalCaracteres).Length + _nossoNumero.Length;
                //int subtotal = 0;
                //subtotal = 20 - _total;
                //string _comnplemento = new string(' ', subtotal);
                //_segmentoP += _nossoNumero;
                //_segmentoP += _comnplemento;
                //=====================================================================================================

                switch (boleto.Cedente.Convenio.ToString().Length)
                {
                    case 4:
                        // Se convênio de 4 posições - normalmente carteira 17 - (0001 à 9999), informar NossoNumero com 11 caracteres, com DV, sendo:
                        // 4 posições do nº do convênio e 7 posições do nº de controle (nº do documento) e DV.
                        _nossoNumero = string.Format("{0}{1}{2}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 7), Mod11BancoBrasil(boleto.NossoNumero));
                        break;
                    case 6:
                        // Se convênio de 6 posições (acima de 10.000 à 999.999), informar NossoNumero com 11 caracteres + DV, sendo:
                        // 6 posições do nº do convênio e 5 posições do nº de controle (nº do documento) e DV do nosso numero.
                        _nossoNumero = string.Format("{0}{1}{2}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 5), Mod11BancoBrasil(boleto.NossoNumero));
                        break;
                    case 7:
                        // Se convênio de 7 posições (acima de 1.000.000 à 9.999.999), informar NossoNumero com 17 caracteres, sem DV, sendo:
                        // 7 posições do nº do convênio e 10 posições do nº de controle (nº do documento)
                        _nossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 7));
                        break;
                    default:
                        throw new Exception("Posições do nº de convênio deve ser 4, 6 ou 7.");
                }

                // Importante: Nosso número, alinhar à esquerda com brancos à direita (conforme manual)
                _segmentoP += Utils.FitStringLength(_nossoNumero, 20, 20, ' ', 0, true, true, false);

                // Informar 1 – para carteira 11/12 na modalidade Simples; 
                // 2 ou 3 – para carteira 11/17 modalidade Vinculada/Caucionada e carteira 31; 
                // 4 – para carteira 11/17 modalidade Descontada e carteira 51; 
                // 7 – para carteira 17 modalidade Simples.
                if (boleto.Carteira.Equals("17-019"))
                    _segmentoP += "7";
                else
                    _segmentoP += "0";

                // Campo não tratado pelo BB. Forma de cadastramento do título no banco. Pode ser branco/espaço, 0, 1=cobrança registrada, 2=sem registro.
                _segmentoP += "1";
                // Campo não tratado pelo BB. Tipo de documento. Pode ser branco, 0, 1=tradicional, 2=escritural.
                _segmentoP += "1";
                // Campo não tratado pelo BB. Identificação de emissão do boleto. Pode ser branco/espaço, 0, ou:
                // No caso de carteira 11/12/31/51, utilizar código 1 – Banco emite, 4 – Banco reemite, 5 – Banco não reemite, porém nestes dois últimos casos, 
                // o código de Movimento Remessa (posições 16 a 17) deve ser código '31'.
                // Alteração de outros dados (para títulos que já estão registrados no Banco do Brasil). 
                // No caso de carteira 17, podem ser usados os códigos: 1 – Banco emite, 2 – Cliente emite, 3 – Banco pre-emite e cliente complementa, 6 – Cobrança sem papel. 
                // Permite ainda, códigos 4 – Banco reemite e 5 – Banco não reemite, porém o código de Movimento Remessa (posições 16 a 17) deve ser código '31' 
                // Alteração de outros dados (para títulos que já estão registrados no Banco do Brasil). 
                // Obs.: Quando utilizar código, informar de acordo com o que foi cadastrado para a carteira junto ao Banco do Brasil, consulte seu gerente de relacionamento.
                _segmentoP += "2";
                // Campo não tratado pelo BB. Informar 'branco' (espaço) OU zero ou de acordo com a carteira e quem fará a distribuição dos bloquetos. 
                // Para carteira 11/12/31/51 utilizar código 1– Banco distribui. 
                // Para carteira 17, pode ser utilizado código 1 – Banco distribui, 2 – Cliente distribui ou 3 – Banco envia e-mail (nesse caso complementar com registro S), 
                // de acordo com o que foi cadastrado para a carteira junto ao Banco do Brasil, consulte seu gerente de relacionamento.
                _segmentoP += "2";
                _segmentoP += Utils.FitStringLength(boleto.NumeroDocumento, 15, 15, ' ', 0, true, true, false);
                _segmentoP += Utils.FitStringLength(boleto.DataVencimento.ToString("ddMMyyyy"), 8, 8, ' ', 0, true, true, false);
                _segmentoP += Utils.FitStringLength(boleto.ValorBoleto.ToString("0.00").Replace(",", ""), 15, 15, '0', 0, true, true, true);
                _segmentoP += "00000 ";
                _segmentoP += Utils.FitStringLength(boleto.EspecieDocumento.Codigo.ToString(), 2, 2, '0', 0, true, true, true);
                _segmentoP += "N";
                _segmentoP += Utils.FitStringLength(boleto.DataDocumento.ToString("ddMMyyyy"), 8, 8, ' ', 0, true, true, false);

                if (boleto.JurosMora > 0)
                {
                    _segmentoP += "1";
                    _segmentoP += Utils.FitStringLength(boleto.DataVencimento.ToString("ddMMyyyy"), 8, 8, '0', 0, true, true, false);
                    _segmentoP += Utils.FitStringLength(boleto.JurosMora.ToString("0.00").Replace(",", ""), 15, 15, '0', 0, true, true, true);
                }
                else
                {
                    _segmentoP += "3";
                    _segmentoP += "00000000";
                    _segmentoP += "000000000000000";
                }

                if (boleto.ValorDesconto > 0)
                {
                    _segmentoP += "1";
                    _segmentoP += Utils.FitStringLength(boleto.DataVencimento.ToString("ddMMyyyy"), 8, 8, '0', 0, true, true, false);
                    _segmentoP += Utils.FitStringLength(boleto.ValorDesconto.ToString("0.00").Replace(",", ""), 15, 15, '0', 0, true, true, true);
                }
                else
                    _segmentoP += "000000000000000000000000";

                _segmentoP += "000000000000000";
                _segmentoP += "000000000000000";
                _segmentoP += Utils.FitStringLength(boleto.NumeroDocumento, 25, 25, ' ', 0, true, true, false);

                if (boleto.Instrucoes.Count > 1 && boleto.Instrucoes[0].QuantidadeDias > 0)
                {
                    _segmentoP += "2";
                    _segmentoP += Utils.FitStringLength(boleto.Instrucoes[0].QuantidadeDias.ToString(), 2, 2, '0', 0, true, true, true);
                }
                else
                    _segmentoP += "300";

                _segmentoP += "2000090000000000 ";

                _segmentoP = Utils.SubstituiCaracteresEspeciais(_segmentoP);

                return _segmentoP;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do SEGMENTO P DO DETALHE do arquivo de REMESSA.", ex);
            }
        }

        public override string GerarDetalheSegmentoQRemessa(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                string _zeros16 = new string('0', 16);
                string _brancos28 = new string(' ', 28);
                string _brancos40 = new string(' ', 40);

                string _segmentoQ;

                _segmentoQ = "00100013";
                _segmentoQ += Utils.FitStringLength(numeroRegistro.ToString(), 5, 5, '0', 0, true, true, true);
                _segmentoQ += "Q 01";

                if (boleto.Sacado.CPFCNPJ.Length <= 11)
                    _segmentoQ += "1";
                else
                    _segmentoQ += "2";

                _segmentoQ += Utils.FitStringLength(boleto.Sacado.CPFCNPJ, 15, 15, '0', 0, true, true, true);
                _segmentoQ += Utils.FitStringLength(boleto.Sacado.Nome.TrimStart(' '), 40, 40, ' ', 0, true, true, false).ToUpper();
                _segmentoQ += Utils.FitStringLength(boleto.Sacado.Endereco.End.TrimStart(' '), 40, 40, ' ', 0, true, true, false).ToUpper();
                _segmentoQ += Utils.FitStringLength(boleto.Sacado.Endereco.Bairro.TrimStart(' '), 15, 15, ' ', 0, true, true, false).ToUpper();
                _segmentoQ += Utils.FitStringLength(boleto.Sacado.Endereco.CEP, 8, 8, ' ', 0, true, true, false).ToUpper(); ;
                _segmentoQ += Utils.FitStringLength(boleto.Sacado.Endereco.Cidade.TrimStart(' '), 15, 15, ' ', 0, true, true, false).ToUpper();
                _segmentoQ += Utils.FitStringLength(boleto.Sacado.Endereco.UF, 2, 2, ' ', 0, true, true, false).ToUpper();
                _segmentoQ += _zeros16;
                _segmentoQ += _brancos40;
                _segmentoQ += "000";
                _segmentoQ += _brancos28;

                _segmentoQ = Utils.SubstituiCaracteresEspeciais(_segmentoQ);

                return _segmentoQ;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do SEGMENTO Q DO DETALHE do arquivo de REMESSA.", ex);
            }
        }

        public override string GerarDetalheSegmentoRRemessa(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                string _brancos110 = new string(' ', 110);
                string _brancos9 = new string(' ', 9);

                string _segmentoR;

                _segmentoR = "00100013";
                _segmentoR += Utils.FitStringLength(numeroRegistro.ToString(), 5, 5, '0', 0, true, true, true);
                _segmentoR += "R 01";
                // Desconto 2
                _segmentoR += "000000000000000000000000"; //24 zeros
                // Desconto 3
                _segmentoR += "000000000000000000000000"; //24 zeros
                // Código da multa 2 - percentual
                _segmentoR += "2";
                _segmentoR += Utils.FitStringLength(boleto.DataMulta.ToString("ddMMyyyy"), 8, 8, '0', 0, true, true, false);
                _segmentoR += Utils.FitStringLength(boleto.ValorMulta.ToString("0.00").Replace(",", ""), 15, 15, '0', 0, true, true, true);
                _segmentoR += _brancos110;
                _segmentoR += "0000000000000000"; //16 zeros
                _segmentoR += " "; //1 branco
                _segmentoR += "000000000000"; //12 zeros
                _segmentoR += "  "; //2 brancos
                _segmentoR += "0"; //1 zero
                _segmentoR += _brancos9;

                _segmentoR = Utils.SubstituiCaracteresEspeciais(_segmentoR);

                return _segmentoR;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do SEGMENTO R DO DETALHE do arquivo de REMESSA.", ex);
            }
        }

        public string GerarDetalheRemessaCNAB240(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            throw new NotImplementedException("Função não implementada.");
        }

        public string GerarDetalheRemessaCNAB400(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            throw new NotImplementedException("Função não implementada.");
        }

        # endregion DETALHE

        # region TRAILER

        /// <summary>
        /// TRAILER do arquivo CNAB
        /// Gera o TRAILER do arquivo remessa de acordo com o lay-out informado
        /// </summary>
        public override string GerarTrailerRemessa(int numeroRegistro, TipoArquivo tipoArquivo, decimal vltitulostotal)
        {
            try
            {
                string _trailer = " ";

                base.GerarTrailerRemessa(numeroRegistro, tipoArquivo, vltitulostotal);

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
                throw new Exception("Erro durante a geração do TRAILER do arquivo de REMESSA.", ex);
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

        public override string GerarTrailerLoteRemessa(int numeroRegistro)
        {
            try
            {
                string _brancos217 = new string(' ', 217);

                string _trailerLote;

                _trailerLote = "00100015         ";
                _trailerLote += Utils.FitStringLength(numeroRegistro.ToString(), 6, 6, '0', 0, true, true, true);
                _trailerLote += _brancos217;

                _trailerLote = Utils.SubstituiCaracteresEspeciais(_trailerLote);

                return _trailerLote;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do TRAILER de lote do arquivo de REMESSA.", ex);
            }
        }

        public override string GerarTrailerArquivoRemessa(int numeroRegistro)
        {
            try
            {
                string _brancos205 = new string(' ', 205);

                string _trailerArquivo;

                _trailerArquivo = "00199999         000001";
                _trailerArquivo += Utils.FitStringLength(numeroRegistro.ToString(), 6, 6, '0', 0, true, true, true);
                _trailerArquivo += "000000";
                _trailerArquivo += _brancos205;

                _trailerArquivo = Utils.SubstituiCaracteresEspeciais(_trailerArquivo);

                return _trailerArquivo;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        # endregion

        #endregion

        internal static string Mod11BancoBrasil(string value)
        {
            #region Trecho do manual DVMD11.doc
            /* 
            Multiplicar cada algarismo que compõe o número pelo seu respectivo multiplicador (PESO).
            Os multiplicadores(PESOS) variam de 9 a 2.
            O primeiro dígito da direita para a esquerda deverá ser multiplicado por 9, o segundo por 8 e assim sucessivamente.
            O resultados das multiplicações devem ser somados:
            72+35+24+27+4+9+8=179
            O total da soma deverá ser dividido por 11:
            179 / 11=16
            RESTO=3

            Se o resto da divisão for igual a 10 o D.V. será igual a X. 
            Se o resto da divisão for igual a 0 o D.V. será igual a 0.
            Se o resto for menor que 10, o D.V.  será igual ao resto.

            No exemplo acima, o dígito verificador será igual a 3
            */
            #endregion

            /* d - Dígito
             * s - Soma
             * p - Peso
             * b - Base
             * r - Resto
             */

            string d;
            int s = 0, p = 9, b = 2;

            for (int i = value.Length - 1; i >= 0; i--)
            {
                s += (int.Parse(value[i].ToString()) * p);
                if (p == b)
                    p = 9;
                else
                    p--;
            }

            int r = (s % 11);
            if (r == 10)
                d = "X";
            else if (r == 0)
                d = "0";
            else
                d = r.ToString();

            return d;
        }

    }
}

using System;
using System.Web.UI;
using Microsoft.VisualBasic;
using System.Text;

[assembly: WebResource("BoletoNet.Imagens.341.jpg", "image/jpg")]
namespace BoletoNet
{
    /// <summary>
    /// Classe referente ao banco Itaú
    /// </summary>
    internal class Banco_Itau : AbstractBanco, IBanco
    {

        #region Variáveis

        private int _dacBoleto = 0;
        private int _dacNossoNumero = 0;

        #endregion

        #region Construtores

        internal Banco_Itau()
        {
            try
            {
                this.Codigo = 341;
                this.Digito = 7;
                this.Nome = "Itaú";
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao instanciar objeto.", ex);
            }
        }

        #endregion

        #region Métodos de Instância

        /// <summary>
        /// Validações particulares do banco Itaú
        /// </summary>
        public override void ValidaBoleto(Boleto boleto)
        {
            try
            {
                //Carteiras válidas
                int[] cv = new int[] { 175, 176, 178, 109, 198, 107, 122, 142, 143, 196, 126, 131, 146, 150, 169 };//Flavio(fhlviana@hotmail.com) - adicionado a carteira 109
                bool valida = false;

                foreach (int c in cv)
                    if (Utils.ToString(boleto.Carteira) == Utils.ToString(c))
                        valida = true;

                if (!valida)
                {
                    StringBuilder carteirasImplementadas = new StringBuilder(100);

                    carteirasImplementadas.Append(". Carteiras implementadas: ");
                    foreach (int c in cv)
                    {
                        carteirasImplementadas.AppendFormat(" {0}", c);
                    }
                    throw new NotImplementedException("Carteira não implementada: " + boleto.Carteira + carteirasImplementadas.ToString());
                }
                //Verifica se o tamanho para o NossoNumero são 8 dígitos
                if (Convert.ToInt32(boleto.NossoNumero).ToString().Length > 8)
                    throw new NotImplementedException("A quantidade de dígitos do nosso número para a carteira " + boleto.Carteira + ", são 8 números.");
                else if (Convert.ToInt32(boleto.NossoNumero).ToString().Length < 8)
                    boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 8);

                //É obrigatório o preenchimento do número do documento
                if (boleto.Carteira == "106" || boleto.Carteira == "107"
                        || boleto.Carteira == "122" || boleto.Carteira == "142"
                        || boleto.Carteira == "143" || boleto.Carteira == "195"
                        || boleto.Carteira == "196" || boleto.Carteira == "198")
                {
                    if (Utils.ToInt32(boleto.NumeroDocumento) == 0)
                        throw new NotImplementedException("O número do documento não pode ser igual a zero.");
                }

                //Formato o número do documento 
                if (Utils.ToInt32(boleto.NumeroDocumento) > 0)
                    boleto.NumeroDocumento = Utils.FormatCode(boleto.NumeroDocumento, 7);

                // Calcula o DAC do Nosso Número a maioria das carteiras
                // agencia/conta/carteira/nosso numero
                if (boleto.Carteira != "126" && boleto.Carteira != "131"
                    && boleto.Carteira != "146" && boleto.Carteira != "150"
                    && boleto.Carteira != "168")
                    _dacNossoNumero = Mod10(boleto.Cedente.ContaBancaria.Agencia + boleto.Cedente.ContaBancaria.Conta + boleto.Carteira + boleto.NossoNumero);
                else
                    // Excessão 126 - 131 - 146 - 150 - 168
                    // carteira/nosso numero
                    _dacNossoNumero = Mod10(boleto.Carteira + boleto.NossoNumero);

                // Calcula o DAC da Conta Corrente
                boleto.Cedente.ContaBancaria.DigitoConta = Mod10(boleto.Cedente.ContaBancaria.Agencia + boleto.Cedente.ContaBancaria.Conta).ToString();
                //Atribui o nome do banco ao local de pagamento
                boleto.LocalPagamento += Nome + ". Após o vencimento, somente no ITAÚ";

                //Verifica se o nosso número é válido
                if (Utils.ToInt64(boleto.NossoNumero) == 0)
                    throw new NotImplementedException("Nosso número inválido");

                //Verifica se data do processamento é valida
                if (boleto.DataProcessamento.ToString("dd/MM/yyyy") == "01/01/0001")
                    boleto.DataProcessamento = DateTime.Now;

                //Verifica se data do documento é valida
                if (boleto.DataDocumento.ToString("dd/MM/yyyy") == "01/01/0001")
                    boleto.DataDocumento = DateTime.Now;

                boleto.FormataCampos();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar boletos.", e);
            }
        }

        # endregion

        # region Métodos de formatação do boleto

        public override void FormataCodigoBarra(Boleto boleto)
        {
            try
            {
                // Código de Barras
                //banco & moeda & fator & valor & carteira & nossonumero & dac_nossonumero & agencia & conta & dac_conta & "000"

                string valorBoleto = boleto.ValorBoleto.ToString("f").Replace(",", "").Replace(".", "");
                valorBoleto = Utils.FormatCode(valorBoleto, 10);

                string numeroDocumento = Utils.FormatCode(boleto.NumeroDocumento.ToString(), 7);
                string codigoCedente = Utils.FormatCode(boleto.Cedente.Codigo.ToString(), 5);

                if (boleto.Carteira == "175" || boleto.Carteira == "176" || boleto.Carteira == "178" || boleto.Carteira == "109")//Flavio(fhlviana@hotmail.com) - Adicionado carteira 109
                {
                    boleto.CodigoBarra.Codigo =
                        string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}000", Codigo, boleto.Moeda,
                                      FatorVencimento(boleto), valorBoleto, boleto.Carteira,
                                      boleto.NossoNumero, _dacNossoNumero, boleto.Cedente.ContaBancaria.Agencia,//Flavio(fhlviana@hotmail.com) => Cedente.ContaBancaria.Agencia --> boleto.Cedente.ContaBancaria.Agencia
                                      Utils.FormatCode(boleto.Cedente.ContaBancaria.Conta, 5), boleto.Cedente.ContaBancaria.DigitoConta);//Flavio(fhlviana@hotmail.com) => Cedente.ContaBancaria.DigitoConta --> boleto.Cedente.ContaBancaria.DigitoConta
                }
                else if (boleto.Carteira == "198" || boleto.Carteira == "107"
                         || boleto.Carteira == "122" || boleto.Carteira == "142"
                         || boleto.Carteira == "143" || boleto.Carteira == "196")
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}0", Codigo, boleto.Moeda,
                        FatorVencimento(boleto), valorBoleto, boleto.Carteira,
                        boleto.NossoNumero, numeroDocumento, codigoCedente,
                        Mod10(boleto.Carteira + boleto.NossoNumero + numeroDocumento + codigoCedente));
                }

                _dacBoleto = Mod11(boleto.CodigoBarra.Codigo, 9, 0);

                boleto.CodigoBarra.Codigo = Strings.Left(boleto.CodigoBarra.Codigo, 4) + _dacBoleto + Strings.Right(boleto.CodigoBarra.Codigo, 39);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao formatar código de barras.", ex);
            }
        }

        public override void FormataLinhaDigitavel(Boleto boleto)
        {
            try
            {
                string numeroDocumento = Utils.FormatCode(boleto.NumeroDocumento.ToString(), 7);
                string codigoCedente = Utils.FormatCode(boleto.Cedente.Codigo.ToString(), 5);

                string AAA = Utils.FormatCode(Codigo.ToString(), 3);
                string B = boleto.Moeda.ToString();
                string CCC = boleto.Carteira.ToString();
                string DD = boleto.NossoNumero.Substring(0, 2);
                string X = Mod10(AAA + B + CCC + DD).ToString();
                string LD = string.Empty; //Linha Digitável

                string DDDDDD = boleto.NossoNumero.Substring(2, 6);

                string K = string.Format(" {0} ", _dacBoleto);

                string UUUU = FatorVencimento(boleto).ToString();
                string VVVVVVVVVV = boleto.ValorBoleto.ToString("f").Replace(",", "").Replace(".", "");

                string C1 = string.Empty;
                string C2 = string.Empty;
                string C3 = string.Empty;
                string C5 = string.Empty;

                #region AAABC.CCDDX

                C1 = string.Format("{0}{1}{2}.", AAA, B, CCC.Substring(0, 1));
                C1 += string.Format("{0}{1}{2} ", CCC.Substring(1, 2), DD, X);

                #endregion AAABC.CCDDX

                #region UUUUVVVVVVVVVV

                VVVVVVVVVV = Utils.FormatCode(VVVVVVVVVV, 10);
                C5 = UUUU + VVVVVVVVVV;

                #endregion UUUUVVVVVVVVVV

                if (boleto.Carteira == "175" || boleto.Carteira == "176" || boleto.Carteira == "178" || boleto.Carteira == "109")//Flavio(fhlviana@hotmail.com) - adicionado carteira 109
                {
                    #region Definições
                    /* AAABC.CCDDX.DDDDD.DEFFFY.FGGGG.GGHHHZ.K.UUUUVVVVVVVVVV
              * ------------------------------------------------------
              * Campo 1
              * AAABC.CCDDX
              * AAA - Código do Banco
              * B   - Moeda
              * CCC - Carteira
              * DD  - 2 primeiros números Nosso Número
              * X   - DAC Campo 1 (AAABC.CCDD) Mod10
              * 
              * Campo 2
              * DDDDD.DEFFFY
              * DDDDD.D - Restante Nosso Número
              * E       - DAC (Agência/Conta/Carteira/Nosso Número)
              * FFF     - Três primeiros da agência
              * Y       - DAC Campo 2 (DDDDD.DEFFF) Mod10
              * 
              * Campo 3
              * FGGGG.GGHHHZ
              * F       - Restante da Agência
              * GGGG.GG - Número Conta Corrente + DAC
              * HHH     - Zeros (Não utilizado)
              * Z       - DAC Campo 3
              * 
              * Campo 4
              * K       - DAC Código de Barras
              * 
              * Campo 5
              * UUUUVVVVVVVVVV
              * UUUU       - Fator Vencimento
              * VVVVVVVVVV - Valor do Título 
              */
                    #endregion Definições

                    #region DDDDD.DEFFFY

                    string E = _dacNossoNumero.ToString();
                    string FFF = boleto.Cedente.ContaBancaria.Agencia.Substring(0, 3);
                    string Y = Mod10(DDDDDD + E + FFF).ToString();

                    C2 = string.Format("{0}.", DDDDDD.Substring(0, 5));
                    C2 += string.Format("{0}{1}{2}{3} ", DDDDDD.Substring(5, 1), E, FFF, Y);

                    #endregion DDDDD.DEFFFY

                    #region FGGGG.GGHHHZ

                    string F = boleto.Cedente.ContaBancaria.Agencia.Substring(3, 1);
                    string GGGGGG = boleto.Cedente.ContaBancaria.Conta + boleto.Cedente.ContaBancaria.DigitoConta;
                    string HHH = "000";
                    string Z = Mod10(F + GGGGGG + HHH).ToString();

                    C3 = string.Format("{0}{1}.{2}{3}{4}", F, GGGGGG.Substring(0, 4), GGGGGG.Substring(4, 2), HHH, Z);

                    #endregion FGGGG.GGHHHZ
                }
                else if (boleto.Carteira == "198" || boleto.Carteira == "107"
                     || boleto.Carteira == "122" || boleto.Carteira == "142"
                     || boleto.Carteira == "143" || boleto.Carteira == "196")
                {
                    #region Definições
                    /* AAABC.CCDDX.DDDDD.DEEEEY.EEEFF.FFFGHZ.K.UUUUVVVVVVVVVV
              * ------------------------------------------------------
              * Campo 1 - AAABC.CCDDX
              * AAA - Código do Banco
              * B   - Moeda
              * CCC - Carteira
              * DD  - 2 primeiros números Nosso Número
              * X   - DAC Campo 1 (AAABC.CCDD) Mod10
              * 
              * Campo 2 - DDDDD.DEEEEY
              * DDDDD.D - Restante Nosso Número
              * EEEE    - 4 primeiros numeros do número do documento
              * Y       - DAC Campo 2 (DDDDD.DEEEEY) Mod10
              * 
              * Campo 3 - EEEFF.FFFGHZ
              * EEE     - Restante do número do documento
              * FFFFF   - Código do Cliente
              * G       - DAC (Carteira/Nosso Numero(sem DAC)/Numero Documento/Codigo Cliente)
              * H       - zero
              * Z       - DAC Campo 3
              * 
              * Campo 4 - K
              * K       - DAC Código de Barras
              * 
              * Campo 5 - UUUUVVVVVVVVVV
              * UUUU       - Fator Vencimento
              * VVVVVVVVVV - Valor do Título 
              */
                    #endregion Definições

                    #region DDDDD.DEEEEY

                    string EEEE = numeroDocumento.Substring(0, 4);
                    string Y = Mod10(DDDDDD + EEEE).ToString();

                    C2 = string.Format("{0}.", DDDDDD.Substring(0, 5));
                    C2 += string.Format("{0}{1}{2} ", DDDDDD.Substring(5, 1), EEEE, Y);

                    #endregion DDDDD.DEEEEY

                    #region EEEFF.FFFGHZ

                    string EEE = numeroDocumento.Substring(4, 3);
                    string FFFFF = codigoCedente;
                    string G = Mod10(boleto.Carteira + boleto.NossoNumero + numeroDocumento + codigoCedente).ToString();
                    string H = "0";
                    string Z = Mod10(EEE + FFFFF + G + H).ToString();
                    C3 = string.Format("{0}{1}.{2}{3}{4}{5}", EEE, FFFFF.Substring(0, 2), FFFFF.Substring(2, 3), G, H, Z);

                    #endregion EEEFF.FFFGHZ
                }
                else if (boleto.Carteira == "126" || boleto.Carteira == "131" || boleto.Carteira == "146" || boleto.Carteira == "150" || boleto.Carteira == "168")
                {
                    throw new NotImplementedException("Função não implementada.");
                }

                boleto.CodigoBarra.LinhaDigitavel = C1 + C2 + C3 + K + C5;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao formatar linha digitável.", ex);
            }
        }

        public override void FormataNossoNumero(Boleto boleto)
        {
            try
            {
                boleto.NossoNumero = string.Format("{0}/{1}-{2}", boleto.Carteira, boleto.NossoNumero, _dacNossoNumero);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao formatar nosso número", ex);
            }
        }

        public override void FormataNumeroDocumento(Boleto boleto)
        {
            try
            {
                boleto.NumeroDocumento = string.Format("{0}-{1}", boleto.NumeroDocumento, Mod10(boleto.NumeroDocumento));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao formatar número do documento.", ex);
            }
        }

        # endregion

        # region Métodos de geração do arquivo remessa

        # region HEADER

        public override string GerarHeaderRemessa(Cedente cedente, TipoArquivo tipoArquivo)
        {
            return GerarHeaderRemessa("0", cedente, tipoArquivo);
        }
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
                        _header = GerarHeaderRemessaCNAB240(cedente);
                        break;
                    case TipoArquivo.CNAB400:
                        _header = GerarHeaderRemessaCNAB400(0, cedente);
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

        /// <summary>
        ///POS INI/FINAL	DESCRIÇÃO	                   A/N	TAM	DEC	CONTEÚDO	NOTAS
        ///--------------------------------------------------------------------------------
        ///001 - 003	Código do Banco na compensação	    N	003		341	
        ///004 - 007	Lote de serviço	                    N	004		0000	1 
        ///008 - 008	Registro Hearder de Arquivo         N	001		0	2
        ///009 - 017	Reservado (uso Banco)	            A	009		Brancos	  
        ///018 - 018	Tipo de inscrição da empresa	    N	001		1 = CPF,  2 = CNPJ 	
        ///019 – 032	Nº de inscrição da empresa	        N	014		Nota 1
        ///033 – 045	Código do Convênio no Banco   	    A	013	    Nota 2 
        ///046 - 052	Reservado (uso Banco)	            A	007		Brancos	
        ///053 - 053	Complemento de Registro             N	001     0			
        ///054 - 057	Agência Referente Convênio Ass.     N	004     Nota 1
        ///058 - 058    Complemento de Registro             A   001     Brancos
        ///059 - 065    Complemento de Registro             N   007     Brancos
        ///066 - 070    Número da C/C do Cliente            N   005     Nota 1
        ///071 - 071    Complemento de Registro             A   001     Brancos
        ///072 - 072    DAC da Agência/Conta                N   001     Nota 1
        ///073 - 102    Nome da Empresa                     A   030     Nome da Empresa
        ///103 - 132	Nome do Banco	                    A	030		Banco Itaú 	
        ///133 - 142	Reservado (uso Banco)	            A	010		Brancos	
        ///143 - 143	Código remessa 	                    N	001		1 = Remessa 	
        ///144 - 151	Data de geração do arquivo	        N	008		DDMMAAAA	
        ///152 - 157	Hora de geração do arquivo          N	006		HHMMSS
        ///158 - 163	Nº seqüencial do arquivo 	        N	006	    Nota 3
        ///164 - 166	Nº da versão do layout do arquivo	N	003		040
        ///167 - 171    Densidaded de Gravação do arquivo   N   005     00000
        ///172 - 240	Reservado (uso Banco)	            A	069		Brancos	
        /// </summary>
        public string GerarHeaderRemessaCNAB240(Cedente cedente)
        {
            try
            {
                string header = "341";
                header += "0000";
                header += "0";
                header += Utils.FormatCode("", " ", 9);
                header += (cedente.CPFCNPJ.Length == 11 ? "1" : "2");
                header += Utils.FormatCode(cedente.CPFCNPJ, "0", 14, true);
                header += Utils.FormatCode(cedente.Convenio.ToString(), " ", 13);
                header += Utils.FormatCode("", " ", 7);
                header += "0";
                header += Utils.FormatCode(cedente.ContaBancaria.Agencia, " ", 4, true);
                header += " ";
                header += Utils.FormatCode("", "0", 7);
                header += Utils.FormatCode(cedente.ContaBancaria.Conta, "0", 5, true);
                header += Utils.FormatCode("", " ", 1);
                header += Utils.FormatCode("", "0", 1);
                header += Utils.FormatCode(cedente.Nome, " ", 30);
                header += Utils.FormatCode("BANCO ITAU", " ", 30);
                header += Utils.FormatCode("", " ", 10);
                header += "1";
                header += DateTime.Now.ToString("ddMMyyyyHHmmss");
                header += Utils.FormatCode("", "0", 6, true);
                header += "040";
                header += "00000";
                header += Utils.FormatCode("", " ", 69);
                header = Utils.SubstituiCaracteresEspeciais(header);
                return header;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar HEADER do arquivo de remessa do CNAB240.", ex);
            }
        }

        public string GerarHeaderRemessaCNAB400(int numeroConvenio, Cedente cedente)
        {
            try
            {
                string complemento = new string(' ', 294);
                string _header;

                _header = "01REMESSA01COBRANCA       ";
                _header += Utils.FitStringLength(cedente.ContaBancaria.Agencia, 4, 4, '0', 0, true, true, true);
                _header += "00";
                _header += Utils.FitStringLength(cedente.ContaBancaria.Conta, 5, 5, '0', 0, true, true, true);
                _header += Utils.FitStringLength(cedente.ContaBancaria.DigitoConta, 1, 1, ' ', 0, true, true, false);
                _header += "        ";
                _header += Utils.FitStringLength(cedente.Nome, 30, 30, ' ', 0, true, true, false).ToUpper();
                _header += "341";
                _header += "BANCO ITAU SA  ";
                _header += DateTime.Now.ToString("ddMMyy");
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

        # endregion

        # region Header do Lote

        public override string GerarHeaderLoteRemessa(string numeroConvenio, Cedente cedente, int numeroArquivoRemessa, TipoArquivo tipoArquivo)
        {
            try
            {
                string header = " ";

                switch (tipoArquivo)
                {

                    case TipoArquivo.CNAB240:
                        header = GerarHeaderLoteRemessaCNAB240(cedente, numeroArquivoRemessa);
                        break;
                    case TipoArquivo.CNAB400:
                        header = GerarHeaderLoteRemessaCNAB400(0, cedente, numeroArquivoRemessa);
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

        /// <summary>
        ///POS INI/FINAL	DESCRIÇÃO	                   A/N	TAM	DEC	CONTEÚDO	NOTAS
        ///--------------------------------------------------------------------------------
        ///001 - 003	Código do Banco na compensação	    N	003		341	
        ///004 - 007	Lote de serviço	                    N	004		Nota 5 
        ///008 - 008	Registro Hearder de Lote            N	001     1
        ///009 - 009	Tipo de Operação                    A	001		D
        ///010 - 011	Tipo de serviço             	    N	002		05
        ///012 – 013	Forma de Lançamento                 N	002		50
        ///014 – 016	Número da versão do Layout   	    A	003	    030
        ///017 - 017	Complemento de Registro             A	001		Brancos	
        ///019 – 032	Nº de inscrição da empresa	        N	014		Nota 1
        ///033 – 045	Código do Convênio no Banco   	    A	013	    Nota 2
        ///018 - 018	Tipo de inscrição da empresa	    N	001		1 = CPF,  2 = CNPJ
        ///046 - 052	Reservado (uso Banco)	            A	007		Brancos	
        ///053 - 053	Complemento de Registro             N	001     0			
        ///054 - 057	Agência Referente Convênio Ass.     N	004     Nota 1
        ///058 - 058    Complemento de Registro             A   001     Brancos
        ///059 - 065    Complemento de Registro             N   007     0000000
        ///066 - 070    Número da C/C do Cliente            N   005     Nota 1
        ///071 - 071    Complemento de Registro             A   001     Brancos
        ///072 - 072    DAC da Agência/Conta                N   001     Nota 1
        ///073 - 102    Nome da Empresa                     A   030     ENIX...
        ///103 - 142	Complemento de Registro             A	040		Brancos
        ///143 - 172	Endereço da Empresa                 A	030		Nome da rua, Av., Pça, etc.
        ///173 - 177	Número do local                     N	005		Número do Local da Empresa
        ///178 - 192	Complemento                         A	015		Casa, Apto., Sala, etc.
        ///193 - 212	Nome da Cidade                      A	020	    Sao Paulo
        ///213 - 220	CEP                             	N	008		CEP
        ///221 - 222    Sigla do Estado                     A   002     SP
        ///223 - 230	Complemento de Registro             A	008		Brancos
        ///231 - 240    Cód. Ocr. para Retorno              A   010     Brancos
        /// </summary>

        private string GerarHeaderLoteRemessaCNAB240(Cedente cedente, int numeroArquivoRemessa)
        {
            try
            {
                string header = Utils.FormatCode(Codigo.ToString(), "0", 3, true);
                header += Utils.FormatCode("", "0", 4, true);
                header += "1";
                header += "D";
                header += "05";
                header += "50";
                header += "030";
                header += " ";
                header += (cedente.CPFCNPJ.Length == 11 ? "1" : "2");
                header += Utils.FormatCode(cedente.CPFCNPJ, "0", 14, true);
                header += Utils.FormatCode("", " ", 13);
                header += Utils.FormatCode("", " ", 7);
                header += "0";
                header += Utils.FormatCode("", "0", 4, true);
                header += " ";
                header += Utils.FormatCode("", "0", 7);
                header += Utils.FormatCode("", "0", 5, true);
                header += " ";
                header += "0";
                header += Utils.FormatCode(cedente.Nome, " ", 30);
                header += Utils.FormatCode("", " ", 40);
                header += Utils.FormatCode("RUA DE TESTE", " ", 30);
                header += Utils.FormatCode("999", "0", 5, true);
                header += Utils.FormatCode("15o. ANDAR", " ", 15);
                header += Utils.FormatCode("SAO PAULO", " ", 20);
                header += Utils.FormatCode("00000000", "0", 8, true);
                header += "SP";
                header += Utils.FormatCode("", " ", 8);
                header += Utils.FormatCode("", " ", 10);
                header = Utils.SubstituiCaracteresEspeciais(header);
                return header;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar HEADER DO LOTE do arquivo de remessa.", e);
            }
        }

        private string GerarHeaderLoteRemessaCNAB400(int numeroConvenio, Cedente cedente, int numeroArquivoRemessa)
        {
            throw new Exception("Função não implementada.");
        }

        #endregion

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

        /// <summary>
        ///POS INI/FINAL	DESCRIÇÃO	                   A/N	TAM	DEC	CONTEÚDO	NOTAS
        ///--------------------------------------------------------------------------------
        ///001 - 003	Código do Banco na compensação	    N	003		341	
        ///004 - 007	Lote de serviço	                    N	004		Nota 5 
        ///008 - 008	Registro Detalhe de Lote            N	001     3
        ///009 - 013	Número Sequencial Registro Lote     N	005		Nota 6
        ///014 - 014	Código Segmento Reg. Detalhe   	    A	001		A
        ///015 – 017	Código da Instrução p/ Movimento    N	003		Nota 7
        ///018 - 020	Código da Câmara de Compensação     N	003	    000
        ///021 - 023	Código do Banco                     N	003	    341
        ///024 – 024	Complemento de Registros	        N	001		0
        ///025 – 028	Número Agencia Debitada       	    N	004	    
        ///029 - 029	Complemento de Registros            A	001		Brancos
        ///030 - 036	Complemento de Registros            N	007		0000000
        ///037 - 041	Número da Conta Debitada            N	005     
        ///042 - 042	Complemento de Registros            A	001     Brancos
        ///043 - 043    Dígito Verificador da AG/Conta      N   001     
        ///044 - 073    Nome do Debitado                    A   030     
        ///074 - 088    Nr. do Docum. Atribuído p/ Empresa  A   015     Nota 8
        ///089 - 093    Complemento de Registros            A   005     Brancos
        ///094 - 101    Data para o Lançamento do Débito    N   008     DDMMAAAA
        ///102 - 104    Tipo da Moeda                       A   005     Nota 9
        ///105 - 119	Quantidade da Moeda ou IOF          N	015		Nota 10
        ///120 - 134	Valor do Lançamento p/ Débito       N	015		Nota 10
        ///135 - 154	Complemento de Registros            A	020		Brancos
        ///155 - 162	Complemento de Registros            A	008		Brancos
        ///163 - 177	Complemento de Registros            N	015	    Brancos
        ///178 - 179	Tipo do Encargo por dia de Atraso 	N	002		Nota 12
        ///180 - 196    Valor do Encargo p/ dia de Atraso   N   017     Nota 12
        ///197 - 212	Info. Compl. p/ Histórico C/C       A	016		Nota 13
        ///213 - 216    Complemento de Registros            A   004     Brancos
        ///217 - 230    No. de Insc. do Debitado(CPF/CNPJ)  N   014     
        ///231 - 240    Cód. Ocr. para Retorno              A   010     Brancos
        /// </summary>
        public string GerarDetalheRemessaCNAB240(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                string detalhe = Utils.FormatCode(Codigo.ToString(), "0", 3, true);
                detalhe += Utils.FormatCode("", "0", 4, true);
                detalhe += "3";
                detalhe += Utils.FormatCode("", "0", 5, true);
                detalhe += "A";
                detalhe += Utils.FormatCode("", "0", 3, true);
                detalhe += "000";
                detalhe += Utils.FormatCode(Codigo.ToString(), "0", 3, true);
                detalhe += "0";
                detalhe += Utils.FormatCode("", "0", 4, true);
                detalhe += " ";
                detalhe += Utils.FormatCode("", "0", 7);
                detalhe += Utils.FormatCode("", "4", 5, true);
                detalhe += " ";
                detalhe += Utils.FormatCode("", "0", 1);
                detalhe += Utils.FormatCode(boleto.Sacado.Nome, " ", 30);
                detalhe += Utils.FormatCode(boleto.NossoNumero, " ", 15);
                detalhe += Utils.FormatCode("", " ", 5);
                detalhe += DateTime.Now.ToString("ddMMyyyy");
                detalhe += Utils.FormatCode("", " ", 3);
                detalhe += Utils.FormatCode("", "0", 15, true);
                detalhe += Utils.FormatCode("", "0", 15, true);
                detalhe += Utils.FormatCode("", " ", 20);
                detalhe += Utils.FormatCode("", " ", 8);
                detalhe += Utils.FormatCode("", " ", 15);
                detalhe += Utils.FormatCode("", "0", 2, true);
                detalhe += Utils.FormatCode("", "0", 17, true);
                detalhe += Utils.FormatCode("", " ", 16);
                detalhe += Utils.FormatCode("", " ", 4);
                detalhe += Utils.FormatCode(boleto.Cedente.CPFCNPJ, "0", 14, true);
                detalhe += Utils.FormatCode("", " ", 10);
                detalhe = Utils.SubstituiCaracteresEspeciais(detalhe);
                return detalhe;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar DETALHE do arquivo CNAB240.", e);
            }
        }

        public string GerarDetalheRemessaCNAB400(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                base.GerarDetalheRemessa(boleto, numeroRegistro, tipoArquivo);

                // USO DO BANCO - Identificação da operação no Banco (posição 87 a 107)
                string identificaOperacaoBanco = new string(' ', 21);
                string usoBanco = new string(' ', 10);
                string nrDocumento = new string(' ', 25);
                string _detalhe;

                _detalhe = "1";

                // Tipo de inscrição da empresa

                // Normalmente definem o tipo (CPF/CNPJ) e o número de inscrição do cedente. 
                // Se o título for negociado, deverão ser utilizados para indicar o CNPJ/CPF do sacador 
                // (cedente original), uma vez que os cartórios exigem essa informação para efetivação 
                // dos protestos. Para este fim, também poderá ser utilizado o registro tipo “5”.
                // 01 - CPF DO CEDENTE
                // 02 - CNPJ DO CEDENTE
                // 03 - CPF DO SACADOR
                // 04 - CNPJ DO SACADOR
                // O arquivo gerado pelo aplicativo do Banco ITAÚ, sempre atriubuiu 04 para o tipo de inscrição da empresa

                if (boleto.Cedente.CPFCNPJ.Length <= 11)
                    _detalhe += "03";
                else
                    _detalhe += "04";
                _detalhe += Utils.FitStringLength(boleto.Sacado.CPFCNPJ.ToString(), 14, 14, '0', 0, true, true, true);
                _detalhe += Utils.FitStringLength(boleto.Cedente.ContaBancaria.Agencia.ToString(), 4, 4, '0', 0, true, true, true);
                _detalhe += "00";
                _detalhe += Utils.FitStringLength(boleto.Cedente.ContaBancaria.Conta.ToString(), 5, 5, '0', 0, true, true, true);
                _detalhe += Utils.FitStringLength(boleto.Cedente.ContaBancaria.DigitoConta.ToString(), 1, 1, ' ', 0, true, true, false);
                _detalhe += "    "; // Complemento do registro - 4 posições em branco

                // Código da instrução/alegação a ser cancelada

                // Deve ser preenchido na remessa somente quando utilizados, na posição 109-110, os códigos de ocorrência 35 – 
                // Cancelamento de Instrução e 38 – Cedente não concorda com alegação do sacado. Para os demais códigos de 
                // ocorrência este campo deverá ser preenchido com zeros. 
                //Obs.: No arquivo retorno será informado o mesmo código da instrução cancelada, e para o cancelamento de alegação 
                // de sacado não há retorno da informação.

                // Por enquanto o objetivo é apenas gerar o arquivo de remessa e não utilizar o arquivo para enviar instruções
                // para títulos que já estão no banco, portanto o campo será preenchido com zeros.
                _detalhe += "0000";

                _detalhe += nrDocumento; // Utils.FitStringLength(boleto.NumeroDocumento, 25, 25, ' ', 0, true, true, false); //Identificação do título na empresa
                _detalhe += Utils.FitStringLength(boleto.NossoNumero, 8, 8, '0', 0, true, true, true);
                // Quantidade de moeda variável - Preencher com zeros se a moeda for REAL
                // O manual do Banco ITAÚ não diz como preencher caso a moeda não seja o REAL
                if (boleto.Moeda == 9)
                    _detalhe += "0000000000000";

                _detalhe += Utils.FitStringLength(boleto.Carteira, 3, 3, '0', 0, true, true, true);
                _detalhe += Utils.FitStringLength(identificaOperacaoBanco, 21, 21, ' ', 0, true, true, true);
                // Código da carteira
                if (boleto.Moeda == 9)
                    _detalhe += "I"; //O código da carteira só muda para dois tipos, quando a cobrança for em dólar

                _detalhe += "01"; // Identificação da ocorrência - 01 REMESSA
                _detalhe += Utils.FitStringLength(boleto.NumeroDocumento, 10, 10, ' ', 0, true, true, false);
                _detalhe += boleto.DataVencimento.ToString("ddMMyy");
                _detalhe += Utils.FitStringLength(Convert.ToString(boleto.ValorBoleto * 100), 13, 13, '0', 0, true, true, true);
                _detalhe += "341";
                _detalhe += "00000"; // Agência onde o título será cobrado - no arquivo de remessa, preencher com ZEROS

                _detalhe += Utils.FitStringLength(EspecieDocumento.ValidaCodigo(boleto.EspecieDocumento).ToString(), 2, 2, '0', 0, true, true, true);
                _detalhe += "N"; // Identificação de título, Aceito ou Não aceito

                //A data informada neste campo deve ser a mesma data de emissão do título de crédito 
                //(Duplicata de Serviço / Duplicata Mercantil / Nota Fiscal, etc), que deu origem a esta Cobrança. 
                //Existindo divergência, na existência de protesto, a documentação poderá não ser aceita pelo Cartório.
                _detalhe += boleto.DataDocumento.ToString("ddMMyy");

                if (boleto.Instrucoes.Count > 1)
                    _detalhe += Utils.FitStringLength(boleto.Instrucoes[0].Codigo.ToString(), 2, 2, '0', 0, true, true, true);

                if (boleto.Instrucoes.Count > 2)
                    _detalhe += Utils.FitStringLength(boleto.Instrucoes[1].Codigo.ToString(), 2, 2, '0', 0, true, true, true);
                else
                    _detalhe += "  ";

                // Juros de 1 dia
                //Se o cliente optar pelo padrão do Banco Itaú ou solicitar o cadastramento permanente na conta corrente, 
                //não haverá a necessidade de informar esse valor.
                //Caso seja expresso em moeda variável, deverá ser preenchido com cinco casas decimais.

                _detalhe += "0000000000000";

                // Data limite para desconto
                _detalhe += boleto.DataVencimento.ToString("ddMMyy");
                _detalhe += Utils.FitStringLength(boleto.ValorDesconto.ToString(), 13, 13, '0', 0, true, true, true);
                _detalhe += "0000000000000"; // Valor do IOF
                _detalhe += "0000000000000"; // Valor do Abatimento

                if (boleto.Cedente.CPFCNPJ.Length > 11)
                    _detalhe += "01";  // CPF
                else
                    _detalhe += "02"; // CNPJ

                _detalhe += Utils.FitStringLength(boleto.Sacado.CPFCNPJ, 14, 14, '0', 0, true, true, true).ToUpper();
                _detalhe += Utils.FitStringLength(boleto.Sacado.Nome, 30, 30, ' ', 0, true, true, false);
                _detalhe += usoBanco;
                _detalhe += Utils.FitStringLength((boleto.Sacado.Endereco.End + " " + boleto.Sacado.Endereco.Numero + " - " + boleto.Sacado.Endereco.Complemento), 40, 40, ' ', 0, true, true, true).ToUpper();
                _detalhe += Utils.FitStringLength(boleto.Sacado.Endereco.Bairro, 12, 12, ' ', 0, true, true, false).ToUpper();
                _detalhe += Utils.FitStringLength(boleto.Sacado.Endereco.CEP, 8, 8, ' ', 0, true, true, false).ToUpper();
                ;
                _detalhe += Utils.FitStringLength(boleto.Sacado.Endereco.Cidade, 15, 15, ' ', 0, true, true, false).ToUpper();
                _detalhe += Utils.FitStringLength(boleto.Sacado.Endereco.UF, 2, 2, ' ', 0, true, true, false).ToUpper();
                // SACADOR/AVALISTA
                // Normalmente deve ser preenchido com o nome do sacador/avalista. Alternativamente este campo poderá 
                // ter dois outros usos:
                // a) 2o e 3o descontos: para de operar com mais de um desconto(depende de cadastramento prévio do 
                // indicador 19.0 pelo Banco Itaú, conforme item 5)
                // b) Mensagens ao sacado: se utilizados as instruções 93 ou 94 (Nota 11), transcrever a mensagem desejada
                _detalhe += Utils.FitStringLength(boleto.Sacado.Nome, 30, 30, ' ', 0, true, true, false).ToUpper();
                _detalhe += "    "; // Complemento do registro
                _detalhe += boleto.DataVencimento.ToString("ddMMyy");
                // PRAZO - Quantidade de DIAS - ver nota 11(A) - depende das instruções de cobrança 
                _detalhe += "00";
                _detalhe += " "; // Complemento do registro
                _detalhe += Utils.FitStringLength(numeroRegistro.ToString(), 6, 6, '0', 0, true, true, true);

                _detalhe = Utils.SubstituiCaracteresEspeciais(_detalhe);

                return _detalhe;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar DETALHE do arquivo CNAB400.", ex);
            }
        }

        # endregion DETALHE

        # region TRAILER CNAB240

        /// <summary>
        ///POS INI/FINAL	DESCRIÇÃO	                   A/N	TAM	DEC	CONTEÚDO	NOTAS
        ///--------------------------------------------------------------------------------
        ///001 - 003	Código do Banco na compensação	    N	003		341	
        ///004 - 007	Lote de serviço	                    N	004		Nota 5 
        ///008 - 008	Registro Trailer de Lote            N	001     5
        ///009 - 017	Complemento de Registros            A	009     Brancos
        ///018 - 023    Qtd. Registros do Lote              N   006     Nota 15     
        ///024 - 041    Soma Valor dos Débitos do Lote      N   018     Nota 14     
        ///042 - 059    Soma Qtd. de Moedas do Lote         N   018     Nota 14
        ///060 - 230    Complemento de Registros            A   171     Brancos
        ///231 - 240    Cód. Ocr. para Retorno              A   010     Brancos
        /// </summary>

        public override string GerarTrailerLoteRemessa(int numeroRegistro)
        {
            try
            {
                string trailer = Utils.FormatCode(Codigo.ToString(), "0", 3, true);
                trailer += Utils.FormatCode("", "0", 4, true);
                trailer += "5";
                trailer += Utils.FormatCode("", " ", 9);
                trailer += Utils.FormatCode("", "0", 6, true);
                trailer += Utils.FormatCode("", "0", 18, true);
                trailer += Utils.FormatCode("", "0", 18, true);
                trailer += Utils.FormatCode("", " ", 171);
                trailer += Utils.FormatCode("", " ", 10);
                trailer = Utils.SubstituiCaracteresEspeciais(trailer);

                return trailer;
            }
            catch (Exception e)
            {
                throw new Exception("Erro durante a geração do registro TRAILER do LOTE de REMESSA.", e);
            }
        }

        /// <summary>
        ///POS INI/FINAL	DESCRIÇÃO	                   A/N	TAM	DEC	CONTEÚDO	NOTAS
        ///--------------------------------------------------------------------------------
        ///001 - 003	Código do Banco na compensação	    N	003		341	
        ///004 - 007	Lote de serviço	                    N	004		9999 
        ///008 - 008	Registro Trailer de Arquivo         N	001     9
        ///009 - 017	Complemento de Registros            A	009     Brancos
        ///018 - 023    Qtd. Lotes do Arquivo               N   006     Nota 15     
        ///024 - 029    Qtd. Registros do Arquivo           N   006     Nota 15     
        ///030 - 240    Complemento de Registros            A   211     Brancos
        /// </summary>

        public override string GerarTrailerArquivoRemessa(int numeroRegistro)
        {
            try
            {
                string trailer = Utils.FormatCode(Codigo.ToString(), "0", 3, true);
                trailer += "9999";
                trailer += "9";
                trailer += Utils.FormatCode("", " ", 9);
                trailer += Utils.FormatCode("", "0", 6, true);
                trailer += Utils.FormatCode("", "0", 6, true);
                trailer += Utils.FormatCode("", " ", 211);
                trailer = Utils.SubstituiCaracteresEspeciais(trailer);

                return trailer;
            }
            catch (Exception e)
            {
                throw new Exception("Erro durante a geração do registro TRAILER do ARQUIVO de REMESSA.", e);
            }
        }
        #endregion

        # region TRAILER CNAB400

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

        #endregion

        #region Métodos de processamento do arquivo retorno CNAB400


        #endregion

    }
}

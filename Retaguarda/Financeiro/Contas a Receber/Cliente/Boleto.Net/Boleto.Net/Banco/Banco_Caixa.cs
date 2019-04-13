using System;
using System.Globalization;
using System.Web.UI;
using BoletoNet;
using Microsoft.VisualBasic;

[assembly: WebResource("BoletoNet.Imagens.104.jpg", "image/jpg")]

namespace BoletoNet
{
    /// <summary>
    /// Classe referente ao banco Banco_Caixa Economica Federal
    /// </summary>
    internal class Banco_Caixa : AbstractBanco, IBanco
    {
        private const int EMISSAO_CEDENTE = 4;

        string _dacBoleto = String.Empty;

        private bool protestar = false;
        private bool baixaDevolver = false;
        private bool desconto = false;
        private int diasProtesto = 0;
        private int diasDevolucao = 0;
        private int diasDesconto = 0;

        internal Banco_Caixa()
        {
            this.Codigo = 104;
            this.Digito = 0;
            this.Nome = "Caixa Econômica Federal";
        }

        public override void FormataCodigoBarra(Boleto boleto)
        {
            // Posição 01-03
            string banco = Codigo.ToString();

            //Posição 04
            string moeda = "9";

            //Posição 05 - No final ...   

            // Posição 06 - 09
            long fatorVencimento = FatorVencimento(boleto);

            // Posição 10 - 19     
            string valorDocumento = boleto.ValorBoleto.ToString("f").Replace(",", "").Replace(".", "");
            valorDocumento = Utils.FormatCode(valorDocumento, 10);


            // Inicio Campo livre
            string campoLivre = string.Empty;

            //ESSA IMPLEMENTAÇÃO FOI FEITA PARA CARTEIAS SIGCB "SR" COM NOSSO NUMERO DE 14 e 17 POSIÇÕES
            if (boleto.Carteira.Equals("SR"))
            {
                //14 POSIÇOES
                if (boleto.NossoNumero.Length == 14)
                {
                    //Posição 20 - 24
                    string contaCedente = Utils.FormatCode(boleto.Cedente.ContaBancaria.Conta, 5);

                    // Posição 25 - 28
                    string agenciaCedente = Utils.FormatCode(boleto.Cedente.ContaBancaria.Agencia, 4);

                    //Posição 29
                    string codigoCarteira = "8";

                    //Posição 30
                    string constante = "7";

                    //Posição 31 - 44
                    string nossoNumero = boleto.NossoNumero;

                    campoLivre = string.Format("{0}{1}{2}{3}{4}", contaCedente, agenciaCedente, codigoCarteira,
                                               constante, nossoNumero);
                }
                //17 POSIÇÕES
                if (boleto.NossoNumero.Length == 17)
                {
                    //104 - Caixa Econômica Federal S.A. 
                    //Carteira SR - 24 (cobrança sem registro). 
                    //Cobrança sem registro, nosso número com 17 dígitos. 

                    //Posição 20 - 25
                    string codigoCedente = Utils.FormatCode(boleto.Cedente.Codigo.ToString(), 6);

                    // Posição 26
                    string dvCodigoCedente = Mod11Base9(codigoCedente).ToString();

                    //Posição 27 - 29
                    //De acordo com documentação, posição 3 a 5 do nosso numero
                    string primeiraParteNossoNumero = boleto.NossoNumero.Substring(2, 3);

                    //Posição 30
                    string primeiraConstante = boleto.Carteira;
                    if (boleto.Carteira == "SR")
                    {
                        primeiraConstante = "2"; //1 => cobrança registrada, 2=> cobrança sem registro
                    }

                    // Posição 31 - 33
                    //DE acordo com documentação, posição 6 a 8 do nosso numero
                    string segundaParteNossoNumero = boleto.NossoNumero.Substring(5, 3);

                    // Posição 34
                    string segundaConstante = "4";// 4 => emissão do boleto pelo cedente

                    //Posição 35 - 43
                    //De acordo com documentaçao, posição 9 a 17 do nosso numero
                    string terceiraParteNossoNumero = boleto.NossoNumero.Substring(8, 9);

                    //Posição 44
                    string ccc = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                                               codigoCedente,
                                               dvCodigoCedente,
                                               primeiraParteNossoNumero,
                                               primeiraConstante,
                                               segundaParteNossoNumero,
                                               segundaConstante,
                                               terceiraParteNossoNumero);
                    string dvCampoLivre = Mod11Base9(ccc).ToString();
                    campoLivre = string.Format("{0}{1}", ccc, dvCampoLivre);
                }
            }
            else
            {
                //Posição 20 - 25
                string codigoCedente = Utils.FormatCode(boleto.Cedente.Codigo.ToString(), 6);

                // Posição 26
                string dvCodigoCedente = Mod11Base9(codigoCedente).ToString();

                //Posição 27 - 29
                string primeiraParteNossoNumero = boleto.NossoNumero.Substring(0, 3);

                //104 - Caixa Econômica Federal S.A. 
                //Carteira 01. 
                //Cobrança rápida. 
                //Cobrança sem registro. 
                //Cobrança sem registro, nosso número com 16 dígitos. 
                //Cobrança simples 

                //Posição 30
                string primeiraConstante = boleto.Carteira;
                if (boleto.Carteira == "SR")
                {
                    primeiraConstante = "2";
                }
                else
                {
                    primeiraConstante = boleto.Carteira;
                }

                // Posição 31 - 33
                string segundaParteNossoNumero = boleto.NossoNumero.Substring(0, 3); //(3, 3);

                // Posição 24
                string segundaConstante = EMISSAO_CEDENTE.ToString();

                //Posição 35 - 43
                string terceiraParteNossoNumero = boleto.NossoNumero.Substring(3, 7) + segundaConstante +
                                                  segundaConstante; //(6, 9);

                //Posição 44
                string ccc = string.Format("{0}{1}{2}{3}{4}{5}{6}", codigoCedente, dvCodigoCedente,
                                           primeiraParteNossoNumero,
                                           primeiraConstante, segundaParteNossoNumero, segundaConstante,
                                           terceiraParteNossoNumero);

                string dvCampoLivre = Mod11Base9(ccc).ToString();

                campoLivre = string.Format("{0}{1}", ccc, dvCampoLivre);
            }


            string xxxx = string.Format("{0}{1}{2}{3}{4}", banco, moeda, fatorVencimento, valorDocumento, campoLivre);

            string dvGeral = Mod11(xxxx, 9).ToString();
            // Posição 5
            _dacBoleto = dvGeral;

            boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}",
                   banco,
                   moeda,
                   dvGeral,
                   fatorVencimento,
                   valorDocumento,
                   campoLivre
                   );
        }

        public override void FormataLinhaDigitavel(Boleto boleto)
        {
            string Grupo1 = string.Empty;
            string Grupo2 = string.Empty;
            string Grupo3 = string.Empty;
            string Grupo4 = string.Empty;
            string Grupo5 = string.Empty;

            string str1 = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;

            /// <summary>
            ///   IMPLEMENTAÇÃO PARA NOSSO NÚMERO COM 17 POSIÇÕES
            ///   Autor.: Fábio Marcos
            ///   E-Mail: fabiomarcos@click21.com.br
            ///   Data..: 01/03/2011
            /// </summary>
            if (boleto.NossoNumero.Length == 17)
            {
                #region Campo 1

                //POSIÇÃO 1 A 4 DO CODIGO DE BARRAS
                str1 = boleto.CodigoBarra.Codigo.Substring(0, 4);
                //POSICAO 20 A 24 DO CODIGO DE BARRAS
                str2 = boleto.CodigoBarra.Codigo.Substring(19, 5);
                //CALCULO DO DIGITO
                str3 = Mod10(str1 + str2).ToString();

                Grupo1 = str1 + str2 + str3;
                Grupo1 = Grupo1.Substring(0, 5) + "." + Grupo1.Substring(5) + " ";

                #endregion Campo 1

                #region Campo 2

                //POSIÇÃO 25 A 34 DO COD DE BARRAS
                str1 = boleto.CodigoBarra.Codigo.Substring(24, 10);
                //DIGITO
                str2 = Mod10(str1).ToString();

                Grupo2 = string.Format("{0}.{1}{2} ", str1.Substring(0, 5), str1.Substring(5, 5), str2);

                #endregion Campo 2

                #region Campo 3

                //POSIÇÃO 35 A 44 DO CODIGO DE BARRAS
                str1 = boleto.CodigoBarra.Codigo.Substring(34, 10);
                //DIGITO
                str2 = Mod10(str1).ToString();

                Grupo3 = string.Format("{0}.{1}{2} ", str1.Substring(0, 5), str1.Substring(5, 5), str2);

                #endregion Campo 3

                #region Campo 4

                string D4 = _dacBoleto.ToString();

                Grupo4 = string.Format("{0} ", D4);

                #endregion Campo 4

                #region Campo 5

                //POSICAO 6 A 9 DO CODIGO DE BARRAS
                str1 = boleto.CodigoBarra.Codigo.Substring(5, 4);

                //POSICAO 10 A 19 DO CODIGO DE BARRAS
                str2 = boleto.CodigoBarra.Codigo.Substring(9, 10);

                Grupo5 = string.Format("{0}{1}", str1, str2);

                #endregion Campo 5
            }
            else
            {
                #region Campo 1

                string BBB = boleto.CodigoBarra.Codigo.Substring(0, 3);
                string M = boleto.CodigoBarra.Codigo.Substring(3, 1);
                string CCCCC = boleto.CodigoBarra.Codigo.Substring(19, 5);
                string D1 = Mod10(BBB + M + CCCCC).ToString();

                Grupo1 = string.Format("{0}{1}{2}.{3}{4} ",
                    BBB,
                    M,
                    CCCCC.Substring(0, 1),
                    CCCCC.Substring(1, 4), D1);


                #endregion Campo 1

                #region Campo 2

                string CCCCCCCCCC2 = boleto.CodigoBarra.Codigo.Substring(24, 10);
                string D2 = Mod10(CCCCCCCCCC2).ToString();

                Grupo2 = string.Format("{0}.{1}{2} ", CCCCCCCCCC2.Substring(0, 5), CCCCCCCCCC2.Substring(5, 5), D2);

                #endregion Campo 2

                #region Campo 3

                string CCCCCCCCCC3 = boleto.CodigoBarra.Codigo.Substring(34, 10);
                string D3 = Mod10(CCCCCCCCCC3).ToString();

                Grupo3 = string.Format("{0}.{1}{2} ", CCCCCCCCCC3.Substring(0, 5), CCCCCCCCCC3.Substring(5, 5), D3);


                #endregion Campo 3

                #region Campo 4

                string D4 = _dacBoleto.ToString();

                Grupo4 = string.Format(" {0} ", D4);

                #endregion Campo 4

                #region Campo 5

                long FFFF = FatorVencimento(boleto);

                string VVVVVVVVVV = boleto.ValorBoleto.ToString("f").Replace(",", "").Replace(".", "");
                VVVVVVVVVV = Utils.FormatCode(VVVVVVVVVV, 10);

                if (Utils.ToInt64(VVVVVVVVVV) == 0)
                    VVVVVVVVVV = "000";

                Grupo5 = string.Format("{0}{1}", FFFF, VVVVVVVVVV);

                #endregion Campo 5
            }

            //MONTA OS DADOS DA INHA DIGITÁVEL DE ACORDO COM OS DADOS OBTIDOS ACIMA
            boleto.CodigoBarra.LinhaDigitavel = Grupo1 + Grupo2 + Grupo3 + Grupo4 + Grupo5;
        }

        public override void FormataNossoNumero(Boleto boleto)
        {
            if (boleto.Carteira.Equals("SR"))
            {
                if (boleto.NossoNumero.Length == 14)
                {
                    boleto.NossoNumero = "8" + boleto.NossoNumero;
                }
            }

            boleto.NossoNumero = string.Format("{0}-{1}", boleto.NossoNumero, Mod11Base9(boleto.NossoNumero)); //
            //boleto.NossoNumero = string.Format("{0}{1}/{2}-{3}", boleto.Carteira, EMISSAO_CEDENTE, boleto.NossoNumero, Mod11Base9(boleto.Carteira + EMISSAO_CEDENTE + boleto.NossoNumero));
        }

        public override void FormataNumeroDocumento(Boleto boleto)
        {

        }

        public override void ValidaBoleto(Boleto boleto)
        {
            if (boleto.Carteira.Equals("SR"))
            {
                if ((boleto.NossoNumero.Length != 14) && (boleto.NossoNumero.Length != 17))
                {
                    throw new Exception("Nosso Número inválido, Para Caixa Econômica - Carteira SR o Nosso Número deve conter 14 ou 17 posições.");
                }
            }
            else
            {
                if (boleto.NossoNumero.Length != 10)
                {
                    throw new Exception(
                        "Nosso Número inválido, Para Caixa Econômica carteira indefinida, o Nosso Número deve conter 10 caracteres.");
                }

                if (!boleto.Cedente.Codigo.Equals(0))
                {
                    string codigoCedente = Utils.FormatCode(boleto.Cedente.Codigo.ToString(), 6);
                    string dvCodigoCedente = Mod10(codigoCedente).ToString(); //Base9 

                    if (boleto.Cedente.DigitoCedente.Equals(-1))
                        boleto.Cedente.DigitoCedente = Convert.ToInt32(dvCodigoCedente);
                }
                else
                {
                    throw new Exception("Informe o código do cedente.");
                }
            }

            //Atribui o nome do banco ao local de pagamento
            boleto.LocalPagamento = "PREFERENCIALMENTE NAS CASAS LOTÉRICAS E AGÊNCIAS DA CAIXA";

            FormataCodigoBarra(boleto);
            FormataLinhaDigitavel(boleto);
            FormataNossoNumero(boleto);
        }

        #region Métodos de geração do arquivo remessa
        public override string GerarHeaderRemessa(Cedente cedente, TipoArquivo tipoArquivo, int numeroArquivoRemessa)
        {
            return GerarHeaderRemessa("0", cedente, tipoArquivo, numeroArquivoRemessa);
        }
        /// <summary>
        /// HEADER do arquivo CNAB
        /// Gera o HEADER do arquivo remessa de acordo com o lay-out informado
        /// </summary>
        public override string GerarHeaderRemessa(string numeroConvenio, Cedente cedente, TipoArquivo tipoArquivo, int numeroArquivoRemessa)
        {
            try
            {
                string _header = " ";

                base.GerarHeaderRemessa("0", cedente, tipoArquivo, numeroArquivoRemessa);

                switch (tipoArquivo)
                {

                    case TipoArquivo.CNAB240:
                        _header = GerarHeaderRemessaCNAB240(cedente);
                        break;
                    case TipoArquivo.CNAB400:
                        _header = GerarHeaderRemessaCNAB400(0, cedente, numeroArquivoRemessa);
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

        public override string GerarDetalheSegmentoPRemessa(Boleto boleto, int numeroRegistro, string numeroConvenio, Cedente cedente)
        {
            return GerarDetalheSegmentoPRemessaCNAB240(boleto, numeroRegistro, numeroConvenio, cedente);
        }

        public override string GerarDetalheSegmentoQRemessa(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            return GerarDetalheSegmentoQRemessaCNAB240(boleto, numeroRegistro, tipoArquivo);
        }

        public override string GerarDetalheSegmentoRRemessa(Boleto boleto, int numeroRegistroDetalhe, TipoArquivo CNAB240)
        {
            return GerarDetalheSegmentoRRemessaCNAB240(boleto, numeroRegistroDetalhe, CNAB240);
        }

        public override string GerarTrailerLoteRemessa(int numeroRegistro)
        {
            return GerarTrailerLoteRemessaCNAB240(numeroRegistro);
        }

        public override string GerarTrailerArquivoRemessa(int numeroRegistro)
        {
            return GerarTrailerArquivoRemessaCNAB240(numeroRegistro);
        }

        public string GerarHeaderRemessaCNAB240(Cedente cedente)
        {
            try
            {
                string header = Utils.FormatCode(Codigo.ToString(), "0", 3, true);                      // código do banco na compensação
                header += "0000";                                                                       // Lote de Serviço 
                header += "0";                                                                          // Tipo de Registro 
                header += Utils.FormatCode("", " ", 9);                                                 // Uso Exclusivo FEBRABAN/CNAB
                header += (cedente.CPFCNPJ.Length == 11 ? "1" : "2");                                   // Tipo de Inscrição 
                header += Utils.FormatCode(cedente.CPFCNPJ, "0", 15);                                   // CPF/CNPJ do cedente 
                header += Utils.FormatCode(cedente.Codigo.ToString() + cedente.DigitoCedente, "0", 16); // Código do Convênio no Banco 
                header += Utils.FormatCode("", "0", 4);                                                 // Uso Exclusivo CAIXA
                header += Utils.FormatCode(cedente.ContaBancaria.Agencia, "0", 5);                      // Agência Mantenedora da Conta 
                header += Utils.FormatCode(cedente.ContaBancaria.DigitoAgencia, "0", 5);                // Dígito Verificador da Agência 
                header += Utils.FormatCode(cedente.ContaBancaria.Conta, "0", 12);                       // Código do Cedente (sem operação)  
                header += cedente.ContaBancaria.DigitoConta;                                            // Díg. Verif. Cedente (sem operação) 
                header += Banco.Mod11(cedente.ContaBancaria.Agencia + cedente.ContaBancaria.Conta).ToString();// Dígito Verif. Ag./Ced  (sem operação)
                header += Utils.FormatCode(cedente.Nome, " ", 30);                                      // Nome do cedente
                header += Utils.FormatCode("CAIXA ECONOMICA FEDERAL", " ", 30);                         // Nome do Banco
                header += Utils.FormatCode("", " ", 10);                                                // Uso Exclusivo FEBRABAN/CNAB
                header += "1";                                                                          // Código 1 - Remessa / 2 - Retorno 
                header += DateTime.Now.ToString("ddMMyyyy");                                            // Data de Geração do Arquivo
                header += string.Format("{0:hh:mm:ss}", DateTime.Now).Replace(":", "");                  // Hora de Geração do Arquivo
                header += "000001";                                                                     // Número Seqüencial do Arquivo 
                header += "030";                                                                        // Número da Versão do Layout do Arquivo 
                header += "0";                                                                          // Densidade de Gravação do Arquivo 
                header += Utils.FormatCode("", " ", 20);                                                // Para Uso Reservado do Banco
                // Na fase de teste deve conter "remessa-produção", após aprovado deve conter espaços em branco
                header += Utils.FormatCode("remessa-produção", " ", 20);                                // Para Uso Reservado da Empresa  
                //header += Utils.FormatCode("", " ", 20);                                              // Para Uso Reservado da Empresa
                header += Utils.FormatCode("", " ", 29);                                                // Uso Exclusivo FEBRABAN/CNAB

                return header;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar HEADER do arquivo de remessa do CNAB240.", ex);
            }
        }

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

        private string GerarHeaderLoteRemessaCNAB400(int numeroConvenio, Cedente cedente, int numeroArquivoRemessa)
        {
            throw new Exception("Função não implementada.");
        }

        private string GerarHeaderLoteRemessaCNAB240(Cedente cedente, int numeroArquivoRemessa)
        {
            try
            {
                string header = Utils.FormatCode(Codigo.ToString(), "0", 3, true);                      // código do banco na compensação
                header += "0001";                                                                       // Lote de Serviço
                header += "1";                                                                          // Tipo de Registro 
                header += "R";                                                                          // Tipo de Operação 
                header += "01";                                                                         // Tipo de Serviço '01' = Cobrança, '03' = Bloqueto Eletrônico 
                header += "  ";                                                                         // Uso Exclusivo FEBRABAN/CNAB
                header += "020";                                                                        // Número da Versão do Layout do Arquivo 
                header += " ";                                                                          // Uso Exclusivo FEBRABAN/CNAB
                header += (cedente.CPFCNPJ.Length == 11 ? "1" : "2");                                   // Tipo de Inscrição 
                header += Utils.FormatCode(cedente.CPFCNPJ, "0", 15);                                   // CPF/CNPJ do cedente
                header += Utils.FormatCode(cedente.Codigo.ToString() + cedente.DigitoCedente, "0", 16); // Código do Convênio no Banco 
                header += Utils.FormatCode("", " ", 4);                                                 // Uso Exclusivo CAIXA
                header += Utils.FormatCode(cedente.ContaBancaria.Agencia, "0", 5);                      // Agência Mantenedora da Conta 
                header += Utils.FormatCode(cedente.ContaBancaria.DigitoAgencia, "0", 5);                // Dígito Verificador da Agência 
                header += Utils.FormatCode(cedente.ContaBancaria.Conta, "0", 12);                       // Número da Conta Corrente 
                header += cedente.ContaBancaria.DigitoConta;                                            // Digito Verificador da Conta Corrente 
                header += Banco.Mod11(cedente.ContaBancaria.Agencia + cedente.ContaBancaria.Conta).ToString();// Dígito Verif. Ag./Ced  (sem operação)
                header += Utils.FormatCode(cedente.Nome, " ", 30);                                      // Nome do cedente
                header += Utils.FormatCode("", " ", 40);                                                // Mensagem 1
                header += Utils.FormatCode("", " ", 40);                                                // Mensagem 2
                header += numeroArquivoRemessa.ToString("00000000");                                    // Número Remessa/Retorno
                header += DateTime.Now.ToString("ddMMyyyy");                                            // Data de Gravação Remessa/Retorno 
                header += Utils.FormatCode("", "0", 8);                                                 // Data do Crédito 
                header += Utils.FormatCode("", " ", 33);                                                // Uso Exclusivo FEBRABAN/CNAB

                return header;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar HEADER DO LOTE do arquivo de remessa.", e);
            }
        }

        public string GerarHeaderRemessaCNAB400(int numeroConvenio, Cedente cedente, int numeroArquivoRemessa)
        {
            throw new Exception("Função não implementada.");
        }

        public string GerarDetalheSegmentoPRemessaCNAB240(Boleto boleto, int numeroRegistro, string numeroConvenio, Cedente cedente)
        {
            try
            {
                validaInstrucoes(boleto); // Para protestar, devolver ou desconto.

                string header = Utils.FormatCode(Codigo.ToString(), "0", 3, true);                      // código do banco na compensação
                header += "0001";                                                                       // Lote de Serviço
                header += "3";                                                                          // Tipo de Registro 
                header += Utils.FormatCode(numeroRegistro.ToString(), "0", 5);                          // Nº Sequencial do Registro no Lote 
                header += "P";                                                                          // Cód. Segmento do Registro Detalhe
                header += " ";                                                                          // Uso Exclusivo FEBRABAN/CNAB
                header += "01";                                                                         // Código de Movimento Remessa 
                header += Utils.FormatCode(cedente.ContaBancaria.Agencia, "0", 5);                      // Agência Mantenedora da Conta 
                header += cedente.ContaBancaria.DigitoAgencia;                                          // Dígito Verificador da Agência 
                header += Utils.FormatCode(cedente.ContaBancaria.Conta, "0", 12);                       // Número da Conta Corrente 
                header += cedente.ContaBancaria.DigitoConta;                                            // Digito Verificador da Conta Corrente 
                header += Banco.Mod11(cedente.ContaBancaria.Agencia + cedente.ContaBancaria.Conta).ToString(); // Dígito Verif. Ag./Ced  (sem operação)
                header += Utils.FormatCode("", "0", 9);                                                 // Uso Exclusivo CAIXA
                header += Utils.FormatCode(boleto.NossoNumero, "0", 11);                                // Identificação do Título no Banco 
                header += "01";                                                                         // Código da Carteira 
                header += (boleto.Carteira == "14" ? "2" : "1");                                        // Forma de Cadastr. do Título no Banco 
                // '1' = Com Cadastramento (Cobrança Registrada) 
                // '2' = Sem Cadastramento (Cobrança sem Registro) 
                header += "2";                                                                          // Tipo de Documento 
                header += "2";                                                                          // Identificação da Emissão do Bloqueto 
                header += "2";                                                                          // Identificação da Distribuição
                header += Utils.FormatCode(boleto.NumeroDocumento, "0", 11);                            // Número do Documento de Cobrança 
                header += "    ";                                                                       // Uso Exclusivo CAIXA
                header += boleto.DataVencimento.ToString("ddMMyyyy");                                   // Data de Vencimento do Título
                header += Utils.FormatCode(boleto.ValorBoleto.ToString().Replace(",", "").Replace(".", ""), "0", 13); // Valor Nominal do Título 13
                header += Utils.FormatCode(cedente.ContaBancaria.Agencia, "0", 5);                      // Agência Encarregada da Cobrança 
                header += cedente.ContaBancaria.DigitoAgencia;                                          // Dígito Verificador da Agência 
                header += boleto.EspecieDocumento.Codigo.ToString("00");                                // Espécie do Título 
                header += boleto.Aceite;                                                                // Identific. de Título Aceito/Não Aceito
                // Data da Emissão do Título 
                header += (boleto.DataProcessamento.ToString("ddMMyyyy") == "01010001" ? DateTime.Now.ToString("ddMMyyyy") : boleto.DataProcessamento.ToString("ddMMyyyy"));
                header += "1";                                                                          // Código do Juros de Mora '1' = Valor por Dia - '2' = Taxa Mensal 
                header += (boleto.DataMulta.ToString("ddMMyyyy") == "01010001" ? "00000000" : boleto.DataMulta.ToString("ddMMyyyy")); // Data do Juros de Mora 
                header += Utils.FormatCode(boleto.ValorMulta.ToString().Replace(",", "").Replace(".", ""), "0", 13); // Juros de Mora por Dia/Taxa 
                header += (desconto ? "1" : "0");                                                       // Código do Desconto 
                header += (boleto.DataDesconto.ToString("ddMMyyyy") == "01010001" ? "00000000" : boleto.DataDesconto.ToString("ddMMyyyy")); // Data do Desconto
                header += Utils.FormatCode(boleto.ValorDesconto.ToString().Replace(",", "").Replace(".", ""), "0", 13); // Valor/Percentual a ser Concedido 
                header += Utils.FormatCode(boleto.IOF.ToString().Replace(",", "").Replace(".", ""), "0", 13); // Valor do IOF a ser Recolhido 
                header += Utils.FormatCode(boleto.Abatimento.ToString().Replace(",", "").Replace(".", ""), "0", 13); // Valor do Abatimento 
                header += Utils.FormatCode("", " ", 25);                                                // Identificação do Título na Empresa
                header += (protestar ? "1" : "3");                                                      // Código para Protesto
                header += diasProtesto.ToString("00");                                                  // Número de Dias para Protesto 2 posi
                header += (baixaDevolver ? "1" : "2");                                                  // Código para Baixa/Devolução 1 posi
                header += diasDevolucao.ToString("00");                                                 // Número de Dias para Baixa/Devolução 3 posi
                header += boleto.Moeda.ToString("00");                                                  // Código da Moeda 
                header += Utils.FormatCode("", " ", 10);                                                // Uso Exclusivo FEBRABAN/CNAB 
                header += Utils.FormatCode("", " ", 1);                                                 // Uso Exclusivo FEBRABAN/CNAB 

                return header;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar SEGMENTO P do arquivo de remessa.", e);
            }
        }

        public string GerarDetalheSegmentoQRemessaCNAB240(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                string header = Utils.FormatCode(Codigo.ToString(), "0", 3, true);                      // código do banco na compensação
                header += "0001";                                                                       // Lote de Serviço
                header += "3";                                                                          // Tipo de Registro 
                header += Utils.FormatCode(numeroRegistro.ToString(), "0", 5);                          // Nº Sequencial do Registro no Lote 
                header += "Q";                                                                          // Cód. Segmento do Registro Detalhe
                header += " ";                                                                          // Uso Exclusivo FEBRABAN/CNAB
                header += "01";                                                                         // Código de Movimento Remessa
                header += (boleto.Sacado.CPFCNPJ.Length == 11 ? "1" : "2");                             // Tipo de Inscrição 
                header += Utils.FormatCode(boleto.Sacado.CPFCNPJ, "0", 15);                             // Número de Inscrição 
                header += Utils.FormatCode(boleto.Sacado.Nome, " ", 40);                                // Nome
                header += Utils.FormatCode(boleto.Sacado.Endereco.End, " ", 40);                        // Endereço
                header += Utils.FormatCode(boleto.Sacado.Endereco.Bairro, " ", 15);                     // Bairro 
                header += boleto.Sacado.Endereco.CEP;                                                   // CEP + Sufixo do CEP
                header += Utils.FormatCode(boleto.Sacado.Endereco.Cidade, " ", 15);                     // Cidade 
                header += boleto.Sacado.Endereco.UF;                                                    // Unidade da Federação
                // Estes campos deverão estar preenchidos quando não for o Cedente original do título.
                header += "0";                                                                          // Tipo de Inscrição 
                header += Utils.FormatCode("", "0", 15);                                                // Número de Inscrição CPF/CNPJ
                header += Utils.FormatCode("", " ", 40);                                                // Nome do Sacador/Avalista 
                //*********
                header += Utils.FormatCode("", " ", 31);                                                // Uso Exclusivo FEBRABAN/CNAB

                return header;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar SEGMENTO Q do arquivo de remessa.", e);
            }
        }

        public string GerarDetalheSegmentoRRemessaCNAB240(Boleto boleto, int numeroRegistroDetalhe, TipoArquivo CNAB240)
        {
            try
            {
                string header = Utils.FormatCode(Codigo.ToString(), "0", 3, true);                      // código do banco na compensação
                header += "0001";                                                                       // Lote de Serviço
                header += "3";                                                                          // Tipo de Registro 
                header += Utils.FormatCode(numeroRegistroDetalhe.ToString(), "0", 5);                   // Nº Sequencial do Registro no Lote 
                header += "R";                                                                          // Cód. Segmento do Registro Detalhe
                header += " ";                                                                          // Uso Exclusivo FEBRABAN/CNAB
                header += "01";                                                                         // Código de Movimento Remessa
                header += Utils.FormatCode("", " ", 48);                                                // Uso Exclusivo FEBRABAN/CNAB 
                header += "1";                                          // Código da Multa '1' = Valor Fixo,'2' = Percentual,'0' = Sem Multa 
                header += boleto.DataMulta.ToString("ddMMyyyy");                                        // Data da Multa 
                header += Utils.FormatCode(boleto.ValorMulta.ToString().Replace(",", "").Replace(".", ""), "0", 13); // Valor/Percentual a Ser Aplicado
                header += Utils.FormatCode("", " ", 10);                                                // Informação ao Sacado
                header += Utils.FormatCode("", " ", 40);                                                // Mensagem 3
                header += Utils.FormatCode("", " ", 40);                                                // Mensagem 4
                header += Utils.FormatCode("", " ", 61);                                                // Uso Exclusivo FEBRABAN/CNAB 

                return header;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar SEGMENTO Q do arquivo de remessa.", e);
            }
        }

        public string GerarTrailerLoteRemessaCNAB240(int numeroRegistro)
        {
            try
            {
                string header = Utils.FormatCode(Codigo.ToString(), "0", 3, true);                      // código do banco na compensação
                header += "0001";                                                                       // Lote de Serviço
                header += "5";                                                                          // Tipo de Registro 
                header += Utils.FormatCode("", " ", 61);                                                // Uso Exclusivo FEBRABAN/CNAB
                header += Utils.FormatCode(numeroRegistro.ToString(), "0", 5);                          // Nº Sequencial do Registro no Lote 

                // Totalização da Cobrança Simples
                header += Utils.FormatCode("", "0", 6);                                                 // Quantidade de Títulos em Cobrança
                header += Utils.FormatCode("", "0", 15);                                                // Valor Total dos Títulos em Carteiras

                header += Utils.FormatCode("", "0", 6);                                                 // Uso Exclusivo FEBRABAN/CNAB
                header += Utils.FormatCode("", "0", 15);                                                // Uso Exclusivo FEBRABAN/CNAB 

                // Totalização da Cobrança Caucionada
                header += Utils.FormatCode("", "0", 6);                                                 // Quantidade de Títulos em Cobrança
                header += Utils.FormatCode("", "0", 15);                                                // Valor Total dos Títulos em Carteiras

                // Totalização da Cobrança Descontada
                header += Utils.FormatCode("", "0", 6);                                                 // Quantidade de Títulos em Cobrança
                header += Utils.FormatCode("", "0", 15);                                                // Valor Total dos Títulos em Carteiras

                header += Utils.FormatCode("", " ", 8);                                                 // Uso Exclusivo FEBRABAN/CNAB
                header += Utils.FormatCode("", " ", 117);                                               // Uso Exclusivo FEBRABAN/CNAB

                return header;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar Trailer de Lote do arquivo de remessa.", e);
            }
        }

        public string GerarTrailerArquivoRemessaCNAB240(int numeroRegistro)
        {
            try
            {
                string header = Utils.FormatCode(Codigo.ToString(), "0", 3, true);                      // código do banco na compensação
                header += "9999";                                                                       // Lote de Serviço
                header += "9";                                                                          // Tipo de Registro 
                header += Utils.FormatCode("", " ", 9);                                                 // Uso Exclusivo FEBRABAN/CNAB
                header += "000001";                                                                     // Quantidade de Lotes do Arquivo
                header += Utils.FormatCode(numeroRegistro.ToString(), "0", 6);                          // Quantidade de Registros do Arquivo
                header += Utils.FormatCode("", " ", 6);                                                 // Uso Exclusivo FEBRABAN/CNAB
                header += Utils.FormatCode("", " ", 205);                                               // Uso Exclusivo FEBRABAN/CNAB

                return header;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar Trailer de arquivo de remessa.", e);
            }
        }

        #endregion Métodos de geração do arquivo remessa

        /// <summary>
        /// Varre as instrucoes para inclusao no Segmento P
        /// </summary>
        /// <param name="boleto"></param>
        private void validaInstrucoes(Boleto boleto)
        {
            if (boleto.Instrucoes.Count.Equals(0))
                return;

            foreach (IInstrucao instrucao in boleto.Instrucoes)
            {
                if (instrucao.Codigo.Equals(9) || instrucao.Codigo.Equals(42) || instrucao.Codigo.Equals(81) || instrucao.Codigo.Equals(82))
                {
                    protestar = true;
                    diasProtesto = instrucao.QuantidadeDias;
                }
                else if (instrucao.Codigo.Equals(91) || instrucao.Codigo.Equals(92))
                {
                    baixaDevolver = true;
                    diasDevolucao = instrucao.QuantidadeDias;
                }
                else if (instrucao.Codigo.Equals(999))
                {
                    desconto = true;
                    diasDesconto = instrucao.QuantidadeDias;
                }
            }
        }

        #region Métodos de Leitura do Arquivo de Retorno
        public override DetalheSegmentoTRetornoCNAB240 LerDetalheSegmentoTRetornoCNAB240(string registro)
        {

            string _Controle_numBanco = registro.Substring(0, 3); //01
            string _Controle_lote = registro.Substring(3, 7); //02
            string _Controle_regis = registro.Substring(7, 1); //03
            string _Servico_numRegis = registro.Substring(8, 5); //04
            string _Servico_segmento = registro.Substring(13, 1); //05
            string _cnab06 = registro.Substring(14, 1); //06
            string _Servico_codMov = registro.Substring(15, 2); //07
            string _ccAgenciaCodigo = registro.Substring(17, 5); //08
            string _ccAgenciaDv = registro.Substring(22, 1); //09
            string _ccContaNumero = registro.Substring(23, 12); //10
            string _ccContaDv = registro.Substring(35, 1); //11
            string _ccDv = registro.Substring(36, 1); //12
            string _outUsoExclusivo = registro.Substring(37, 9); //13
            string _outNossoNumero = registro.Substring(46, 11); //14
            string _outCarteira = registro.Substring(57, 1); //15
            string _outNumeroDocumento = registro.Substring(58, 15); //16
            string _outVencimento = registro.Substring(73, 8); //17
            string _outValor = registro.Substring(81, 15); //18
            string _outUf = registro.Substring(96, 2); //19
            string _outBanco = registro.Substring(98, 1); //20
            string _outCodCedente = registro.Substring(99, 5); //21
            string _outDvCedente = registro.Substring(104, 1); //22
            string _outNomeCedente = registro.Substring(105, 25); //23
            string _outCodMoeda = registro.Substring(130, 2); //24
            string _sacadoInscricaoTipo = registro.Substring(132, 1); //25
            string _sacadoInscricaoNumero = registro.Substring(133, 15); //26
            string _sacadoNome = registro.Substring(148, 40); //27
            string _cnab28 = registro.Substring(188, 10); //28
            string _valorTarifasCustas = registro.Substring(198, 13); //29
            string _motivoCobraca = registro.Substring(213, 10); //30
            string _cnab31 = registro.Substring(223, 17); //31

            try
            {
                /* 05 */
                if (!registro.Substring(13, 1).Equals(@"T"))
                {
                    throw new Exception("Registro inválida. O detalhe não possuí as características do segmento T.");
                }
                DetalheSegmentoTRetornoCNAB240 segmentoT = new DetalheSegmentoTRetornoCNAB240(registro);
                segmentoT.CodigoBanco = Convert.ToInt32(registro.Substring(0, 3)); //01
                segmentoT.idCodigoMovimento = Convert.ToInt32(registro.Substring(15, 2)); //07
                segmentoT.Agencia = Convert.ToInt32(registro.Substring(17, 5)); //08
                segmentoT.DigitoAgencia = registro.Substring(22, 1); //09
                segmentoT.Conta = Convert.ToInt64(registro.Substring(23, 12)); //10
                segmentoT.DigitoConta = registro.Substring(35, 1); //11
                segmentoT.DACAgenciaConta = Convert.ToInt32(registro.Substring(36, 1)); //12
                segmentoT.NossoNumero = registro.Substring(46, 11); //14
                segmentoT.CodigoCarteira = Convert.ToInt32(registro.Substring(57, 1)); //15
                segmentoT.NumeroDocumento = registro.Substring(58, 15); //16
                segmentoT.DataVencimento = DateTime.ParseExact(registro.Substring(73, 8), "ddMMyyyy", CultureInfo.InvariantCulture); //17
                segmentoT.ValorTitulo = Convert.ToDecimal(registro.Substring(81, 15)) / 100; //18
                segmentoT.IdentificacaoTituloEmpresa = registro.Substring(105, 25); //23
                segmentoT.TipoInscricao = Convert.ToInt32(registro.Substring(132, 1)); //25
                segmentoT.NumeroInscricao = registro.Substring(133, 15); //26
                segmentoT.NomeSacado = registro.Substring(148, 40); //27
                segmentoT.ValorTarifas = Convert.ToDecimal(registro.Substring(198, 13)) / 100; //29
                segmentoT.CodigoRejeicao = Convert.ToInt32(registro.Substring(213, 10)); //30

                return segmentoT;
            }
            catch (Exception ex)
            {
                //TrataErros.Tratar(ex);
                throw new Exception("Erro ao processar arquivo de RETORNO - SEGMENTO T.", ex);
            }
        }

        public override DetalheSegmentoURetornoCNAB240 LerDetalheSegmentoURetornoCNAB240(string registro)
        {
            string _Controle_numBanco = registro.Substring(0, 3); //01
            string _Controle_lote = registro.Substring(3, 7); //02
            string _Controle_regis = registro.Substring(7, 1); //03
            string _Servico_numRegis = registro.Substring(8, 5); //04
            string _Servico_segmento = registro.Substring(13, 1); //05
            string _cnab06 = registro.Substring(14, 1); //06
            string _Servico_codMov = registro.Substring(15, 2); //07
            string _dadosTituloAcrescimo = registro.Substring(17, 15); //08
            string _dadosTituloValorDesconto = registro.Substring(32, 15); //09
            string _dadosTituloValorAbatimento = registro.Substring(47, 15); //10
            string _dadosTituloValorIof = registro.Substring(62, 15); //11
            string _dadosTituloValorPago = registro.Substring(76, 15); //12
            string _dadosTituloValorCreditoBruto = registro.Substring(92, 15); //13
            string _outDespesas = registro.Substring(107, 15); //14
            string _outPerCredEntRecb = registro.Substring(122, 5); //15
            string _outBanco = registro.Substring(127, 10); //16
            string _outDataOcorrencia = registro.Substring(137, 8); //17
            string _outDataCredito = registro.Substring(145, 8); //18
            string _cnab19 = registro.Substring(153, 87); //19


            try
            {

                if (!registro.Substring(13, 1).Equals(@"U"))
                {
                    throw new Exception("Registro inválida. O detalhe não possuí as características do segmento U.");
                }

                DetalheSegmentoURetornoCNAB240 segmentoU = new DetalheSegmentoURetornoCNAB240(registro);
                segmentoU.JurosMultaEncargos = Convert.ToDecimal(registro.Substring(17, 15)) / 100;
                segmentoU.ValorDescontoConcedido = Convert.ToDecimal(registro.Substring(32, 15)) / 100;
                segmentoU.ValorAbatimentoConcedido = Convert.ToDecimal(registro.Substring(47, 15)) / 100;
                segmentoU.ValorIOFRecolhido = Convert.ToDecimal(registro.Substring(62, 15)) / 100;
                segmentoU.ValorOcorrenciaSacado = segmentoU.ValorPagoPeloSacado = Convert.ToDecimal(registro.Substring(77, 15)) / 100;
                segmentoU.ValorLiquidoASerCreditado = Convert.ToDecimal(registro.Substring(92, 15)) / 100;
                segmentoU.ValorOutrasDespesas = Convert.ToDecimal(registro.Substring(107, 15)) / 100;
                segmentoU.ValorOutrosCreditos = Convert.ToDecimal(registro.Substring(122, 15)) / 100;
                segmentoU.DataOcorrencia = segmentoU.DataOcorrencia = DateTime.ParseExact(registro.Substring(137, 8), "ddMMyyyy", CultureInfo.InvariantCulture);
                segmentoU.DataCredito = DateTime.ParseExact(registro.Substring(145, 8), "ddMMyyyy", CultureInfo.InvariantCulture);
                segmentoU.CodigoOcorrenciaSacado = registro.Substring(153, 4);

                return segmentoU;
            }
            catch (Exception ex)
            {
                //TrataErros.Tratar(ex);
                throw new Exception("Erro ao processar arquivo de RETORNO - SEGMENTO U.", ex);
            }
        }
        #endregion Métodos de Leitura do Arquivo de Retorno
    }
}

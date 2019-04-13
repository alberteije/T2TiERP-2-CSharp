using System;
using System.Web.UI;
using BoletoNet;

[assembly: WebResource("BoletoNet.Imagens.033.jpg", "image/jpg")]

namespace BoletoNet
{
    /// <author>  
    /// Eduardo Frare
    /// Stiven 
    /// Diogo
    /// Miamoto
    /// </author>    


    ///<summary>
    /// Classe referente ao banco Banco_Santander
    ///</summary>
    internal class Banco_Santander : AbstractBanco, IBanco
    {

        /// <summary>
        /// Classe responsavel em criar os campos do Banco Banco_Santander.
        /// </summary>
        internal Banco_Santander()
        {
            this.Codigo = 033;
            this.Digito = 7;
            this.Nome = "Santander";
        }

        internal Banco_Santander(int Codigo)
        {

            this.Codigo = ((Codigo != 353) && (Codigo != 8)) ? 033 : Codigo;
            this.Digito = 0;
            this.Nome = "Banco_Santander";
        }

        #region IBanco Members

        /// <summary>
        /// 
        ///   *******
        /// 
        ///	O código de barra para cobrança contém 44 posições dispostas da seguinte forma:
        ///    01 a 03 -  3 - 033 fixo - Código do banco
        ///    04 a 04 -  1 - 9 fixo - Código da moeda (R$)
        ///    05 a 05 –  1 - Dígito verificador do código de barras
        ///    06 a 09 -  4 - Fator de vencimento
        ///    10 a 19 - 10 - Valor
        ///    20 a 20 –  1 - Fixo 9
        ///    21 a 27 -  7 - Código do cedente padrão satander
        ///    28 a 40 - 13 - Nosso número
        ///    41 - 41 - 1 -  IOS  - Seguradoras(Se 7% informar 7. Limitado  a 9%) Demais clientes usar 0 
        ///    42 - 44 - 3 - Tipo de modalidade da carteira 101, 102, 201
        /// 
        ///   *******
        /// 
        /// </summary>
        public override void FormataCodigoBarra(Boleto boleto)
        {
            string codigoBanco = Utils.FormatCode(this.Codigo.ToString(), 3);//3
            string codigoMoeda = boleto.Moeda.ToString();//1
            string calculoDV = "";//1
            string fatorVencimento = FatorVencimento(boleto).ToString(); //4
            string valorNominal = Utils.FormatCode(boleto.ValorBoleto.ToString("f").Replace(",", "").Replace(".", ""), 10);//10
            string fixo = "9";//1
            string codigoCedente = Utils.FormatCode(boleto.Cedente.Codigo.ToString(), 7).ToString();//7
            string nossoNumero = Utils.FormatCode(boleto.NossoNumero, 12) + Mod11(Utils.FormatCode(boleto.NossoNumero, 12), 9, 0);//13
            string IOS = "0";//1
            string tipoCarteira = boleto.Carteira;//3;
            //boleto.CodigoBarra.Codigo = "00000000000000000000000000000000000000000000";

            boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}",
                codigoBanco, codigoMoeda, fatorVencimento, valorNominal, fixo, codigoCedente, nossoNumero, IOS, tipoCarteira);

            calculoDV = Mod11(boleto.CodigoBarra.Codigo, 9, 0).ToString();

            boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",
                codigoBanco, codigoMoeda, calculoDV, fatorVencimento, valorNominal, fixo, codigoCedente, nossoNumero, IOS, tipoCarteira);


        }

        /// <summary>
        /// 
        ///   *******
        /// 
        ///	A Linha Digitavel para cobrança contém 44 posições dispostas da seguinte forma:
        ///   1º Grupo - 
        ///    01 a 03 -  3 - 033 fixo - Código do banco
        ///    04 a 04 -  1 - 9 fixo - Código da moeda (R$) outra moedas 8
        ///    05 a 05 –  1 - Fixo 9
        ///    06 a 09 -  4 - Código cedente padrão santander
        ///    10 a 10 -  1 - Código DV do primeiro grupo
        ///   2º Grupo -
        ///    11 a 13 –  3 - Restante do código cedente
        ///    14 a 20 -  7 - 7 primeiros campos do nosso número
        ///    21 a 21 - 13 - Código DV do segundo grupo
        ///   3º Grupo -  
        ///    22 - 27 - 6 -  Restante do nosso número
        ///    28 - 28 - 1 - IOS  - Seguradoras(Se 7% informar 7. Limitado  a 9%) Demais clientes usar 0 
        ///    29 - 31 - 3 - Tipo de carteira
        ///    32 - 32 - 1 - Código DV do terceiro grupo
        ///   4º Grupo -
        ///    33 - 33 - 1 - Composto pelo DV do código de barras
        ///   5º Grupo -
        ///    34 - 36 - 4 - Fator de vencimento
        ///    37 - 47 - 10 - Valor do título
        ///   *******
        /// 
        /// </summary>
        public override void FormataLinhaDigitavel(Boleto boleto)
        {
            string nossoNumero = Utils.FormatCode(boleto.NossoNumero, 12) + Mod11(Utils.FormatCode(boleto.NossoNumero, 12), 9, 0);//13
            string codigoCedente = Utils.FormatCode(boleto.Cedente.Codigo.ToString(), 7).ToString();

            #region Grupo1

            string codigoBanco = Utils.FormatCode(this.Codigo.ToString(), 3);//3
            string codigoModeda = boleto.Moeda.ToString();//1
            string fixo = "9";//1
            string codigoCedente1 = codigoCedente.Substring(0, 4);//4
            string calculoDV1 = Mod10(string.Format("{0}{1}{2}{3}", codigoBanco, codigoModeda, fixo, codigoCedente1)).ToString();//1
            string grupo1 = string.Format("{0}{1}{2}.{3}{4}", codigoBanco, codigoModeda, fixo, codigoCedente1, calculoDV1);

            #endregion

            #region Grupo2

            string codigoCedente2 = codigoCedente.Substring(4, 3);//3
            string nossoNumero1 = nossoNumero.Substring(0, 7);//7
            string calculoDV2 = Mod10(string.Format("{0}{1}", codigoCedente2, nossoNumero1)).ToString();
            string grupo2 = string.Format("{0}{1}{2}", codigoCedente2, nossoNumero1, calculoDV2);
            grupo2 = " " + grupo2.Substring(0, 5) + "." + grupo2.Substring(5, 6);

            #endregion

            #region Grupo3

            string nossoNumero2 = nossoNumero.Substring(7, 6); //6
            string IOS = "0";//1
            string tipoCarteira = boleto.Carteira;//3
            string calculoDV3 = Mod10(string.Format("{0}{1}{2}", nossoNumero2, IOS, tipoCarteira)).ToString();//1
            string grupo3 = string.Format("{0}{1}{2}{3}", nossoNumero2, IOS, tipoCarteira, calculoDV3);
            grupo3 = " " + grupo3.Substring(0, 5) + "." + grupo3.Substring(5, 6) + " ";

            #endregion

            #region Grupo4
            string DVcodigoBanco = Utils.FormatCode(this.Codigo.ToString(), 3);//3
            string DVcodigoMoeda = boleto.Moeda.ToString();//1
            string DVfatorVencimento = FatorVencimento(boleto).ToString();//4
            string DVvalorNominal = Utils.FormatCode(boleto.ValorBoleto.ToString("f").Replace(",", "").Replace(".", ""), 10);//10
            string DVfixo = "9";//1
            string DVcodigoCedente = Utils.FormatCode(boleto.Cedente.Codigo.ToString(), 7).ToString();//7
            string DVnossoNumero = Utils.FormatCode(boleto.NossoNumero, 12) + Mod11(Utils.FormatCode(boleto.NossoNumero, 12), 9, 0);
            string DVIOS = "0";//1
            string DVtipoCarteira = boleto.Carteira;//3;

            string calculoDVcodigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}",
                DVcodigoBanco, DVcodigoMoeda, DVfatorVencimento, DVvalorNominal, DVfixo, DVcodigoCedente, DVnossoNumero, DVIOS, DVtipoCarteira);

            string grupo4 = Mod11(calculoDVcodigo, 9, 0).ToString() + " ";

            #endregion

            #region Grupo5

            string fatorVencimento = FatorVencimento(boleto).ToString(); //4
            string valorNominal = Utils.FormatCode(boleto.ValorBoleto.ToString("f").Replace(",", "").Replace(".", ""), 10);//10

            string grupo5 = string.Format("{0}{1}", fatorVencimento, valorNominal);
            //grupo5 = grupo5.Substring(0, 4) + " " + grupo5.Substring(4, 1)+" "+grupo5.Substring(5,9);



            #endregion

            boleto.CodigoBarra.LinhaDigitavel = string.Format("{0}{1}{2}{3}{4}", grupo1, grupo2, grupo3, grupo4, grupo5);


            //Usado somente no Santander
            boleto.Cedente.ContaBancaria.Conta = boleto.Cedente.Codigo.ToString();

        }

        public override void FormataNossoNumero(Boleto boleto)
        {
            boleto.NossoNumero = string.Format("{0}-{1}", boleto.NossoNumero, Mod11(boleto.NossoNumero, 9, 0));
        }

        public override void FormataNumeroDocumento(Boleto boleto)
        {
            throw new NotImplementedException("Função não implementada.");
        }

        public override void ValidaBoleto(Boleto boleto)
        {
            //throw new NotImplementedException("Função não implementada.");
            if (!((boleto.Carteira == "102") || (boleto.Carteira == "101") || (boleto.Carteira == "201")))
                throw new NotImplementedException("Carteira Não implementada.");

            //Banco 353  - Utilizar somente 08 posições do Nosso Numero (07 posições + DV), zerando os 05 primeiros dígitos
            if (this.Codigo == 353)
            {
                if (boleto.NossoNumero.Length != 7)
                    throw new NotImplementedException("Nosso Número deve ter 7 posições para o banco 353.");
            }

            //Banco 008  - Utilizar somente 09 posições do Nosso Numero (08 posições + DV), zerando os 04 primeiros dígitos
            if (this.Codigo == 8)
            {
                if (boleto.NossoNumero.Length != 8)
                    throw new NotImplementedException("Nosso Número deve ter 7 posições para o banco 008.");
            }

            if (this.Codigo == 33)
            {
                if (boleto.NossoNumero.Length != 12)
                    throw new NotImplementedException("Nosso Número deve ter 12 posições para o banco 033.");
            }
            if (boleto.Cedente.Codigo.ToString().Length > 7)
                throw new NotImplementedException("Código cedente deve ter 7 posições.");

            boleto.LocalPagamento += "Grupo Santander - GC";

            if(EspecieDocumento.ValidaSigla(boleto.EspecieDocumento) == "")
               boleto.EspecieDocumento = new EspecieDocumento_Santander(2);

            boleto.FormataCampos();
        }

        #region Métodos de geração do arquivo remessa
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
        ///001 - 003	Código do Banco na compensação	    N	003		353 / 008 / 033	
        ///004 - 007	Lote de serviço	                    N	004		0000	1 
        ///008 - 008	Tipo de registro	                N	001		0	2
        ///009 - 016	Reservado (uso Banco)	            A	008		Brancos	  
        ///017 - 017	Tipo de inscrição da empresa	    N	001		1 = CPF,  2 = CNPJ 	
        ///018 – 032	Nº de inscrição da empresa	        N	015			
        ///033 – 047	Código de Transmissão   	        N	015			3 
        ///048 - 072	Reservado (uso Banco)	            A	025		Brancos	
        ///073 - 102	Nome da empresa	                    A	030			
        ///103 - 132	Nome do Banco	                    A	030		Banco Santander 	
        ///133 - 142	Reservado (uso Banco)	            A	010		Brancos	
        ///143 - 143	Código remessa 	                    N	001		1 = Remessa 	
        ///144 - 151	Data de geração do arquivo	        N	008		DDMMAAAA	
        ///152 - 157	Reservado (uso Banco)  	            A	006		Brancos	
        ///158 - 163	Nº seqüencial do arquivo 	        N	006			4
        ///164 - 166	Nº da versão do layout do arquivo	N	003		040	
        ///167 - 240	Reservado (uso Banco)	            A	074		Brancos	
        /// </summary>
        public string GerarHeaderRemessaCNAB240(Cedente cedente)
        {
            try
            {
                string header = Utils.FormatCode(Codigo.ToString(), "0", 3, true);
                header += "0000";
                header += "0";
                header += Utils.FormatCode("", " ", 8);
                header += (cedente.CPFCNPJ.Length == 11 ? "1" : "2");
                header += Utils.FormatCode("", "0", 15);
                header += Utils.FormatCode("", "0", 15);
                header += Utils.FormatCode("", " ", 25);
                header += Utils.FormatCode(cedente.Nome, " ", 30);
                header += Utils.FormatCode("BANCO SANTANDER", " ", 30);
                header += Utils.FormatCode("", " ", 10);
                header += "1";
                header += DateTime.Now.ToString("ddMMyyyy");
                header += Utils.FormatCode("", " ", 6);
                header += "0001";
                header += "040";
                header += Utils.FormatCode("", " ", 74);
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
            throw new Exception("Funçã não implementada.");
        }

        private string GerarHeaderLoteRemessaCNAB240(Cedente cedente, int numeroArquivoRemessa)
        {
            try
            {
                string header = Utils.FormatCode(Codigo.ToString(), "0", 3, true);
                header += "0000";
                header += "0";
                header += "R";
                header += "  ";
                header += "030";
                header += " ";
                header += "0";
                header += (cedente.CPFCNPJ.Length == 11 ? "1" : "2");
                header += Utils.FormatCode("", "0", 15);
                header += Utils.FormatCode("", " ", 20);
                header += Utils.FormatCode("", "0", 15);
                header += Utils.FormatCode("", " ", 5);
                header += Utils.FormatCode(cedente.Nome, " ", 30);
                header += Utils.FormatCode("", " ", 40);
                header += Utils.FormatCode("", " ", 40);
                header += Utils.FormatCode(numeroArquivoRemessa.ToString(), "0", 8);
                header += DateTime.Now.ToString("ddMMyyyy");
                header += Utils.FormatCode("", " ", 41);
                return header;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar HEADER DO LOTE do arquivo de remessa.", e);
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
                _header += "033";
                _header += "BANCO SANTANDER  ";
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

        #endregion Métodos de geração do arquivo remessa

        #endregion
    }
}

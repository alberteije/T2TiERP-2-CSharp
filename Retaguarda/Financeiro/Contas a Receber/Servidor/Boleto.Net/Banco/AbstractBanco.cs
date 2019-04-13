using System;
using System.Threading;

namespace BoletoNet
{
    public abstract class AbstractBanco
    {

        #region Variaveis

        private int _codigo = 0;
        private int _digito = 0;
        private string _nome = string.Empty;
        private Cedente _cedente = null;

        #endregion Variaveis

        #region Propriedades

        /// <summary>
        /// Código do Banco
        /// 237 - Bradesco; 341 - Itaú
        /// </summary>
        public virtual int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        /// <summary>
        /// Dígito do Banco
        /// </summary>
        public virtual int Digito
        {
            get { return _digito; }
            protected set { _digito = value; }
        }

        /// <summary>
        /// Nome da Instituição Financeira
        /// </summary>
        public virtual string Nome
        {
            get { return _nome; }
            protected set { _nome = value; }
        }

        /// <summary>
        /// Cedente
        /// </summary>
        public virtual Cedente Cedente
        {
            get { return _cedente; }
            protected set { _cedente = value; }
        }

        #endregion Propriedades

        # region Métodos

        /// <summary>
        /// Retorna o campo que compos o código de barras que para todos os bancos são iguais foramado por:
        /// </summary>
        /// <returns></returns>
        public virtual string CampoFixo()
        {
            throw new NotImplementedException("Função não implementada");
        }
        /// <summary>
        /// Gera os registros de header do aquivo de remessa
        /// </summary>
        public virtual string GerarHeaderRemessa(string numeroConvenio, Cedente cedente, TipoArquivo tipoArquivo)
        {
            string _header = "";
            return _header;
        }
        /// <summary>
        /// Gera registros de detalhe do arquivo remessa
        /// </summary>
        public virtual string GerarDetalheRemessa(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            string _remessa = "";
            return _remessa;
        }
        /// <summary>
        /// Gera os registros de Trailer do arquivo de remessa
        /// </summary>
        public virtual string GerarTrailerRemessa(int numeroRegistro, TipoArquivo tipoArquivo)
        {
            string _trailer = "";
            return _trailer;
        }
        /// <summary>
        /// Gera os registros de header de aquivo do arquivo de remessa
        /// </summary>
        public virtual string GerarHeaderRemessa(Cedente cedente, TipoArquivo tipoArquivo)
        {
            string _headerArquivo = "";
            return _headerArquivo;
        }
        /// <summary>
        /// Gera os registros de header de lote do arquivo de remessa
        /// </summary>
        public virtual string GerarHeaderLoteRemessa(string numeroConvenio, Cedente cedente, int numeroArquivoRemessa)
        {
            string _headerLote = "";
            return _headerLote;
        }
        /// <summary>
        /// Gera os registros de header de lote do arquivo de remessa
        /// </summary>
        public virtual string GerarHeaderLoteRemessa(string numeroConvenio, Cedente cedente, int numeroArquivoRemessa, TipoArquivo tipoArquivo)
        {
            string _headerLote = "";
            return _headerLote;
        }
        /// <summary>
        /// Gera registros de detalhe do arquivo remessa - SEGMENTO P
        /// </summary>
        public virtual string GerarDetalheSegmentoPRemessa(Boleto boleto, int numeroRegistro, string numeroConvenio, Cedente cedente)
        {
            string _segmentoP = "";
            return _segmentoP;
        }
        /// <summary>
        /// Gera registros de detalhe do arquivo remessa - SEGMENTO P
        /// </summary>
        public virtual string GerarDetalheSegmentoPRemessa(Boleto boleto, int numeroRegistro, string numeroConvenio)
        {
            string _segmentoP = "";
            return _segmentoP;
        }
        /// <summary>
        /// Gera registros de detalhe do arquivo remessa - SEGMENTO Q
        /// </summary>
        public virtual string GerarDetalheSegmentoQRemessa(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo, Cedente cedente)
        {
            string _segmentoQ = "";
            return _segmentoQ;
        }
        /// <summary>
        /// Gera registros de detalhe do arquivo remessa - SEGMENTO Q
        /// </summary>
        public virtual string GerarDetalheSegmentoQRemessa(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            string _segmentoQ = "";
            return _segmentoQ;
        }
        /// <summary>
        /// Gera registros de detalhe do arquivo remessa - SEGMENTO R
        /// </summary>
        public virtual string GerarDetalheSegmentoRRemessa(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            string _segmentoR = "";
            return _segmentoR;
        }
        /// <summary>
        /// Gera os registros de Trailer de arquivo do arquivo de remessa
        /// </summary>
        public virtual string GerarTrailerArquivoRemessa(int numeroRegistro)
        {
            string _trailerArquivo = "";
            return _trailerArquivo;
        }
        /// <summary>
        /// Gera os registros de Trailer de lote do arquivo de remessa
        /// </summary>
        public virtual string GerarTrailerLoteRemessa(int numeroRegistro)
        {
            string _trailerLote = "";
            return _trailerLote;
        }
        /// <summary>
        /// Formata código de barras
        /// </summary>      
        public virtual void FormataCodigoBarra(Boleto boleto)
        {
            throw new NotImplementedException("Função não implementada na classe filha. Implemente na classe que está sendo criada.");
        }
        /// <summary>
        /// Formata linha digitável
        /// </summary>
        public virtual void FormataLinhaDigitavel(Boleto boleto)
        {
            throw new NotImplementedException("Função não implementada na classe filha. Implemente na classe que está sendo criada.");
        }
        /// <summary>
        /// Formata nosso número
        /// </summary>
        public virtual void FormataNossoNumero(Boleto boleto)
        {
            throw new NotImplementedException("Função não implementada na classe filha. Implemente na classe que está sendo criada.");
        }
        /// <summary>
        /// Formata número do documento
        /// </summary>
        public virtual void FormataNumeroDocumento(Boleto boleto)
        {
            throw new NotImplementedException("Função não implementada na classe filha. Implemente na classe que está sendo criada.");
        }
        /// <summary>
        /// Valida o boleto
        /// </summary>
        public virtual void ValidaBoleto(Boleto boleto)
        {
            throw new NotImplementedException("Função não implementada na classe filha. Implemente na classe que está sendo criada.");
        }

        public virtual DetalheSegmentoWRetornoCNAB240 LerDetalheSegmentoWRetornoCNAB240(string registro)
        {
            var detalhe = new DetalheSegmentoWRetornoCNAB240();

            detalhe.LerDetalheSegmentoWRetornoCNAB240(registro);

            return detalhe;
        }

        public virtual DetalheSegmentoTRetornoCNAB240 LerDetalheSegmentoTRetornoCNAB240(string registro)
        {
            var detalhe = new DetalheSegmentoTRetornoCNAB240(registro);

            detalhe.LerDetalheSegmentoTRetornoCNAB240(registro);

            return detalhe;
        }

        public virtual DetalheSegmentoURetornoCNAB240 LerDetalheSegmentoURetornoCNAB240(string registro)
        {
            var detalhe = new DetalheSegmentoURetornoCNAB240(registro);

            detalhe.LerDetalheSegmentoURetornoCNAB240(registro);

            return detalhe;
        }

        public virtual DetalheRetorno LerDetalheRetornoCNAB400(string registro)
        {
            try
            {
                int dataOcorrencia = Utils.ToInt32(registro.Substring(110, 6));
                int dataVencimento = Utils.ToInt32(registro.Substring(146, 6));
                int dataCredito = Utils.ToInt32(registro.Substring(295, 6));

                DetalheRetorno detalhe = new DetalheRetorno(registro);

                detalhe.CodigoInscricao = Utils.ToInt32(registro.Substring(1, 2));
                detalhe.NumeroInscricao = registro.Substring(3, 14);
                detalhe.Agencia = Utils.ToInt32(registro.Substring(17, 4));
                detalhe.Conta = Utils.ToInt32(registro.Substring(23, 5));
                detalhe.DACConta = Utils.ToInt32(registro.Substring(28, 1));
                detalhe.UsoEmpresa = registro.Substring(37, 25);
                detalhe.NossoNumero = registro.Substring(85, 8);
                detalhe.DACNossoNumero = Utils.ToInt32(registro.Substring(93, 1));
                detalhe.Carteira = registro.Substring(107, 1);
                detalhe.CodigoOcorrencia = Utils.ToInt32(registro.Substring(108, 2));
                detalhe.DataOcorrencia = Utils.ToDateTime(dataOcorrencia.ToString("##-##-##"));
                detalhe.NumeroDocumento = registro.Substring(116, 10);
                detalhe.NossoNumero = registro.Substring(126, 9);
                detalhe.DataVencimento = Utils.ToDateTime(dataVencimento.ToString("##-##-##"));
                double valorTitulo = Convert.ToInt64(registro.Substring(152, 13));
                detalhe.ValorTitulo = valorTitulo / 100;
                detalhe.CodigoBanco = Utils.ToInt32(registro.Substring(165, 3));
                detalhe.AgenciaCobradora = Utils.ToInt32(registro.Substring(168, 4));
                detalhe.Especie = Utils.ToInt32(registro.Substring(173, 2));
                double tarifaCobranca = Convert.ToUInt64(registro.Substring(174, 13));
                detalhe.TarifaCobranca = tarifaCobranca / 100;
                // 26 brancos
                double iof = Convert.ToUInt64(registro.Substring(214, 13));
                detalhe.IOF = iof / 100;
                double valorAbatimento = Convert.ToUInt64(registro.Substring(227, 13));
                detalhe.ValorAbatimento = valorAbatimento / 100;
                double valorPrincipal = Convert.ToUInt64(registro.Substring(253, 13));
                detalhe.ValorPrincipal = valorPrincipal / 100;
                double jurosMora = Convert.ToUInt64(registro.Substring(266, 13));
                detalhe.JurosMora = jurosMora / 100;
                detalhe.DataOcorrencia = Utils.ToDateTime(dataOcorrencia.ToString("##-##-##"));
                // 293 - 3 brancos
                detalhe.DataCredito = Utils.ToDateTime(dataCredito.ToString("##-##-##"));
                detalhe.InstrucaoCancelada = Utils.ToInt32(registro.Substring(301, 4));
                // 306 - 6 brancos
                // 311 - 13 zeros
                detalhe.NomeSacado = registro.Substring(324, 30);
                // 354 - 23 brancos
                detalhe.Erros = registro.Substring(377, 8);
                // 377 - Registros rejeitados ou alegação do sacado
                // 386 - 7 brancos

                detalhe.CodigoLiquidacao = registro.Substring(392, 2);
                detalhe.NumeroSequencial = Utils.ToInt32(registro.Substring(394, 6));

                return detalhe;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ler detalhe do arquivo de RETORNO / CNAB 400.", ex);
            }
        }
        # endregion

        /// <summary>
        /// Fator de vencimento do boleto
        /// </summary>
        /// <param name="boleto"></param>
        /// <returns></returns>
        protected static long FatorVencimento(Boleto boleto)
        {
            DateTime dateBase = new DateTime(2000, 7, 3, 0, 0, 0);
            return Utils.DateDiff(DateInterval.Day, dateBase, boleto.DataVencimento) + 1000;
        }

        //internal static string CalcFatorVencimento(DateTime dtv)
        //{
        //    DateTime dateBase = new DateTime(2000, 7, 3, 0, 0, 0);
        //    return Convert.ToString(Utils.DateDiff(DateInterval.Day, dateBase, dtv) + 1000);
        //}

        #region Mod
        internal static int Mod10(string seq)
        {
            /* Variáveis
             * -------------
             * d - Dígito
             * s - Soma
             * p - Peso
             * b - Base
             * r - Resto
             */

            int d, s = 0, p = 2, r;

            for (int i = seq.Length; i > 0; i--)
            {
                r = (Convert.ToInt32(Microsoft.VisualBasic.Strings.Mid(seq, i, 1)) * p);

                if (r > 9)
                    r = (r / 10) + (r % 10);

                s += r;

                if (p == 2)
                    p = 1;
                else
                    p = p + 1;
            }
            d = ((10 - (s % 10)) % 10);
            return d;
        }

        protected static int Mod11(string seq)
        {
            /* Variáveis
             * -------------
             * d - Dígito
             * s - Soma
             * p - Peso
             * b - Base
             * r - Resto
             */

            int d, s = 0, p = 2, b = 9;

            for (int i = 0; i < seq.Length; i++)
            {
                s = s + (Convert.ToInt32(seq[i]) * p);
                if (p < b)
                    p = p + 1;
                else
                    p = 2;
            }

            d = 11 - (s % 11);
            if (d > 9)
                d = 0;
            return d;
        }

        protected static int Mod11(string seq, int b)
        {
            /* Variáveis
             * -------------
             * d - Dígito
             * s - Soma
             * p - Peso
             * b - Base
             * r - Resto
             */

            int d, s = 0, p = 2;


            for (int i = seq.Length; i > 0; i--)
            {
                s = s + (Convert.ToInt32(Microsoft.VisualBasic.Strings.Mid(seq, i, 1)) * p);
                if (p == b)
                    p = 2;
                else
                    p = p + 1;
            }

            d = 11 - (s % 11);


            if ((d > 9) || (d == 0) || (d == 1))
                d = 1;

            return d;
        }

        protected static int Mod11Base9(string seq)
        {
            /* Variáveis
             * -------------
             * d - Dígito
             * s - Soma
             * p - Peso
             * b - Base
             * r - Resto
             */

            int d, s = 0, p = 2, b = 9;


            for (int i = seq.Length - 1; i >= 0; i--)
            {
                string aux = Convert.ToString(seq[i]);
                s += (Convert.ToInt32(aux) * p);
                if (p >= b)
                    p = 2;
                else
                    p = p + 1;
            }

            if (s < 11)
            {
                d = 11 - s;
                return d;
            }
            else
            {
                d = 11 - (s % 11);
                if ((d > 9) || (d == 0))
                    d = 0;

                return d;
            }
        }

        protected static int Mod11(string seq, int lim, int flag)
        {
            int mult = 0;
            int total = 0;
            int pos = 1;
            //int res = 0;
            int ndig = 0;
            int nresto = 0;
            string num = string.Empty;

            mult = 1 + (seq.Length % (lim - 1));

            if (mult == 1)
                mult = lim;


            while (pos <= seq.Length)
            {
                num = Microsoft.VisualBasic.Strings.Mid(seq, pos, 1);
                total += Convert.ToInt32(num) * mult;

                mult -= 1;
                if (mult == 1)
                    mult = lim;

                pos += 1;
            }
            nresto = (total % 11);
            if (flag == 1)
                return nresto;
            else
            {
                if (nresto == 0 || nresto == 1 || nresto == 10)
                    ndig = 1;
                else
                    ndig = (11 - nresto);

                return ndig;
            }
        }
        #endregion Mod
    }
}

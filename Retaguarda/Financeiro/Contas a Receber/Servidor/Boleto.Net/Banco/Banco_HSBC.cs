using System;
using System.Web.UI;
using Microsoft.VisualBasic;

[assembly: WebResource("BoletoNet.Imagens.399.jpg", "image/jpg")]
namespace BoletoNet
{
    internal class Banco_HSBC : AbstractBanco, IBanco
    {
        #region Variáveis
        private string dacBoleto;
        #endregion

        #region Construtores

        internal Banco_HSBC()
        {
            try
            {
                this.Codigo = 399;
                this.Digito = 9;
                this.Nome = "HSBC";
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
            FormataNossoNumero(boleto);
            FormataCodigoBarra(boleto);
            FormataLinhaDigitavel(boleto);
        }

        # endregion

        # region Métodos de formatação do boleto
        /// <summary>
        /// Formata o código de barras
        /// </summary>
        /// <example>
        /// DE ATÉ TAMANHO CONTEÚDO
        /// -----------------------
        /// 01 03 03 Código do HSBC na Câmara de Compensação, igual a 399.
        /// 04 04 01 Tipo de Moeda (9 para moeda Real ou 0 para Moeda Variável).
        /// 05 05 01 Dígito de Autoconferência (DAC).
        /// 06 09 04 Fator de Vencimento.
        /// 10 19 10 Valor do Documento. Se Moeda Variável, o valor deverá ser igual a zeros.
        /// 20 26 07 Código do Cedente
        /// 27 39 13 Número Bancário, igual ao Código do Documento, sem os dígitos verificadores e tipo identificador.
        /// 40 43 04 Data de Vencimento no Formato Juliano.
        /// 44 44 01 Código do Produto CNR, igual a 2.
        /// </example>
        public override void FormataCodigoBarra(Boleto boleto)
        {
            boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}"
                , Codigo.ToString()
                , boleto.Moeda
                , FatorVencimento(boleto)
                , boleto.ValorBoleto.ToString("f").Replace(",", "").Replace(".", "").PadLeft(10, '0')
                , boleto.Cedente.Codigo.ToString()
                , boleto.NossoNumero.Substring(0, 13)
                , boleto.DataVencimento.DayOfYear.ToString("000") + boleto.DataVencimento.ToString("yy").Substring(1, 1)
                , "2");

            dacBoleto = DVDAC(boleto.CodigoBarra.Codigo);

            boleto.CodigoBarra.Codigo = Strings.Left(boleto.CodigoBarra.Codigo, 4) + dacBoleto + Strings.Right(boleto.CodigoBarra.Codigo, 39);
        }

        /// <summary>
        /// Formata a linha digitavel
        /// </summary>
        public override void FormataLinhaDigitavel(Boleto boleto)
        {
            //AAABC.CCCCd CCDDD.DDDDDd DDDDD.EEEE2d d FFFFVVVVVVVVVV

            string parte1, parte2;
            string Grupo1, Grupo2, Grupo3, Grupo4, Grupo5;

            #region Campo 1

            string cd = boleto.Cedente.Codigo.ToString().Length < 7 ? "0000000" : boleto.Cedente.Codigo.ToString();

            parte1 = "399" + boleto.Moeda.ToString() + boleto.Cedente.Codigo.ToString().Substring(0, 1);
            parte2 = cd.Substring(1, 4);
            Grupo1 = string.Format("{0}.{1}{2} ", parte1, parte2, DVLinhaDigitavel(parte1 + parte2));

            #endregion

            #region Campo 2

            parte1 = cd.ToString().Substring(5, 2) + boleto.NossoNumero.Substring(0, 3);
            parte2 = boleto.NossoNumero.Substring(3, 5);
            Grupo2 = string.Format("{0}.{1}{2} ", parte1, parte2, DVLinhaDigitavel(parte1 + parte2));

            #endregion

            #region Campo 3

            parte1 = boleto.NossoNumero.Substring(8, 5);
            parte2 = boleto.DataVencimento.DayOfYear.ToString("000") + boleto.DataVencimento.ToString("yy").Substring(1, 1) + "2";
            Grupo3 = string.Format("{0}.{1}{2} ", parte1, parte2, DVLinhaDigitavel(parte1 + parte2));

            #endregion

            #region Campo 4

            Grupo4 = string.Format("{0} ", dacBoleto);

            #endregion Campo 4

            #region Campo 5

            parte1 = FatorVencimento(boleto) + boleto.ValorBoleto.ToString("f").Replace(",", "").Replace(".", "").PadLeft(10, '0');
            Grupo5 = string.Format("{0}", parte1);

            #endregion

            boleto.CodigoBarra.LinhaDigitavel = Grupo1 + Grupo2 + Grupo3 + Grupo4 + Grupo5;
        }

        /// <summary>
        /// Realiza formatação do NossoNumero de acordo com as regras do HSBC
        /// </summary>
        public override void FormataNossoNumero(Boleto boleto)
        {
            string dv1, dv2;
            long soma;
            boleto.NossoNumero = boleto.NossoNumero.PadLeft(13, '0');

            dv1 = DVNossoNumero(boleto.NossoNumero);

            soma = Convert.ToInt64(boleto.NossoNumero + dv1 + "4") + boleto.Cedente.Codigo + int.Parse(boleto.DataVencimento.ToString("ddMMyy"));

            dv2 = DVNossoNumero(soma.ToString());

            boleto.NossoNumero += dv1 + "4" + dv2;
        }

        public override void FormataNumeroDocumento(Boleto boleto)
        {

        }

        # endregion

        # region Métodos de geração do arquivo remessa CNAB400

        # region HEADER

        /// <summary>
        /// HEADER do arquivo CNAB
        /// Gera o HEADER do arquivo remessa de acordo com o lay-out informado
        /// </summary>
        public override string GerarHeaderRemessa(string numeroConvenio, Cedente cedente, TipoArquivo tipoArquivo)
        {
            throw new NotImplementedException("Função não implementada.");
        }

        public string GerarHeaderRemessaCNAB240()
        {
            throw new NotImplementedException("Função não implementada.");
        }

        public string GerarHeaderRemessaCNAB400(int numeroConvenio, Cedente cedente)
        {
            throw new NotImplementedException("Função não implementada.");
        }

        # endregion

        # region DETALHE

        /// <summary>
        /// DETALHE do arquivo CNAB
        /// Gera o DETALHE do arquivo remessa de acordo com o lay-out informado
        /// </summary>
        public override string GerarDetalheRemessa(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            throw new NotImplementedException("Função não implementada.");
        }

        public string GerarDetalheRemessaCNAB240()
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
        public override string GerarTrailerRemessa(int numeroRegistro, TipoArquivo tipoArquivo)
        {
            throw new NotImplementedException("Função não implementada.");
        }

        public string GerarTrailerRemessa240()
        {
            throw new NotImplementedException("Função não implementada.");
        }

        public string GerarTrailerRemessa400(int numeroRegistro)
        {
            throw new NotImplementedException("Função não implementada.");
        }

        # endregion

        #endregion

        #region Métodos de processamento do arquivo retorno CNAB400


        #endregion

        #region Métodos privados
        /// <summary>
        /// DV DAC Mod11
        /// </summary>
        /// <param name="cVariavel"></param>
        /// <returns></returns>
        private string DVDAC(string cVariavel)
        {
            string lRetorno = "0";
            int nSoma = 0, nMult = 2, nIndice;

            for (nIndice = cVariavel.Length - 1; nIndice >= 0; nIndice--)
            {
                nSoma += (Convert.ToByte(cVariavel[nIndice]) - 48) * nMult;
                if (nMult == 9) nMult = 2;
                else nMult++;
            }

            nSoma = nSoma % 11;
            if (nSoma < 2 || nSoma > 9) lRetorno = "1";
            else lRetorno = (11 - nSoma).ToString();

            return lRetorno;
        }

        /// <summary>
        /// DV NossoNumero Mod11
        /// </summary>
        /// <param name="cVariavel"></param>
        /// <returns></returns>
        private string DVNossoNumero(string cVariavel)
        {
            string lRetorno = "0";
            int nSoma = 0, nMult = 9, nIndice;

            for (nIndice = cVariavel.Length - 1; nIndice >= 0; nIndice--)
            {
                nSoma += (Convert.ToByte(cVariavel[nIndice]) - 48) * nMult;
                if (nMult == 2) nMult = 9;
                else nMult--;
            }

            nSoma = nSoma % 11;
            if (nSoma > 9) lRetorno = "0";
            else lRetorno = nSoma.ToString();

            return lRetorno;
        }

        /// <summary>
        /// DV Linha Digitavel Mod10
        /// </summary>
        /// <param name="seq"></param>
        /// <returns></returns>
        private string DVLinhaDigitavel(string seq)
        {

            int Digito, Soma = 0, Peso = 2, res;

            for (int i = seq.Length; i > 0; i--)
            {
                res = (Convert.ToInt32(Strings.Mid(seq, i, 1)) * Peso);

                if (res > 9)
                    res = (res - 9);

                Soma += res;

                if (Peso == 2)
                    Peso = 1;
                else
                    Peso = Peso + 1;
            }

            Digito = ((10 - (Soma % 10)) % 10);

            return Digito.ToString();
        }

        #endregion
    }
}

using System;
using System.Web.UI;
using Microsoft.VisualBasic;
using System.Text;

[assembly: WebResource("BoletoNet.Imagens.041.jpg", "image/jpg")]
namespace BoletoNet
{
    /// <Author>
    /// Felipe Silveira - Transis Informática
    /// </Author>
    internal class Banco_Banrisul : AbstractBanco, IBanco
    {
        private string _dacNossoNumero = string.Empty;
        //private int _dacContaCorrente = 0;
        //private int _dacBoleto = 0;
        private int _primDigito;
        private int _segDigito;

        /// <author>
        /// Classe responsavel em criar os campos do Banco Banrisul.
        /// </author>
        internal Banco_Banrisul()
        {
            this.Codigo = 041;
            this.Digito = 8;
            this.Nome = "Banco Banrisul";
        }

        public override void ValidaBoleto(Boleto boleto)
        {
            //Formata o tamanho do número da agência
            if (boleto.Cedente.ContaBancaria.Conta.Length < 4)
                throw new Exception("Número da agência inválido");

            //Formata o tamanho do número da conta corrente
            if (boleto.Cedente.ContaBancaria.Conta.Length < 7)
                boleto.Cedente.ContaBancaria.Conta = Utils.FormatCode(boleto.Cedente.ContaBancaria.Conta, 7);

            //Formata o tamanho do número de nosso número
            if (boleto.NossoNumero.Length < 13)
                boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 13);

            // Calcula o DAC do Nosso Número
            //_dacNossoNumero = CalcularDigitoNossoNumero(boleto);

            // Calcula o DAC da Conta Corrente
            //int _dacContaCorrente = Mod10(boleto.Cedente.ContaBancaria.Agencia + boleto.Cedente.ContaBancaria.Conta);
            //boleto.Cedente.ContaBancaria.DigitoConta = _dacContaCorrente.ToString();

            //Atribui o nome do banco ao local de pagamento
            if (boleto.LocalPagamento == "Até o vencimento, preferencialmente no ") 
                boleto.LocalPagamento += Nome;

            //Verifica se o nosso número é válido
            if (Utils.ToInt64(boleto.NossoNumero) == 0)
                throw new NotImplementedException("Nosso número inválido");

            //Verifica se data do processamento é valida
            if (boleto.DataProcessamento.ToString("dd/MM/yyyy") == "01/01/0001")
                boleto.DataProcessamento = DateTime.Now;

            //Verifica se data do documento é valida
            if (boleto.DataDocumento.ToString("dd/MM/yyyy") == "01/01/0001")
                boleto.DataDocumento = DateTime.Now;

            FormataCodigoBarra(boleto);
            FormataLinhaDigitavel(boleto);
            FormataNossoNumero(boleto);
        }

        public override void FormataNossoNumero(Boleto boleto)
        {
            //throw new NotImplementedException("Função do fomata nosso número não implementada.");
        }

        public override void FormataNumeroDocumento(Boleto boleto)
        {
            throw new NotImplementedException("Função do fomata número do documento não implementada.");
        }

        public string CalcularDigitoNossoNumero(Boleto boleto)
        {
            string ReConta = boleto.Cedente.ContaBancaria.Conta;
            string ReNossoNumero = boleto.NossoNumero.Substring(0, 9);
            string ReAgencia = boleto.Cedente.ContaBancaria.Agencia;
            int ReDigito;

            ReDigito = Mod10(ReNossoNumero + ReAgencia + ReConta);

            return ReDigito.ToString();

            //throw new NotImplementedException("Função do calcular digito do nosso número não implementada.");
        }

        public override void FormataLinhaDigitavel(Boleto boleto)
        {
            //041M2.1AAAd1  CCCCC.CCNNNd2  NNNNN.041XXd3  V FFFF9999999999

            string campo1 = string.Empty;
            string campo2 = string.Empty;
            string campo3 = string.Empty;
            string campo4 = string.Empty;
            string campo5 = string.Empty;
            long icampo5 = 0;
            //int digitoMod = 0;

            //CAMPO 1
            string AAA = Strings.Mid(boleto.Cedente.ContaBancaria.Agencia, 1, 3);
            string M = boleto.Moeda.ToString();
            string Metade1 = "041" + M + "2";
            string Metade2 = "1" + AAA;
            int d1 = Mod10(Metade1 + Metade2);
            Metade2 = Metade2 + d1;

            campo1 = Metade1 + "." + Metade2;

            //CAMPO 2
            string Cedente = Strings.Mid(boleto.Cedente.ContaBancaria.Conta, 1, 7);
            Metade1 = Strings.Mid(Cedente, 1, 5);
            string Cedente2 = Strings.Mid(Cedente, 6, 2);
            string m_NossoNum = Strings.Right(boleto.NossoNumero, 10);
            string NossoNum1 = Strings.Mid(m_NossoNum, 1, 3);
            Metade2 = Cedente2 + NossoNum1;
            int d2 = Mod10(Metade1 + Metade2);
            Metade2 = Metade2 + d2;

            campo2 = Metade1 + "." + Metade2;

            //CAMPO 3
            Metade1 = Strings.Mid(m_NossoNum, 4, 5);
            Metade2 = "041" + _primDigito + _segDigito;
            int d3 = Mod10(Metade1 + Metade2);
            Metade2 = Metade2 + d3;

            campo3 = Metade1 + "." + Metade2;

            //CAMPO 4
            campo4 = Strings.Mid(boleto.CodigoBarra.Codigo, 5, 1);

            //CAMPO 5
            icampo5 = Convert.ToInt64(Strings.Mid(boleto.CodigoBarra.Codigo, 6, 14));

            if (icampo5 == 0)
                campo5 = "000";
            else
                campo5 = icampo5.ToString();

            boleto.CodigoBarra.LinhaDigitavel = campo1 + "  " + campo2 + "  " + campo3 + "  " + campo4 + "  " + campo5;
        }


        public override void FormataCodigoBarra(Boleto boleto)
        {
            string valorBoleto = boleto.ValorBoleto.ToString("f").Replace(",", "").Replace(".", "");
            valorBoleto = Utils.FormatCode(valorBoleto, 10);

            string W;
            int soma;
            string cta_cc = Strings.Mid(Utils.FormatCode(boleto.Cedente.ContaBancaria.Conta, 7),1,7);
            string agenc = Strings.Mid(Utils.FormatCode(boleto.Cedente.ContaBancaria.Agencia, 3).ToString(),1,3);
            string nossoNum = Strings.Mid(boleto.NossoNumero, 4, 8);
            W = "21" + agenc + cta_cc + nossoNum + "041";
            _primDigito = Mod10(W);
            int resto;
        volta:

            W = "21" + agenc + cta_cc + nossoNum + "041";
            soma = CalculaSoma(W + _primDigito);
            if (soma < 11)
            {
                resto = soma;
            }
            else
            {
                resto = soma % 11;
            }
            if (resto == 1)
            {
                _primDigito = _primDigito + 1;
                if (_primDigito == 10)
                    _primDigito = 0;
                goto volta;
            }
            else if (resto == 0)
            {
                _segDigito = 0;
            }
            else
            {
                _segDigito = 11 - resto;
                if (_segDigito > 9)
                    _segDigito = 0;
            }
            //boleto.CodigoBarra.Codigo = "041" + "9" + FatorVencimento(boleto) + valorBoleto + "21" + agenc + cta_cc + nossoNum + "041" + _primDigito + _segDigito;
            boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}", Utils.FormatCode(Codigo.ToString(), 3), boleto.Moeda, FatorVencimento(boleto), valorBoleto, "21", agenc, cta_cc, nossoNum, Utils.FormatCode(Codigo.ToString(), 3), _primDigito, _segDigito);

            //int Dig;
            //int mult = 2;
            //soma = 0;
            //int resul = 0;
            //int I = Strings.Len(boleto.CodigoBarra.Codigo);
            //int x;
            //string y;
            //for (x = 1; x <= Strings.Len(boleto.CodigoBarra.Codigo); x++)
            //{
            //    if (mult > 9)
            //        mult = 2;
            //    y = Strings.Mid(boleto.CodigoBarra.Codigo, I, 1);
            //    resul = Convert.ToInt32(y) * mult;
            //    soma = soma + resul;
            //    mult = mult + 1;
            //    I = I - 1;
            //}
            //I = (soma % 11);
            
            //soma = 11 - I;
            //if (soma == 0 | soma == 1 | soma > 9)
            //{
            //    Dig = 1;
            //}
            //else
            //{
            //    Dig = soma;
            //}

            int _dacBoleto = Mod11(boleto.CodigoBarra.Codigo, 9);

            boleto.CodigoBarra.Codigo = Strings.Left(boleto.CodigoBarra.Codigo, 4) + _dacBoleto + Strings.Right(boleto.CodigoBarra.Codigo, 39);
        }

        private int CalculaSoma(string Numero)
        {
            int mult;
            int x;
            int y;
            int resul;
            int resto;
            int soma;
            soma = 0;
            mult = 2;
            int I = Strings.Len(Numero);
            //para começar o cálculo pelo nº final (sempre começa multiplicando por 2)
            for (x = 1; x <= Strings.Len(Numero); x++)
            {
                if (Codigo == 41)
                {
                    //Banrisul só vai até 7
                    if (mult == 8)
                        mult = 2;
                }
                else
                {
                    if (mult == 10)
                        mult = 2;
                }
                y = Convert.ToInt32(Strings.Mid(Numero, I, 1));
                resul = y * mult;
                soma = soma + resul;
                mult = mult + 1;
                I = I - 1;
            }
            if (Codigo == 41 | Codigo == 33 | Codigo == 353)
            {
                return soma;
                // calcula no retorno pois tem umas exceções
            }
            else
            {
                resto = soma % 11;
                if (resto == 0)
                    resto = 1;
                return resto;
            }
        }

        
        public override string GerarDetalheRemessa(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            throw new NotImplementedException("Função não implementada.");
        }

        public override string GerarHeaderRemessa(string numeroConvenio, Cedente cedente, TipoArquivo tipoArquivo)
        {
            throw new NotImplementedException("Função não implementada.");
        }

        public override string GerarTrailerRemessa(int numeroRegistro, TipoArquivo tipoArquivo)
        {
            throw new NotImplementedException("Função não implementada.");
        }
    }
}

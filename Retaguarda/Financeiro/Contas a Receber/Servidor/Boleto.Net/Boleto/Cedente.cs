using System;
using System.ComponentModel;

namespace BoletoNet
{
    [Serializable(), Browsable(false)]
    public class Cedente
    {
        #region Variaveis

        private int _codigo = 0;
        private string _cpfcnpj;
        private string _nome;
        private ContaBancaria _contaBancaria;
        private int _convenio = 0;
        private int _digitoCedente = -1;
        #endregion Variaveis

        public Cedente()
        {
        }

        public Cedente(ContaBancaria contaBancaria)
        {
            _contaBancaria = contaBancaria;
        }

        public Cedente(string cpfcnpj, string nome)
        {
            CPFCNPJ = cpfcnpj;
            _nome = nome;
        }

        public Cedente(string cpfcnpj, string nome, string agencia, string digitoAgencia, string conta, string digitoConta, string operacaoConta)
        {
            CPFCNPJ = cpfcnpj;
            _nome = nome;

            _contaBancaria = new ContaBancaria();
            _contaBancaria.Agencia = agencia;
            _contaBancaria.DigitoAgencia = digitoAgencia;
            _contaBancaria.Conta = conta;
            _contaBancaria.DigitoConta = digitoConta;
            _contaBancaria.OperacaConta = operacaoConta;

        }

        public Cedente(string cpfcnpj, string nome, string agencia, string digitoAgencia, string conta, string digitoConta)
        {
            CPFCNPJ = cpfcnpj;
            _nome = nome;

            _contaBancaria = new ContaBancaria();
            _contaBancaria.Agencia = agencia;
            _contaBancaria.DigitoAgencia = digitoAgencia;
            _contaBancaria.Conta = conta;
            _contaBancaria.DigitoConta  = digitoConta;
        }

        public Cedente(string cpfcnpj, string nome, string agencia, string conta, string digitoConta)
        {
            CPFCNPJ = cpfcnpj;
            _nome = nome;

            _contaBancaria = new ContaBancaria();
            _contaBancaria.Agencia = agencia;
            _contaBancaria.Conta = conta;
            _contaBancaria.DigitoConta = digitoConta;
        }

        public Cedente(string cpfcnpj, string nome, string agencia, string conta)
        {
            CPFCNPJ = cpfcnpj;
            _nome = nome;

            _contaBancaria = new ContaBancaria();
            _contaBancaria.Agencia = agencia;
            _contaBancaria.Conta = conta;
        }

        #region Propriedades
        /// <summary>
        /// Código do Cedente
        /// </summary>
        public int Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                _codigo = value;
            }
        }

        public int DigitoCedente
        {
            get
            {
                return _digitoCedente;
            }
            set
            {
                _digitoCedente = value;
            }
            
        }

        /// <summary>
        /// Retona o CPF ou CNPJ do Cedente
        /// </summary>
        public string CPFCNPJ
        {
            get
            {
                return _cpfcnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            }
            set
            {
                string o = value.Replace(".", "").Replace("-", "").Replace("/", "");
                if (o == null || (o.Length != 11 && o.Length != 14))
                    throw new ArgumentException("O CPF/CNPJ inválido. Utilize 11 dígitos para CPF ou 14 para CPNJ.");

                _cpfcnpj = value;
            }
        }

        /// <summary>
        /// Nome do Cedente
        /// </summary>
        public String Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                _nome = value;
            }
        }

        /// <summary>
        /// Conta Correnta do Cedente
        /// </summary>
        public ContaBancaria ContaBancaria
        {
            get
            {
                return _contaBancaria;
            }
            set
            {
                _contaBancaria = value;
            }
        }

        /// <summary>
        /// Número do Convênio
        /// </summary>
        public int Convenio
        {
            get
            {
                return _convenio;
            }
            set
            {
                _convenio = value;
            }
        }
        #endregion Propriedades
    }
}

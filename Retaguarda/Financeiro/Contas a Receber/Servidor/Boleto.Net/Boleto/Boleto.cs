using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Microsoft.VisualBasic;

namespace BoletoNet
{
    [Serializable(), Browsable(false)]
    public class Boleto
    {
        #region Variaveis

        private string _carteira = "";
        private string _nossoNumero = "";
        private DateTime _dataVencimento;
        private DateTime _dataDocumento;
        private DateTime _dataProcessamento;
        private double _valorBoleto = 0;
        private string _localPagamento = "Até o vencimento, preferencialmente no ";
        private int _quantidadeMoeda = 1;
        private string _valorMoeda = "";
        private List<IInstrucao> _instrucoes = new List<IInstrucao>();
        private IEspecieDocumento _especieDocumento = new EspecieDocumento();
        private string _aceite = "N";
        private string _numeroDocumento = "";
        private string _especie = "R$";
        private int _moeda = 9;
        private string _usoBanco = string.Empty;
        private CodigoBarra _codigoBarra =  new CodigoBarra();
        private Cedente _cedente;
        private int _categoria = 0;
        //private string _instrucoesHtml = string.Empty;
        private IBanco _banco;
        private ContaBancaria _contaBancaria = new ContaBancaria();
        private double _valorDesconto;
        private Sacado _sacado;

        private double _jurosMora;
        private double _iof;
        private double _abatimento;
        private double _valorMulta;
        private double _outrosAcrescimos;
        private double _outrosDescontos;
        private DateTime _dataJurosMora;
        private DateTime _dataMulta;
        private DateTime _dataDesconto;
        private DateTime _dataOutrosAcrescimos;
        private DateTime _dataOutrosDescontos;

        private string _tipoModalidae = string.Empty;
        #endregion 

        #region Construtor
        public Boleto()
        {
        }

        public Boleto(DateTime dataVencimento, double valorBoleto, string carteira, string nossoNumero, Cedente cedente, EspecieDocumento especieDocumento)
        {
            _carteira = carteira;
            _nossoNumero = nossoNumero;
            _dataVencimento = dataVencimento;
            _valorBoleto = valorBoleto;
            _valorBoleto = valorBoleto;

            _cedente = cedente;

            _especieDocumento = especieDocumento;
        }

        public Boleto(double valorBoleto, string carteira, string nossoNumero, Cedente cedente)
        {
            _carteira = carteira;
            _nossoNumero = nossoNumero;
            _valorBoleto = valorBoleto;
            _valorBoleto = valorBoleto;

            _cedente = cedente;
        }

        public Boleto(DateTime dataVencimento, double valorBoleto, string carteira, string nossoNumero, Cedente cedente)
        {
            _carteira = carteira;
            _nossoNumero = nossoNumero;
            _dataVencimento = dataVencimento;
            _valorBoleto = valorBoleto;
            _valorBoleto = valorBoleto;

            _cedente = cedente;
        }

        public Boleto(DateTime dataVencimento, double valorBoleto, string carteira, string nossoNumero, string agencia, string conta)
        {
            _carteira = carteira;
            _nossoNumero = nossoNumero;
            _dataVencimento = dataVencimento;
            _valorBoleto = valorBoleto;
            _valorBoleto = valorBoleto;

            _cedente = new Cedente(new ContaBancaria(agencia, conta));
        }
        #endregion Construtor

        #region Properties
        /// <summary> 
        /// Retorna a Categoria do boleto
        /// </summary>
        public int Categoria
        {
            get { return _categoria; }
            set { this._categoria = value; }
        }
        /// <summary> 
        /// Retorna o numero da carteira.
        /// </summary>
        public string Carteira
        {
            get{ return _carteira; }
            set { this._carteira = value; }
        }

        /// <summary> 
        /// Retorna a data do vencimento do titulo.
        /// </summary>
        public DateTime DataVencimento
        {
            get{ return _dataVencimento; }
            set { this._dataVencimento = value; }
        }

        /// <summary> 
        /// Retorna o valor do titulo.
        /// </summary>
        public double ValorBoleto
        {
            get { return _valorBoleto; }
            set { _valorBoleto = value; }
        }

        /// <summary> 
        /// Retorna o campo para a 1 linha da instrucao.
        /// </summary>
        public List<IInstrucao> Instrucoes
        {
            get { return _instrucoes; }
            set { _instrucoes = value; }
        }

        /// <summary> 
        /// Retorna o local de pagamento.
        /// </summary>
        public string LocalPagamento
        {
            get { return _localPagamento; }
            set { this._localPagamento = value; }
        }

        /// <summary> 
        /// Retorna a quantidade da moeda.
        /// </summary>
        public int QuantidadeMoeda
        {
            get { return _quantidadeMoeda; }
            set { _quantidadeMoeda = value; }
        }

        /// <summary> 
        /// Retorna o valor da moeda
        /// </summary>
        public String ValorMoeda
        {
            get { return _valorMoeda; }
            set { this._valorMoeda = value; }
        }

        /// <summary> 
        /// Retorna o campo aceite que por padrao vem com N.
        /// </summary>
        public String Aceite
        {
            get { return _aceite; }
            set { _aceite = value; }
        }

        /// <summary> 
        /// Retorna o campo especie do documento que por padrao vem com DV
        /// </summary>
        public string Especie
        {
            get { return _especie; }
            set { _especie = value; }
        }

        /// <summary> 
        /// Retorna o campo especie do documento que por padrao vem com DV
        /// </summary>
        public IEspecieDocumento EspecieDocumento
        {
            get
            {
                if (_especieDocumento == null)
                    _especieDocumento = new EspecieDocumento();
                return _especieDocumento;
            }
            set { _especieDocumento = value; }
        }

        /// <summary> 
        /// Retorna a data do documento.
        /// </summary>        
        public DateTime DataDocumento
        {
            get { return _dataDocumento; }
            set { _dataDocumento = value; }
        }

        /// <summary> 
        /// Retorna a data do processamento
        /// </summary>        
        public DateTime DataProcessamento
        {
            get { return _dataProcessamento; }
            set { _dataProcessamento = value; }
        }

        /// <summary> 
        /// Recupara o número do documento
        /// </summary>        
        public string NumeroDocumento
        {
            get { return _numeroDocumento; }
            set { _numeroDocumento = value; }
        }

        /// <summary> 
        /// Recupara o nosso número 
        /// </summary>        
        public string NossoNumero
        {
            get{return _nossoNumero;}
            set{_nossoNumero = value;}
        }

        /// <summary> 
        /// Recupera o valor da moeda 
        /// </summary>  
        public int Moeda
        {
            get { return _moeda; }
            set { _moeda = value; }
        }

        public Cedente Cedente
        {
            get { return _cedente; }
            set { _cedente = value; }
        }

        public CodigoBarra CodigoBarra
        {
            get { return _codigoBarra; }
        }

        public IBanco Banco
        {
            get { return _banco; }
            set { _banco = value; }
        }

        public ContaBancaria ContaBancaria
        {
            get { return _contaBancaria; }
            set { _contaBancaria = value; }
        }

        /// <summary> 
        /// Retorna o valor do desconto do titulo.
        /// </summary>
        public double ValorDesconto
        {
            get { return _valorDesconto; }
            set { _valorDesconto = value; }
        }

        /// <summary>
        /// Retorna do Sacado
        /// </summary>
        public Sacado Sacado
        {
            get { return _sacado; }
            set { _sacado = value; }
        }

        /// <summary> 
        /// Para uso do banco 
        /// </summary>        
        public string UsoBanco
        {
            get { return _usoBanco; }
            set { _usoBanco = value; }
        }

        /// <summary> 
        /// Juros de mora 
        /// </summary>  
        public double JurosMora
        {
            get { return _jurosMora; }
            set { _jurosMora = value; }
        }

        /// <summary> 
        /// IOF
        /// </summary>  
        public double IOF
        {
            get { return _iof; }
            set { _iof = value; }
        }

        /// <summary> 
        /// Abatimento
        /// </summary>  
        public double Abatimento
        {
            get { return _abatimento; }
            set { _abatimento = value; }
        }

        /// <summary> 
        /// Valor da Multa
        /// </summary>  
        public double ValorMulta
        {
            get { return _valorMulta; }
            set { _valorMulta = value; }
        }

        /// <summary> 
        /// Outros Acréscimos
        /// </summary>  
        public double OutrosAcrescimos
        {
            get { return _outrosAcrescimos; }
            set { _outrosAcrescimos = value; }
        }

        /// <summary> 
        /// Outros descontos
        /// </summary>  
        public double OutrosDescontos
        {
            get { return _outrosDescontos; }
            set { _outrosDescontos = value; }
        }

        /// <summary> 
        /// Data do Juros de Mora
        /// </summary>  
        public DateTime DataJurosMora
        {
            get { return _dataJurosMora; }
            set { _dataJurosMora = value; }
        }

        /// <summary> 
        /// Data do Juros da Multa
        /// </summary>  
        public DateTime DataMulta
        {
            get { return _dataMulta; }
            set { _dataMulta = value; }
        }

        /// <summary> 
        /// Data do Juros do Desconto
        /// </summary>  
        public DateTime DataDesconto
        {
            get { return _dataDesconto; }
            set { _dataDesconto = value; }
        }

        /// <summary> 
        /// Data de Outros Acréscimos
        /// </summary>  
        public DateTime DataOutrosAcrescimos
        {
            get { return _dataOutrosAcrescimos; }
            set { _dataOutrosAcrescimos = value; }
        }

        /// <summary> 
        /// Data de Outros Descontos
        /// </summary>  
        public DateTime DataOutrosDescontos
        {
            get { return _dataOutrosDescontos; }
            set { _dataOutrosDescontos = value; }
        }

        /// <summary> 
        /// Retorna o tipo da modalidade
        /// </summary>
        public String TipoModalidade
        {
            get { return _tipoModalidae; }
            set { this._tipoModalidae = value; }
        }
        #endregion Properties

        public void Valida()
        {
            //Validações básicas, caso ainda tenha implementada na classe do banco.ValidaBoleto()
            if (this.Cedente == null)
                throw new Exception("Cedente não cadastrado.");

            //Atribui o nome do banco ao local de pagamento
            //Comentada por duplicidade no nome do banco
            //this.LocalPagamento += this.Banco.Nome + "";

            //Verifica se data do processamento é valida
            if (this.DataProcessamento.ToString("dd/MM/yyyy") == "01/01/0001")
                this.DataProcessamento = DateTime.Now;

            //Verifica se data do documento é valida
            if (this.DataDocumento.ToString("dd/MM/yyyy") == "01/01/0001")
                this.DataDocumento = DateTime.Now;

            this.Banco.ValidaBoleto(this);
        }

        public void FormataCampos()
        {
            try
            {
                this.QuantidadeMoeda = 0;
                this.Banco.FormataCodigoBarra(this);
                this.Banco.FormataLinhaDigitavel(this);
                this.Banco.FormataNossoNumero(this);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a formatação dos campos.", ex);
            }
        }
    }
}

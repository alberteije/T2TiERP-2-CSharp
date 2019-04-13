using System;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    public class DetalheSegmentoURetornoCNAB240
    {

        #region Variáveis

        double _jurosMultaEncargos;
        double _valorDescontoConcedido;
        double _valorAbatimentoConcedido;
        double _valorIOFRecolhido;
        double _valorPagoPeloSacado;
        double _valorLiquidoASerCreditado;
        double _valorOutrasDespesas;
        double _valorOutrosCreditos;
        DateTime _dataOcorrencia;
        DateTime _dataCredito;
        string _codigoOcorrenciaSacado;
        DateTime _dataOcorrenciaSacado;
        double _valorOcorrenciaSacado;
        string _registro;

        private List<DetalheSegmentoURetornoCNAB240> _listaDetalhe = new List<DetalheSegmentoURetornoCNAB240>();

        #endregion

        #region Construtores

        public DetalheSegmentoURetornoCNAB240(string registro)
		{
            _registro = registro;
        }

        public DetalheSegmentoURetornoCNAB240()
        {
        }

        #endregion

        #region Propriedades

        public double JurosMultaEncargos
        {
            get { return _jurosMultaEncargos; }
            set { _jurosMultaEncargos = value; }
        }

        public double ValorDescontoConcedido
        {
            get { return _valorDescontoConcedido; }
            set { _valorDescontoConcedido = value; }
        }

        public double ValorAbatimentoConcedido
        {
            get { return _valorAbatimentoConcedido; }
            set { _valorAbatimentoConcedido = value; }
        }

        public double ValorIOFRecolhido
        {
            get { return _valorIOFRecolhido; }
            set { _valorIOFRecolhido = value; }
        }

        public double ValorPagoPeloSacado
        {
            get { return _valorPagoPeloSacado; }
            set { _valorPagoPeloSacado = value; }
        }

        public double ValorLiquidoASerCreditado
        {
            get { return _valorLiquidoASerCreditado; }
            set { _valorLiquidoASerCreditado = value; }
        }

        public double ValorOutrasDespesas
        {
            get { return _valorOutrasDespesas; }
            set { _valorOutrasDespesas = value; }
        }

        public double ValorOutrosCreditos
        {
            get { return _valorOutrosCreditos; }
            set { _valorOutrosCreditos = value; }
        }

        public DateTime DataOcorrencia
        {
            get { return _dataOcorrencia; }
            set { _dataOcorrencia = value; }
        }

        public DateTime DataCredito
        {
            get { return _dataCredito; }
            set { _dataCredito = value; }
        }

        public string CodigoOcorrenciaSacado
        {
            get { return _codigoOcorrenciaSacado; }
            set { _codigoOcorrenciaSacado = value; }
        }

        public DateTime DataOcorrenciaSacado
        {
            get { return _dataOcorrenciaSacado; }
            set { _dataOcorrenciaSacado = value; }
        }

        public double ValorOcorrenciaSacado

        {
            get { return _valorOcorrenciaSacado; }
            set { _valorOcorrenciaSacado = value; }
        }

        public List<DetalheSegmentoURetornoCNAB240> ListaDetalhe
        {
            get { return _listaDetalhe; }
            set { _listaDetalhe = value; }
        }

        public string Registro
        {
            get { return _registro; }
        }

        #endregion

        #region Métodos de Instância

        public void LerDetalheSegmentoURetornoCNAB240(string registro)
        {
            try
            {
                _registro = Registro;

                if (registro.Substring(13, 1) != "U")
                    throw new Exception("Registro inválida. O detalhe não possuí as características do segmento U.");

                int dataOcorrencia = Convert.ToInt32(registro.Substring(137, 8));
                int dataCredito = Convert.ToInt32(registro.Substring(145, 8));

                int dataOcorrenciaSacado = 0;
                if (registro.Substring(153, 4) != "    ")
                    dataOcorrenciaSacado = Convert.ToInt32(registro.Substring(157, 8));

                double jurosMultaEncargos = Convert.ToInt64(registro.Substring(17, 15));
                JurosMultaEncargos = jurosMultaEncargos / 100;
                double valorDescontoConcedido = Convert.ToInt64(registro.Substring(32, 15));
                ValorDescontoConcedido = valorDescontoConcedido / 100;
                double valorAbatimentoConcedido = Convert.ToInt64(registro.Substring(47, 15));
                ValorAbatimentoConcedido = valorAbatimentoConcedido / 100;
                double valorIOFRecolhido = Convert.ToInt64(registro.Substring(62, 15));
                ValorIOFRecolhido = valorIOFRecolhido / 100;
                double valorPagoPeloSacado = Convert.ToInt64(registro.Substring(77, 15));
                ValorPagoPeloSacado = valorPagoPeloSacado / 100;
                double valorLiquidoASerCreditado = Convert.ToInt64(registro.Substring(92, 15));
                ValorLiquidoASerCreditado = valorLiquidoASerCreditado / 100;
                double valorOutrasDespesas = Convert.ToInt64(registro.Substring(107, 15));
                ValorOutrasDespesas = valorOutrasDespesas / 100;
                double valorOutrosCreditos = Convert.ToInt64(registro.Substring(122, 15));
                ValorOutrosCreditos = valorOutrosCreditos / 100;
                DataOcorrencia = Convert.ToDateTime(dataOcorrencia.ToString("##-##-####"));
                DataCredito = Convert.ToDateTime(dataCredito.ToString("##-##-####"));
                CodigoOcorrenciaSacado = registro.Substring(153, 4);
                if (dataOcorrenciaSacado != 0)
                    DataOcorrenciaSacado = Convert.ToDateTime(dataOcorrenciaSacado.ToString("##-##-####"));
                double valorOcorrenciaSacado = Convert.ToInt64(registro.Substring(165, 15));
                ValorOcorrenciaSacado = valorOcorrenciaSacado / 100;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao processar arquivo de RETORNO - SEGMENTO U.", ex);
            }
        }

        #endregion
    }
}

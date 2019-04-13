using System;
using System.Collections;
using System.Text;

namespace BoletoNet
{
    public class Banco : AbstractBanco, IBanco
    {

        #region Variaveis

        private IBanco _IBanco;

        #endregion Variaveis

        #region Construtores

        internal Banco() 
        { 
        }

        public Banco(int CodigoBanco)
        {
            try
            {
                InstanciaBanco(CodigoBanco);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao instanciar objeto.", ex);
            }
        }

        #endregion

        #region Propriedades da Interface

        public override int Codigo
        {
            get { return _IBanco.Codigo; }
            set { _IBanco.Codigo = value; }
        }

        public override int Digito
        {
            get { return _IBanco.Digito; }
        }

        public override string Nome
        {
            get { return _IBanco.Nome; }
        }

        #endregion

        # region Métodos Privados

        private void InstanciaBanco(int codigoBanco)
        {
            try
            {
                switch (codigoBanco)
                {
                    //104 - Caixa
                    case 104:
                        _IBanco = new Banco_Caixa();
                        break;
                    //341 - Itaú
                    case 341:
                        _IBanco = new Banco_Itau();
                        break;
                    //356 - Real
                    case 275:
                    case 356:
                        _IBanco = new Banco_Real();
                        break;
                    //422 - Safra
                    case 422:
                        _IBanco = new Banco_Safra();
                        break;
                    //237 - Bradesco
                    case 237:
                        _IBanco = new Banco_Bradesco();
                        break;
                    //347 - Sudameris
                    case 347:
                        _IBanco = new Banco_Sudameris();
                        break;
                    //353 - Santander
                    case 353:
                        _IBanco = new Banco_Santander();
                        break;
                    //070 - BRB
                    case 70:
                        _IBanco = new Banco_BRB();
                        break;
                    //479 - BankBoston
                    case 479:
                        _IBanco = new Banco_BankBoston();
                        break;
                    //001 - Banco do Brasil
                    case 1:
                        _IBanco = new Banco_Brasil();
                        break;
                    //399 - HSBC
                    case 399:
                        _IBanco = new Banco_HSBC();
                        break;
                    //003 - HSBC
                    case 3:
                        _IBanco = new Banco_Basa();
                        break;
                    //409 - Unibanco
                    case 409:
                        _IBanco = new Banco_Unibanco();
                        break;
                    //33 - Unibanco
                    case 33:
                        _IBanco = new Banco_Santander();
                        break;
                    //41 - Banrisul
                    case 41:
                        _IBanco = new Banco_Banrisul();
                        break;
                    default:
                        throw new Exception("Código do banco não implementando: " + codigoBanco);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a execução da transação.", ex);
            }
        }

        # endregion

        # region Métodos de Interface

        public override void FormataCodigoBarra(Boleto boleto)
        {
            try
            {
                _IBanco.FormataCodigoBarra(boleto);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a formatação do código de barra.", ex);
            }
        }

        public override void FormataLinhaDigitavel(Boleto boleto)
        {
            try
            {
                _IBanco.FormataLinhaDigitavel(boleto);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a formatação da linha digitável.", ex);
            }
        }

        public override void FormataNossoNumero(Boleto boleto)
        {
            try
            {
                _IBanco.FormataNossoNumero(boleto);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a formatação do nosso número.", ex);
            }
        }

        public override void FormataNumeroDocumento(Boleto boleto)
        {
            try
            {
                _IBanco.FormataNumeroDocumento(boleto);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a formatação do número do documento.", ex);
            }
        }

        public override void ValidaBoleto(Boleto boleto)
        {
            //try
            //{
                _IBanco.ValidaBoleto(boleto);
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Erro durante a validação do banco.", ex);
            //}
        }

        # endregion

        # region Métodos de geração de arquivo

        public override string GerarHeaderRemessa(string numeroConvenio, Cedente cedente, TipoArquivo tipoArquivo)
        {
            try
            {
                return _IBanco.GerarHeaderRemessa(numeroConvenio, cedente, tipoArquivo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do registro HEADER do arquivo de REMESSA.", ex);
            }
        }
        
        public override string GerarDetalheRemessa(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                return _IBanco.GerarDetalheRemessa(boleto, numeroRegistro, tipoArquivo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração dos registros de DETALHE do arquivo de REMESSA.", ex);
            }
        }

        public override string GerarTrailerRemessa(int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                return _IBanco.GerarTrailerRemessa(numeroRegistro, tipoArquivo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do registro TRAILER do arquivo de REMESSA.", ex);
            }
        }

        public override string GerarHeaderRemessa(Cedente cedente, TipoArquivo tipoArquivo)
        {
            try
            {
                return _IBanco.GerarHeaderRemessa(cedente, tipoArquivo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do registro HEADER do arquivo de REMESSA.", ex);
            }
        }

        public override string GerarHeaderLoteRemessa(string numeroConvenio, Cedente cedente, int numeroArquivoRemessa)
        {
            try
            {
                return _IBanco.GerarHeaderLoteRemessa(numeroConvenio, cedente, numeroArquivoRemessa);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do registro HEADER do arquivo de REMESSA.", ex);
            }
        }

        public override string GerarHeaderLoteRemessa(string numeroConvenio, Cedente cedente, int numeroArquivoRemessa, TipoArquivo tipoArquivo)
        {
            try
            {
                return _IBanco.GerarHeaderLoteRemessa(numeroConvenio, cedente, numeroArquivoRemessa, tipoArquivo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do registro HEADER do arquivo de REMESSA.", ex);
            }
        }

        public override string GerarDetalheSegmentoPRemessa(Boleto boleto, int numeroRegistro, string numeroConvenio)
        {
            try
            {
                return _IBanco.GerarDetalheSegmentoPRemessa(boleto, numeroRegistro, numeroConvenio);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração dos registros de DETALHE do arquivo de REMESSA.", ex);
            }
        }

        public override string GerarDetalheSegmentoPRemessa(Boleto boleto, int numeroRegistro, string numeroConvenio,Cedente cedente)
        {
            try
            {
                return _IBanco.GerarDetalheSegmentoPRemessa(boleto, numeroRegistro, numeroConvenio,cedente);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração dos registros de DETALHE do arquivo de REMESSA.", ex);
            }
        }

        public override string GerarDetalheSegmentoQRemessa(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                return _IBanco.GerarDetalheSegmentoQRemessa(boleto, numeroRegistro, tipoArquivo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração dos registros de DETALHE do arquivo de REMESSA.", ex);
            }
        }

        public override string GerarDetalheSegmentoRRemessa(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                return _IBanco.GerarDetalheSegmentoRRemessa(boleto, numeroRegistro, tipoArquivo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração dos registros de DETALHE do arquivo de REMESSA.", ex);
            }
        }

        public override string GerarTrailerArquivoRemessa(int numeroRegistro)
        {
            try
            {
                return _IBanco.GerarTrailerArquivoRemessa(numeroRegistro);
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
                return _IBanco.GerarTrailerLoteRemessa(numeroRegistro);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do registro TRAILER do arquivo de REMESSA.", ex);
            }
        }

        # endregion

        #region Métodos de Leitura do arquivo de Retorno

        public override DetalheSegmentoTRetornoCNAB240 LerDetalheSegmentoTRetornoCNAB240(string registro)
        {
            return _IBanco.LerDetalheSegmentoTRetornoCNAB240(registro);
        }

        public override DetalheSegmentoURetornoCNAB240 LerDetalheSegmentoURetornoCNAB240(string registro)
        {
            return _IBanco.LerDetalheSegmentoURetornoCNAB240(registro);
        }

        public override DetalheSegmentoWRetornoCNAB240 LerDetalheSegmentoWRetornoCNAB240(string registro)
        {
            return _IBanco.LerDetalheSegmentoWRetornoCNAB240(registro);
        }


        public override DetalheRetorno LerDetalheRetornoCNAB400(string registro)
        {
            return _IBanco.LerDetalheRetornoCNAB400(registro);
        }

        #endregion Métodos de Leitura do arquivo de Retorno
    }
}

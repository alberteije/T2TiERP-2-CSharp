using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ContasReceberService.Model;
using NHibernate;
using ContasReceberService.NHibernate;
using BoletoNet;
using System.IO;

namespace ContasReceberService
{
    public class ContasReceberService : IContasReceberService
    {

        #region Boleto
        public FinParcelaReceberDTO gerarBoleto(FinParcelaReceberDTO parcelaReceber)
        {

            Cedente cedente = new Cedente("10.793.118/0001-78", "T2Ti.com", "1234", "0", "45678", "8");
            Boleto boleto = new Boleto((DateTime)parcelaReceber.DataVencimento, (decimal) parcelaReceber.Valor, 
                "06", "01030405001", cedente);
            Sacado sacado = new Sacado("000.000.000-00", "Cliente");
            EspecieDocumento especDoc = new EspecieDocumento(237, 2);
            Endereco enderecoCliente = new Endereco();
            enderecoCliente.Bairro = "Centro";
            enderecoCliente.CEP = "71936250";
            enderecoCliente.UF = "DF";
            enderecoCliente.End = "Av Araucarias 1135";
            sacado.Endereco = enderecoCliente;
            BoletoBancario boletoBancario = new BoletoBancario();
            boleto.Sacado = sacado;
            boleto.Cedente = cedente;
            boleto.EspecieDocumento = especDoc;
            boleto.Banco = new Banco(237);
            boleto.DataDocumento = DateTime.Now;
            boletoBancario.CodigoBanco = 237;
            boletoBancario.Boleto = boleto;
            boletoBancario.Boleto.Valida();
            boletoBancario.MontaHtmlNoArquivoLocal(System.IO.Path.GetTempPath() + "\\boleto.html");

            BoletoHTML boletoHTML = new BoletoHTML();

            FileInfo fiBoleto = new FileInfo(System.IO.Path.GetTempPath() + "\\boleto.html");
            FileStream fsBoleto = fiBoleto.OpenRead();
            MemoryStream msBoleto = new MemoryStream((int)fsBoleto.Length);
            fsBoleto.CopyTo(msBoleto);
            fsBoleto.Close();
            msBoleto.Position = 0;

            boletoHTML.fiBoleto = fiBoleto;
            boletoHTML.msBoleto = msBoleto;

            FileInfo fiLogo = new FileInfo(System.IO.Path.GetTempPath() + "\\logo.jpg");
            FileStream fsLogo = fiLogo.OpenRead();
            MemoryStream msLogo = new MemoryStream((int)fsLogo.Length);
            fsLogo.CopyTo(msLogo);
            fsLogo.Close();
            msLogo.Position = 0;

            boletoHTML.fiLogo = fiLogo;
            boletoHTML.msLogo = msLogo;

            FileInfo fiBarra = new FileInfo(System.IO.Path.GetTempPath() + "\\BoletoNetBarra.gif");
            FileStream fsBarra = fiBarra.OpenRead();
            MemoryStream msBarra = new MemoryStream((int)fsBarra.Length);
            fsBarra.CopyTo(msBarra);
            fsBarra.Close();
            msBarra.Position = 0;

            boletoHTML.fiBarra = fiBarra;
            boletoHTML.msBarra = msBarra;

            FileInfo fiCodBarra = new FileInfo(System.IO.Path.GetTempPath() + "\\barra.bmp");
            FileStream fsCodBarra = fiCodBarra.OpenRead();
            MemoryStream msCodBarra = new MemoryStream((int)fsCodBarra.Length);
            fsCodBarra.CopyTo(msCodBarra);
            fsCodBarra.Close();
            msCodBarra.Position = 0;

            boletoHTML.fiCodBarra = fiCodBarra;
            boletoHTML.msCodBarra = msCodBarra;

            parcelaReceber.boletoHTML = boletoHTML;

            return parcelaReceber;
        }
        #endregion

        #region PlanoNaturezaFinanceira
        public int deletePlanoNaturezaFinanceira(PlanoNaturezaFinanceiraDTO planoNaturezaFinanceira)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PlanoNaturezaFinanceiraDTO> DAL = new NHibernateDAL<PlanoNaturezaFinanceiraDTO>(session);
                    DAL.delete(planoNaturezaFinanceira);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PlanoNaturezaFinanceiraDTO salvarAtualizarPlanoNaturezaFinanceira(PlanoNaturezaFinanceiraDTO planoNaturezaFinanceira)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PlanoNaturezaFinanceiraDTO> DAL = new NHibernateDAL<PlanoNaturezaFinanceiraDTO>(session);
                    DAL.saveOrUpdate(planoNaturezaFinanceira);
                    session.Flush();
                }
                return planoNaturezaFinanceira;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PlanoNaturezaFinanceiraDTO> selectPlanoNaturezaFinanceira(PlanoNaturezaFinanceiraDTO planoNaturezaFinanceira)
        {
            try
            {
                IList<PlanoNaturezaFinanceiraDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PlanoNaturezaFinanceiraDTO> DAL = new NHibernateDAL<PlanoNaturezaFinanceiraDTO>(session);
                    resultado = DAL.select(planoNaturezaFinanceira);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PlanoNaturezaFinanceiraDTO> selectPlanoNaturezaFinanceiraPagina(int primeiroResultado, int quantidadeResultados, PlanoNaturezaFinanceiraDTO planoNaturezaFinanceira)
        {
            try
            {
                IList<PlanoNaturezaFinanceiraDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PlanoNaturezaFinanceiraDTO> DAL = new NHibernateDAL<PlanoNaturezaFinanceiraDTO>(session);
                    resultado = DAL.selectPagina<PlanoNaturezaFinanceiraDTO>(primeiroResultado, quantidadeResultados, planoNaturezaFinanceira);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion

        #region NaturezaFinanceira
        public int deleteNaturezaFinanceira(NaturezaFinanceiraDTO naturezaFinanceira)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<NaturezaFinanceiraDTO> DAL = new NHibernateDAL<NaturezaFinanceiraDTO>(session);
                    DAL.delete(naturezaFinanceira);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public NaturezaFinanceiraDTO salvarAtualizarNaturezaFinanceira(NaturezaFinanceiraDTO naturezaFinanceira)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<NaturezaFinanceiraDTO> DAL = new NHibernateDAL<NaturezaFinanceiraDTO>(session);
                    DAL.saveOrUpdate(naturezaFinanceira);
                    session.Flush();
                }
                return naturezaFinanceira;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<NaturezaFinanceiraDTO> selectNaturezaFinanceira(NaturezaFinanceiraDTO naturezaFinanceira)
        {
            try
            {
                IList<NaturezaFinanceiraDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<NaturezaFinanceiraDTO> DAL = new NHibernateDAL<NaturezaFinanceiraDTO>(session);
                    resultado = DAL.select(naturezaFinanceira);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<NaturezaFinanceiraDTO> selectNaturezaFinanceiraPagina(int primeiroResultado, int quantidadeResultados, NaturezaFinanceiraDTO naturezaFinanceira)
        {
            try
            {
                IList<NaturezaFinanceiraDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<NaturezaFinanceiraDTO> DAL = new NHibernateDAL<NaturezaFinanceiraDTO>(session);
                    resultado = DAL.selectPagina<NaturezaFinanceiraDTO>(primeiroResultado, quantidadeResultados, naturezaFinanceira);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FinStatusParcela
        public int deleteFinStatusParcela(FinStatusParcelaDTO finStatusParcela)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinStatusParcelaDTO> DAL = new NHibernateDAL<FinStatusParcelaDTO>(session);
                    DAL.delete(finStatusParcela);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public FinStatusParcelaDTO salvarAtualizarFinStatusParcela(FinStatusParcelaDTO finStatusParcela)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinStatusParcelaDTO> DAL = new NHibernateDAL<FinStatusParcelaDTO>(session);
                    DAL.saveOrUpdate(finStatusParcela);
                    session.Flush();
                }
                return finStatusParcela;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinStatusParcelaDTO> selectFinStatusParcela(FinStatusParcelaDTO finStatusParcela)
        {
            try
            {
                IList<FinStatusParcelaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinStatusParcelaDTO> DAL = new NHibernateDAL<FinStatusParcelaDTO>(session);
                    resultado = DAL.select(finStatusParcela);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinStatusParcelaDTO> selectFinStatusParcelaPagina(int primeiroResultado, int quantidadeResultados, FinStatusParcelaDTO finStatusParcela)
        {
            try
            {
                IList<FinStatusParcelaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinStatusParcelaDTO> DAL = new NHibernateDAL<FinStatusParcelaDTO>(session);
                    resultado = DAL.selectPagina<FinStatusParcelaDTO>(primeiroResultado, quantidadeResultados, finStatusParcela);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FinTipoRecebimento
        public int deleteFinTipoRecebimento(FinTipoRecebimentoDTO finTipoRecebimento)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinTipoRecebimentoDTO> DAL = new NHibernateDAL<FinTipoRecebimentoDTO>(session);
                    DAL.delete(finTipoRecebimento);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public FinTipoRecebimentoDTO salvarAtualizarFinTipoRecebimento(FinTipoRecebimentoDTO finTipoRecebimento)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinTipoRecebimentoDTO> DAL = new NHibernateDAL<FinTipoRecebimentoDTO>(session);
                    DAL.saveOrUpdate(finTipoRecebimento);
                    session.Flush();
                }
                return finTipoRecebimento;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinTipoRecebimentoDTO> selectFinTipoRecebimento(FinTipoRecebimentoDTO finTipoRecebimento)
        {
            try
            {
                IList<FinTipoRecebimentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinTipoRecebimentoDTO> DAL = new NHibernateDAL<FinTipoRecebimentoDTO>(session);
                    resultado = DAL.select(finTipoRecebimento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinTipoRecebimentoDTO> selectFinTipoRecebimentoPagina(int primeiroResultado, int quantidadeResultados, FinTipoRecebimentoDTO finTipoRecebimento)
        {
            try
            {
                IList<FinTipoRecebimentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinTipoRecebimentoDTO> DAL = new NHibernateDAL<FinTipoRecebimentoDTO>(session);
                    resultado = DAL.selectPagina<FinTipoRecebimentoDTO>(primeiroResultado, quantidadeResultados, finTipoRecebimento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FinConfiguracaoBoleto
        public int deleteFinConfiguracaoBoleto(FinConfiguracaoBoletoDTO finConfiguracaoBoleto)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinConfiguracaoBoletoDTO> DAL = new NHibernateDAL<FinConfiguracaoBoletoDTO>(session);
                    DAL.delete(finConfiguracaoBoleto);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public FinConfiguracaoBoletoDTO salvarAtualizarFinConfiguracaoBoleto(FinConfiguracaoBoletoDTO finConfiguracaoBoleto)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinConfiguracaoBoletoDTO> DAL = new NHibernateDAL<FinConfiguracaoBoletoDTO>(session);
                    DAL.saveOrUpdate(finConfiguracaoBoleto);
                    session.Flush();
                }
                return finConfiguracaoBoleto;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinConfiguracaoBoletoDTO> selectFinConfiguracaoBoleto(FinConfiguracaoBoletoDTO finConfiguracaoBoleto)
        {
            try
            {
                IList<FinConfiguracaoBoletoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinConfiguracaoBoletoDTO> DAL = new NHibernateDAL<FinConfiguracaoBoletoDTO>(session);
                    resultado = DAL.select(finConfiguracaoBoleto);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinConfiguracaoBoletoDTO> selectFinConfiguracaoBoletoPagina(int primeiroResultado, int quantidadeResultados, FinConfiguracaoBoletoDTO finConfiguracaoBoleto)
        {
            try
            {
                IList<FinConfiguracaoBoletoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinConfiguracaoBoletoDTO> DAL = new NHibernateDAL<FinConfiguracaoBoletoDTO>(session);
                    resultado = DAL.selectPagina<FinConfiguracaoBoletoDTO>(primeiroResultado, quantidadeResultados, finConfiguracaoBoleto);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FinDocumentoOrigem
        public int deleteFinDocumentoOrigem(FinDocumentoOrigemDTO finDocumentoOrigem)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinDocumentoOrigemDTO> DAL = new NHibernateDAL<FinDocumentoOrigemDTO>(session);
                    DAL.delete(finDocumentoOrigem);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public FinDocumentoOrigemDTO salvarAtualizarFinDocumentoOrigem(FinDocumentoOrigemDTO finDocumentoOrigem)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinDocumentoOrigemDTO> DAL = new NHibernateDAL<FinDocumentoOrigemDTO>(session);
                    DAL.saveOrUpdate(finDocumentoOrigem);
                    session.Flush();
                }
                return finDocumentoOrigem;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinDocumentoOrigemDTO> selectFinDocumentoOrigem(FinDocumentoOrigemDTO finDocumentoOrigem)
        {
            try
            {
                IList<FinDocumentoOrigemDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinDocumentoOrigemDTO> DAL = new NHibernateDAL<FinDocumentoOrigemDTO>(session);
                    resultado = DAL.select(finDocumentoOrigem);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinDocumentoOrigemDTO> selectFinDocumentoOrigemPagina(int primeiroResultado, int quantidadeResultados, FinDocumentoOrigemDTO finDocumentoOrigem)
        {
            try
            {
                IList<FinDocumentoOrigemDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinDocumentoOrigemDTO> DAL = new NHibernateDAL<FinDocumentoOrigemDTO>(session);
                    resultado = DAL.selectPagina<FinDocumentoOrigemDTO>(primeiroResultado, quantidadeResultados, finDocumentoOrigem);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion

        #region FinLancamentoReceber
        public int deleteFinLancamentoReceber(FinLancamentoReceberDTO FinLancamentoReceber)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    LancamentoReceberDAL DAL = new LancamentoReceberDAL(session);
                    DAL.delete(FinLancamentoReceber);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public FinLancamentoReceberDTO salvarAtualizarFinLancamentoReceber(FinLancamentoReceberDTO FinLancamentoReceber)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    LancamentoReceberDAL DAL = new LancamentoReceberDAL(session);
                    DAL.saveOrUpdate(FinLancamentoReceber);
                    session.Flush();
                }
                return FinLancamentoReceber;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinLancamentoReceberDTO> selectFinLancamentoReceber(FinLancamentoReceberDTO FinLancamentoReceber)
        {
            try
            {
                IList<FinLancamentoReceberDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    LancamentoReceberDAL DAL = new LancamentoReceberDAL(session);
                    resultado = DAL.select(FinLancamentoReceber);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinLancamentoReceberDTO> selectFinLancamentoReceberPagina(int primeiroResultado, int quantidadeResultados, FinLancamentoReceberDTO FinLancamentoReceber)
        {
            try
            {
                IList<FinLancamentoReceberDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    LancamentoReceberDAL DAL = new LancamentoReceberDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, FinLancamentoReceber);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ViewFinLancamentoReceber
        public ViewFinLancamentoReceberDTO salvarAtualizarViewFinLancamentoReceber(ViewFinLancamentoReceberDTO ViewFinLancamentoReceber)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    RecebimentoDAL DAL = new RecebimentoDAL(session);
                    DAL.saveOrUpdate(ViewFinLancamentoReceber);
                    session.Flush();
                }
                return ViewFinLancamentoReceber;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ViewFinLancamentoReceberDTO> selectViewFinLancamentoReceber(ViewFinLancamentoReceberDTO ViewFinLancamentoReceber)
        {
            try
            {
                IList<ViewFinLancamentoReceberDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    RecebimentoDAL DAL = new RecebimentoDAL(session);
                    resultado = DAL.select(ViewFinLancamentoReceber);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ViewFinLancamentoReceberDTO> selectViewFinLancamentoReceberPagina(int primeiroResultado, int quantidadeResultados, ViewFinLancamentoReceberDTO ViewFinLancamentoReceber)
        {
            try
            {
                IList<ViewFinLancamentoReceberDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    RecebimentoDAL DAL = new RecebimentoDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, ViewFinLancamentoReceber);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 



        #region ContaCaixa
        public IList<ContaCaixaDTO> selectContaCaixa(ContaCaixaDTO contaCaixa)
        {
            try
            {
                IList<ContaCaixaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContaCaixaDTO> DAL = new NHibernateDAL<ContaCaixaDTO>(session);
                    resultado = DAL.select(contaCaixa);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContaCaixaDTO> selectContaCaixaPagina(int primeiroResultado, int quantidadeResultados, ContaCaixaDTO contaCaixa)
        {
            try
            {
                IList<ContaCaixaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContaCaixaDTO> DAL = new NHibernateDAL<ContaCaixaDTO>(session);
                    resultado = DAL.selectPagina<ContaCaixaDTO>(primeiroResultado, quantidadeResultados, contaCaixa);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ContabilConta
        public IList<ContabilContaDTO> selectContabilConta(ContabilContaDTO contabilConta)
        {
            try
            {
                IList<ContabilContaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilContaDTO> DAL = new NHibernateDAL<ContabilContaDTO>(session);
                    resultado = DAL.select(contabilConta);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilContaDTO> selectContabilContaPagina(int primeiroResultado, int quantidadeResultados, ContabilContaDTO contabilConta)
        {
            try
            {
                IList<ContabilContaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilContaDTO> DAL = new NHibernateDAL<ContabilContaDTO>(session);
                    resultado = DAL.selectPagina<ContabilContaDTO>(primeiroResultado, quantidadeResultados, contabilConta);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        #endregion
        
        #region Usuario
        public UsuarioDTO selectUsuario(String login, String senha)
        {
            try
            {
                UsuarioDTO resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    UsuarioDAL DAL = new UsuarioDAL(session);
                    resultado = DAL.select(login, senha);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        #endregion

        #region ControleAcesso
        public IList<ViewControleAcessoDTO> selectControleAcesso(ViewControleAcessoDTO viewControleAcesso)
        {
            try
            {
                IList<ViewControleAcessoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewControleAcessoDTO> DAL = new NHibernateDAL<ViewControleAcessoDTO>(session);
                    resultado = DAL.select(viewControleAcesso);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }

        }
        #endregion

        #region ViewPessoaCliente
        public IList<ViewPessoaClienteDTO> selectViewPessoaCliente(ViewPessoaClienteDTO viewPessoaCliente)
        {
            try
            {
                IList<ViewPessoaClienteDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewPessoaClienteDTO> DAL = new NHibernateDAL<ViewPessoaClienteDTO>(session);
                    resultado = DAL.select(viewPessoaCliente);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ViewPessoaClienteDTO> selectViewPessoaClientePagina(int primeiroResultado, int quantidadeResultados, ViewPessoaClienteDTO viewPessoaCliente)
        {
            try
            {
                IList<ViewPessoaClienteDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewPessoaClienteDTO> DAL = new NHibernateDAL<ViewPessoaClienteDTO>(session);
                    resultado = DAL.selectPagina<ViewPessoaClienteDTO>(primeiroResultado, quantidadeResultados, viewPessoaCliente);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

    }
}

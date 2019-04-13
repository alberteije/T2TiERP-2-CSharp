using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using OrcamentoService.Model;
using NHibernate;
using OrcamentoService.NHibernate;

namespace OrcamentoService
{
    public class Service : IService
    {
        public IList<OrcamentoPeriodoDTO> selectPeriodo(OrcamentoPeriodoDTO periodo)
        {
            try
            {
                IList<OrcamentoPeriodoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<OrcamentoPeriodoDTO> periodoDAL = new NHibernateDAL<OrcamentoPeriodoDTO>(session);
                    resultado = periodoDAL.select(periodo);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }            
        }

        public IList<NaturezaFinanceiraDTO> selectNaturezaFinanceira(NaturezaFinanceiraDTO naturezaFinanceira)
        {
            try
            {
                IList<NaturezaFinanceiraDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<NaturezaFinanceiraDTO> naturezaFinanceiraDAL = new NHibernateDAL<NaturezaFinanceiraDTO>(session);
                    resultado = naturezaFinanceiraDAL.select(naturezaFinanceira);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }            
        }

        public IList<ParcelaPagarDTO> selectLancamentosPagar(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                IList<ParcelaPagarDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ParcelaDAL parcelaDAL = new ParcelaDAL(session);
                    resultado = parcelaDAL.selectParcelaPagar(dataInicio, dataFim);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<ParcelaReceberDTO> selectLancamentosReceber(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                IList<ParcelaReceberDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ParcelaDAL parcelaDAL = new ParcelaDAL(session);
                    resultado = parcelaDAL.selectParcelaReceber(dataInicio, dataFim);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<OrcamentoDTO> selectOrcamento(OrcamentoDTO orcamento)
        {
            try
            {
                IList<OrcamentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<OrcamentoDTO> orcamentoDAL = new NHibernateDAL<OrcamentoDTO>(session);
                    resultado = orcamentoDAL.select(orcamento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public OrcamentoDTO selectOrcamentoCompleto(OrcamentoDTO orcamento)
        {
            try
            {
                OrcamentoDTO resultado = null;

                if (orcamento != null && orcamento.id > 0)
                {

                    using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                    {
                        NHibernateDAL<OrcamentoDTO> orcamentoDAL = new NHibernateDAL<OrcamentoDTO>(session);
                        resultado = orcamentoDAL.selectId<OrcamentoDTO>((int)orcamento.id);

                        OrcamentoDetalheDTO orcamentoDetalhe = new OrcamentoDetalheDTO();
                        orcamentoDetalhe.orcamento = resultado;
                        OrcamentoDetalheDAL orcamentoDetDAL = new OrcamentoDetalheDAL(session);
                        resultado.listaOrcamentoDetalhe = orcamentoDetDAL.select(orcamentoDetalhe);
                    }
                }
                else
                    throw new Exception("Orçamento nulo/inexistente.");
                return resultado;
            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException(ex.Message);
                throw fault;
            }
        }

        public OrcamentoDTO saveOrcamento(OrcamentoDTO orcamento)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<OrcamentoDTO> orcamentoDAL = new NHibernateDAL<OrcamentoDTO>(session);
                    IList<OrcamentoDetalheDTO> listaOrcamentoDetalhe = orcamento.listaOrcamentoDetalhe;

                    orcamentoDAL.saveOrUpdate(orcamento);

                    foreach (OrcamentoDetalheDTO orcamentoDetalhe in listaOrcamentoDetalhe)
                    {
                        orcamentoDetalhe.orcamento = orcamento;
                        NHibernateDAL<OrcamentoDetalheDTO> orcamentoDetDAL = new NHibernateDAL<OrcamentoDetalheDTO>(session);
                        orcamentoDetDAL.saveOrUpdate(orcamentoDetalhe);
                    }

                    session.Flush();
                }
                return orcamento;
            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException(ex.Message);
                throw fault;
            }
        }

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

        public EmpresaDTO selectEmpresaId(int id)
        {
            try
            {
                EmpresaDTO resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<EmpresaDTO> empresaDAL = new NHibernateDAL<EmpresaDTO>(session);
                    resultado = empresaDAL.selectId<EmpresaDTO>(id);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}

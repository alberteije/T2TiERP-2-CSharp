using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace ContratosService.Model
{
    public class ContratoDAL : NHibernateDAL<ContratoDTO>
    {
        public ContratoDAL(ISession session) : base(session) { }

        public ContratoDTO saveOrUpdate(ContratoDTO objeto)
        {
            try
            {
                base.saveOrUpdate<ContratoDTO>(objeto);

                IList<ContratoHistFaturamentoDTO> listaExclusaoFat = session.CreateCriteria(typeof(ContratoHistFaturamentoDTO)).
                    Add(Expression.Eq("IdContrato", objeto.Id)).List<ContratoHistFaturamentoDTO>();

                foreach (ContratoHistFaturamentoDTO objLista in listaExclusaoFat)
                {
                    session.Delete(objLista);
                }

                foreach (ContratoHistFaturamentoDTO objLista in objeto.ListaContratoHistFaturamento)
                {
                    objLista.IdContrato = objeto.Id;
                    session.Save(objLista);
                }

                IList<ContratoHistoricoReajusteDTO> listaExclusaoReaj = session.CreateCriteria(typeof(ContratoHistoricoReajusteDTO)).
                    Add(Expression.Eq("IdContrato", objeto.Id)).List<ContratoHistoricoReajusteDTO>();

                foreach (ContratoHistoricoReajusteDTO objLista in listaExclusaoReaj)
                {
                    session.Delete(objLista);
                }

                foreach (ContratoHistoricoReajusteDTO objLista in objeto.ListaContratoHistoricoReajuste)
                {
                    objLista.IdContrato = objeto.Id;
                    session.Save(objLista);
                }

                IList<ContratoPrevFaturamentoDTO> listaExclusaoPrevFat = session.CreateCriteria(typeof(ContratoPrevFaturamentoDTO)).
                    Add(Expression.Eq("IdContrato", objeto.Id)).List<ContratoPrevFaturamentoDTO>();

                foreach (ContratoPrevFaturamentoDTO objLista in listaExclusaoPrevFat)
                {
                    session.Delete(objLista);
                }

                foreach (ContratoPrevFaturamentoDTO objLista in objeto.ListaContratoPrevFaturamento)
                {
                    objLista.IdContrato = objeto.Id;
                    session.Save(objLista);
                }
                session.Flush();

                return objeto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<ContratoDTO> select(ContratoDTO objeto)
        {
            try
            {

                IList<ContratoDTO> resultado = base.select<ContratoDTO>(objeto);

                foreach (ContratoDTO objP in resultado)
                {
                    NHibernateDAL<ContratoHistFaturamentoDTO> DAL = new NHibernateDAL<ContratoHistFaturamentoDTO>(session);
                    objP.ListaContratoHistFaturamento = DAL.select<ContratoHistFaturamentoDTO>(
                        new ContratoHistFaturamentoDTO { IdContrato = objP.Id });

                    NHibernateDAL<ContratoHistoricoReajusteDTO> DALHst = new NHibernateDAL<ContratoHistoricoReajusteDTO>(session);
                    objP.ListaContratoHistoricoReajuste = DALHst.select<ContratoHistoricoReajusteDTO>(
                        new ContratoHistoricoReajusteDTO { IdContrato = objP.Id });

                    NHibernateDAL<ContratoPrevFaturamentoDTO> DALPrev = new NHibernateDAL<ContratoPrevFaturamentoDTO>(session);
                    objP.ListaContratoPrevFaturamento = DALPrev.select<ContratoPrevFaturamentoDTO>(
                        new ContratoPrevFaturamentoDTO { IdContrato = objP.Id });

                }


                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<ContratoDTO> selectPagina(int primeiroResultado, int quantidadeResultados, ContratoDTO objeto)
        {
            try
            {
                IList<ContratoDTO> resultado = base.selectPagina<ContratoDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (ContratoDTO objLista in resultado)
                {
                    NHibernateDAL<ContratoHistFaturamentoDTO> DAL = new NHibernateDAL<ContratoHistFaturamentoDTO>(session);
                    objLista.ListaContratoHistFaturamento = DAL.select<ContratoHistFaturamentoDTO>(
                        new ContratoHistFaturamentoDTO { IdContrato = objeto.Id });

                    NHibernateDAL<ContratoHistoricoReajusteDTO> DALHst = new NHibernateDAL<ContratoHistoricoReajusteDTO>(session);
                    objLista.ListaContratoHistoricoReajuste = DALHst.select<ContratoHistoricoReajusteDTO>(
                        new ContratoHistoricoReajusteDTO { IdContrato = objeto.Id });

                    NHibernateDAL<ContratoPrevFaturamentoDTO> DALPrev = new NHibernateDAL<ContratoPrevFaturamentoDTO>(session);
                    objLista.ListaContratoPrevFaturamento = DALPrev.select<ContratoPrevFaturamentoDTO>(
                        new ContratoPrevFaturamentoDTO { IdContrato = objeto.Id });

                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(ContratoDTO objeto)
        {
            try
            {

                IList<ContratoHistFaturamentoDTO> listaExclusaoHist = session.CreateCriteria(typeof(ContratoHistFaturamentoDTO)).
                    Add(Expression.Eq("IdContrato", objeto.Id)).List<ContratoHistFaturamentoDTO>();

                foreach (ContratoHistFaturamentoDTO objLista in listaExclusaoHist)
                {
                    session.Delete(objLista);
                }

                IList<ContratoHistoricoReajusteDTO> listaExclusaoReaj = session.CreateCriteria(typeof(ContratoHistoricoReajusteDTO)).
                    Add(Expression.Eq("IdContrato", objeto.Id)).List<ContratoHistoricoReajusteDTO>();

                foreach (ContratoHistoricoReajusteDTO objLista in listaExclusaoReaj)
                {
                    session.Delete(objLista);
                }


                IList<ContratoPrevFaturamentoDTO> listaExclusao = session.CreateCriteria(typeof(ContratoPrevFaturamentoDTO)).
                    Add(Expression.Eq("IdContrato", objeto.Id)).List<ContratoPrevFaturamentoDTO>();

                foreach (ContratoPrevFaturamentoDTO objLista in listaExclusao)
                {
                    session.Delete(objLista);
                }

                int resultado = base.delete<ContratoDTO>(objeto);

                session.Flush();

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
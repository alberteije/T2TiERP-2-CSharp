using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace ContasReceberService.Model
{
    public class LancamentoReceberDAL : NHibernateDAL<FinLancamentoReceberDTO>
    {
        public LancamentoReceberDAL(ISession session) : base(session) { }

        public FinLancamentoReceberDTO saveOrUpdate(FinLancamentoReceberDTO objeto)
        {
            try
            {
                base.saveOrUpdate<FinLancamentoReceberDTO>(objeto);

                IList<FinParcelaReceberDTO> listaExclusaoParcelaReceber = session.CreateCriteria(typeof(FinParcelaReceberDTO)).
                    Add(Expression.Eq("IdFinLancamentoReceber", objeto.Id)).List<FinParcelaReceberDTO>();

                foreach (FinParcelaReceberDTO objLista in listaExclusaoParcelaReceber)
                {
                    session.Delete(objLista);
                }
                
                if(objeto.ListaFinParcelaReceber != null)
                foreach (FinParcelaReceberDTO objLista in objeto.ListaFinParcelaReceber)
                {
                    objLista.IdFinLancamentoReceber = objeto.Id;
                    objLista.IdFinStatusParcela = 1; //em aberto
                    session.Save(objLista);
                }

                IList<FinLctoReceberNtFinanceiraDTO> listaExclusaoNaturezaFinanceira = session.CreateCriteria(typeof(FinLctoReceberNtFinanceiraDTO)).
                    Add(Expression.Eq("IdFinLancamentoReceber", objeto.Id)).List<FinLctoReceberNtFinanceiraDTO>();

                foreach (FinLctoReceberNtFinanceiraDTO objLista in listaExclusaoNaturezaFinanceira)
                {
                    session.Delete(objLista);
                }

                if (objeto.ListaNaturezaFinanceira != null)
                foreach (FinLctoReceberNtFinanceiraDTO objLista in objeto.ListaNaturezaFinanceira)
                {
                    objLista.IdFinLancamentoReceber = objeto.Id;
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

        
        public IList<FinLancamentoReceberDTO> select(FinLancamentoReceberDTO objeto)
        {
            try
            {

                IList<FinLancamentoReceberDTO> resultado = base.select<FinLancamentoReceberDTO>(objeto);

                foreach (FinLancamentoReceberDTO objP in resultado)
                {
                    NHibernateDAL<FinParcelaReceberDTO> DAL = new NHibernateDAL<FinParcelaReceberDTO>(session);
                    objP.ListaFinParcelaReceber = DAL.select<FinParcelaReceberDTO>(
                        new FinParcelaReceberDTO { IdFinLancamentoReceber = objP.Id });
                }

                foreach (FinLancamentoReceberDTO objP in resultado)
                {
                    NHibernateDAL<FinLctoReceberNtFinanceiraDTO> DAL = new NHibernateDAL<FinLctoReceberNtFinanceiraDTO>(session);
                    objP.ListaNaturezaFinanceira = DAL.select<FinLctoReceberNtFinanceiraDTO>(
                        new FinLctoReceberNtFinanceiraDTO { IdFinLancamentoReceber = objP.Id });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public IList<FinLancamentoReceberDTO> selectPagina(int primeiroResultado, int quantidadeResultados, FinLancamentoReceberDTO objeto)
        {
            try
            {
                IList<FinLancamentoReceberDTO> resultado = base.selectPagina<FinLancamentoReceberDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (FinLancamentoReceberDTO objLista in resultado)
                {
                    NHibernateDAL<FinParcelaReceberDTO> DAL = new NHibernateDAL<FinParcelaReceberDTO>(session);
                    objLista.ListaFinParcelaReceber = DAL.select<FinParcelaReceberDTO>(
                        new FinParcelaReceberDTO { IdFinLancamentoReceber = objLista.Id });
                }

                foreach (FinLancamentoReceberDTO objLista in resultado)
                {
                    NHibernateDAL<FinLctoReceberNtFinanceiraDTO> DAL = new NHibernateDAL<FinLctoReceberNtFinanceiraDTO>(session);
                    objLista.ListaNaturezaFinanceira = DAL.select<FinLctoReceberNtFinanceiraDTO>(
                        new FinLctoReceberNtFinanceiraDTO { IdFinLancamentoReceber = objLista.Id });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public int delete(FinLancamentoReceberDTO objeto)
        {
            try
            {
                IList<FinParcelaReceberDTO> listaExclusaoParcelaReceber = session.CreateCriteria(typeof(FinParcelaReceberDTO)).
                    Add(Expression.Eq("IdFinLancamentoReceber", objeto.Id)).List<FinParcelaReceberDTO>();

                foreach (FinParcelaReceberDTO objLista in listaExclusaoParcelaReceber)
                {
                    session.Delete(objLista);
                }

                IList<FinLctoReceberNtFinanceiraDTO> listaExclusaoNaturezaFinanceira = session.CreateCriteria(typeof(FinLctoReceberNtFinanceiraDTO)).
                    Add(Expression.Eq("IdFinLancamentoReceber", objeto.Id)).List<FinLctoReceberNtFinanceiraDTO>();

                foreach (FinLctoReceberNtFinanceiraDTO objLista in listaExclusaoNaturezaFinanceira)
                {
                    session.Delete(objLista);
                }

                int resultado = base.delete<FinLancamentoReceberDTO>(objeto);

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
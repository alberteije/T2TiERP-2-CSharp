using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace ContasPagarService.Model
{
    public class LancamentoPagarDAL : NHibernateDAL<FinLancamentoPagarDTO>
    {
        public LancamentoPagarDAL(ISession session) : base(session) { }

        public FinLancamentoPagarDTO saveOrUpdate(FinLancamentoPagarDTO objeto)
        {
            try
            {
                base.saveOrUpdate<FinLancamentoPagarDTO>(objeto);

                IList<FinParcelaPagarDTO> listaExclusaoParcelaPagar = session.CreateCriteria(typeof(FinParcelaPagarDTO)).
                    Add(Expression.Eq("IdFinLancamentoPagar", objeto.Id)).List<FinParcelaPagarDTO>();

                foreach (FinParcelaPagarDTO objLista in listaExclusaoParcelaPagar)
                {
                    session.Delete(objLista);
                }
                
                if(objeto.ListaFinParcelaPagar != null)
                foreach (FinParcelaPagarDTO objLista in objeto.ListaFinParcelaPagar)
                {
                    objLista.IdFinLancamentoPagar = objeto.Id;
                    objLista.IdFinStatusParcela = 1; //em aberto
                    session.Save(objLista);
                }

                IList<FinLctoPagarNtFinanceiraDTO> listaExclusaoNaturezaFinanceira = session.CreateCriteria(typeof(FinLctoPagarNtFinanceiraDTO)).
                    Add(Expression.Eq("IdFinLancamentoPagar", objeto.Id)).List<FinLctoPagarNtFinanceiraDTO>();

                foreach (FinLctoPagarNtFinanceiraDTO objLista in listaExclusaoNaturezaFinanceira)
                {
                    session.Delete(objLista);
                }

                if (objeto.ListaNaturezaFinanceira != null)
                foreach (FinLctoPagarNtFinanceiraDTO objLista in objeto.ListaNaturezaFinanceira)
                {
                    objLista.IdFinLancamentoPagar = objeto.Id;
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

        
        public IList<FinLancamentoPagarDTO> select(FinLancamentoPagarDTO objeto)
        {
            try
            {

                IList<FinLancamentoPagarDTO> resultado = base.select<FinLancamentoPagarDTO>(objeto);

                foreach (FinLancamentoPagarDTO objP in resultado)
                {
                    NHibernateDAL<FinParcelaPagarDTO> DAL = new NHibernateDAL<FinParcelaPagarDTO>(session);
                    objP.ListaFinParcelaPagar = DAL.select<FinParcelaPagarDTO>(
                        new FinParcelaPagarDTO { IdFinLancamentoPagar = objP.Id });
                }

                foreach (FinLancamentoPagarDTO objP in resultado)
                {
                    NHibernateDAL<FinLctoPagarNtFinanceiraDTO> DAL = new NHibernateDAL<FinLctoPagarNtFinanceiraDTO>(session);
                    objP.ListaNaturezaFinanceira = DAL.select<FinLctoPagarNtFinanceiraDTO>(
                        new FinLctoPagarNtFinanceiraDTO { IdFinLancamentoPagar = objP.Id });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public IList<FinLancamentoPagarDTO> selectPagina(int primeiroResultado, int quantidadeResultados, FinLancamentoPagarDTO objeto)
        {
            try
            {
                IList<FinLancamentoPagarDTO> resultado = base.selectPagina<FinLancamentoPagarDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (FinLancamentoPagarDTO objLista in resultado)
                {
                    NHibernateDAL<FinParcelaPagarDTO> DAL = new NHibernateDAL<FinParcelaPagarDTO>(session);
                    objLista.ListaFinParcelaPagar = DAL.select<FinParcelaPagarDTO>(
                        new FinParcelaPagarDTO { IdFinLancamentoPagar = objLista.Id });
                }

                foreach (FinLancamentoPagarDTO objLista in resultado)
                {
                    NHibernateDAL<FinLctoPagarNtFinanceiraDTO> DAL = new NHibernateDAL<FinLctoPagarNtFinanceiraDTO>(session);
                    objLista.ListaNaturezaFinanceira = DAL.select<FinLctoPagarNtFinanceiraDTO>(
                        new FinLctoPagarNtFinanceiraDTO { IdFinLancamentoPagar = objLista.Id });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public int delete(FinLancamentoPagarDTO objeto)
        {
            try
            {
                IList<FinParcelaPagarDTO> listaExclusaoParcelaPagar = session.CreateCriteria(typeof(FinParcelaPagarDTO)).
                    Add(Expression.Eq("IdFinLancamentoPagar", objeto.Id)).List<FinParcelaPagarDTO>();

                foreach (FinParcelaPagarDTO objLista in listaExclusaoParcelaPagar)
                {
                    session.Delete(objLista);
                }

                IList<FinLctoPagarNtFinanceiraDTO> listaExclusaoNaturezaFinanceira = session.CreateCriteria(typeof(FinLctoPagarNtFinanceiraDTO)).
                    Add(Expression.Eq("IdFinLancamentoPagar", objeto.Id)).List<FinLctoPagarNtFinanceiraDTO>();

                foreach (FinLctoPagarNtFinanceiraDTO objLista in listaExclusaoNaturezaFinanceira)
                {
                    session.Delete(objLista);
                }

                int resultado = base.delete<FinLancamentoPagarDTO>(objeto);

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
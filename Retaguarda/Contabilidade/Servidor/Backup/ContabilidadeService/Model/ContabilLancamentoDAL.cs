using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace ContabilidadeService.Model
{
    public class ContabilLancamentoDAL : NHibernateDAL<ContabilLancamentoCabecalhoDTO>
    {
        public ContabilLancamentoDAL(ISession session) : base(session) { }

        public ContabilLancamentoCabecalhoDTO saveOrUpdate(ContabilLancamentoCabecalhoDTO objeto)
        {
            try
            {
                base.saveOrUpdate<ContabilLancamentoCabecalhoDTO>(objeto);

                IList<ContabilLancamentoDetalheDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(ContabilLancamentoDetalheDTO)).
                    Add(Expression.Eq("IdContabilLancamentoCabecalho", objeto.Id)).List<ContabilLancamentoDetalheDTO>();

                foreach (ContabilLancamentoDetalheDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }
                
                if(objeto.ListaContabilLancamentoDetalhe != null)
                foreach (ContabilLancamentoDetalheDTO objLista in objeto.ListaContabilLancamentoDetalhe)
                {
                    objLista.IdContabilLancamentoCabecalho = objeto.Id;
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
        public IList<ContabilLancamentoCabecalhoDTO> select(ContabilLancamentoCabecalhoDTO objeto)
        {
            try
            {

                IList<ContabilLancamentoCabecalhoDTO> resultado = base.select<ContabilLancamentoCabecalhoDTO>(objeto);

                foreach (ContabilLancamentoCabecalhoDTO objP in resultado)
                {
                    NHibernateDAL<ContabilLancamentoDetalheDTO> DAL = new NHibernateDAL<ContabilLancamentoDetalheDTO>(session);
                    objP.ListaContabilLancamentoDetalhe = DAL.select<ContabilLancamentoDetalheDTO>(
                        new ContabilLancamentoDetalheDTO { IdContabilLancamentoCabecalho = objP.Id });

                    if (objP.ListaContabilLancamentoDetalhe == null)
                        objP.ListaContabilLancamentoDetalhe = new List<ContabilLancamentoDetalheDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<ContabilLancamentoCabecalhoDTO> selectPagina(int primeiroResultado, int quantidadeResultados, ContabilLancamentoCabecalhoDTO objeto)
        {
            try
            {
                IList<ContabilLancamentoCabecalhoDTO> resultado = base.selectPagina<ContabilLancamentoCabecalhoDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (ContabilLancamentoCabecalhoDTO objLista in resultado)
                {
                    NHibernateDAL<ContabilLancamentoDetalheDTO> DAL = new NHibernateDAL<ContabilLancamentoDetalheDTO>(session);
                    objLista.ListaContabilLancamentoDetalhe = DAL.select<ContabilLancamentoDetalheDTO>(
                        new ContabilLancamentoDetalheDTO { IdContabilLancamentoCabecalho = objLista.Id });

                    if (objLista.ListaContabilLancamentoDetalhe == null)
                        objLista.ListaContabilLancamentoDetalhe = new List<ContabilLancamentoDetalheDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(ContabilLancamentoCabecalhoDTO objeto)
        {
            try
            {
                IList<ContabilLancamentoDetalheDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(ContabilLancamentoDetalheDTO)).
                    Add(Expression.Eq("IdContabilLancamentoCabecalho", objeto.Id)).List<ContabilLancamentoDetalheDTO>();

                foreach (ContabilLancamentoDetalheDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }

                int resultado = base.delete<ContabilLancamentoCabecalhoDTO>(objeto);

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
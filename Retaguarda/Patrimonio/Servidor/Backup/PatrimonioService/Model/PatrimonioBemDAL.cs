using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace PatrimonioService.Model
{
    public class PatrimonioBemDAL : NHibernateDAL<PatrimBemDTO>
    {
        public PatrimonioBemDAL(ISession session) : base(session) { }

        public PatrimBemDTO saveOrUpdate(PatrimBemDTO objeto)
        {
            try
            {
                base.saveOrUpdate<PatrimBemDTO>(objeto);

                IList<PatrimDepreciacaoBemDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(PatrimDepreciacaoBemDTO)).
                    Add(Expression.Eq("IdPatrimBem", objeto.Id)).List<PatrimDepreciacaoBemDTO>();

                foreach (PatrimDepreciacaoBemDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }
                
                if(objeto.ListaPatrimDepreciacaoBem != null)
                foreach (PatrimDepreciacaoBemDTO objLista in objeto.ListaPatrimDepreciacaoBem)
                {
                    objLista.IdPatrimBem = objeto.Id;
                    session.Save(objLista);
                }

                IList<PatrimMovimentacaoBemDTO> listaExclusaoMovim = session.CreateCriteria(typeof(PatrimMovimentacaoBemDTO)).
                    Add(Expression.Eq("IdPatrimBem", objeto.Id)).List<PatrimMovimentacaoBemDTO>();

                foreach (PatrimMovimentacaoBemDTO objLista in listaExclusaoMovim)
                {
                    session.Delete(objLista);
                }

                if (objeto.ListaPatrimMovimentacaoBem != null)
                foreach (PatrimMovimentacaoBemDTO objLista in objeto.ListaPatrimMovimentacaoBem)
                {
                    objLista.IdPatrimBem = objeto.Id;
                    session.Save(objLista);
                }

                IList<PatrimDocumentoBemDTO> listaExclusaoDoc = session.CreateCriteria(typeof(PatrimDocumentoBemDTO)).
                    Add(Expression.Eq("IdPatrimBem", objeto.Id)).List<PatrimDocumentoBemDTO>();

                foreach (PatrimDocumentoBemDTO objLista in listaExclusaoDoc)
                {
                    session.Delete(objLista);
                }

                if (objeto.ListaPatrimDocumentoBem != null)
                foreach (PatrimDocumentoBemDTO objLista in objeto.ListaPatrimDocumentoBem)
                {
                    objLista.IdPatrimBem = objeto.Id;
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
        public IList<PatrimBemDTO> select(PatrimBemDTO objeto)
        {
            try
            {

                IList<PatrimBemDTO> resultado = base.select<PatrimBemDTO>(objeto);

                foreach (PatrimBemDTO objP in resultado)
                {
                    NHibernateDAL<PatrimDepreciacaoBemDTO> DAL = new NHibernateDAL<PatrimDepreciacaoBemDTO>(session);
                    objP.ListaPatrimDepreciacaoBem = DAL.select<PatrimDepreciacaoBemDTO>(
                        new PatrimDepreciacaoBemDTO { IdPatrimBem = objP.Id });
                }

                foreach (PatrimBemDTO objP in resultado)
                {
                    NHibernateDAL<PatrimMovimentacaoBemDTO> DAL = new NHibernateDAL<PatrimMovimentacaoBemDTO>(session);
                    objP.ListaPatrimMovimentacaoBem = DAL.select<PatrimMovimentacaoBemDTO>(
                        new PatrimMovimentacaoBemDTO { IdPatrimBem = objP.Id });
                }

                foreach (PatrimBemDTO objP in resultado)
                {
                    NHibernateDAL<PatrimDocumentoBemDTO> DAL = new NHibernateDAL<PatrimDocumentoBemDTO>(session);
                    objP.ListaPatrimDocumentoBem = DAL.select<PatrimDocumentoBemDTO>(
                        new PatrimDocumentoBemDTO { IdPatrimBem = objP.Id });
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<PatrimBemDTO> selectPagina(int primeiroResultado, int quantidadeResultados, PatrimBemDTO objeto)
        {
            try
            {
                IList<PatrimBemDTO> resultado = base.selectPagina<PatrimBemDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (PatrimBemDTO objLista in resultado)
                {
                    NHibernateDAL<PatrimDepreciacaoBemDTO> DAL = new NHibernateDAL<PatrimDepreciacaoBemDTO>(session);
                    objLista.ListaPatrimDepreciacaoBem = DAL.select<PatrimDepreciacaoBemDTO>(
                        new PatrimDepreciacaoBemDTO { IdPatrimBem = objLista.Id });
                }

                foreach (PatrimBemDTO objLista in resultado)
                {
                    NHibernateDAL<PatrimMovimentacaoBemDTO> DAL = new NHibernateDAL<PatrimMovimentacaoBemDTO>(session);
                    objLista.ListaPatrimMovimentacaoBem = DAL.select<PatrimMovimentacaoBemDTO>(
                        new PatrimMovimentacaoBemDTO { IdPatrimBem = objLista.Id });
                }

                foreach (PatrimBemDTO objLista in resultado)
                {
                    NHibernateDAL<PatrimDocumentoBemDTO> DAL = new NHibernateDAL<PatrimDocumentoBemDTO>(session);
                    objLista.ListaPatrimDocumentoBem = DAL.select<PatrimDocumentoBemDTO>(
                        new PatrimDocumentoBemDTO { IdPatrimBem = objLista.Id });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(PatrimBemDTO objeto)
        {
            try
            {
                IList<PatrimDepreciacaoBemDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(PatrimDepreciacaoBemDTO)).
                    Add(Expression.Eq("IdPatrimBem", objeto.Id)).List<PatrimDepreciacaoBemDTO>();

                foreach (PatrimDepreciacaoBemDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }

                IList<PatrimMovimentacaoBemDTO> listaExclusaoMovim = session.CreateCriteria(typeof(PatrimMovimentacaoBemDTO)).
                    Add(Expression.Eq("IdPatrimBem", objeto.Id)).List<PatrimMovimentacaoBemDTO>();

                foreach (PatrimMovimentacaoBemDTO objLista in listaExclusaoMovim)
                {
                    session.Delete(objLista);
                }

                IList<PatrimDocumentoBemDTO> listaExclusaoDoc = session.CreateCriteria(typeof(PatrimDocumentoBemDTO)).
                    Add(Expression.Eq("IdPatrimBem", objeto.Id)).List<PatrimDocumentoBemDTO>();

                foreach (PatrimDocumentoBemDTO objLista in listaExclusaoDoc)
                {
                    session.Delete(objLista);
                }

                int resultado = base.delete<PatrimBemDTO>(objeto);

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace ContabilidadeService.Model
{
    public class ContabilLivroDAL : NHibernateDAL<ContabilLivroDTO>
    {
        public ContabilLivroDAL(ISession session) : base(session) { }

        public ContabilLivroDTO saveOrUpdate(ContabilLivroDTO objeto)
        {
            try
            {
                base.saveOrUpdate<ContabilLivroDTO>(objeto);

                IList<ContabilTermoDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(ContabilTermoDTO)).
                    Add(Expression.Eq("IdContabilLivro", objeto.Id)).List<ContabilTermoDTO>();

                foreach (ContabilTermoDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }
                
                if(objeto.ListaContabilTermo != null)
                foreach (ContabilTermoDTO objLista in objeto.ListaContabilTermo)
                {
                    objLista.IdContabilLivro = objeto.Id;
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
        public IList<ContabilLivroDTO> select(ContabilLivroDTO objeto)
        {
            try
            {

                IList<ContabilLivroDTO> resultado = base.select<ContabilLivroDTO>(objeto);

                foreach (ContabilLivroDTO objP in resultado)
                {
                    NHibernateDAL<ContabilTermoDTO> DAL = new NHibernateDAL<ContabilTermoDTO>(session);
                    objP.ListaContabilTermo = DAL.select<ContabilTermoDTO>(
                        new ContabilTermoDTO { IdContabilLivro = objP.Id });

                    if (objP.ListaContabilTermo == null)
                        objP.ListaContabilTermo = new List<ContabilTermoDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<ContabilLivroDTO> selectPagina(int primeiroResultado, int quantidadeResultados, ContabilLivroDTO objeto)
        {
            try
            {
                IList<ContabilLivroDTO> resultado = base.selectPagina<ContabilLivroDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (ContabilLivroDTO objLista in resultado)
                {
                    NHibernateDAL<ContabilTermoDTO> DAL = new NHibernateDAL<ContabilTermoDTO>(session);
                    objLista.ListaContabilTermo = DAL.select<ContabilTermoDTO>(
                        new ContabilTermoDTO { IdContabilLivro = objLista.Id });

                    if (objLista.ListaContabilTermo == null)
                        objLista.ListaContabilTermo = new List<ContabilTermoDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(ContabilLivroDTO objeto)
        {
            try
            {
                IList<ContabilTermoDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(ContabilTermoDTO)).
                    Add(Expression.Eq("IdContabilLivro", objeto.Id)).List<ContabilTermoDTO>();

                foreach (ContabilTermoDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }

                int resultado = base.delete<ContabilLivroDTO>(objeto);

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace ContabilidadeService.Model
{
    public class NHibernateDAL<T> : IDAL<T>
    {
        protected ISession session;
        public NHibernateDAL(ISession session)
        {
            this.session = session;
        }
        public virtual T save<T>(T objeto)
        {
            try
            {
                session.Save(objeto);
                return objeto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T update<T>(T objeto)
        {
            try
            {
                session.Update(objeto);
                return objeto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual int delete<T>(T objeto)
        {
            try
            {
                int resultado = -1;
                session.Delete(objeto);
                resultado = 0;
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IList<T> select<T>(T objeto)
        {
            try
            {
                IList<T> resultado = new List<T>();
                Example example = Example.Create(objeto).EnableLike(MatchMode.Anywhere).IgnoreCase().ExcludeNulls().ExcludeZeroes();
                resultado = session.CreateCriteria(typeof(T)).Add(example).List<T>();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T selectId<T>(int id)
        {
            try
            {
                T resultado = session.Get<T>(id);
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public virtual T saveOrUpdate<T>(T objeto)
        {
            try
            {
                session.SaveOrUpdate(objeto);
                return objeto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IList<T> selectPagina<T>(int primeiroResultado, int quantidadeResultados, T objeto)
        {
            try
            {
                IList<T> resultado = new List<T>();
                Example example = Example.Create(objeto).EnableLike(MatchMode.Anywhere).IgnoreCase().ExcludeNulls().ExcludeZeroes();
                resultado = session.CreateCriteria(typeof(T)).Add(example).SetFirstResult(primeiroResultado)
                    .SetMaxResults(quantidadeResultados).List<T>();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T selectObjetoSql<T>(String consultaSql)
        {
            try
            {
                IQuery consulta = session.CreateQuery(consultaSql);
                IList<T> lista = consulta.List<T>();

                T resultado = default(T);

                if (lista.Count > 0)
                {
                    resultado = lista[0];
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public virtual IList<T> selectListaSql<T>(String consultaSql)
        {
            try
            {
                IQuery consulta = session.CreateQuery(consultaSql);
                IList<T> resultado = new List<T>();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace EscritaFiscalService.Model
{
    public class FiscalLivroDAL : NHibernateDAL<FiscalLivroDTO>
    {
        public FiscalLivroDAL(ISession session) : base(session) { }

        public FiscalLivroDTO saveOrUpdate(FiscalLivroDTO objeto)
        {
            try
            {
                base.saveOrUpdate<FiscalLivroDTO>(objeto);

                IList<FiscalTermoDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(FiscalTermoDTO)).
                    Add(Expression.Eq("IdFiscalLivro", objeto.Id)).List<FiscalTermoDTO>();

                foreach (FiscalTermoDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }
                
                if(objeto.ListaFiscalTermo != null)
                foreach (FiscalTermoDTO objLista in objeto.ListaFiscalTermo)
                {
                    objLista.IdFiscalLivro = objeto.Id;
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
        public IList<FiscalLivroDTO> select(FiscalLivroDTO objeto)
        {
            try
            {

                IList<FiscalLivroDTO> resultado = base.select<FiscalLivroDTO>(objeto);

                foreach (FiscalLivroDTO objP in resultado)
                {
                    NHibernateDAL<FiscalTermoDTO> DAL = new NHibernateDAL<FiscalTermoDTO>(session);
                    objP.ListaFiscalTermo = DAL.select<FiscalTermoDTO>(
                        new FiscalTermoDTO { IdFiscalLivro = objP.Id });

                    if (objP.ListaFiscalTermo == null)
                        objP.ListaFiscalTermo = new List<FiscalTermoDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<FiscalLivroDTO> selectPagina(int primeiroResultado, int quantidadeResultados, FiscalLivroDTO objeto)
        {
            try
            {
                IList<FiscalLivroDTO> resultado = base.selectPagina<FiscalLivroDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (FiscalLivroDTO objLista in resultado)
                {
                    NHibernateDAL<FiscalTermoDTO> DAL = new NHibernateDAL<FiscalTermoDTO>(session);
                    objLista.ListaFiscalTermo = DAL.select<FiscalTermoDTO>(
                        new FiscalTermoDTO { IdFiscalLivro = objLista.Id });

                    if (objLista.ListaFiscalTermo == null)
                        objLista.ListaFiscalTermo = new List<FiscalTermoDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(FiscalLivroDTO objeto)
        {
            try
            {
                IList<FiscalTermoDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(FiscalTermoDTO)).
                    Add(Expression.Eq("IdFiscalLivro", objeto.Id)).List<FiscalTermoDTO>();

                foreach (FiscalTermoDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }

                int resultado = base.delete<FiscalLivroDTO>(objeto);

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
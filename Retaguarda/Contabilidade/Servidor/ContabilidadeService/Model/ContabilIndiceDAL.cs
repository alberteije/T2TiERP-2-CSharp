using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace ContabilidadeService.Model
{
    public class ContabilIndiceDAL : NHibernateDAL<ContabilIndiceDTO>
    {
        public ContabilIndiceDAL(ISession session) : base(session) { }

        public ContabilIndiceDTO saveOrUpdate(ContabilIndiceDTO objeto)
        {
            try
            {
                base.saveOrUpdate<ContabilIndiceDTO>(objeto);

                IList<ContabilIndiceValorDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(ContabilIndiceValorDTO)).
                    Add(Expression.Eq("IdContabilIndice", objeto.Id)).List<ContabilIndiceValorDTO>();

                foreach (ContabilIndiceValorDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }
                
                if(objeto.ListaContabilIndiceValor != null)
                foreach (ContabilIndiceValorDTO objLista in objeto.ListaContabilIndiceValor)
                {
                    objLista.IdContabilIndice = objeto.Id;
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
        public IList<ContabilIndiceDTO> select(ContabilIndiceDTO objeto)
        {
            try
            {

                IList<ContabilIndiceDTO> resultado = base.select<ContabilIndiceDTO>(objeto);

                foreach (ContabilIndiceDTO objP in resultado)
                {
                    NHibernateDAL<ContabilIndiceValorDTO> DAL = new NHibernateDAL<ContabilIndiceValorDTO>(session);
                    objP.ListaContabilIndiceValor = DAL.select<ContabilIndiceValorDTO>(
                        new ContabilIndiceValorDTO { IdContabilIndice = objP.Id });

                    if (objP.ListaContabilIndiceValor == null)
                        objP.ListaContabilIndiceValor = new List<ContabilIndiceValorDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<ContabilIndiceDTO> selectPagina(int primeiroResultado, int quantidadeResultados, ContabilIndiceDTO objeto)
        {
            try
            {
                IList<ContabilIndiceDTO> resultado = base.selectPagina<ContabilIndiceDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (ContabilIndiceDTO objLista in resultado)
                {
                    NHibernateDAL<ContabilIndiceValorDTO> DAL = new NHibernateDAL<ContabilIndiceValorDTO>(session);
                    objLista.ListaContabilIndiceValor = DAL.select<ContabilIndiceValorDTO>(
                        new ContabilIndiceValorDTO { IdContabilIndice = objLista.Id });

                    if (objLista.ListaContabilIndiceValor == null)
                        objLista.ListaContabilIndiceValor = new List<ContabilIndiceValorDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(ContabilIndiceDTO objeto)
        {
            try
            {
                IList<ContabilIndiceValorDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(ContabilIndiceValorDTO)).
                    Add(Expression.Eq("IdContabilIndice", objeto.Id)).List<ContabilIndiceValorDTO>();

                foreach (ContabilIndiceValorDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }

                int resultado = base.delete<ContabilIndiceDTO>(objeto);

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
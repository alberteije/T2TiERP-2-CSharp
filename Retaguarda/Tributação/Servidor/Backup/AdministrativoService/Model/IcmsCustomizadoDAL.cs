using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace AdministrativoService.Model
{
    public class IcmsCustomizadoDAL : NHibernateDAL<TributIcmsCustomCabDTO>
    {
        public IcmsCustomizadoDAL(ISession session) : base(session) { }

        public TributIcmsCustomCabDTO saveOrUpdate(TributIcmsCustomCabDTO objeto)
        {
            try
            {
                base.saveOrUpdate<TributIcmsCustomCabDTO>(objeto);

                IList<TributIcmsCustomDetDTO> listaExclusao = session.CreateCriteria(typeof(TributIcmsCustomDetDTO)).
                    Add(Expression.Eq("IdTributIcmsCustomCab", objeto.Id)).List<TributIcmsCustomDetDTO>();

                foreach (TributIcmsCustomDetDTO objLista in listaExclusao)
                {
                    session.Delete(objLista);
                }
                
                foreach (TributIcmsCustomDetDTO objLista in objeto.ListaTributIcmsCustomDet)
                {
                    objLista.IdTributIcmsCustomCab = objeto.Id;
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
        public IList<TributIcmsCustomCabDTO> select(TributIcmsCustomCabDTO objeto)
        {
            try
            {

                IList<TributIcmsCustomCabDTO> resultado = base.select<TributIcmsCustomCabDTO>(objeto);

                foreach (TributIcmsCustomCabDTO objP in resultado)
                {
                    NHibernateDAL<TributIcmsCustomDetDTO> DAL = new NHibernateDAL<TributIcmsCustomDetDTO>(session);
                    objP.ListaTributIcmsCustomDet = DAL.select<TributIcmsCustomDetDTO>(
                        new TributIcmsCustomDetDTO { IdTributIcmsCustomCab = objP.Id });
                    
                    if (objP.ListaTributIcmsCustomDet == null)
                        objP.ListaTributIcmsCustomDet = new List<TributIcmsCustomDetDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<TributIcmsCustomCabDTO> selectPagina(int primeiroResultado, int quantidadeResultados, TributIcmsCustomCabDTO objeto)
        {
            try
            {
                IList<TributIcmsCustomCabDTO> resultado = base.selectPagina<TributIcmsCustomCabDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (TributIcmsCustomCabDTO objLista in resultado)
                {
                    NHibernateDAL<TributIcmsCustomDetDTO> DAL = new NHibernateDAL<TributIcmsCustomDetDTO>(session);
                    objLista.ListaTributIcmsCustomDet = DAL.select<TributIcmsCustomDetDTO>(
                        new TributIcmsCustomDetDTO { IdTributIcmsCustomCab = objLista.Id });

                    if (objLista.ListaTributIcmsCustomDet == null)
                        objLista.ListaTributIcmsCustomDet = new List<TributIcmsCustomDetDTO>();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(TributIcmsCustomCabDTO objeto)
        {
            try
            {
                IList<TributIcmsCustomDetDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(TributIcmsCustomDetDTO)).
                    Add(Expression.Eq("IdTributIcmsCustomCab", objeto.Id)).List<TributIcmsCustomDetDTO>();

                foreach (TributIcmsCustomDetDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }

                int resultado = base.delete<TributIcmsCustomCabDTO>(objeto);

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
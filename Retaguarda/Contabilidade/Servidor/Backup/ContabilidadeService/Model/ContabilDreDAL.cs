using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace ContabilidadeService.Model
{
    public class ContabilDreDAL : NHibernateDAL<ContabilDreCabecalhoDTO>
    {
        public ContabilDreDAL(ISession session) : base(session) { }

        public ContabilDreCabecalhoDTO saveOrUpdate(ContabilDreCabecalhoDTO objeto)
        {
            try
            {
                base.saveOrUpdate<ContabilDreCabecalhoDTO>(objeto);

                IList<ContabilDreDetalheDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(ContabilDreDetalheDTO)).
                    Add(Expression.Eq("IdContabilDreCabecalho", objeto.Id)).List<ContabilDreDetalheDTO>();

                foreach (ContabilDreDetalheDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }
                
                if(objeto.ListaContabilDreDetalhe != null)
                foreach (ContabilDreDetalheDTO objLista in objeto.ListaContabilDreDetalhe)
                {
                    objLista.IdContabilDreCabecalho = objeto.Id;
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
        public IList<ContabilDreCabecalhoDTO> select(ContabilDreCabecalhoDTO objeto)
        {
            try
            {

                IList<ContabilDreCabecalhoDTO> resultado = base.select<ContabilDreCabecalhoDTO>(objeto);

                foreach (ContabilDreCabecalhoDTO objP in resultado)
                {
                    NHibernateDAL<ContabilDreDetalheDTO> DAL = new NHibernateDAL<ContabilDreDetalheDTO>(session);
                    objP.ListaContabilDreDetalhe = DAL.select<ContabilDreDetalheDTO>(
                        new ContabilDreDetalheDTO { IdContabilDreCabecalho = objP.Id });

                    if (objP.ListaContabilDreDetalhe == null)
                        objP.ListaContabilDreDetalhe = new List<ContabilDreDetalheDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<ContabilDreCabecalhoDTO> selectPagina(int primeiroResultado, int quantidadeResultados, ContabilDreCabecalhoDTO objeto)
        {
            try
            {
                IList<ContabilDreCabecalhoDTO> resultado = base.selectPagina<ContabilDreCabecalhoDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (ContabilDreCabecalhoDTO objLista in resultado)
                {
                    NHibernateDAL<ContabilDreDetalheDTO> DAL = new NHibernateDAL<ContabilDreDetalheDTO>(session);
                    objLista.ListaContabilDreDetalhe = DAL.select<ContabilDreDetalheDTO>(
                        new ContabilDreDetalheDTO { IdContabilDreCabecalho = objLista.Id });

                    if (objLista.ListaContabilDreDetalhe == null)
                        objLista.ListaContabilDreDetalhe = new List<ContabilDreDetalheDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(ContabilDreCabecalhoDTO objeto)
        {
            try
            {
                IList<ContabilDreDetalheDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(ContabilDreDetalheDTO)).
                    Add(Expression.Eq("IdContabilDreCabecalho", objeto.Id)).List<ContabilDreDetalheDTO>();

                foreach (ContabilDreDetalheDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }

                int resultado = base.delete<ContabilDreCabecalhoDTO>(objeto);

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
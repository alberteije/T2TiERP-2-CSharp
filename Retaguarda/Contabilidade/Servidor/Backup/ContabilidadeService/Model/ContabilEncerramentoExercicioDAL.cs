using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace ContabilidadeService.Model
{
    public class ContabilEncerramentoExercicioDAL : NHibernateDAL<ContabilEncerramentoExeCabDTO>
    {
        public ContabilEncerramentoExercicioDAL(ISession session) : base(session) { }

        public ContabilEncerramentoExeCabDTO saveOrUpdate(ContabilEncerramentoExeCabDTO objeto)
        {
            try
            {
                base.saveOrUpdate<ContabilEncerramentoExeCabDTO>(objeto);

                IList<ContabilEncerramentoExeDetDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(ContabilEncerramentoExeDetDTO)).
                    Add(Expression.Eq("IdContabilEncerramentoExeCab", objeto.Id)).List<ContabilEncerramentoExeDetDTO>();

                foreach (ContabilEncerramentoExeDetDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }
                
                if(objeto.ListaContabilEncerramentoExeDet != null)
                foreach (ContabilEncerramentoExeDetDTO objLista in objeto.ListaContabilEncerramentoExeDet)
                {
                    objLista.IdContabilEncerramentoExeCab = objeto.Id;
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
        public IList<ContabilEncerramentoExeCabDTO> select(ContabilEncerramentoExeCabDTO objeto)
        {
            try
            {

                IList<ContabilEncerramentoExeCabDTO> resultado = base.select<ContabilEncerramentoExeCabDTO>(objeto);

                foreach (ContabilEncerramentoExeCabDTO objP in resultado)
                {
                    NHibernateDAL<ContabilEncerramentoExeDetDTO> DAL = new NHibernateDAL<ContabilEncerramentoExeDetDTO>(session);
                    objP.ListaContabilEncerramentoExeDet = DAL.select<ContabilEncerramentoExeDetDTO>(
                        new ContabilEncerramentoExeDetDTO { IdContabilEncerramentoExeCab = objP.Id });

                    if (objP.ListaContabilEncerramentoExeDet == null)
                        objP.ListaContabilEncerramentoExeDet = new List<ContabilEncerramentoExeDetDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<ContabilEncerramentoExeCabDTO> selectPagina(int primeiroResultado, int quantidadeResultados, ContabilEncerramentoExeCabDTO objeto)
        {
            try
            {
                IList<ContabilEncerramentoExeCabDTO> resultado = base.selectPagina<ContabilEncerramentoExeCabDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (ContabilEncerramentoExeCabDTO objLista in resultado)
                {
                    NHibernateDAL<ContabilEncerramentoExeDetDTO> DAL = new NHibernateDAL<ContabilEncerramentoExeDetDTO>(session);
                    objLista.ListaContabilEncerramentoExeDet = DAL.select<ContabilEncerramentoExeDetDTO>(
                        new ContabilEncerramentoExeDetDTO { IdContabilEncerramentoExeCab = objLista.Id });

                    if (objLista.ListaContabilEncerramentoExeDet == null)
                        objLista.ListaContabilEncerramentoExeDet = new List<ContabilEncerramentoExeDetDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(ContabilEncerramentoExeCabDTO objeto)
        {
            try
            {
                IList<ContabilEncerramentoExeDetDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(ContabilEncerramentoExeDetDTO)).
                    Add(Expression.Eq("IdContabilEncerramentoExeCab", objeto.Id)).List<ContabilEncerramentoExeDetDTO>();

                foreach (ContabilEncerramentoExeDetDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }

                int resultado = base.delete<ContabilEncerramentoExeCabDTO>(objeto);

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
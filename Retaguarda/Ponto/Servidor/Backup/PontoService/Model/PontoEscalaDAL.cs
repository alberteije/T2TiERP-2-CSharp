using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace PontoService.Model
{
    public class PontoEscalaDAL : NHibernateDAL<PontoEscalaDTO>
    {
        public PontoEscalaDAL(ISession session) : base(session) { }

        public PontoEscalaDTO saveOrUpdate(PontoEscalaDTO objeto)
        {
            try
            {
                base.saveOrUpdate<PontoEscalaDTO>(objeto);

                IList<PontoTurmaDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(PontoTurmaDTO)).
                    Add(Expression.Eq("IdPontoEscala", objeto.Id)).List<PontoTurmaDTO>();

                foreach (PontoTurmaDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }
                
                if(objeto.ListaPontoTurma != null)
                foreach (PontoTurmaDTO objLista in objeto.ListaPontoTurma)
                {
                    objLista.IdPontoEscala = objeto.Id;
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
        public IList<PontoEscalaDTO> select(PontoEscalaDTO objeto)
        {
            try
            {

                IList<PontoEscalaDTO> resultado = base.select<PontoEscalaDTO>(objeto);

                foreach (PontoEscalaDTO objP in resultado)
                {
                    NHibernateDAL<PontoTurmaDTO> DAL = new NHibernateDAL<PontoTurmaDTO>(session);
                    objP.ListaPontoTurma = DAL.select<PontoTurmaDTO>(
                        new PontoTurmaDTO { IdPontoEscala = objP.Id });

                    if (objP.ListaPontoTurma == null)
                        objP.ListaPontoTurma = new List<PontoTurmaDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<PontoEscalaDTO> selectPagina(int primeiroResultado, int quantidadeResultados, PontoEscalaDTO objeto)
        {
            try
            {
                IList<PontoEscalaDTO> resultado = base.selectPagina<PontoEscalaDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (PontoEscalaDTO objLista in resultado)
                {
                    NHibernateDAL<PontoTurmaDTO> DAL = new NHibernateDAL<PontoTurmaDTO>(session);
                    objLista.ListaPontoTurma = DAL.select<PontoTurmaDTO>(
                        new PontoTurmaDTO { IdPontoEscala = objLista.Id });

                    if (objLista.ListaPontoTurma == null)
                        objLista.ListaPontoTurma = new List<PontoTurmaDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(PontoEscalaDTO objeto)
        {
            try
            {
                IList<PontoTurmaDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(PontoTurmaDTO)).
                    Add(Expression.Eq("IdPontoEscala", objeto.Id)).List<PontoTurmaDTO>();

                foreach (PontoTurmaDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }

                int resultado = base.delete<PontoEscalaDTO>(objeto);

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
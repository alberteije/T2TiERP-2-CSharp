using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace FolhaService.Model
{
    public class FolhaPppDAL : NHibernateDAL<FolhaPppDTO>
    {
        public FolhaPppDAL(ISession session) : base(session) { }

        public FolhaPppDTO saveOrUpdate(FolhaPppDTO objeto)
        {
            try
            {
                base.saveOrUpdate<FolhaPppDTO>(objeto);

                IList<FolhaPppAtividadeDTO> listaFolhaPppAtividade = session.CreateCriteria(typeof(FolhaPppAtividadeDTO)).
                    Add(Expression.Eq("IdFolhaPpp", objeto.Id)).List<FolhaPppAtividadeDTO>();

                foreach (FolhaPppAtividadeDTO objLista in listaFolhaPppAtividade)
                {
                    session.Delete(objLista);
                }
                
                if(objeto.ListaFolhaPppAtividade != null)
                foreach (FolhaPppAtividadeDTO objLista in objeto.ListaFolhaPppAtividade)
                {
                    objLista.IdFolhaPpp = objeto.Id;
                    session.Save(objLista);
                }

                IList<FolhaPppCatDTO> listaFolhaPppCat = session.CreateCriteria(typeof(FolhaPppCatDTO)).
                    Add(Expression.Eq("IdFolhaPpp", objeto.Id)).List<FolhaPppCatDTO>();

                foreach (FolhaPppCatDTO objLista in listaFolhaPppCat)
                {
                    session.Delete(objLista);
                }

                if (objeto.ListaFolhaPppCat != null)
                foreach (FolhaPppCatDTO objLista in objeto.ListaFolhaPppCat)
                {
                    objLista.IdFolhaPpp = objeto.Id;
                    session.Save(objLista);
                }

                IList<FolhaPppExameMedicoDTO> listaFolhaPppExameMedico = session.CreateCriteria(typeof(FolhaPppExameMedicoDTO)).
                    Add(Expression.Eq("IdFolhaPpp", objeto.Id)).List<FolhaPppExameMedicoDTO>();

                foreach (FolhaPppExameMedicoDTO objLista in listaFolhaPppExameMedico)
                {
                    session.Delete(objLista);
                }

                if (objeto.ListaFolhaPppExameMedico != null)
                foreach (FolhaPppExameMedicoDTO objLista in objeto.ListaFolhaPppExameMedico)
                {
                    objLista.IdFolhaPpp = objeto.Id;
                    session.Save(objLista);
                }


                IList<FolhaPppFatorRiscoDTO> listaFolhaPppFatorRisco = session.CreateCriteria(typeof(FolhaPppFatorRiscoDTO)).
                    Add(Expression.Eq("IdFolhaPpp", objeto.Id)).List<FolhaPppFatorRiscoDTO>();

                foreach (FolhaPppFatorRiscoDTO objLista in listaFolhaPppFatorRisco)
                {
                    session.Delete(objLista);
                }

                if (objeto.ListaFolhaPppFatorRisco != null)
                    foreach (FolhaPppFatorRiscoDTO objLista in objeto.ListaFolhaPppFatorRisco)
                    {
                        objLista.IdFolhaPpp = objeto.Id;
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
        public IList<FolhaPppDTO> select(FolhaPppDTO objeto)
        {
            try
            {

                IList<FolhaPppDTO> resultado = base.select<FolhaPppDTO>(objeto);

                foreach (FolhaPppDTO objP in resultado)
                {
                    NHibernateDAL<FolhaPppAtividadeDTO> DAL = new NHibernateDAL<FolhaPppAtividadeDTO>(session);
                    objP.ListaFolhaPppAtividade = DAL.select<FolhaPppAtividadeDTO>(
                        new FolhaPppAtividadeDTO { IdFolhaPpp = objP.Id });
                }

                foreach (FolhaPppDTO objP in resultado)
                {
                    NHibernateDAL<FolhaPppCatDTO> DAL = new NHibernateDAL<FolhaPppCatDTO>(session);
                    objP.ListaFolhaPppCat = DAL.select<FolhaPppCatDTO>(
                        new FolhaPppCatDTO { IdFolhaPpp = objP.Id });
                }

                foreach (FolhaPppDTO objP in resultado)
                {
                    NHibernateDAL<FolhaPppExameMedicoDTO> DAL = new NHibernateDAL<FolhaPppExameMedicoDTO>(session);
                    objP.ListaFolhaPppExameMedico = DAL.select<FolhaPppExameMedicoDTO>(
                        new FolhaPppExameMedicoDTO { IdFolhaPpp = objP.Id });
                }

                foreach (FolhaPppDTO objP in resultado)
                {
                    NHibernateDAL<FolhaPppFatorRiscoDTO> DAL = new NHibernateDAL<FolhaPppFatorRiscoDTO>(session);
                    objP.ListaFolhaPppFatorRisco = DAL.select<FolhaPppFatorRiscoDTO>(
                        new FolhaPppFatorRiscoDTO { IdFolhaPpp = objP.Id });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<FolhaPppDTO> selectPagina(int primeiroResultado, int quantidadeResultados, FolhaPppDTO objeto)
        {
            try
            {
                IList<FolhaPppDTO> resultado = base.selectPagina<FolhaPppDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (FolhaPppDTO objLista in resultado)
                {
                    NHibernateDAL<FolhaPppAtividadeDTO> DAL = new NHibernateDAL<FolhaPppAtividadeDTO>(session);
                    objLista.ListaFolhaPppAtividade = DAL.select<FolhaPppAtividadeDTO>(
                        new FolhaPppAtividadeDTO { IdFolhaPpp = objLista.Id });
                }

                foreach (FolhaPppDTO objLista in resultado)
                {
                    NHibernateDAL<FolhaPppCatDTO> DAL = new NHibernateDAL<FolhaPppCatDTO>(session);
                    objLista.ListaFolhaPppCat = DAL.select<FolhaPppCatDTO>(
                        new FolhaPppCatDTO { IdFolhaPpp = objLista.Id });
                }

                foreach (FolhaPppDTO objLista in resultado)
                {
                    NHibernateDAL<FolhaPppExameMedicoDTO> DAL = new NHibernateDAL<FolhaPppExameMedicoDTO>(session);
                    objLista.ListaFolhaPppExameMedico = DAL.select<FolhaPppExameMedicoDTO>(
                        new FolhaPppExameMedicoDTO { IdFolhaPpp = objLista.Id });
                }

                foreach (FolhaPppDTO objLista in resultado)
                {
                    NHibernateDAL<FolhaPppFatorRiscoDTO> DAL = new NHibernateDAL<FolhaPppFatorRiscoDTO>(session);
                    objLista.ListaFolhaPppFatorRisco = DAL.select<FolhaPppFatorRiscoDTO>(
                        new FolhaPppFatorRiscoDTO { IdFolhaPpp = objLista.Id });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(FolhaPppDTO objeto)
        {
            try
            {
                IList<FolhaPppAtividadeDTO> listaFolhaPppAtividade = session.CreateCriteria(typeof(FolhaPppAtividadeDTO)).
                    Add(Expression.Eq("IdFolhaPpp", objeto.Id)).List<FolhaPppAtividadeDTO>();

                foreach (FolhaPppAtividadeDTO objLista in listaFolhaPppAtividade)
                {
                    session.Delete(objLista);
                }

                IList<FolhaPppCatDTO> listaFolhaPppCat = session.CreateCriteria(typeof(FolhaPppCatDTO)).
                    Add(Expression.Eq("IdFolhaPpp", objeto.Id)).List<FolhaPppCatDTO>();

                foreach (FolhaPppCatDTO objLista in listaFolhaPppCat)
                {
                    session.Delete(objLista);
                }

                IList<FolhaPppExameMedicoDTO> listaFolhaPppExameMedico = session.CreateCriteria(typeof(FolhaPppExameMedicoDTO)).
                    Add(Expression.Eq("IdFolhaPpp", objeto.Id)).List<FolhaPppExameMedicoDTO>();

                foreach (FolhaPppExameMedicoDTO objLista in listaFolhaPppExameMedico)
                {
                    session.Delete(objLista);
                }

                IList<FolhaPppFatorRiscoDTO> ListaFolhaPppFatorRisco = session.CreateCriteria(typeof(FolhaPppFatorRiscoDTO)).
                    Add(Expression.Eq("IdFolhaPpp", objeto.Id)).List<FolhaPppFatorRiscoDTO>();

                foreach (FolhaPppFatorRiscoDTO objLista in ListaFolhaPppFatorRisco)
                {
                    session.Delete(objLista);
                }


                int resultado = base.delete<FolhaPppDTO>(objeto);

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace AdministrativoService.Model
{
    public class ConfiguraTributacaoDAL : NHibernateDAL<TributConfiguraOfGtDTO>
    {
        public ConfiguraTributacaoDAL(ISession session) : base(session) { }

        public TributConfiguraOfGtDTO saveOrUpdate(TributConfiguraOfGtDTO objeto)
        {
            try
            {
                base.saveOrUpdate<TributConfiguraOfGtDTO>(objeto);

                IList<TributIpiDipiDTO> listaTributIpiDipi = session.CreateCriteria(typeof(TributIpiDipiDTO)).
                    Add(Expression.Eq("IdTributConfiguraOfGt", objeto.Id)).List<TributIpiDipiDTO>();

                foreach (TributIpiDipiDTO objLista in listaTributIpiDipi)
                {
                    session.Delete(objLista);
                }
                
                if(objeto.ListaTributIpiDipi != null)
                foreach (TributIpiDipiDTO objLista in objeto.ListaTributIpiDipi)
                {
                    objLista.IdTributConfiguraOfGt = objeto.Id;
                    session.Save(objLista);
                }

                IList<TributPisCodApuracaoDTO> listaTributPisCodApuracao = session.CreateCriteria(typeof(TributPisCodApuracaoDTO)).
                    Add(Expression.Eq("IdTributConfiguraOfGt", objeto.Id)).List<TributPisCodApuracaoDTO>();

                foreach (TributPisCodApuracaoDTO objLista in listaTributPisCodApuracao)
                {
                    session.Delete(objLista);
                }

                if (objeto.ListaTributPisCodApuracao != null)
                foreach (TributPisCodApuracaoDTO objLista in objeto.ListaTributPisCodApuracao)
                {
                    objLista.IdTributConfiguraOfGt = objeto.Id;
                    session.Save(objLista);
                }

                IList<TributCofinsCodApuracaoDTO> listaTributCofinsCodApuracao = session.CreateCriteria(typeof(TributCofinsCodApuracaoDTO)).
                    Add(Expression.Eq("IdTributConfiguraOfGt", objeto.Id)).List<TributCofinsCodApuracaoDTO>();

                foreach (TributCofinsCodApuracaoDTO objLista in listaTributCofinsCodApuracao)
                {
                    session.Delete(objLista);
                }

                if (objeto.ListaTributCofinsCodApuracao != null)
                foreach (TributCofinsCodApuracaoDTO objLista in objeto.ListaTributCofinsCodApuracao)
                {
                    objLista.IdTributConfiguraOfGt = objeto.Id;
                    session.Save(objLista);
                }


                IList<TributIcmsUfDTO> listaTributIcmsUf = session.CreateCriteria(typeof(TributIcmsUfDTO)).
                    Add(Expression.Eq("IdTributConfiguraOfGt", objeto.Id)).List<TributIcmsUfDTO>();

                foreach (TributIcmsUfDTO objLista in listaTributIcmsUf)
                {
                    session.Delete(objLista);
                }

                if (objeto.ListaTributIcmsUf != null)
                    foreach (TributIcmsUfDTO objLista in objeto.ListaTributIcmsUf)
                    {
                        objLista.IdTributConfiguraOfGt = objeto.Id;
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
        public IList<TributConfiguraOfGtDTO> select(TributConfiguraOfGtDTO objeto)
        {
            try
            {

                IList<TributConfiguraOfGtDTO> resultado = base.select<TributConfiguraOfGtDTO>(objeto);

                foreach (TributConfiguraOfGtDTO objP in resultado)
                {
                    NHibernateDAL<TributIpiDipiDTO> DAL = new NHibernateDAL<TributIpiDipiDTO>(session);
                    objP.ListaTributIpiDipi = DAL.select<TributIpiDipiDTO>(
                        new TributIpiDipiDTO { IdTributConfiguraOfGt = objP.Id });
                }

                foreach (TributConfiguraOfGtDTO objP in resultado)
                {
                    NHibernateDAL<TributPisCodApuracaoDTO> DAL = new NHibernateDAL<TributPisCodApuracaoDTO>(session);
                    objP.ListaTributPisCodApuracao = DAL.select<TributPisCodApuracaoDTO>(
                        new TributPisCodApuracaoDTO { IdTributConfiguraOfGt = objP.Id });
                }

                foreach (TributConfiguraOfGtDTO objP in resultado)
                {
                    NHibernateDAL<TributCofinsCodApuracaoDTO> DAL = new NHibernateDAL<TributCofinsCodApuracaoDTO>(session);
                    objP.ListaTributCofinsCodApuracao = DAL.select<TributCofinsCodApuracaoDTO>(
                        new TributCofinsCodApuracaoDTO { IdTributConfiguraOfGt = objP.Id });
                }

                foreach (TributConfiguraOfGtDTO objP in resultado)
                {
                    NHibernateDAL<TributIcmsUfDTO> DAL = new NHibernateDAL<TributIcmsUfDTO>(session);
                    objP.ListaTributIcmsUf = DAL.select<TributIcmsUfDTO>(
                        new TributIcmsUfDTO { IdTributConfiguraOfGt = objP.Id });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<TributConfiguraOfGtDTO> selectPagina(int primeiroResultado, int quantidadeResultados, TributConfiguraOfGtDTO objeto)
        {
            try
            {
                IList<TributConfiguraOfGtDTO> resultado = base.selectPagina<TributConfiguraOfGtDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (TributConfiguraOfGtDTO objLista in resultado)
                {
                    NHibernateDAL<TributIpiDipiDTO> DAL = new NHibernateDAL<TributIpiDipiDTO>(session);
                    objLista.ListaTributIpiDipi = DAL.select<TributIpiDipiDTO>(
                        new TributIpiDipiDTO { IdTributConfiguraOfGt = objLista.Id });
                }

                foreach (TributConfiguraOfGtDTO objLista in resultado)
                {
                    NHibernateDAL<TributPisCodApuracaoDTO> DAL = new NHibernateDAL<TributPisCodApuracaoDTO>(session);
                    objLista.ListaTributPisCodApuracao = DAL.select<TributPisCodApuracaoDTO>(
                        new TributPisCodApuracaoDTO { IdTributConfiguraOfGt = objLista.Id });
                }

                foreach (TributConfiguraOfGtDTO objLista in resultado)
                {
                    NHibernateDAL<TributCofinsCodApuracaoDTO> DAL = new NHibernateDAL<TributCofinsCodApuracaoDTO>(session);
                    objLista.ListaTributCofinsCodApuracao = DAL.select<TributCofinsCodApuracaoDTO>(
                        new TributCofinsCodApuracaoDTO { IdTributConfiguraOfGt = objLista.Id });
                }

                foreach (TributConfiguraOfGtDTO objLista in resultado)
                {
                    NHibernateDAL<TributIcmsUfDTO> DAL = new NHibernateDAL<TributIcmsUfDTO>(session);
                    objLista.ListaTributIcmsUf = DAL.select<TributIcmsUfDTO>(
                        new TributIcmsUfDTO { IdTributConfiguraOfGt = objLista.Id });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(TributConfiguraOfGtDTO objeto)
        {
            try
            {
                IList<TributIpiDipiDTO> listaTributIpiDipi = session.CreateCriteria(typeof(TributIpiDipiDTO)).
                    Add(Expression.Eq("IdTributConfiguraOfGt", objeto.Id)).List<TributIpiDipiDTO>();

                foreach (TributIpiDipiDTO objLista in listaTributIpiDipi)
                {
                    session.Delete(objLista);
                }

                IList<TributPisCodApuracaoDTO> listaTributPisCodApuracao = session.CreateCriteria(typeof(TributPisCodApuracaoDTO)).
                    Add(Expression.Eq("IdTributConfiguraOfGt", objeto.Id)).List<TributPisCodApuracaoDTO>();

                foreach (TributPisCodApuracaoDTO objLista in listaTributPisCodApuracao)
                {
                    session.Delete(objLista);
                }

                IList<TributCofinsCodApuracaoDTO> listaTributCofinsCodApuracao = session.CreateCriteria(typeof(TributCofinsCodApuracaoDTO)).
                    Add(Expression.Eq("IdTributConfiguraOfGt", objeto.Id)).List<TributCofinsCodApuracaoDTO>();

                foreach (TributCofinsCodApuracaoDTO objLista in listaTributCofinsCodApuracao)
                {
                    session.Delete(objLista);
                }

                IList<TributIcmsUfDTO> ListaTributIcmsUf = session.CreateCriteria(typeof(TributIcmsUfDTO)).
                    Add(Expression.Eq("IdTributConfiguraOfGt", objeto.Id)).List<TributIcmsUfDTO>();

                foreach (TributIcmsUfDTO objLista in ListaTributIcmsUf)
                {
                    session.Delete(objLista);
                }


                int resultado = base.delete<TributConfiguraOfGtDTO>(objeto);

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
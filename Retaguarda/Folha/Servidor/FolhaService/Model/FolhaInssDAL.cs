using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace FolhaService.Model
{
    public class FolhaInssDAL : NHibernateDAL<FolhaInssDTO>
    {
        public FolhaInssDAL(ISession session) : base(session) { }

        public FolhaInssDTO saveOrUpdate(FolhaInssDTO objeto)
        {
            try
            {
                base.saveOrUpdate<FolhaInssDTO>(objeto);

                IList<FolhaInssRetencaoDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(FolhaInssRetencaoDTO)).
                    Add(Expression.Eq("IdFolhaInss", objeto.Id)).List<FolhaInssRetencaoDTO>();

                foreach (FolhaInssRetencaoDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }
                
                if(objeto.ListaFolhaInssRetencao != null)
                foreach (FolhaInssRetencaoDTO objLista in objeto.ListaFolhaInssRetencao)
                {
                    objLista.IdFolhaInss = objeto.Id;
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
        public IList<FolhaInssDTO> select(FolhaInssDTO objeto)
        {
            try
            {

                IList<FolhaInssDTO> resultado = base.select<FolhaInssDTO>(objeto);

                foreach (FolhaInssDTO objP in resultado)
                {
                    NHibernateDAL<FolhaInssRetencaoDTO> DAL = new NHibernateDAL<FolhaInssRetencaoDTO>(session);
                    objP.ListaFolhaInssRetencao = DAL.select<FolhaInssRetencaoDTO>(
                        new FolhaInssRetencaoDTO { IdFolhaInss = objP.Id });

                    if (objP.ListaFolhaInssRetencao == null)
                        objP.ListaFolhaInssRetencao = new List<FolhaInssRetencaoDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<FolhaInssDTO> selectPagina(int primeiroResultado, int quantidadeResultados, FolhaInssDTO objeto)
        {
            try
            {
                IList<FolhaInssDTO> resultado = base.selectPagina<FolhaInssDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (FolhaInssDTO objLista in resultado)
                {
                    NHibernateDAL<FolhaInssRetencaoDTO> DAL = new NHibernateDAL<FolhaInssRetencaoDTO>(session);
                    objLista.ListaFolhaInssRetencao = DAL.select<FolhaInssRetencaoDTO>(
                        new FolhaInssRetencaoDTO { IdFolhaInss = objLista.Id });

                    if (objLista.ListaFolhaInssRetencao == null)
                        objLista.ListaFolhaInssRetencao = new List<FolhaInssRetencaoDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(FolhaInssDTO objeto)
        {
            try
            {
                IList<FolhaInssRetencaoDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(FolhaInssRetencaoDTO)).
                    Add(Expression.Eq("IdFolhaInss", objeto.Id)).List<FolhaInssRetencaoDTO>();

                foreach (FolhaInssRetencaoDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }

                int resultado = base.delete<FolhaInssDTO>(objeto);

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
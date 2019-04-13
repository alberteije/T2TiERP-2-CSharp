using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace FolhaService.Model
{
    public class FolhaLancamentoDAL : NHibernateDAL<FolhaLancamentoCabecalhoDTO>
    {
        public FolhaLancamentoDAL(ISession session) : base(session) { }

        public FolhaLancamentoCabecalhoDTO saveOrUpdate(FolhaLancamentoCabecalhoDTO objeto)
        {
            try
            {
                base.saveOrUpdate<FolhaLancamentoCabecalhoDTO>(objeto);

                IList<FolhaLancamentoDetalheDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(FolhaLancamentoDetalheDTO)).
                    Add(Expression.Eq("IdFolhaLancamentoCabecalho", objeto.Id)).List<FolhaLancamentoDetalheDTO>();

                foreach (FolhaLancamentoDetalheDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }
                
                if(objeto.ListaFolhaLancamentoDetalhe != null)
                foreach (FolhaLancamentoDetalheDTO objLista in objeto.ListaFolhaLancamentoDetalhe)
                {
                    objLista.IdFolhaLancamentoCabecalho = objeto.Id;
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
        public IList<FolhaLancamentoCabecalhoDTO> select(FolhaLancamentoCabecalhoDTO objeto)
        {
            try
            {

                IList<FolhaLancamentoCabecalhoDTO> resultado = base.select<FolhaLancamentoCabecalhoDTO>(objeto);

                foreach (FolhaLancamentoCabecalhoDTO objP in resultado)
                {
                    NHibernateDAL<FolhaLancamentoDetalheDTO> DAL = new NHibernateDAL<FolhaLancamentoDetalheDTO>(session);
                    objP.ListaFolhaLancamentoDetalhe = DAL.select<FolhaLancamentoDetalheDTO>(
                        new FolhaLancamentoDetalheDTO { IdFolhaLancamentoCabecalho = objP.Id });

                    if (objP.ListaFolhaLancamentoDetalhe == null)
                        objP.ListaFolhaLancamentoDetalhe = new List<FolhaLancamentoDetalheDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<FolhaLancamentoCabecalhoDTO> selectPagina(int primeiroResultado, int quantidadeResultados, FolhaLancamentoCabecalhoDTO objeto)
        {
            try
            {
                IList<FolhaLancamentoCabecalhoDTO> resultado = base.selectPagina<FolhaLancamentoCabecalhoDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (FolhaLancamentoCabecalhoDTO objLista in resultado)
                {
                    NHibernateDAL<FolhaLancamentoDetalheDTO> DAL = new NHibernateDAL<FolhaLancamentoDetalheDTO>(session);
                    objLista.ListaFolhaLancamentoDetalhe = DAL.select<FolhaLancamentoDetalheDTO>(
                        new FolhaLancamentoDetalheDTO { IdFolhaLancamentoCabecalho = objLista.Id });

                    if (objLista.ListaFolhaLancamentoDetalhe == null)
                        objLista.ListaFolhaLancamentoDetalhe = new List<FolhaLancamentoDetalheDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(FolhaLancamentoCabecalhoDTO objeto)
        {
            try
            {
                IList<FolhaLancamentoDetalheDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(FolhaLancamentoDetalheDTO)).
                    Add(Expression.Eq("IdFolhaLancamentoCabecalho", objeto.Id)).List<FolhaLancamentoDetalheDTO>();

                foreach (FolhaLancamentoDetalheDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }

                int resultado = base.delete<FolhaLancamentoCabecalhoDTO>(objeto);

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace ComprasService.Model
{
    public class CompraRequisicaoDAL : NHibernateDAL<CompraRequisicaoDTO>
    {
        public CompraRequisicaoDAL(ISession session) : base(session) { }

        public CompraRequisicaoDTO saveOrUpdate(CompraRequisicaoDTO objeto)
        {
            try
            {
                base.saveOrUpdate<CompraRequisicaoDTO>(objeto);

                IList<CompraRequisicaoDetalheDTO> listaExclusaoCompraRequisicaoDetalhe = session.CreateCriteria(typeof(CompraRequisicaoDetalheDTO)).
                    Add(Expression.Eq("IdCompraRequisicao", objeto.Id)).List<CompraRequisicaoDetalheDTO>();

                foreach (CompraRequisicaoDetalheDTO objLista in listaExclusaoCompraRequisicaoDetalhe)
                {
                    session.Delete(objLista);
                }
                
                if(objeto.ListaCompraRequisicaoDetalhe != null)
                foreach (CompraRequisicaoDetalheDTO objLista in objeto.ListaCompraRequisicaoDetalhe)
                {
                    objLista.IdCompraRequisicao = objeto.Id;
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
        public IList<CompraRequisicaoDTO> select(CompraRequisicaoDTO objeto)
        {
            try
            {

                IList<CompraRequisicaoDTO> resultado = base.select<CompraRequisicaoDTO>(objeto);

                foreach (CompraRequisicaoDTO objP in resultado)
                {
                    NHibernateDAL<CompraRequisicaoDetalheDTO> DAL = new NHibernateDAL<CompraRequisicaoDetalheDTO>(session);
                    objP.ListaCompraRequisicaoDetalhe = DAL.select<CompraRequisicaoDetalheDTO>(
                        new CompraRequisicaoDetalheDTO { IdCompraRequisicao = objP.Id });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<CompraRequisicaoDTO> selectPagina(int primeiroResultado, int quantidadeResultados, CompraRequisicaoDTO objeto)
        {
            try
            {
                IList<CompraRequisicaoDTO> resultado = base.selectPagina<CompraRequisicaoDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (CompraRequisicaoDTO objLista in resultado)
                {
                    NHibernateDAL<CompraRequisicaoDetalheDTO> DAL = new NHibernateDAL<CompraRequisicaoDetalheDTO>(session);
                    objLista.ListaCompraRequisicaoDetalhe = DAL.select<CompraRequisicaoDetalheDTO>(
                        new CompraRequisicaoDetalheDTO { IdCompraRequisicao = objLista.Id });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(CompraRequisicaoDTO objeto)
        {
            try
            {
                IList<CompraRequisicaoDetalheDTO> listaExclusaoCompraRequisicaoDetalhe = session.CreateCriteria(typeof(CompraRequisicaoDetalheDTO)).
                    Add(Expression.Eq("IdCompraRequisicao", objeto.Id)).List<CompraRequisicaoDetalheDTO>();

                foreach (CompraRequisicaoDetalheDTO objLista in listaExclusaoCompraRequisicaoDetalhe)
                {
                    session.Delete(objLista);
                }

                int resultado = base.delete<CompraRequisicaoDTO>(objeto);

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
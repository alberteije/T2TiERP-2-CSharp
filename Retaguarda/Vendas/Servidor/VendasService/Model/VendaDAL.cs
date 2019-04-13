using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace VendasService.Model
{
    public class VendaDAL : NHibernateDAL<VendaCabecalhoDTO>
    {
        public VendaDAL(ISession session) : base(session) { }

        public VendaCabecalhoDTO saveOrUpdate(VendaCabecalhoDTO objeto)
        {
            try
            {
                base.saveOrUpdate<VendaCabecalhoDTO>(objeto);

                IList<VendaDetalheDTO> listaExclusao = session.CreateCriteria(typeof(VendaDetalheDTO)).
                    Add(Expression.Eq("IdVendaCabecalho", objeto.Id)).List<VendaDetalheDTO>();

                foreach (VendaDetalheDTO objLista in listaExclusao)
                {
                    session.Delete(objLista);
                }

                foreach (VendaDetalheDTO objLista in objeto.ListaVendaDetalhe)
                {
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
        public IList<VendaCabecalhoDTO> select(VendaCabecalhoDTO objeto)
        {
            try
            {

                IList<VendaCabecalhoDTO> resultado = base.select<VendaCabecalhoDTO>(objeto);

                foreach (VendaCabecalhoDTO objP in resultado)
                {
                    NHibernateDAL<VendaDetalheDTO> DAL = new NHibernateDAL<VendaDetalheDTO>(session);
                    objP.ListaVendaDetalhe = DAL.select<VendaDetalheDTO>(
                        new VendaDetalheDTO { IdVendaCabecalho = objP.Id });

                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<VendaCabecalhoDTO> selectPagina(int primeiroResultado, int quantidadeResultados, VendaCabecalhoDTO objeto)
        {
            try
            {
                IList<VendaCabecalhoDTO> resultado = base.selectPagina<VendaCabecalhoDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (VendaCabecalhoDTO objLista in resultado)
                {
                    NHibernateDAL<VendaDetalheDTO> DAL = new NHibernateDAL<VendaDetalheDTO>(session);
                    objLista.ListaVendaDetalhe = DAL.select<VendaDetalheDTO>(
                        new VendaDetalheDTO { IdVendaCabecalho = objLista.Id });

                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(VendaCabecalhoDTO objeto)
        {
            try
            {
                IList<VendaDetalheDTO> listaVendaDetalhe = objeto.ListaVendaDetalhe;
                int resultado = base.delete<VendaCabecalhoDTO>(objeto);

                if (resultado == 0)
                    foreach (VendaDetalheDTO objLista in listaVendaDetalhe)
                    {
                        NHibernateDAL<VendaDetalheDTO> DAL = new NHibernateDAL<VendaDetalheDTO>(session);
                        DAL.delete(objLista);
                    }
                session.Flush();

                resultado = 0;
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
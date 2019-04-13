using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace VendasService.Model
{
    public class OrcamentoDAL : NHibernateDAL<OrcamentoPedidoVendaCabDTO>
    {
        public OrcamentoDAL(ISession session) : base(session) { }

        public OrcamentoPedidoVendaCabDTO saveOrUpdate(OrcamentoPedidoVendaCabDTO objeto)
        {
            try
            {
                base.saveOrUpdate<OrcamentoPedidoVendaCabDTO>(objeto);

                IList<OrcamentoPedidoVendaDetDTO> listaExclusao = session.CreateCriteria(typeof(OrcamentoPedidoVendaDetDTO)).
                    Add(Expression.Eq("IdOrcamentoPedidoVendaCab", objeto.Id)).List<OrcamentoPedidoVendaDetDTO>();

                foreach (OrcamentoPedidoVendaDetDTO objLista in listaExclusao)
                {
                    session.Delete(objLista);
                }

                foreach (OrcamentoPedidoVendaDetDTO objLista in objeto.ListaOrcamentoPedidoVendaDet)
                {
                    objLista.IdOrcamentoPedidoVendaCab = objeto.Id;
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
        public IList<OrcamentoPedidoVendaCabDTO> select(OrcamentoPedidoVendaCabDTO objeto)
        {
            try
            {

                IList<OrcamentoPedidoVendaCabDTO> resultado = base.select<OrcamentoPedidoVendaCabDTO>(objeto);

                foreach (OrcamentoPedidoVendaCabDTO objP in resultado)
                {
                    NHibernateDAL<OrcamentoPedidoVendaDetDTO> DAL = new NHibernateDAL<OrcamentoPedidoVendaDetDTO>(session);
                    objP.ListaOrcamentoPedidoVendaDet = DAL.select<OrcamentoPedidoVendaDetDTO>(
                        new OrcamentoPedidoVendaDetDTO { IdOrcamentoPedidoVendaCab = objP.Id });

                    if (objP.ListaOrcamentoPedidoVendaDet == null)
                        objP.ListaOrcamentoPedidoVendaDet = new List<OrcamentoPedidoVendaDetDTO>();
                }
				
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<OrcamentoPedidoVendaCabDTO> selectPagina(int primeiroResultado, int quantidadeResultados, OrcamentoPedidoVendaCabDTO objeto)
        {
            try
            {
                IList<OrcamentoPedidoVendaCabDTO> resultado = base.selectPagina<OrcamentoPedidoVendaCabDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (OrcamentoPedidoVendaCabDTO objLista in resultado)
                {
                    NHibernateDAL<OrcamentoPedidoVendaDetDTO> DAL = new NHibernateDAL<OrcamentoPedidoVendaDetDTO>(session);
                    objLista.ListaOrcamentoPedidoVendaDet = DAL.select<OrcamentoPedidoVendaDetDTO>(
                        new OrcamentoPedidoVendaDetDTO { IdOrcamentoPedidoVendaCab = objeto.Id });

                    if (objLista.ListaOrcamentoPedidoVendaDet == null)
                        objLista.ListaOrcamentoPedidoVendaDet = new List<OrcamentoPedidoVendaDetDTO>();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(OrcamentoPedidoVendaCabDTO objeto)
        {
            try
            {
                IList<OrcamentoPedidoVendaDetDTO> listaExclusao = session.CreateCriteria(typeof(OrcamentoPedidoVendaDetDTO)).
                    Add(Expression.Eq("IdOrcamentoPedidoVendaCab", objeto.Id)).List<OrcamentoPedidoVendaDetDTO>();

                foreach (OrcamentoPedidoVendaDetDTO objLista in listaExclusao)
                {
                    session.Delete(objLista);
                }

                int resultado = base.delete<OrcamentoPedidoVendaCabDTO>(objeto);

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
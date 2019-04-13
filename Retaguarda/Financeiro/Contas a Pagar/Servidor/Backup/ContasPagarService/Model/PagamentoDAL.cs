using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace ContasPagarService.Model
{
    public class PagamentoDAL : NHibernateDAL<ViewFinLancamentoPagarDTO>
    {
        public PagamentoDAL(ISession session) : base(session) { }

        public ViewFinLancamentoPagarDTO saveOrUpdate(ViewFinLancamentoPagarDTO objeto)
        {
            try
            {
                FinParcelaPagarDTO parcela = new FinParcelaPagarDTO();
                parcela.Id = objeto.IdParcelaPagar;
                parcela.IdFinLancamentoPagar = objeto.IdLancamentoPagar;
                parcela.ContaCaixa = new ContaCaixaDTO();
                parcela.ContaCaixa.Id = objeto.IdContaCaixa;
                parcela.IdFinStatusParcela = (Int32)objeto.IdStatusParcela;

                base.saveOrUpdate<FinParcelaPagarDTO>(parcela);

                IList<FinParcelaPagamentoDTO> listaExclusaoParcelaPagamento = session.CreateCriteria(typeof(FinParcelaPagamentoDTO)).
                    Add(Expression.Eq("IdFinParcelaPagar", objeto.IdParcelaPagar)).List<FinParcelaPagamentoDTO>();

                foreach (FinParcelaPagamentoDTO objLista in listaExclusaoParcelaPagamento)
                {
                    session.Delete(objLista);
                }
                
                if(objeto.ListaFinParcelaPagamento != null)
                foreach (FinParcelaPagamentoDTO objLista in objeto.ListaFinParcelaPagamento)
                {
                    objLista.IdFinParcelaPagar = parcela.Id;
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


        public IList<ViewFinLancamentoPagarDTO> select(ViewFinLancamentoPagarDTO objeto)
        {
            try
            {

                IList<ViewFinLancamentoPagarDTO> resultado = base.select<ViewFinLancamentoPagarDTO>(objeto);

                foreach (ViewFinLancamentoPagarDTO objP in resultado)
                {
                    NHibernateDAL<FinParcelaPagamentoDTO> DAL = new NHibernateDAL<FinParcelaPagamentoDTO>(session);
                    objP.ListaFinParcelaPagamento = DAL.select<FinParcelaPagamentoDTO>(
                        new FinParcelaPagamentoDTO { IdFinParcelaPagar = objP.IdParcelaPagar });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IList<ViewFinLancamentoPagarDTO> selectPagina(int primeiroResultado, int quantidadeResultados, ViewFinLancamentoPagarDTO objeto)
        {
            try
            {
                IList<ViewFinLancamentoPagarDTO> resultado = base.selectPagina<ViewFinLancamentoPagarDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (ViewFinLancamentoPagarDTO objLista in resultado)
                {
                    NHibernateDAL<FinParcelaPagamentoDTO> DAL = new NHibernateDAL<FinParcelaPagamentoDTO>(session);
                    objLista.ListaFinParcelaPagamento = DAL.select<FinParcelaPagamentoDTO>(
                        new FinParcelaPagamentoDTO { IdFinParcelaPagar = objLista.IdParcelaPagar });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace ContasReceberService.Model
{
    public class RecebimentoDAL : NHibernateDAL<ViewFinLancamentoReceberDTO>
    {
        public RecebimentoDAL(ISession session) : base(session) { }

        public ViewFinLancamentoReceberDTO saveOrUpdate(ViewFinLancamentoReceberDTO objeto)
        {
            try
            {
                FinParcelaReceberDTO parcela = new FinParcelaReceberDTO();
                parcela.Id = objeto.IdParcelaReceber;
                parcela.IdFinLancamentoReceber = objeto.IdLancamentoReceber;
                parcela.ContaCaixa = new ContaCaixaDTO();
                parcela.ContaCaixa.Id = objeto.IdContaCaixa;
                parcela.IdFinStatusParcela = (Int32)objeto.IdStatusParcela;

                base.saveOrUpdate<FinParcelaReceberDTO>(parcela);

                IList<FinParcelaRecebimentoDTO> listaExclusaoParcelaRecebimento = session.CreateCriteria(typeof(FinParcelaRecebimentoDTO)).
                    Add(Expression.Eq("IdFinParcelaReceber", objeto.IdParcelaReceber)).List<FinParcelaRecebimentoDTO>();

                foreach (FinParcelaRecebimentoDTO objLista in listaExclusaoParcelaRecebimento)
                {
                    session.Delete(objLista);
                }
                
                if(objeto.ListaFinParcelaRecebimento != null)
                foreach (FinParcelaRecebimentoDTO objLista in objeto.ListaFinParcelaRecebimento)
                {
                    objLista.IdFinParcelaReceber = parcela.Id;
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


        public IList<ViewFinLancamentoReceberDTO> select(ViewFinLancamentoReceberDTO objeto)
        {
            try
            {

                IList<ViewFinLancamentoReceberDTO> resultado = base.select<ViewFinLancamentoReceberDTO>(objeto);

                foreach (ViewFinLancamentoReceberDTO objP in resultado)
                {
                    NHibernateDAL<FinParcelaRecebimentoDTO> DAL = new NHibernateDAL<FinParcelaRecebimentoDTO>(session);
                    objP.ListaFinParcelaRecebimento = DAL.select<FinParcelaRecebimentoDTO>(
                        new FinParcelaRecebimentoDTO { IdFinParcelaReceber = objP.IdParcelaReceber });
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IList<ViewFinLancamentoReceberDTO> selectPagina(int primeiroResultado, int quantidadeResultados, ViewFinLancamentoReceberDTO objeto)
        {
            try
            {
                IList<ViewFinLancamentoReceberDTO> resultado = base.selectPagina<ViewFinLancamentoReceberDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (ViewFinLancamentoReceberDTO objLista in resultado)
                {
                    NHibernateDAL<FinParcelaRecebimentoDTO> DAL = new NHibernateDAL<FinParcelaRecebimentoDTO>(session);
                    objLista.ListaFinParcelaRecebimento = DAL.select<FinParcelaRecebimentoDTO>(
                        new FinParcelaRecebimentoDTO { IdFinParcelaReceber = objLista.IdParcelaReceber });
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
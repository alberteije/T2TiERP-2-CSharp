using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Criterion;
using NHibernate;

namespace VendasService.Model
{
    public class CondicoesPagamentoDAL : NHibernateDAL<CondicoesPagamentoDTO>
    {
        public CondicoesPagamentoDAL(ISession session) : base(session) { }

        public IList<CondicoesPagamentoDTO> select(CondicoesPagamentoDTO condicoesPagamento)
        {
            try
            {

                IList<CondicoesPagamentoDTO> resultado = base.select<CondicoesPagamentoDTO>(condicoesPagamento);

                foreach (CondicoesPagamentoDTO condicoesPag in resultado)
                {
                    NHibernateDAL<CondicoesParcelaDTO> DAL = new NHibernateDAL<CondicoesParcelaDTO>(session);
                    condicoesPag.ListaCondicoesParcela = DAL.select<CondicoesParcelaDTO>(
                        new CondicoesParcelaDTO { IdCondicoesPagamento = condicoesPag.Id });
                    
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<CondicoesPagamentoDTO> selectPagina(int primeiroResultado, int quantidadeResultados, CondicoesPagamentoDTO condicoesPagamento)
        {
            try
            {
                IList<CondicoesPagamentoDTO> resultado = base.selectPagina<CondicoesPagamentoDTO>(primeiroResultado, quantidadeResultados, condicoesPagamento);
                foreach (CondicoesPagamentoDTO condicoesPag in resultado)
                {
                    NHibernateDAL<CondicoesParcelaDTO> DAL = new NHibernateDAL<CondicoesParcelaDTO>(session);
                    condicoesPag.ListaCondicoesParcela = DAL.select<CondicoesParcelaDTO>(
                        new CondicoesParcelaDTO { IdCondicoesPagamento = condicoesPag.Id });

                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CondicoesPagamentoDTO saveOrUpdate(CondicoesPagamentoDTO condicoesPagamento)
        {
            try
            {
                base.saveOrUpdate<CondicoesPagamentoDTO>(condicoesPagamento);

                IList<CondicoesParcelaDTO> listaExclusao = session.CreateCriteria(typeof(CondicoesParcelaDTO)).
                    Add(Expression.Eq("IdCondicoesPagamento",condicoesPagamento.Id)).List<CondicoesParcelaDTO>();

                foreach (CondicoesParcelaDTO CondicoesParcela in listaExclusao)
                {
                    session.Delete(CondicoesParcela);
                }

                foreach (CondicoesParcelaDTO condParc in condicoesPagamento.ListaCondicoesParcela)
                {
                    condParc.IdCondicoesPagamento = condicoesPagamento.Id;
                    session.Save(condParc);
                }

                session.Flush();

                return condicoesPagamento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(CondicoesPagamentoDTO condicoesPagamento)
        {
            try
            {
                IList<CondicoesParcelaDTO> listaCondicoesParcela = condicoesPagamento.ListaCondicoesParcela;
                int resultado = base.delete<CondicoesPagamentoDTO>(condicoesPagamento);

                if(resultado == 0)
                    foreach (CondicoesParcelaDTO condParc in listaCondicoesParcela)
                    {
                        NHibernateDAL<CondicoesParcelaDTO> DAL = new NHibernateDAL<CondicoesParcelaDTO>(session);
                        DAL.delete(condParc);
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
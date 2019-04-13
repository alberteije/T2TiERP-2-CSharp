using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace EscritaFiscalService.Model
{
    public class SimplesNacionalDAL : NHibernateDAL<SimplesNacionalCabecalhoDTO>
    {
        public SimplesNacionalDAL(ISession session) : base(session) { }

        public SimplesNacionalCabecalhoDTO saveOrUpdate(SimplesNacionalCabecalhoDTO objeto)
        {
            try
            {
                base.saveOrUpdate<SimplesNacionalCabecalhoDTO>(objeto);

                IList<SimplesNacionalDetalheDTO> listaExclusao = session.CreateCriteria(typeof(SimplesNacionalDetalheDTO)).
                    Add(Expression.Eq("IdSimplesNacionalCabecalho", objeto.Id)).List<SimplesNacionalDetalheDTO>();

                foreach (SimplesNacionalDetalheDTO objLista in listaExclusao)
                {
                    session.Delete(objLista);
                }
                
                foreach (SimplesNacionalDetalheDTO objLista in objeto.ListaSimplesNacionalDetalhe)
                {
                    objLista.IdSimplesNacionalCabecalho = objeto.Id;
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
        public IList<SimplesNacionalCabecalhoDTO> select(SimplesNacionalCabecalhoDTO objeto)
        {
            try
            {

                IList<SimplesNacionalCabecalhoDTO> resultado = base.select<SimplesNacionalCabecalhoDTO>(objeto);

                foreach (SimplesNacionalCabecalhoDTO objP in resultado)
                {
                    NHibernateDAL<SimplesNacionalDetalheDTO> DAL = new NHibernateDAL<SimplesNacionalDetalheDTO>(session);
                    objP.ListaSimplesNacionalDetalhe = DAL.select<SimplesNacionalDetalheDTO>(
                        new SimplesNacionalDetalheDTO { IdSimplesNacionalCabecalho = objP.Id });
                    
                    if (objP.ListaSimplesNacionalDetalhe == null)
                        objP.ListaSimplesNacionalDetalhe = new List<SimplesNacionalDetalheDTO>();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<SimplesNacionalCabecalhoDTO> selectPagina(int primeiroResultado, int quantidadeResultados, SimplesNacionalCabecalhoDTO objeto)
        {
            try
            {
                IList<SimplesNacionalCabecalhoDTO> resultado = base.selectPagina<SimplesNacionalCabecalhoDTO>(primeiroResultado, quantidadeResultados, objeto);
                foreach (SimplesNacionalCabecalhoDTO objLista in resultado)
                {
                    NHibernateDAL<SimplesNacionalDetalheDTO> DAL = new NHibernateDAL<SimplesNacionalDetalheDTO>(session);
                    objLista.ListaSimplesNacionalDetalhe = DAL.select<SimplesNacionalDetalheDTO>(
                        new SimplesNacionalDetalheDTO { IdSimplesNacionalCabecalho = objLista.Id });

                    if (objLista.ListaSimplesNacionalDetalhe == null)
                        objLista.ListaSimplesNacionalDetalhe = new List<SimplesNacionalDetalheDTO>();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(SimplesNacionalCabecalhoDTO objeto)
        {
            try
            {
                IList<SimplesNacionalDetalheDTO> listaExclusaoDepreciacao = session.CreateCriteria(typeof(SimplesNacionalDetalheDTO)).
                    Add(Expression.Eq("IdSimplesNacionalCabecalho", objeto.Id)).List<SimplesNacionalDetalheDTO>();

                foreach (SimplesNacionalDetalheDTO objLista in listaExclusaoDepreciacao)
                {
                    session.Delete(objLista);
                }

                int resultado = base.delete<SimplesNacionalCabecalhoDTO>(objeto);

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
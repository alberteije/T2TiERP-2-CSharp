using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace GEDService.Model
{
    public class DocumentoDAL : NHibernateDAL<GedDocumentoDTO>
    {
        public DocumentoDAL(ISession session) : base(session) { }

        public GedDocumentoDTO saveOrUpdate(GedDocumentoDTO objeto)
        {
            try
            {
                base.saveOrUpdate<GedDocumentoDTO>(objeto);

                session.Flush();

                return objeto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<GedDocumentoDTO> select(GedDocumentoDTO objeto)
        {
            try
            {

                IList<GedDocumentoDTO> resultado = base.select<GedDocumentoDTO>(objeto);
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<GedDocumentoDTO> selectPagina(int primeiroResultado, int quantidadeResultados, GedDocumentoDTO objeto)
        {
            try
            {
                IList<GedDocumentoDTO> resultado = base.selectPagina<GedDocumentoDTO>(primeiroResultado, quantidadeResultados, objeto);
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int delete(GedDocumentoDTO objeto)
        {
            try
            {
                int resultado = base.delete<GedDocumentoDTO>(objeto);

                session.Flush();

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<GedDocumentoDTO> selectDocumentosAtivos(GedDocumentoDTO documento)
        {
            IList<GedDocumentoDTO> resultado = new List<GedDocumentoDTO>();
            Example example = Example.Create(documento).EnableLike(MatchMode.Anywhere).IgnoreCase().ExcludeNulls().ExcludeZeroes();
            ICriteria criteriaQuery = session.CreateCriteria(typeof(GedDocumentoDTO)).Add(example);
            criteriaQuery.Add(Restrictions.Or
                                (
                                    Restrictions.Gt("DataExclusao", DateTime.Now),
                                    Restrictions.IsNull("DataExclusao")
                                )
                              );
            resultado = criteriaQuery.List<GedDocumentoDTO>();
            return resultado;
        }

    }
}
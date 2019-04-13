using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using NHibernate;
using TesourariaService.NHibernate;
using TesourariaService.Model;

namespace TesourariaService
{
    public class TesourariaService : ITesourariaService
    {
        public IList<ViewFinResumoTesourariaDTO> selectResumoTesouraria(ViewFinResumoTesourariaDTO resumoTesouraria)
        {
            using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
            {
                NHibernateDAL<ViewFinResumoTesourariaDTO> resumoTesourariaDAL = new NHibernateDAL<ViewFinResumoTesourariaDTO>(session);
                return resumoTesourariaDAL.select(resumoTesouraria);
            }
        }

        public IList<FechamentoCaixaBancoDTO> selectFechamentoCaixaBanco(FechamentoCaixaBancoDTO fechamentoCaixaBanco)
        {
            using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
            {
                NHibernateDAL<FechamentoCaixaBancoDTO> fechamentoDAL = new NHibernateDAL<FechamentoCaixaBancoDTO>(session);
                return fechamentoDAL.select(fechamentoCaixaBanco);
            }
        }


        public IList<ContaCaixaDTO> selectContaCaixa(ContaCaixaDTO contaCaixa)
        {
            using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
            {
                NHibernateDAL<ContaCaixaDTO> contaCaixaDAL = new NHibernateDAL<ContaCaixaDTO>(session);
                return contaCaixaDAL.select(contaCaixa);
            }
        }


        public IList<ViewFinResumoTesourariaDTO> selectResumoTesourariaMes(ViewFinResumoTesourariaDTO resumoTesouraria)
        {
            using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
            {
                ResumoTesourariaDAL resumoTesourariaDAL = new ResumoTesourariaDAL( session);
                return resumoTesourariaDAL.selectResumoTesourariaMes(resumoTesouraria);
            }
        }



        #region Usuario
        public UsuarioDTO selectUsuario(String login, String senha)
        {
            try
            {
                UsuarioDTO resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    UsuarioDAL DAL = new UsuarioDAL(session);
                    resultado = DAL.select(login, senha);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        #endregion

        #region ControleAcesso
        public IList<ViewControleAcessoDTO> selectControleAcesso(ViewControleAcessoDTO viewControleAcesso)
        {
            try
            {
                IList<ViewControleAcessoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewControleAcessoDTO> DAL = new NHibernateDAL<ViewControleAcessoDTO>(session);
                    resultado = DAL.select(viewControleAcesso);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }

        }
        #endregion


        #region Empresa
        public IList<EmpresaDTO> selectEmpresa(EmpresaDTO Empresa)
        {
            using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
            {
                NHibernateDAL<EmpresaDTO> EmpresaDAL = new NHibernateDAL<EmpresaDTO>(session);
                return EmpresaDAL.select(Empresa);
            }
        }
        #endregion
    }
}

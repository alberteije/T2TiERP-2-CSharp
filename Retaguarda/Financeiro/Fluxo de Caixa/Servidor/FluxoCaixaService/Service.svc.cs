using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FluxoCaixaService.Model;
using NHibernate;
using FluxoCaixaService.NHibernate;

namespace FluxoCaixaService
{
    public class Service : IService
    {

        public IList<ViewFinFluxoCaixaDTO> selectFluxoCaixa(ViewFinFluxoCaixaDTO fluxo)
        {
            using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
            {
                NHibernateDAL<ViewFinFluxoCaixaDTO> fluxoDAL = new NHibernateDAL<ViewFinFluxoCaixaDTO>(session);
                return fluxoDAL.select(fluxo);
            }
        }

        public IList<ViewFinFluxoCaixaDTO> selectFluxoCaixaMes(ViewFinFluxoCaixaDTO fluxo)
        {
            using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
            {
                FluxoCaixaDAL fluxoDAL = new FluxoCaixaDAL(session);
                return fluxoDAL.selectFluxoCaixaMes(fluxo);
            }
        }


        #region ContaCaixa
        public IList<ContaCaixaDTO> selectContaCaixa(ContaCaixaDTO contaCaixa)
        {
            using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
            {
                NHibernateDAL<ContaCaixaDTO> contaCaixaDAL = new NHibernateDAL<ContaCaixaDTO>(session);
                return contaCaixaDAL.select(contaCaixa);
            }
        }
        #endregion

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

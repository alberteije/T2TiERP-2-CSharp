using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ContratosService.Model;
using NHibernate;
using ContratosService.NHibernate;

namespace ContratosService
{
    public class ServicoContratos : IServicoContratos
    {
        #region Contrato
        public int deleteContrato(ContratoDTO contrato)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContratoDAL DAL = new ContratoDAL(session);
                    DAL.delete(contrato);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public ContratoDTO salvarAtualizarContrato(ContratoDTO contrato)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContratoDAL DAL = new ContratoDAL(session);
                    DAL.saveOrUpdate(contrato);
                    session.Flush();
                }
                return contrato;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContratoDTO> selectContrato(ContratoDTO contrato)
        {
            try
            {
                IList<ContratoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContratoDAL DAL = new ContratoDAL(session);
                    resultado = DAL.select(contrato);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContratoDTO> selectContratoPagina(int primeiroResultado, int quantidadeResultados, ContratoDTO contrato)
        {
            try
            {
                IList<ContratoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContratoDAL DAL = new ContratoDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, contrato);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ContratoTipoServico
        public int deleteContratoTipoServico(ContratoTipoServicoDTO contratoTipoServico)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContratoTipoServicoDTO> DAL = new NHibernateDAL<ContratoTipoServicoDTO>(session);
                    DAL.delete(contratoTipoServico);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public ContratoTipoServicoDTO salvarAtualizarContratoTipoServico(ContratoTipoServicoDTO contratoTipoServico)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContratoTipoServicoDTO> DAL = new NHibernateDAL<ContratoTipoServicoDTO>(session);
                    DAL.saveOrUpdate(contratoTipoServico);
                    session.Flush();
                }
                return contratoTipoServico;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContratoTipoServicoDTO> selectContratoTipoServico(ContratoTipoServicoDTO contratoTipoServico)
        {
            try
            {
                IList<ContratoTipoServicoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContratoTipoServicoDTO> DAL = new NHibernateDAL<ContratoTipoServicoDTO>(session);
                    resultado = DAL.select(contratoTipoServico);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContratoTipoServicoDTO> selectContratoTipoServicoPagina(int primeiroResultado, int quantidadeResultados, ContratoTipoServicoDTO contratoTipoServico)
        {
            try
            {
                IList<ContratoTipoServicoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContratoTipoServicoDTO> DAL = new NHibernateDAL<ContratoTipoServicoDTO>(session);
                    resultado = DAL.selectPagina<ContratoTipoServicoDTO>(primeiroResultado, quantidadeResultados, contratoTipoServico);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion

        #region TipoContrato
        public int deleteTipoContrato(TipoContratoDTO tipoContrato)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TipoContratoDTO> DAL = new NHibernateDAL<TipoContratoDTO>(session);
                    DAL.delete(tipoContrato);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public TipoContratoDTO salvarAtualizarTipoContrato(TipoContratoDTO tipoContrato)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TipoContratoDTO> DAL = new NHibernateDAL<TipoContratoDTO>(session);
                    DAL.saveOrUpdate(tipoContrato);
                    session.Flush();
                }
                return tipoContrato;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TipoContratoDTO> selectTipoContrato(TipoContratoDTO tipoContrato)
        {
            try
            {
                IList<TipoContratoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TipoContratoDTO> DAL = new NHibernateDAL<TipoContratoDTO>(session);
                    resultado = DAL.select(tipoContrato);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TipoContratoDTO> selectTipoContratoPagina(int primeiroResultado, int quantidadeResultados, TipoContratoDTO tipoContrato)
        {
            try
            {
                IList<TipoContratoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TipoContratoDTO> DAL = new NHibernateDAL<TipoContratoDTO>(session);
                    resultado = DAL.selectPagina<TipoContratoDTO>(primeiroResultado, quantidadeResultados, tipoContrato);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ContratoSolicitacaoServico
        public int deleteContratoSolicitacaoServico(ContratoSolicitacaoServicoDTO contratoSolicitacaoServico)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContratoSolicitacaoServicoDTO> DAL = new NHibernateDAL<ContratoSolicitacaoServicoDTO>(session);
                    DAL.delete(contratoSolicitacaoServico);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public ContratoSolicitacaoServicoDTO salvarAtualizarContratoSolicitacaoServico(ContratoSolicitacaoServicoDTO contratoSolicitacaoServico)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContratoSolicitacaoServicoDTO> DAL = new NHibernateDAL<ContratoSolicitacaoServicoDTO>(session);
                    DAL.saveOrUpdate(contratoSolicitacaoServico);
                    session.Flush();
                }
                return contratoSolicitacaoServico;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContratoSolicitacaoServicoDTO> selectContratoSolicitacaoServico(ContratoSolicitacaoServicoDTO contratoSolicitacaoServico)
        {
            try
            {
                IList<ContratoSolicitacaoServicoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContratoSolicitacaoServicoDTO> DAL = new NHibernateDAL<ContratoSolicitacaoServicoDTO>(session);
                    resultado = DAL.select(contratoSolicitacaoServico);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContratoSolicitacaoServicoDTO> selectContratoSolicitacaoServicoPagina(int primeiroResultado, int quantidadeResultados, ContratoSolicitacaoServicoDTO contratoSolicitacaoServico)
        {
            try
            {
                IList<ContratoSolicitacaoServicoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContratoSolicitacaoServicoDTO> DAL = new NHibernateDAL<ContratoSolicitacaoServicoDTO>(session);
                    resultado = DAL.selectPagina<ContratoSolicitacaoServicoDTO>(primeiroResultado, quantidadeResultados, contratoSolicitacaoServico);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 
        
        #region Fornecedor
        public IList<FornecedorDTO> selectFornecedor(FornecedorDTO fornecedor)
        {
            try
            {
                IList<FornecedorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FornecedorDTO> DAL = new NHibernateDAL<FornecedorDTO>(session);
                    resultado = DAL.select(fornecedor);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public IList<FornecedorDTO> selectFornecedorPagina(int primeiroResultado, int quantidadeResultados, FornecedorDTO fornecedor)
        {
            try
            {
                IList<FornecedorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FornecedorDTO> DAL = new NHibernateDAL<FornecedorDTO>(session);
                    resultado = DAL.selectPagina<FornecedorDTO>(primeiroResultado, quantidadeResultados, fornecedor);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        #endregion 
    
        #region Cliente
        public IList<ClienteDTO> selectCliente(ClienteDTO cliente)
        {
            try
            {
                IList<ClienteDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ClienteDTO> DAL = new NHibernateDAL<ClienteDTO>(session);
                    resultado = DAL.select(cliente);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        public IList<ClienteDTO> selectClientePagina(int primeiroResultado, int quantidadeResultados, ClienteDTO cliente)
        {
            try
            {
                IList<ClienteDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ClienteDTO> DAL = new NHibernateDAL<ClienteDTO>(session);
                    resultado = DAL.selectPagina<ClienteDTO>(primeiroResultado, quantidadeResultados, cliente);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        #endregion

        #region Setor

        public IList<SetorDTO> selectSetor(SetorDTO setor)
        {
            try
            {
                IList<SetorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<SetorDTO> DAL = new NHibernateDAL<SetorDTO>(session);
                    resultado = DAL.select(setor);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<SetorDTO> selectSetorPagina(int primeiroResultado, int quantidadeResultados, SetorDTO setor)
        {
            try
            {
                IList<SetorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<SetorDTO> DAL = new NHibernateDAL<SetorDTO>(session);
                    resultado = DAL.selectPagina<SetorDTO>(primeiroResultado, quantidadeResultados, setor);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region Colaborador
        public IList<ColaboradorDTO> selectColaborador(ColaboradorDTO colaborador)
        {
            try
            {
                IList<ColaboradorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ColaboradorDTO> DAL = new NHibernateDAL<ColaboradorDTO>(session);
                    resultado = DAL.select(colaborador);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        public IList<ColaboradorDTO> selectColaboradorPagina(int primeiroResultado, int quantidadeResultados, ColaboradorDTO colaborador)
        {
            try
            {
                IList<ColaboradorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ColaboradorDTO> DAL = new NHibernateDAL<ColaboradorDTO>(session);
                    resultado = DAL.selectPagina<ColaboradorDTO>(primeiroResultado, quantidadeResultados, colaborador);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        #endregion

        #region Pessoa
        public PessoaDTO selectPessoa(PessoaDTO pessoa)
        {
            PessoaDTO resultado = null;
            using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
            {
                NHibernateDAL<PessoaDTO> DAL = new NHibernateDAL<PessoaDTO>(session);
                resultado = DAL.selectId<PessoaDTO>(pessoa.Id);

                if (resultado != null)
                {
                    NHibernateDAL<EnderecoDTO> DALEnd = new NHibernateDAL<EnderecoDTO>(session);
                    IList<EnderecoDTO> listaEnd = DALEnd.select<EnderecoDTO>(new EnderecoDTO { IdPessoa = resultado.Id });
                    if (listaEnd != null && listaEnd.Count > 0)
                        resultado.Endereco = listaEnd.First();
                }
            }
            return resultado;
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

    }
}

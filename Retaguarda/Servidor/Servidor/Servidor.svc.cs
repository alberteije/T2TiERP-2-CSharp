using NHibernate;
using Servidor.DAL;
using Servidor.Model;
using Servidor.NHibernate;
using Servidor.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Servidor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please Select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceServidor : IServidor
    {

        #region === Comum ===

        #region Empresa

        public EmpresaDTO SelectObjetoEmpresa(string pFiltro)
        {
            try
            {
                EmpresaDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EmpresaDTO> DAL = new NHibernateDAL<EmpresaDTO>(Session);
                    Resultado = new EmpresaDAL(Session).SelectId(1);

                    if (Resultado != null)
                    {
                        Resultado.ListaEndereco = DAL.Select<EmpresaEnderecoDTO>(new EmpresaEnderecoDTO { IdEmpresa = Resultado.Id });

                        if (Resultado.ListaEndereco == null)
                            Resultado.ListaEndereco = new List<EmpresaEnderecoDTO>();
                        else
                        {
                            for (int i = 0; i <= Resultado.ListaEndereco.Count - 1; i++)
                            {
                                if (Resultado.ListaEndereco[i].Principal == "S")
                                    Resultado.EnderecoPrincipal = Resultado.ListaEndereco[i];
                            }
                        }
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public IList<EmpresaDTO> SelectEmpresa(EmpresaDTO empresa)
        {
            try
            {
                IList<EmpresaDTO> resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    EmpresaDAL DAL = new EmpresaDAL(Session);
                    resultado = DAL.Select(empresa);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<EmpresaDTO> SelectEmpresaPagina(int primeiroResultado, int quantidadeResultados, EmpresaDTO empresa)
        {
            try
            {
                IList<EmpresaDTO> resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    EmpresaDAL DAL = new EmpresaDAL(Session);
                    resultado = DAL.SelectPagina(primeiroResultado, quantidadeResultados, empresa);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion

        #region Usuario
        public UsuarioDTO SelectUsuario(String login, String senha)
        {
            try
            {
                UsuarioDTO resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    UsuarioDAL DAL = new UsuarioDAL(Session);
                    resultado = DAL.Select(login, senha);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        #endregion

        #endregion

        #region === Cadastros ===

        #region EstadoCivil
        public void DeleteEstadoCivil(EstadoCivilDTO estadoCivil)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EstadoCivilDTO> DAL = new NHibernateDAL<EstadoCivilDTO>(Session);
                    DAL.Delete(estadoCivil);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public EstadoCivilDTO SalvarAtualizarEstadoCivil(EstadoCivilDTO estadoCivil)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EstadoCivilDTO> DAL = new NHibernateDAL<EstadoCivilDTO>(Session);
                    DAL.SaveOrUpdate(estadoCivil);
                    Session.Flush();
                }
                return estadoCivil;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<EstadoCivilDTO> SelectEstadoCivil(EstadoCivilDTO estadoCivil)
        {
            try
            {
                IList<EstadoCivilDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EstadoCivilDTO> DAL = new NHibernateDAL<EstadoCivilDTO>(Session);
                    Resultado = DAL.Select(estadoCivil);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<EstadoCivilDTO> SelectEstadoCivilPagina(int primeiroResultado, int quantidadeResultados, EstadoCivilDTO estadoCivil)
        {
            try
            {
                IList<EstadoCivilDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EstadoCivilDTO> DAL = new NHibernateDAL<EstadoCivilDTO>(Session);
                    Resultado = DAL.SelectPagina<EstadoCivilDTO>(primeiroResultado, quantidadeResultados, estadoCivil);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        #endregion 

        #region AtividadeForCli
        public void DeleteAtividadeForCli(AtividadeForCliDTO atividadeForCli)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<AtividadeForCliDTO> DAL = new NHibernateDAL<AtividadeForCliDTO>(Session);
                    DAL.Delete(atividadeForCli);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public AtividadeForCliDTO SalvarAtualizarAtividadeForCli(AtividadeForCliDTO atividadeForCli)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<AtividadeForCliDTO> DAL = new NHibernateDAL<AtividadeForCliDTO>(Session);
                    DAL.SaveOrUpdate(atividadeForCli);
                    Session.Flush();
                }
                return atividadeForCli;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<AtividadeForCliDTO> SelectAtividadeForCli(AtividadeForCliDTO atividadeForCli)
        {
            try
            {
                IList<AtividadeForCliDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<AtividadeForCliDTO> DAL = new NHibernateDAL<AtividadeForCliDTO>(Session);
                    Resultado = DAL.Select(atividadeForCli);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<AtividadeForCliDTO> SelectAtividadeForCliPagina(int primeiroResultado, int quantidadeResultados, AtividadeForCliDTO atividadeForCli)
        {
            try
            {
                IList<AtividadeForCliDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<AtividadeForCliDTO> DAL = new NHibernateDAL<AtividadeForCliDTO>(Session);
                    Resultado = DAL.SelectPagina<AtividadeForCliDTO>(primeiroResultado, quantidadeResultados, atividadeForCli);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region Cargo
        public void DeleteCargo(CargoDTO cargo)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CargoDTO> DAL = new NHibernateDAL<CargoDTO>(Session);
                    DAL.Delete(cargo);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public CargoDTO SalvarAtualizarCargo(CargoDTO cargo)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CargoDTO> DAL = new NHibernateDAL<CargoDTO>(Session);
                    DAL.SaveOrUpdate(cargo);
                    Session.Flush();
                }
                return cargo;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CargoDTO> SelectCargo(CargoDTO cargo)
        {
            try
            {
                IList<CargoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CargoDTO> DAL = new NHibernateDAL<CargoDTO>(Session);
                    Resultado = DAL.Select(cargo);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CargoDTO> SelectCargoPagina(int primeiroResultado, int quantidadeResultados, CargoDTO cargo)
        {
            try
            {
                IList<CargoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CargoDTO> DAL = new NHibernateDAL<CargoDTO>(Session);
                    Resultado = DAL.SelectPagina<CargoDTO>(primeiroResultado, quantidadeResultados, cargo);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region Cbo
        public void DeleteCbo(CboDTO cbo)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CboDTO> DAL = new NHibernateDAL<CboDTO>(Session);
                    DAL.Delete(cbo);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public CboDTO SalvarAtualizarCbo(CboDTO cbo)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CboDTO> DAL = new NHibernateDAL<CboDTO>(Session);
                    DAL.SaveOrUpdate(cbo);
                    Session.Flush();
                }
                return cbo;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CboDTO> SelectCbo(CboDTO cbo)
        {
            try
            {
                IList<CboDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CboDTO> DAL = new NHibernateDAL<CboDTO>(Session);
                    Resultado = DAL.Select(cbo);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CboDTO> SelectCboPagina(int primeiroResultado, int quantidadeResultados, CboDTO cbo)
        {
            try
            {
                IList<CboDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CboDTO> DAL = new NHibernateDAL<CboDTO>(Session);
                    Resultado = DAL.SelectPagina<CboDTO>(primeiroResultado, quantidadeResultados, cbo);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region OperadoraPlanoSaude
        public void DeleteOperadoraPlanoSaude(OperadoraPlanoSaudeDTO operadoraPlanoSaude)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OperadoraPlanoSaudeDTO> DAL = new NHibernateDAL<OperadoraPlanoSaudeDTO>(Session);
                    DAL.Delete(operadoraPlanoSaude);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public OperadoraPlanoSaudeDTO SalvarAtualizarOperadoraPlanoSaude(OperadoraPlanoSaudeDTO operadoraPlanoSaude)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OperadoraPlanoSaudeDTO> DAL = new NHibernateDAL<OperadoraPlanoSaudeDTO>(Session);
                    DAL.SaveOrUpdate(operadoraPlanoSaude);
                    Session.Flush();
                }
                return operadoraPlanoSaude;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<OperadoraPlanoSaudeDTO> SelectOperadoraPlanoSaude(OperadoraPlanoSaudeDTO operadoraPlanoSaude)
        {
            try
            {
                IList<OperadoraPlanoSaudeDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OperadoraPlanoSaudeDTO> DAL = new NHibernateDAL<OperadoraPlanoSaudeDTO>(Session);
                    Resultado = DAL.Select(operadoraPlanoSaude);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<OperadoraPlanoSaudeDTO> SelectOperadoraPlanoSaudePagina(int primeiroResultado, int quantidadeResultados, OperadoraPlanoSaudeDTO operadoraPlanoSaude)
        {
            try
            {
                IList<OperadoraPlanoSaudeDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OperadoraPlanoSaudeDTO> DAL = new NHibernateDAL<OperadoraPlanoSaudeDTO>(Session);
                    Resultado = DAL.SelectPagina<OperadoraPlanoSaudeDTO>(primeiroResultado, quantidadeResultados, operadoraPlanoSaude);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region Pais
        public void DeletePais(PaisDTO pais)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PaisDTO> DAL = new NHibernateDAL<PaisDTO>(Session);
                    DAL.Delete(pais);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PaisDTO SalvarAtualizarPais(PaisDTO pais)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PaisDTO> DAL = new NHibernateDAL<PaisDTO>(Session);
                    DAL.SaveOrUpdate(pais);
                    Session.Flush();
                }
                return pais;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PaisDTO> SelectPais(PaisDTO pais)
        {
            try
            {
                IList<PaisDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PaisDTO> DAL = new NHibernateDAL<PaisDTO>(Session);
                    Resultado = DAL.Select(pais);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PaisDTO> SelectPaisPagina(int primeiroResultado, int quantidadeResultados, PaisDTO pais)
        {
            try
            {
                IList<PaisDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PaisDTO> DAL = new NHibernateDAL<PaisDTO>(Session);
                    Resultado = DAL.SelectPagina<PaisDTO>(primeiroResultado, quantidadeResultados, pais);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region Produto
        public void DeleteProduto(ProdutoDTO produto)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoDTO> DAL = new NHibernateDAL<ProdutoDTO>(Session);
                    DAL.Delete(produto);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public ProdutoDTO SalvarAtualizarProduto(ProdutoDTO produto)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoDTO> DAL = new NHibernateDAL<ProdutoDTO>(Session);
                    DAL.SaveOrUpdate(produto);
                    Session.Flush();
                }
                return produto;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ProdutoDTO> SelectProduto(ProdutoDTO produto)
        {
            try
            {
                IList<ProdutoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoDTO> DAL = new NHibernateDAL<ProdutoDTO>(Session);
                    Resultado = DAL.Select(produto);

                    if (Resultado != null)
                    {
                        foreach (ProdutoDTO prod in Resultado)
                        {
                            prod.ListaFichaTecnica = DAL.Select<FichaTecnicaDTO>(new FichaTecnicaDTO { IdProduto = prod.Id });
                        }
                    }

                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public ProdutoDTO SelectProdutoId(ProdutoDTO produto)
        {
            try
            {
                ProdutoDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoDTO> DAL = new NHibernateDAL<ProdutoDTO>(Session);
                    Resultado = DAL.SelectId<ProdutoDTO>(produto.Id);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public IList<ProdutoDTO> SelectProdutoPagina(int primeiroResultado, int quantidadeResultados, ProdutoDTO produto)
        {
            try
            {
                IList<ProdutoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoDTO> DAL = new NHibernateDAL<ProdutoDTO>(Session);
                    Resultado = DAL.SelectPagina<ProdutoDTO>(primeiroResultado, quantidadeResultados, produto);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ProdutoSubGrupo
        public void DeleteProdutoSubGrupo(ProdutoSubGrupoDTO produtoSubGrupo)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoSubGrupoDTO> DAL = new NHibernateDAL<ProdutoSubGrupoDTO>(Session);
                    DAL.Delete(produtoSubGrupo);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public ProdutoSubGrupoDTO SalvarAtualizarProdutoSubGrupo(ProdutoSubGrupoDTO produtoSubGrupo)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoSubGrupoDTO> DAL = new NHibernateDAL<ProdutoSubGrupoDTO>(Session);
                    DAL.SaveOrUpdate(produtoSubGrupo);
                    Session.Flush();
                }
                return produtoSubGrupo;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ProdutoSubGrupoDTO> SelectProdutoSubGrupo(ProdutoSubGrupoDTO produtoSubGrupo)
        {
            try
            {
                IList<ProdutoSubGrupoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoSubGrupoDTO> DAL = new NHibernateDAL<ProdutoSubGrupoDTO>(Session);
                    Resultado = DAL.Select(produtoSubGrupo);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ProdutoSubGrupoDTO> SelectProdutoSubGrupoPagina(int primeiroResultado, int quantidadeResultados, ProdutoSubGrupoDTO produtoSubGrupo)
        {
            try
            {
                IList<ProdutoSubGrupoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoSubGrupoDTO> DAL = new NHibernateDAL<ProdutoSubGrupoDTO>(Session);
                    Resultado = DAL.SelectPagina<ProdutoSubGrupoDTO>(primeiroResultado, quantidadeResultados, produtoSubGrupo);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ProdutoMarca
        public void DeleteProdutoMarca(ProdutoMarcaDTO produtoMarca)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoMarcaDTO> DAL = new NHibernateDAL<ProdutoMarcaDTO>(Session);
                    DAL.Delete(produtoMarca);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public ProdutoMarcaDTO SalvarAtualizarProdutoMarca(ProdutoMarcaDTO produtoMarca)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoMarcaDTO> DAL = new NHibernateDAL<ProdutoMarcaDTO>(Session);
                    DAL.SaveOrUpdate(produtoMarca);
                    Session.Flush();
                }
                return produtoMarca;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ProdutoMarcaDTO> SelectProdutoMarca(ProdutoMarcaDTO produtoMarca)
        {
            try
            {
                IList<ProdutoMarcaDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoMarcaDTO> DAL = new NHibernateDAL<ProdutoMarcaDTO>(Session);
                    Resultado = DAL.Select(produtoMarca);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ProdutoMarcaDTO> SelectProdutoMarcaPagina(int primeiroResultado, int quantidadeResultados, ProdutoMarcaDTO produtoMarca)
        {
            try
            {
                IList<ProdutoMarcaDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoMarcaDTO> DAL = new NHibernateDAL<ProdutoMarcaDTO>(Session);
                    Resultado = DAL.SelectPagina<ProdutoMarcaDTO>(primeiroResultado, quantidadeResultados, produtoMarca);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region Almoxarifado
        public void DeleteAlmoxarifado(AlmoxarifadoDTO almoxarifado)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<AlmoxarifadoDTO> DAL = new NHibernateDAL<AlmoxarifadoDTO>(Session);
                    DAL.Delete(almoxarifado);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public AlmoxarifadoDTO SalvarAtualizarAlmoxarifado(AlmoxarifadoDTO almoxarifado)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<AlmoxarifadoDTO> DAL = new NHibernateDAL<AlmoxarifadoDTO>(Session);
                    DAL.SaveOrUpdate(almoxarifado);
                    Session.Flush();
                }
                return almoxarifado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<AlmoxarifadoDTO> SelectAlmoxarifado(AlmoxarifadoDTO almoxarifado)
        {
            try
            {
                IList<AlmoxarifadoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<AlmoxarifadoDTO> DAL = new NHibernateDAL<AlmoxarifadoDTO>(Session);
                    Resultado = DAL.Select(almoxarifado);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<AlmoxarifadoDTO> SelectAlmoxarifadoPagina(int primeiroResultado, int quantidadeResultados, AlmoxarifadoDTO almoxarifado)
        {
            try
            {
                IList<AlmoxarifadoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<AlmoxarifadoDTO> DAL = new NHibernateDAL<AlmoxarifadoDTO>(Session);
                    Resultado = DAL.SelectPagina<AlmoxarifadoDTO>(primeiroResultado, quantidadeResultados, almoxarifado);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region Pessoa
        public void DeletePessoa(PessoaDTO pessoa)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PessoaDTO> DAL = new NHibernateDAL<PessoaDTO>(Session);
                    DAL.Delete(pessoa);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PessoaDTO SalvarAtualizarPessoa(PessoaDTO pessoa)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PessoaDTO> DAL = new NHibernateDAL<PessoaDTO>(Session);
                    DAL.SaveOrUpdate(pessoa);
                    Session.Flush();
                }
                return pessoa;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PessoaDTO> SelectPessoa(PessoaDTO pessoa)
        {
            try
            {
                IList<PessoaDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PessoaDTO> DAL = new NHibernateDAL<PessoaDTO>(Session);
                    Resultado = DAL.Select(pessoa);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PessoaDTO> SelectPessoaPagina(int primeiroResultado, int quantidadeResultados, PessoaDTO pessoa)
        {
            try
            {
                IList<PessoaDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PessoaDTO> DAL = new NHibernateDAL<PessoaDTO>(Session);
                    Resultado = DAL.SelectPagina<PessoaDTO>(primeiroResultado, quantidadeResultados, pessoa);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region Contador

        public IList<ContadorDTO> SelectContador(ContadorDTO contador)
        {
            try
            {
                IList<ContadorDTO> resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContadorDTO> DAL = new NHibernateDAL<ContadorDTO>(Session);
                    resultado = DAL.Select(contador);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContadorDTO> SelectContadorPagina(int primeiroResultado, int quantidadeResultados, ContadorDTO contador)
        {
            try
            {
                IList<ContadorDTO> resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContadorDTO> DAL = new NHibernateDAL<ContadorDTO>(Session);
                    resultado = DAL.SelectPagina<ContadorDTO>(primeiroResultado, quantidadeResultados, contador);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion

        #region Banco
        public void DeleteBanco(BancoDTO banco)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<BancoDTO> DAL = new NHibernateDAL<BancoDTO>(Session);
                    DAL.Delete(banco);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public BancoDTO SalvarAtualizarBanco(BancoDTO banco)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<BancoDTO> DAL = new NHibernateDAL<BancoDTO>(Session);
                    DAL.SaveOrUpdate(banco);
                    Session.Flush();
                }
                return banco;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<BancoDTO> SelectBanco(BancoDTO banco)
        {
            try
            {
                IList<BancoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<BancoDTO> DAL = new NHibernateDAL<BancoDTO>(Session);
                    Resultado = DAL.Select(banco);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<BancoDTO> SelectBancoPagina(int primeiroResultado, int quantidadeResultados, BancoDTO banco)
        {
            try
            {
                IList<BancoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<BancoDTO> DAL = new NHibernateDAL<BancoDTO>(Session);
                    Resultado = DAL.SelectPagina<BancoDTO>(primeiroResultado, quantidadeResultados, banco);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region UnidadeProduto
        public void DeleteUnidadeProduto(UnidadeProdutoDTO unidadeProduto)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<UnidadeProdutoDTO> DAL = new NHibernateDAL<UnidadeProdutoDTO>(Session);
                    DAL.Delete(unidadeProduto);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public UnidadeProdutoDTO SalvarAtualizarUnidadeProduto(UnidadeProdutoDTO unidadeProduto)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<UnidadeProdutoDTO> DAL = new NHibernateDAL<UnidadeProdutoDTO>(Session);
                    DAL.SaveOrUpdate(unidadeProduto);
                    Session.Flush();
                }
                return unidadeProduto;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<UnidadeProdutoDTO> SelectUnidadeProduto(UnidadeProdutoDTO unidadeProduto)
        {
            try
            {
                IList<UnidadeProdutoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<UnidadeProdutoDTO> DAL = new NHibernateDAL<UnidadeProdutoDTO>(Session);
                    Resultado = DAL.Select(unidadeProduto);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<UnidadeProdutoDTO> SelectUnidadeProdutoPagina(int primeiroResultado, int quantidadeResultados, UnidadeProdutoDTO unidadeProduto)
        {
            try
            {
                IList<UnidadeProdutoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<UnidadeProdutoDTO> DAL = new NHibernateDAL<UnidadeProdutoDTO>(Session);
                    Resultado = DAL.SelectPagina<UnidadeProdutoDTO>(primeiroResultado, quantidadeResultados, unidadeProduto);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region Colaborador
        public int DeleteColaborador(ColaboradorDTO colaborador)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ColaboradorDTO> DAL = new NHibernateDAL<ColaboradorDTO>(Session);
                    DAL.Delete(colaborador);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public ColaboradorDTO SalvarAtualizarColaborador(ColaboradorDTO colaborador)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ColaboradorDTO> DAL = new NHibernateDAL<ColaboradorDTO>(Session);
                    DAL.SaveOrUpdate(colaborador);
                    Session.Flush();
                }
                return colaborador;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ColaboradorDTO> SelectColaborador(ColaboradorDTO colaborador)
        {
            try
            {
                IList<ColaboradorDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ColaboradorDTO> DAL = new NHibernateDAL<ColaboradorDTO>(Session);
                    Resultado = DAL.Select(colaborador);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ColaboradorDTO> SelectColaboradorPagina(int primeiroResultado, int quantidadeResultados, ColaboradorDTO colaborador)
        {
            try
            {
                IList<ColaboradorDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ColaboradorDTO> DAL = new NHibernateDAL<ColaboradorDTO>(Session);
                    Resultado = DAL.SelectPagina<ColaboradorDTO>(primeiroResultado, quantidadeResultados, colaborador);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #endregion

        #region === Compras ===

        #region CompraPedidoDetalhe
        public int DeleteCompraPedidoDetalhe(CompraPedidoDetalheDTO compraPedidoDetalhe)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraPedidoDetalheDTO> DAL = new NHibernateDAL<CompraPedidoDetalheDTO>(Session);
                    DAL.Delete(compraPedidoDetalhe);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public CompraPedidoDetalheDTO SalvarAtualizarCompraPedidoDetalhe(CompraPedidoDetalheDTO compraPedidoDetalhe)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraPedidoDetalheDTO> DAL = new NHibernateDAL<CompraPedidoDetalheDTO>(Session);
                    DAL.SaveOrUpdate(compraPedidoDetalhe);
                    Session.Flush();
                }
                return compraPedidoDetalhe;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraPedidoDetalheDTO> SelectCompraPedidoDetalhe(CompraPedidoDetalheDTO compraPedidoDetalhe)
        {
            try
            {
                IList<CompraPedidoDetalheDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraPedidoDetalheDTO> DAL = new NHibernateDAL<CompraPedidoDetalheDTO>(Session);
                    Resultado = DAL.Select(compraPedidoDetalhe);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraPedidoDetalheDTO> SelectCompraPedidoDetalhePagina(int primeiroResultado, int quantidadeResultados, CompraPedidoDetalheDTO compraPedidoDetalhe)
        {
            try
            {
                IList<CompraPedidoDetalheDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraPedidoDetalheDTO> DAL = new NHibernateDAL<CompraPedidoDetalheDTO>(Session);
                    Resultado = DAL.SelectPagina<CompraPedidoDetalheDTO>(primeiroResultado, quantidadeResultados, compraPedidoDetalhe);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region CompraTipoPedido
        public int DeleteCompraTipoPedido(CompraTipoPedidoDTO compraTipoPedido)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraTipoPedidoDTO> DAL = new NHibernateDAL<CompraTipoPedidoDTO>(Session);
                    DAL.Delete(compraTipoPedido);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public CompraTipoPedidoDTO SalvarAtualizarCompraTipoPedido(CompraTipoPedidoDTO compraTipoPedido)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraTipoPedidoDTO> DAL = new NHibernateDAL<CompraTipoPedidoDTO>(Session);
                    DAL.SaveOrUpdate(compraTipoPedido);
                    Session.Flush();
                }
                return compraTipoPedido;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraTipoPedidoDTO> SelectCompraTipoPedido(CompraTipoPedidoDTO compraTipoPedido)
        {
            try
            {
                IList<CompraTipoPedidoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraTipoPedidoDTO> DAL = new NHibernateDAL<CompraTipoPedidoDTO>(Session);
                    Resultado = DAL.Select(compraTipoPedido);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraTipoPedidoDTO> SelectCompraTipoPedidoPagina(int primeiroResultado, int quantidadeResultados, CompraTipoPedidoDTO compraTipoPedido)
        {
            try
            {
                IList<CompraTipoPedidoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraTipoPedidoDTO> DAL = new NHibernateDAL<CompraTipoPedidoDTO>(Session);
                    Resultado = DAL.SelectPagina<CompraTipoPedidoDTO>(primeiroResultado, quantidadeResultados, compraTipoPedido);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region CompraRequisicaoDetalhe
        public int DeleteCompraRequisicaoDetalhe(CompraRequisicaoDetalheDTO compraRequisicaoDetalhe)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraRequisicaoDetalheDTO> DAL = new NHibernateDAL<CompraRequisicaoDetalheDTO>(Session);
                    DAL.Delete(compraRequisicaoDetalhe);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public CompraRequisicaoDetalheDTO SalvarAtualizarCompraRequisicaoDetalhe(CompraRequisicaoDetalheDTO compraRequisicaoDetalhe)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraRequisicaoDetalheDTO> DAL = new NHibernateDAL<CompraRequisicaoDetalheDTO>(Session);
                    DAL.SaveOrUpdate(compraRequisicaoDetalhe);
                    Session.Flush();
                }
                return compraRequisicaoDetalhe;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraRequisicaoDetalheDTO> SelectCompraRequisicaoDetalhe(CompraRequisicaoDetalheDTO compraRequisicaoDetalhe)
        {
            try
            {
                IList<CompraRequisicaoDetalheDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraRequisicaoDetalheDTO> DAL = new NHibernateDAL<CompraRequisicaoDetalheDTO>(Session);
                    Resultado = DAL.Select(compraRequisicaoDetalhe);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraRequisicaoDetalheDTO> SelectCompraRequisicaoDetalhePagina(int primeiroResultado, int quantidadeResultados, CompraRequisicaoDetalheDTO compraRequisicaoDetalhe)
        {
            try
            {
                IList<CompraRequisicaoDetalheDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraRequisicaoDetalheDTO> DAL = new NHibernateDAL<CompraRequisicaoDetalheDTO>(Session);
                    Resultado = DAL.SelectPagina<CompraRequisicaoDetalheDTO>(primeiroResultado, quantidadeResultados, compraRequisicaoDetalhe);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region CompraReqCotacaoDetalhe
        public int DeleteCompraReqCotacaoDetalhe(CompraReqCotacaoDetalheDTO compraReqCotacaoDetalhe)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraReqCotacaoDetalheDTO> DAL = new NHibernateDAL<CompraReqCotacaoDetalheDTO>(Session);
                    DAL.Delete(compraReqCotacaoDetalhe);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public CompraReqCotacaoDetalheDTO SalvarAtualizarCompraReqCotacaoDetalhe(CompraReqCotacaoDetalheDTO compraReqCotacaoDetalhe)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraReqCotacaoDetalheDTO> DAL = new NHibernateDAL<CompraReqCotacaoDetalheDTO>(Session);
                    DAL.SaveOrUpdate(compraReqCotacaoDetalhe);
                    Session.Flush();
                }
                return compraReqCotacaoDetalhe;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraReqCotacaoDetalheDTO> SelectCompraReqCotacaoDetalhe(CompraReqCotacaoDetalheDTO compraReqCotacaoDetalhe)
        {
            try
            {
                IList<CompraReqCotacaoDetalheDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraReqCotacaoDetalheDTO> DAL = new NHibernateDAL<CompraReqCotacaoDetalheDTO>(Session);
                    Resultado = DAL.Select(compraReqCotacaoDetalhe);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraReqCotacaoDetalheDTO> SelectCompraReqCotacaoDetalhePagina(int primeiroResultado, int quantidadeResultados, CompraReqCotacaoDetalheDTO compraReqCotacaoDetalhe)
        {
            try
            {
                IList<CompraReqCotacaoDetalheDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraReqCotacaoDetalheDTO> DAL = new NHibernateDAL<CompraReqCotacaoDetalheDTO>(Session);
                    Resultado = DAL.SelectPagina<CompraReqCotacaoDetalheDTO>(primeiroResultado, quantidadeResultados, compraReqCotacaoDetalhe);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region CompraRequisicao
        public int DeleteCompraRequisicao(CompraRequisicaoDTO compraRequisicao)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraRequisicaoDTO> DAL = new NHibernateDAL<CompraRequisicaoDTO>(Session);
                    DAL.Delete(compraRequisicao);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public CompraRequisicaoDTO SalvarAtualizarCompraRequisicao(CompraRequisicaoDTO compraRequisicao)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraRequisicaoDTO> DAL = new NHibernateDAL<CompraRequisicaoDTO>(Session);
                    DAL.SaveOrUpdate(compraRequisicao);
                    Session.Flush();
                }
                return compraRequisicao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraRequisicaoDTO> SelectCompraRequisicao(CompraRequisicaoDTO compraRequisicao)
        {
            try
            {
                IList<CompraRequisicaoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraRequisicaoDTO> DAL = new NHibernateDAL<CompraRequisicaoDTO>(Session);
                    Resultado = DAL.Select(compraRequisicao);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraRequisicaoDTO> SelectCompraRequisicaoPagina(int primeiroResultado, int quantidadeResultados, CompraRequisicaoDTO compraRequisicao)
        {
            try
            {
                IList<CompraRequisicaoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraRequisicaoDTO> DAL = new NHibernateDAL<CompraRequisicaoDTO>(Session);
                    Resultado = DAL.SelectPagina<CompraRequisicaoDTO>(primeiroResultado, quantidadeResultados, compraRequisicao);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region CompraPedido
        public int DeleteCompraPedido(CompraPedidoDTO compraPedido)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraPedidoDTO> DAL = new NHibernateDAL<CompraPedidoDTO>(Session);
                    DAL.Delete(compraPedido);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public CompraPedidoDTO SalvarAtualizarCompraPedido(CompraPedidoDTO compraPedido)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraPedidoDTO> DAL = new NHibernateDAL<CompraPedidoDTO>(Session);
                    DAL.SaveOrUpdate(compraPedido);
                    Session.Flush();
                }
                return compraPedido;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraPedidoDTO> SelectCompraPedido(CompraPedidoDTO compraPedido)
        {
            try
            {
                IList<CompraPedidoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraPedidoDTO> DAL = new NHibernateDAL<CompraPedidoDTO>(Session);
                    Resultado = DAL.Select(compraPedido);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraPedidoDTO> SelectCompraPedidoPagina(int primeiroResultado, int quantidadeResultados, CompraPedidoDTO compraPedido)
        {
            try
            {
                IList<CompraPedidoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraPedidoDTO> DAL = new NHibernateDAL<CompraPedidoDTO>(Session);
                    Resultado = DAL.SelectPagina<CompraPedidoDTO>(primeiroResultado, quantidadeResultados, compraPedido);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region CompraTipoRequisicao
        public int DeleteCompraTipoRequisicao(CompraTipoRequisicaoDTO compraTipoRequisicao)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraTipoRequisicaoDTO> DAL = new NHibernateDAL<CompraTipoRequisicaoDTO>(Session);
                    DAL.Delete(compraTipoRequisicao);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public CompraTipoRequisicaoDTO SalvarAtualizarCompraTipoRequisicao(CompraTipoRequisicaoDTO compraTipoRequisicao)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraTipoRequisicaoDTO> DAL = new NHibernateDAL<CompraTipoRequisicaoDTO>(Session);
                    DAL.SaveOrUpdate(compraTipoRequisicao);
                    Session.Flush();
                }
                return compraTipoRequisicao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraTipoRequisicaoDTO> SelectCompraTipoRequisicao(CompraTipoRequisicaoDTO compraTipoRequisicao)
        {
            try
            {
                IList<CompraTipoRequisicaoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraTipoRequisicaoDTO> DAL = new NHibernateDAL<CompraTipoRequisicaoDTO>(Session);
                    Resultado = DAL.Select(compraTipoRequisicao);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraTipoRequisicaoDTO> SelectCompraTipoRequisicaoPagina(int primeiroResultado, int quantidadeResultados, CompraTipoRequisicaoDTO compraTipoRequisicao)
        {
            try
            {
                IList<CompraTipoRequisicaoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraTipoRequisicaoDTO> DAL = new NHibernateDAL<CompraTipoRequisicaoDTO>(Session);
                    Resultado = DAL.SelectPagina<CompraTipoRequisicaoDTO>(primeiroResultado, quantidadeResultados, compraTipoRequisicao);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region CompraCotacao
        public int DeleteCompraCotacao(CompraCotacaoDTO compraCotacao)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraCotacaoDTO> DAL = new NHibernateDAL<CompraCotacaoDTO>(Session);
                    DAL.Delete(compraCotacao);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public CompraCotacaoDTO SalvarAtualizarCompraCotacao(CompraCotacaoDTO compraCotacao)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraCotacaoDTO> DAL = new NHibernateDAL<CompraCotacaoDTO>(Session);
                    DAL.SaveOrUpdate(compraCotacao);
                    Session.Flush();
                }
                return compraCotacao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraCotacaoDTO> SelectCompraCotacao(CompraCotacaoDTO compraCotacao)
        {
            try
            {
                IList<CompraCotacaoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraCotacaoDTO> DAL = new NHibernateDAL<CompraCotacaoDTO>(Session);
                    Resultado = DAL.Select(compraCotacao);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraCotacaoDTO> SelectCompraCotacaoPagina(int primeiroResultado, int quantidadeResultados, CompraCotacaoDTO compraCotacao)
        {
            try
            {
                IList<CompraCotacaoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraCotacaoDTO> DAL = new NHibernateDAL<CompraCotacaoDTO>(Session);
                    Resultado = DAL.SelectPagina<CompraCotacaoDTO>(primeiroResultado, quantidadeResultados, compraCotacao);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region CompraFornecedorCotacao
        public int DeleteCompraFornecedorCotacao(CompraFornecedorCotacaoDTO compraFornecedorCotacao)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraFornecedorCotacaoDTO> DAL = new NHibernateDAL<CompraFornecedorCotacaoDTO>(Session);
                    DAL.Delete(compraFornecedorCotacao);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public CompraFornecedorCotacaoDTO SalvarAtualizarCompraFornecedorCotacao(CompraFornecedorCotacaoDTO compraFornecedorCotacao)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraFornecedorCotacaoDTO> DAL = new NHibernateDAL<CompraFornecedorCotacaoDTO>(Session);
                    DAL.SaveOrUpdate(compraFornecedorCotacao);
                    Session.Flush();
                }
                return compraFornecedorCotacao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraFornecedorCotacaoDTO> SelectCompraFornecedorCotacao(CompraFornecedorCotacaoDTO compraFornecedorCotacao)
        {
            try
            {
                IList<CompraFornecedorCotacaoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraFornecedorCotacaoDTO> DAL = new NHibernateDAL<CompraFornecedorCotacaoDTO>(Session);
                    Resultado = DAL.Select(compraFornecedorCotacao);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraFornecedorCotacaoDTO> SelectCompraFornecedorCotacaoPagina(int primeiroResultado, int quantidadeResultados, CompraFornecedorCotacaoDTO compraFornecedorCotacao)
        {
            try
            {
                IList<CompraFornecedorCotacaoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraFornecedorCotacaoDTO> DAL = new NHibernateDAL<CompraFornecedorCotacaoDTO>(Session);
                    Resultado = DAL.SelectPagina<CompraFornecedorCotacaoDTO>(primeiroResultado, quantidadeResultados, compraFornecedorCotacao);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region CompraCotacaoDetalhe
        public int DeleteCompraCotacaoDetalhe(CompraCotacaoDetalheDTO compraCotacaoDetalhe)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraCotacaoDetalheDTO> DAL = new NHibernateDAL<CompraCotacaoDetalheDTO>(Session);
                    DAL.Delete(compraCotacaoDetalhe);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public CompraCotacaoDetalheDTO SalvarAtualizarCompraCotacaoDetalhe(CompraCotacaoDetalheDTO compraCotacaoDetalhe)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraCotacaoDetalheDTO> DAL = new NHibernateDAL<CompraCotacaoDetalheDTO>(Session);
                    DAL.SaveOrUpdate(compraCotacaoDetalhe);
                    Session.Flush();
                }
                return compraCotacaoDetalhe;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraCotacaoDetalheDTO> SelectCompraCotacaoDetalhe(CompraCotacaoDetalheDTO compraCotacaoDetalhe)
        {
            try
            {
                IList<CompraCotacaoDetalheDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraCotacaoDetalheDTO> DAL = new NHibernateDAL<CompraCotacaoDetalheDTO>(Session);
                    Resultado = DAL.Select(compraCotacaoDetalhe);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraCotacaoDetalheDTO> SelectCompraCotacaoDetalhePagina(int primeiroResultado, int quantidadeResultados, CompraCotacaoDetalheDTO compraCotacaoDetalhe)
        {
            try
            {
                IList<CompraCotacaoDetalheDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraCotacaoDetalheDTO> DAL = new NHibernateDAL<CompraCotacaoDetalheDTO>(Session);
                    Resultado = DAL.SelectPagina<CompraCotacaoDetalheDTO>(primeiroResultado, quantidadeResultados, compraCotacaoDetalhe);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region CompraCotacaoPedidoDetalhe
        public int DeleteCompraCotacaoPedidoDetalhe(CompraCotacaoPedidoDetalheDTO compraCotacaoPedidoDetalhe)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraCotacaoPedidoDetalheDTO> DAL = new NHibernateDAL<CompraCotacaoPedidoDetalheDTO>(Session);
                    DAL.Delete(compraCotacaoPedidoDetalhe);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public CompraCotacaoPedidoDetalheDTO SalvarAtualizarCompraCotacaoPedidoDetalhe(CompraCotacaoPedidoDetalheDTO compraCotacaoPedidoDetalhe)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraCotacaoPedidoDetalheDTO> DAL = new NHibernateDAL<CompraCotacaoPedidoDetalheDTO>(Session);
                    DAL.SaveOrUpdate(compraCotacaoPedidoDetalhe);
                    Session.Flush();
                }
                return compraCotacaoPedidoDetalhe;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraCotacaoPedidoDetalheDTO> SelectCompraCotacaoPedidoDetalhe(CompraCotacaoPedidoDetalheDTO compraCotacaoPedidoDetalhe)
        {
            try
            {
                IList<CompraCotacaoPedidoDetalheDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraCotacaoPedidoDetalheDTO> DAL = new NHibernateDAL<CompraCotacaoPedidoDetalheDTO>(Session);
                    Resultado = DAL.Select(compraCotacaoPedidoDetalhe);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraCotacaoPedidoDetalheDTO> SelectCompraCotacaoPedidoDetalhePagina(int primeiroResultado, int quantidadeResultados, CompraCotacaoPedidoDetalheDTO compraCotacaoPedidoDetalhe)
        {
            try
            {
                IList<CompraCotacaoPedidoDetalheDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraCotacaoPedidoDetalheDTO> DAL = new NHibernateDAL<CompraCotacaoPedidoDetalheDTO>(Session);
                    Resultado = DAL.SelectPagina<CompraCotacaoPedidoDetalheDTO>(primeiroResultado, quantidadeResultados, compraCotacaoPedidoDetalhe);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 


        #endregion

        #region === Escrita Fiscal ===

        #region NotaFiscalTipo
        public int DeleteNotaFiscalTipo(NotaFiscalTipoDTO notaFiscalTipo)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NotaFiscalTipoDTO> DAL = new NHibernateDAL<NotaFiscalTipoDTO>(Session);
                    DAL.Delete(notaFiscalTipo);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public NotaFiscalTipoDTO SalvarAtualizarNotaFiscalTipo(NotaFiscalTipoDTO notaFiscalTipo)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NotaFiscalTipoDTO> DAL = new NHibernateDAL<NotaFiscalTipoDTO>(Session);
                    DAL.SaveOrUpdate(notaFiscalTipo);
                    Session.Flush();
                }
                return notaFiscalTipo;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<NotaFiscalTipoDTO> SelectNotaFiscalTipo(NotaFiscalTipoDTO notaFiscalTipo)
        {
            try
            {
                IList<NotaFiscalTipoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NotaFiscalTipoDTO> DAL = new NHibernateDAL<NotaFiscalTipoDTO>(Session);
                    Resultado = DAL.Select(notaFiscalTipo);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<NotaFiscalTipoDTO> SelectNotaFiscalTipoPagina(int primeiroResultado, int quantidadeResultados, NotaFiscalTipoDTO notaFiscalTipo)
        {
            try
            {
                IList<NotaFiscalTipoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NotaFiscalTipoDTO> DAL = new NHibernateDAL<NotaFiscalTipoDTO>(Session);
                    Resultado = DAL.SelectPagina<NotaFiscalTipoDTO>(primeiroResultado, quantidadeResultados, notaFiscalTipo);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region SimplesNacionalCabecalho
        public int DeleteSimplesNacionalCabecalho(SimplesNacionalCabecalhoDTO simplesNacionalCabecalho)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<SimplesNacionalCabecalhoDTO> DAL = new NHibernateDAL<SimplesNacionalCabecalhoDTO>(Session);
                    DAL.Delete(simplesNacionalCabecalho);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public SimplesNacionalCabecalhoDTO SalvarAtualizarSimplesNacionalCabecalho(SimplesNacionalCabecalhoDTO simplesNacionalCabecalho)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<SimplesNacionalCabecalhoDTO> DAL = new NHibernateDAL<SimplesNacionalCabecalhoDTO>(Session);
                    DAL.SaveOrUpdate(simplesNacionalCabecalho);
                    Session.Flush();
                }
                return simplesNacionalCabecalho;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<SimplesNacionalCabecalhoDTO> SelectSimplesNacionalCabecalho(SimplesNacionalCabecalhoDTO simplesNacionalCabecalho)
        {
            try
            {
                IList<SimplesNacionalCabecalhoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<SimplesNacionalCabecalhoDTO> DAL = new NHibernateDAL<SimplesNacionalCabecalhoDTO>(Session);
                    Resultado = DAL.Select(simplesNacionalCabecalho);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<SimplesNacionalCabecalhoDTO> SelectSimplesNacionalCabecalhoPagina(int primeiroResultado, int quantidadeResultados, SimplesNacionalCabecalhoDTO simplesNacionalCabecalho)
        {
            try
            {
                IList<SimplesNacionalCabecalhoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<SimplesNacionalCabecalhoDTO> DAL = new NHibernateDAL<SimplesNacionalCabecalhoDTO>(Session);
                    Resultado = DAL.SelectPagina<SimplesNacionalCabecalhoDTO>(primeiroResultado, quantidadeResultados, simplesNacionalCabecalho);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region RegistroCartorio
        public int DeleteRegistroCartorio(RegistroCartorioDTO registroCartorio)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<RegistroCartorioDTO> DAL = new NHibernateDAL<RegistroCartorioDTO>(Session);
                    DAL.Delete(registroCartorio);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public RegistroCartorioDTO SalvarAtualizarRegistroCartorio(RegistroCartorioDTO registroCartorio)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<RegistroCartorioDTO> DAL = new NHibernateDAL<RegistroCartorioDTO>(Session);
                    DAL.SaveOrUpdate(registroCartorio);
                    Session.Flush();
                }
                return registroCartorio;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<RegistroCartorioDTO> SelectRegistroCartorio(RegistroCartorioDTO registroCartorio)
        {
            try
            {
                IList<RegistroCartorioDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<RegistroCartorioDTO> DAL = new NHibernateDAL<RegistroCartorioDTO>(Session);
                    Resultado = DAL.Select(registroCartorio);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<RegistroCartorioDTO> SelectRegistroCartorioPagina(int primeiroResultado, int quantidadeResultados, RegistroCartorioDTO registroCartorio)
        {
            try
            {
                IList<RegistroCartorioDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<RegistroCartorioDTO> DAL = new NHibernateDAL<RegistroCartorioDTO>(Session);
                    Resultado = DAL.SelectPagina<RegistroCartorioDTO>(primeiroResultado, quantidadeResultados, registroCartorio);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FiscalParametro
        public int DeleteFiscalParametro(FiscalParametroDTO fiscalParametro)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalParametroDTO> DAL = new NHibernateDAL<FiscalParametroDTO>(Session);
                    DAL.Delete(fiscalParametro);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public FiscalParametroDTO SalvarAtualizarFiscalParametro(FiscalParametroDTO fiscalParametro)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalParametroDTO> DAL = new NHibernateDAL<FiscalParametroDTO>(Session);
                    DAL.SaveOrUpdate(fiscalParametro);
                    Session.Flush();
                }
                return fiscalParametro;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FiscalParametroDTO> SelectFiscalParametro(FiscalParametroDTO fiscalParametro)
        {
            try
            {
                IList<FiscalParametroDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalParametroDTO> DAL = new NHibernateDAL<FiscalParametroDTO>(Session);
                    Resultado = DAL.Select(fiscalParametro);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FiscalParametroDTO> SelectFiscalParametroPagina(int primeiroResultado, int quantidadeResultados, FiscalParametroDTO fiscalParametro)
        {
            try
            {
                IList<FiscalParametroDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalParametroDTO> DAL = new NHibernateDAL<FiscalParametroDTO>(Session);
                    Resultado = DAL.SelectPagina<FiscalParametroDTO>(primeiroResultado, quantidadeResultados, fiscalParametro);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FiscalLivro
        public int DeleteFiscalLivro(FiscalLivroDTO fiscalLivro)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalLivroDTO> DAL = new NHibernateDAL<FiscalLivroDTO>(Session);
                    DAL.Delete(fiscalLivro);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public FiscalLivroDTO SalvarAtualizarFiscalLivro(FiscalLivroDTO fiscalLivro)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalLivroDTO> DAL = new NHibernateDAL<FiscalLivroDTO>(Session);
                    DAL.SaveOrUpdate(fiscalLivro);
                    Session.Flush();
                }
                return fiscalLivro;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FiscalLivroDTO> SelectFiscalLivro(FiscalLivroDTO fiscalLivro)
        {
            try
            {
                IList<FiscalLivroDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalLivroDTO> DAL = new NHibernateDAL<FiscalLivroDTO>(Session);
                    Resultado = DAL.Select(fiscalLivro);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FiscalLivroDTO> SelectFiscalLivroPagina(int primeiroResultado, int quantidadeResultados, FiscalLivroDTO fiscalLivro)
        {
            try
            {
                IList<FiscalLivroDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalLivroDTO> DAL = new NHibernateDAL<FiscalLivroDTO>(Session);
                    Resultado = DAL.SelectPagina<FiscalLivroDTO>(primeiroResultado, quantidadeResultados, fiscalLivro);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FiscalApuracaoIcms
        public int DeleteFiscalApuracaoIcms(FiscalApuracaoIcmsDTO fiscalApuracaoIcms)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalApuracaoIcmsDTO> DAL = new NHibernateDAL<FiscalApuracaoIcmsDTO>(Session);
                    DAL.Delete(fiscalApuracaoIcms);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public FiscalApuracaoIcmsDTO SalvarAtualizarFiscalApuracaoIcms(FiscalApuracaoIcmsDTO fiscalApuracaoIcms)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalApuracaoIcmsDTO> DAL = new NHibernateDAL<FiscalApuracaoIcmsDTO>(Session);
                    DAL.SaveOrUpdate(fiscalApuracaoIcms);
                    Session.Flush();
                }
                return fiscalApuracaoIcms;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FiscalApuracaoIcmsDTO> SelectFiscalApuracaoIcms(FiscalApuracaoIcmsDTO fiscalApuracaoIcms)
        {
            try
            {
                IList<FiscalApuracaoIcmsDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalApuracaoIcmsDTO> DAL = new NHibernateDAL<FiscalApuracaoIcmsDTO>(Session);
                    Resultado = DAL.Select(fiscalApuracaoIcms);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FiscalApuracaoIcmsDTO> SelectFiscalApuracaoIcmsPagina(int primeiroResultado, int quantidadeResultados, FiscalApuracaoIcmsDTO fiscalApuracaoIcms)
        {
            try
            {
                IList<FiscalApuracaoIcmsDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalApuracaoIcmsDTO> DAL = new NHibernateDAL<FiscalApuracaoIcmsDTO>(Session);
                    Resultado = DAL.SelectPagina<FiscalApuracaoIcmsDTO>(primeiroResultado, quantidadeResultados, fiscalApuracaoIcms);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FiscalTermo
        public int DeleteFiscalTermo(FiscalTermoDTO fiscalTermo)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalTermoDTO> DAL = new NHibernateDAL<FiscalTermoDTO>(Session);
                    DAL.Delete(fiscalTermo);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public FiscalTermoDTO SalvarAtualizarFiscalTermo(FiscalTermoDTO fiscalTermo)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalTermoDTO> DAL = new NHibernateDAL<FiscalTermoDTO>(Session);
                    DAL.SaveOrUpdate(fiscalTermo);
                    Session.Flush();
                }
                return fiscalTermo;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FiscalTermoDTO> SelectFiscalTermo(FiscalTermoDTO fiscalTermo)
        {
            try
            {
                IList<FiscalTermoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalTermoDTO> DAL = new NHibernateDAL<FiscalTermoDTO>(Session);
                    Resultado = DAL.Select(fiscalTermo);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FiscalTermoDTO> SelectFiscalTermoPagina(int primeiroResultado, int quantidadeResultados, FiscalTermoDTO fiscalTermo)
        {
            try
            {
                IList<FiscalTermoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalTermoDTO> DAL = new NHibernateDAL<FiscalTermoDTO>(Session);
                    Resultado = DAL.SelectPagina<FiscalTermoDTO>(primeiroResultado, quantidadeResultados, fiscalTermo);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 


        #endregion


        #region === Nfe ===

        #region NfeCabecalho
        public void DeleteNfeCabecalho(NfeCabecalhoDTO nfeCabecalho)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeCabecalhoDTO> DAL = new NHibernateDAL<NfeCabecalhoDTO>(Session);
                    DAL.Delete(nfeCabecalho);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public NfeCabecalhoDTO SalvarAtualizarNfeCabecalho(NfeCabecalhoDTO nfeCabecalho)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeCabecalhoDTO> DAL = new NHibernateDAL<NfeCabecalhoDTO>(Session);

                    if (nfeCabecalho.Id == 0)
                    {
                        nfeCabecalho.ChaveAcesso = nfeCabecalho.NfeEmitente.CodigoMunicipio.ToString().Substring(0, 2) +
                                           ((DateTime)nfeCabecalho.DataHoraEmissao).ToString("yy") +
                                           ((DateTime)nfeCabecalho.DataHoraEmissao).ToString("MM") +
                                           nfeCabecalho.NfeEmitente.CpfCnpj +
                                           "55" +
                                           (int.Parse(nfeCabecalho.Serie)).ToString("000") +
                                           (int.Parse(nfeCabecalho.Numero)).ToString("000000000") +
                                           nfeCabecalho.FinalidadeEmissao +
                                           (int.Parse(nfeCabecalho.Numero)).ToString("00000000");
                        nfeCabecalho.DigitoChaveAcesso = Biblioteca.DigitoModulo11(nfeCabecalho.ChaveAcesso);

                        nfeCabecalho.Numero = (int.Parse(nfeCabecalho.Numero)).ToString("000000000");
                        nfeCabecalho.CodigoNumerico = (int.Parse(nfeCabecalho.Numero)).ToString("00000000");

                        //Ambiente, 2 - homologacao
                        nfeCabecalho.Ambiente = 2;
                    }

                    DAL.SaveOrUpdate(nfeCabecalho);

                    if (nfeCabecalho.NfeDestinatario != null)
                    {
                        NHibernateDAL<NfeDestinatarioDTO> nfeDest = new NHibernateDAL<NfeDestinatarioDTO>(Session);
                        nfeCabecalho.NfeDestinatario.IdNfeCabecalho = nfeCabecalho.Id;
                        nfeDest.SaveOrUpdate(nfeCabecalho.NfeDestinatario);
                    }

                    if (nfeCabecalho.NfeEmitente != null)
                    {
                        NHibernateDAL<NfeEmitenteDTO> nfeEmit = new NHibernateDAL<NfeEmitenteDTO>(Session);
                        nfeCabecalho.NfeEmitente.IdNfeCabecalho = nfeCabecalho.Id;
                        nfeEmit.SaveOrUpdate(nfeCabecalho.NfeEmitente);
                    }

                    if (nfeCabecalho.NfeFatura != null)
                    {
                        NHibernateDAL<NfeFaturaDTO> nfeFatura = new NHibernateDAL<NfeFaturaDTO>(Session);
                        nfeCabecalho.NfeFatura.IdNfeCabecalho = nfeCabecalho.Id;
                        nfeFatura.SaveOrUpdate(nfeCabecalho.NfeFatura);
                    }

                    if (nfeCabecalho.ListaNfeDuplicata.Count > 0)
                    {
                        NHibernateDAL<NfeDuplicataDTO> nfeDuplicata = new NHibernateDAL<NfeDuplicataDTO>(Session);

                        IList<NfeDuplicataDTO> listaDuplic = nfeCabecalho.ListaNfeDuplicata;
                        foreach (NfeDuplicataDTO duplic in listaDuplic)
                        {
                            duplic.IdNfeCabecalho = nfeCabecalho.Id;
                            nfeDuplicata.SaveOrUpdate((NfeDuplicataDTO)Session.Merge(duplic));
                        }
                    }

                    if (nfeCabecalho.ListaNfeCupomFiscalReferenciado.Count > 0)
                    {
                        NHibernateDAL<NfeCupomFiscalReferenciadoDTO> nfeCF = new NHibernateDAL<NfeCupomFiscalReferenciadoDTO>(Session);

                        IList<NfeCupomFiscalReferenciadoDTO> listaCupom = nfeCabecalho.ListaNfeCupomFiscalReferenciado;
                        foreach (NfeCupomFiscalReferenciadoDTO nfeCupom in listaCupom)
                        {
                            nfeCupom.IdNfeCabecalho = nfeCabecalho.Id;
                            nfeCF.SaveOrUpdate((NfeCupomFiscalReferenciadoDTO)Session.Merge(nfeCupom));
                        }
                    }

                    if (nfeCabecalho.ListaNfeDetalhe.Count > 0)
                    {
                        NHibernateDAL<NfeDetalheDTO> nfeDetDAL = new NHibernateDAL<NfeDetalheDTO>(Session);

                        IList<NfeDetalheDTO> listaDetalhe = nfeCabecalho.ListaNfeDetalhe;
                        foreach (NfeDetalheDTO nfeDet in listaDetalhe)
                        {
                            nfeDet.IdNfeCabecalho = nfeCabecalho.Id;
                            nfeDetDAL.SaveOrUpdate(nfeDet);

                            nfeDetDAL.SaveOrUpdate((NfeDetalheDTO)Session.Merge(nfeDet));

                            /// EXERCICIO: Atualize o estoque
                            // Atualiza estoque TIPO_OPERACAO ->> 0=Entrada | 1=Saída
                            /*
                              if (nfeCabecalho.TipoOperacao == 0)
                                AtualizarEstoque(nfeDet.QuantidadeComercial, nfeDet.IdProduto, nfeCabecalho.IdEmpresa, Empresa.TipoControleEstoque)
                              else
                                AtualizarEstoque(nfeDet.QuantidadeComercial * -1, nfeDet.IdProduto, nfeCabecalho.IdEmpresa, Empresa.TipoControleEstoque)
                            */

                            if (nfeDet.NfeDetalheImpostoIcms != null)
                            {
                                NHibernateDAL<NfeDetalheImpostoIcmsDTO> impostoIcms = new NHibernateDAL<NfeDetalheImpostoIcmsDTO>(Session);
                                nfeDet.NfeDetalheImpostoIcms.IdNfeDetalhe = nfeDet.Id;
                                impostoIcms.SaveOrUpdate(nfeDet.NfeDetalheImpostoIcms);
                            }

                            if (nfeDet.NfeDetalheImpostoCofins != null)
                            {
                                NHibernateDAL<NfeDetalheImpostoCofinsDTO> impostoCofins = new NHibernateDAL<NfeDetalheImpostoCofinsDTO>(Session);
                                nfeDet.NfeDetalheImpostoCofins.IdNfeDetalhe = nfeDet.Id;
                                impostoCofins.SaveOrUpdate(nfeDet.NfeDetalheImpostoCofins);
                            }

                            if (nfeDet.NfeDetalheImpostoPis != null)
                            {
                                NHibernateDAL<NfeDetalheImpostoPisDTO> impostoPis = new NHibernateDAL<NfeDetalheImpostoPisDTO>(Session);
                                nfeDet.NfeDetalheImpostoPis.IdNfeDetalhe = nfeDet.Id;
                                impostoPis.SaveOrUpdate(nfeDet.NfeDetalheImpostoPis);
                            }

                        }
                    }

                    if (nfeCabecalho.NfeLocalEntrega != null)
                    {
                        NHibernateDAL<NfeLocalEntregaDTO> nfeLE = new NHibernateDAL<NfeLocalEntregaDTO>(Session);
                        nfeCabecalho.NfeLocalEntrega.IdNfeCabecalho = nfeCabecalho.Id;
                        nfeLE.SaveOrUpdate(nfeCabecalho.NfeLocalEntrega);
                    }

                    if (nfeCabecalho.NfeLocalRetirada != null)
                    {
                        NHibernateDAL<NfeLocalRetiradaDTO> nfeLR = new NHibernateDAL<NfeLocalRetiradaDTO>(Session);
                        nfeCabecalho.NfeLocalRetirada.IdNfeCabecalho = nfeCabecalho.Id;
                        nfeLR.SaveOrUpdate(nfeCabecalho.NfeLocalRetirada);
                    }

                    if (nfeCabecalho.NfeTransporte != null)
                    {
                        NHibernateDAL<NfeTransporteDTO> nfeTransporte = new NHibernateDAL<NfeTransporteDTO>(Session);
                        nfeCabecalho.NfeTransporte.IdNfeCabecalho = nfeCabecalho.Id;
                        nfeTransporte.SaveOrUpdate(nfeCabecalho.NfeTransporte);
                    }

                    Session.Flush();
                }
                return nfeCabecalho;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public IList<NfeCabecalhoDTO> SelectNfeCabecalho(NfeCabecalhoDTO nfeCabecalho)
        {
            try
            {
                IList<NfeCabecalhoDTO> resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeCabecalhoDTO> DAL = new NHibernateDAL<NfeCabecalhoDTO>(Session);
                    resultado = DAL.Select(nfeCabecalho);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public IList<NfeCabecalhoDTO> SelectNfeCabecalhoPagina(int primeiroResultado, int quantidadeResultados, NfeCabecalhoDTO nfeCabecalho)
        {
            try
            {
                IList<NfeCabecalhoDTO> resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeCabecalhoDTO> DAL = new NHibernateDAL<NfeCabecalhoDTO>(Session);
                    resultado = DAL.SelectPagina<NfeCabecalhoDTO>(primeiroResultado, quantidadeResultados, nfeCabecalho);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public NfeCabecalhoDTO SelectNfeCabecalhoId(int id)
        {
            try
            {
                NfeCabecalhoDTO resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeCabecalhoDTO> nfeDAL = new NHibernateDAL<NfeCabecalhoDTO>(Session);
                    resultado = nfeDAL.SelectId<NfeCabecalhoDTO>(id);
                    
                    if (resultado != null)
                    { 

                        NHibernateDAL<NfeDestinatarioDTO> nfeDest = new NHibernateDAL<NfeDestinatarioDTO>(Session);
                        resultado.NfeDestinatario = nfeDest.SelectObjeto<NfeDestinatarioDTO>(new NfeDestinatarioDTO { IdNfeCabecalho = resultado.Id });
                    
                        NHibernateDAL<NfeEmitenteDTO> nfeEmit = new NHibernateDAL<NfeEmitenteDTO>(Session);
                        resultado.NfeEmitente = nfeEmit.SelectObjeto<NfeEmitenteDTO>(new NfeEmitenteDTO { IdNfeCabecalho = resultado.Id });

                        NHibernateDAL<NfeLocalEntregaDTO> nfeLE = new NHibernateDAL<NfeLocalEntregaDTO>(Session);
                        resultado.NfeLocalEntrega = nfeLE.SelectObjeto<NfeLocalEntregaDTO>(new NfeLocalEntregaDTO { IdNfeCabecalho = resultado.Id });

                        NHibernateDAL<NfeLocalRetiradaDTO> nfeLR = new NHibernateDAL<NfeLocalRetiradaDTO>(Session);
                        resultado.NfeLocalRetirada = nfeLR.SelectObjeto<NfeLocalRetiradaDTO>(new NfeLocalRetiradaDTO { IdNfeCabecalho = resultado.Id });

                        NHibernateDAL<NfeTransporteDTO> nfeTransporte = new NHibernateDAL<NfeTransporteDTO>(Session);
                        resultado.NfeTransporte = nfeTransporte.SelectObjeto<NfeTransporteDTO>(new NfeTransporteDTO { IdNfeCabecalho = resultado.Id });

                        NHibernateDAL<NfeFaturaDTO> nfeFatura = new NHibernateDAL<NfeFaturaDTO>(Session);
                        resultado.NfeFatura = nfeFatura.SelectObjeto<NfeFaturaDTO>(new NfeFaturaDTO { IdNfeCabecalho = resultado.Id });

                        NHibernateDAL<NfeCupomFiscalReferenciadoDTO> nfeCF = new NHibernateDAL<NfeCupomFiscalReferenciadoDTO>(Session);
                        resultado.ListaNfeCupomFiscalReferenciado = nfeCF.Select<NfeCupomFiscalReferenciadoDTO>(new NfeCupomFiscalReferenciadoDTO { IdNfeCabecalho = resultado.Id });

                        NHibernateDAL<NfeDetalheDTO> nfeDetDAL = new NHibernateDAL<NfeDetalheDTO>(Session);
                        resultado.ListaNfeDetalhe = nfeDetDAL.Select<NfeDetalheDTO>(new NfeDetalheDTO { IdNfeCabecalho = id });

                        foreach (NfeDetalheDTO item in resultado.ListaNfeDetalhe)
                        {
                            NHibernateDAL<NfeDetalheImpostoCofinsDTO> nfeDetCofins = new NHibernateDAL<NfeDetalheImpostoCofinsDTO>(Session);
                            item.NfeDetalheImpostoCofins = nfeDetCofins.SelectObjeto<NfeDetalheImpostoCofinsDTO>(new NfeDetalheImpostoCofinsDTO { IdNfeDetalhe = item.Id });

                            NHibernateDAL<NfeDetalheImpostoIcmsDTO> nfeDetIcms = new NHibernateDAL<NfeDetalheImpostoIcmsDTO>(Session);
                            item.NfeDetalheImpostoIcms = nfeDetIcms.SelectObjeto<NfeDetalheImpostoIcmsDTO>(new NfeDetalheImpostoIcmsDTO { IdNfeDetalhe = item.Id });

                            NHibernateDAL<NfeDetalheImpostoIssqnDTO> nfeDetIss = new NHibernateDAL<NfeDetalheImpostoIssqnDTO>(Session);
                            item.NfeDetalheImpostoIssqn = nfeDetIss.SelectObjeto<NfeDetalheImpostoIssqnDTO>(new NfeDetalheImpostoIssqnDTO { IdNfeDetalhe = item.Id });

                            NHibernateDAL<NfeDetalheImpostoPisDTO> nfeDetPis = new NHibernateDAL<NfeDetalheImpostoPisDTO>(Session);
                            item.NfeDetalheImpostoPis = nfeDetPis.SelectObjeto<NfeDetalheImpostoPisDTO>(new NfeDetalheImpostoPisDTO { IdNfeDetalhe = item.Id });

                            NHibernateDAL<NfeDetalheImpostoIpiDTO> nfeDetIpi = new NHibernateDAL<NfeDetalheImpostoIpiDTO>(Session);
                            item.NfeDetalheImpostoIpi = nfeDetIpi.SelectObjeto<NfeDetalheImpostoIpiDTO>(new NfeDetalheImpostoIpiDTO { IdNfeDetalhe = item.Id });

                            NHibernateDAL<NfeDetalheImpostoIiDTO> nfeDetII = new NHibernateDAL<NfeDetalheImpostoIiDTO>(Session);
                            item.NfeDetalheImpostoII = nfeDetII.SelectObjeto<NfeDetalheImpostoIiDTO>(new NfeDetalheImpostoIiDTO { IdNfeDetalhe = item.Id });
                        }


                        NHibernateDAL<NfeDuplicataDTO> nfeDupl = new NHibernateDAL<NfeDuplicataDTO>(Session);
                        resultado.ListaNfeDuplicata = nfeDupl.Select<NfeDuplicataDTO>(new NfeDuplicataDTO { IdNfeCabecalho = id });
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        #endregion

        #endregion

        #region === Tributação ===

        #region TributOperacaoFiscal
        public int DeleteTributOperacaoFiscal(TributOperacaoFiscalDTO tributOperacaoFiscal)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributOperacaoFiscalDTO> DAL = new NHibernateDAL<TributOperacaoFiscalDTO>(Session);
                    DAL.Delete(tributOperacaoFiscal);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public TributOperacaoFiscalDTO SalvarAtualizarTributOperacaoFiscal(TributOperacaoFiscalDTO tributOperacaoFiscal)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributOperacaoFiscalDTO> DAL = new NHibernateDAL<TributOperacaoFiscalDTO>(Session);
                    DAL.SaveOrUpdate(tributOperacaoFiscal);
                    Session.Flush();
                }
                return tributOperacaoFiscal;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TributOperacaoFiscalDTO> SelectTributOperacaoFiscal(TributOperacaoFiscalDTO tributOperacaoFiscal)
        {
            try
            {
                IList<TributOperacaoFiscalDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributOperacaoFiscalDTO> DAL = new NHibernateDAL<TributOperacaoFiscalDTO>(Session);
                    Resultado = DAL.Select(tributOperacaoFiscal);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TributOperacaoFiscalDTO> SelectTributOperacaoFiscalPagina(int primeiroResultado, int quantidadeResultados, TributOperacaoFiscalDTO tributOperacaoFiscal)
        {
            try
            {
                IList<TributOperacaoFiscalDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributOperacaoFiscalDTO> DAL = new NHibernateDAL<TributOperacaoFiscalDTO>(Session);
                    Resultado = DAL.SelectPagina<TributOperacaoFiscalDTO>(primeiroResultado, quantidadeResultados, tributOperacaoFiscal);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region TributGrupoTributario
        public void DeleteTributGrupoTributario(TributGrupoTributarioDTO tributGrupoTributario)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributGrupoTributarioDTO> DAL = new NHibernateDAL<TributGrupoTributarioDTO>(Session);
                    DAL.Delete(tributGrupoTributario);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public TributGrupoTributarioDTO SalvarAtualizarTributGrupoTributario(TributGrupoTributarioDTO tributGrupoTributario)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributGrupoTributarioDTO> DAL = new NHibernateDAL<TributGrupoTributarioDTO>(Session);
                    DAL.SaveOrUpdate(tributGrupoTributario);
                    Session.Flush();
                }
                return tributGrupoTributario;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TributGrupoTributarioDTO> SelectTributGrupoTributario(TributGrupoTributarioDTO tributGrupoTributario)
        {
            try
            {
                IList<TributGrupoTributarioDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributGrupoTributarioDTO> DAL = new NHibernateDAL<TributGrupoTributarioDTO>(Session);
                    Resultado = DAL.Select(tributGrupoTributario);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TributGrupoTributarioDTO> SelectTributGrupoTributarioPagina(int primeiroResultado, int quantidadeResultados, TributGrupoTributarioDTO tributGrupoTributario)
        {
            try
            {
                IList<TributGrupoTributarioDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributGrupoTributarioDTO> DAL = new NHibernateDAL<TributGrupoTributarioDTO>(Session);
                    Resultado = DAL.SelectPagina<TributGrupoTributarioDTO>(primeiroResultado, quantidadeResultados, tributGrupoTributario);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region TributIcmsCustomCab
        public void DeleteTributIcmsCustomCab(TributIcmsCustomCabDTO tributIcmsCustomCab)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributIcmsCustomCabDTO> DAL = new NHibernateDAL<TributIcmsCustomCabDTO>(Session);
                    DAL.Delete(tributIcmsCustomCab);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public TributIcmsCustomCabDTO SalvarAtualizarTributIcmsCustomCab(TributIcmsCustomCabDTO tributIcmsCustomCab)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributIcmsCustomCabDTO> DAL = new NHibernateDAL<TributIcmsCustomCabDTO>(Session);
                    DAL.SaveOrUpdate(tributIcmsCustomCab);
                    Session.Flush();
                }
                return tributIcmsCustomCab;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TributIcmsCustomCabDTO> SelectTributIcmsCustomCab(TributIcmsCustomCabDTO tributIcmsCustomCab)
        {
            try
            {
                IList<TributIcmsCustomCabDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributIcmsCustomCabDTO> DAL = new NHibernateDAL<TributIcmsCustomCabDTO>(Session);
                    Resultado = DAL.Select(tributIcmsCustomCab);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TributIcmsCustomCabDTO> SelectTributIcmsCustomCabPagina(int primeiroResultado, int quantidadeResultados, TributIcmsCustomCabDTO tributIcmsCustomCab)
        {
            try
            {
                IList<TributIcmsCustomCabDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributIcmsCustomCabDTO> DAL = new NHibernateDAL<TributIcmsCustomCabDTO>(Session);
                    Resultado = DAL.SelectPagina<TributIcmsCustomCabDTO>(primeiroResultado, quantidadeResultados, tributIcmsCustomCab);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 
        
        #region ViewTributacaoCofins
        public ViewTributacaoCofinsDTO SelectViewTributacaoCofins(ViewTributacaoCofinsDTO viewTributacaoCofins)
        {
            try
            {
                ViewTributacaoCofinsDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewTributacaoCofinsDTO> DAL = new NHibernateDAL<ViewTributacaoCofinsDTO>(Session);
                    Resultado = DAL.SelectObjeto(viewTributacaoCofins);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        #endregion 

        #region ViewTributacaoPis
        public ViewTributacaoPisDTO SelectViewTributacaoPis(ViewTributacaoPisDTO viewTributacaoPis)
        {
            try
            {
                ViewTributacaoPisDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewTributacaoPisDTO> DAL = new NHibernateDAL<ViewTributacaoPisDTO>(Session);
                    Resultado = DAL.SelectObjeto(viewTributacaoPis);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        #endregion 

        #region ViewTributacaoIcms
        public ViewTributacaoIcmsDTO SelectViewTributacaoIcms(ViewTributacaoIcmsDTO viewTributacaoIcms)
        {
            try
            {
                ViewTributacaoIcmsDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewTributacaoIcmsDTO> DAL = new NHibernateDAL<ViewTributacaoIcmsDTO>(Session);
                    Resultado = DAL.SelectObjeto(viewTributacaoIcms);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        #endregion 

        #endregion

        #region === Sintegra ===

        public byte[] GerarSintegra(string pDataIni, string pDataFim, string pCodigoConvenio, string pFinalidade, string pNaturezaInformacao, string pIdEmpresa, string pInventario, string pIdContador)
        {
            SintegraDAL sintegra = new SintegraDAL();

            try
            {
                if (sintegra.GerarArquivoSintegra(pDataIni, pDataFim, int.Parse(pCodigoConvenio), int.Parse(pFinalidade), int.Parse(pNaturezaInformacao), int.Parse(pIdEmpresa), int.Parse(pInventario), int.Parse(pIdContador)))
                {
                    FileInfo fi = new FileInfo("C:\\T2Ti\\Arquivos\\Sintegra.txt");
                    FileStream fs = fi.OpenRead();
                    MemoryStream ms = new MemoryStream((int)fs.Length);
                    fs.CopyTo(ms);
                    fs.Close();
                    ms.Position = 0L;
                    return ms.ToArray();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region === Sped ===

        public byte[] GerarSped(string pDataIni, string pDataFim, string pVersao, string pFinalidade, string pPerfil, string pIdEmpresa, string pInventario, string pIdContador)
        {
            SpedFiscalDAL sped = new SpedFiscalDAL();

            try
            {
                if (sped.GerarArquivoSpedFiscal(pDataIni, pDataFim, int.Parse(pVersao), int.Parse(pFinalidade), int.Parse(pPerfil), int.Parse(pIdEmpresa), int.Parse(pInventario), int.Parse(pIdContador)))
                {
                    FileInfo fi = new FileInfo("C:\\T2Ti\\Arquivos\\SpedFiscal.txt");
                    FileStream fs = fi.OpenRead();
                    MemoryStream ms = new MemoryStream((int)fs.Length);
                    fs.CopyTo(ms);
                    fs.Close();
                    ms.Position = 0L;
                    return ms.ToArray();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] GerarSpedContribuicoes(string pDataIni, string pDataFim, string pVersao, string pTipoEscrituracao, string pIdEmpresa, string pIdContador)
        {
            SpedContribuicoesDAL sped = new SpedContribuicoesDAL();

            try
            {
                if (sped.GerarArquivoSpedContribuicoes(pDataIni, pDataFim, int.Parse(pVersao), int.Parse(pTipoEscrituracao), int.Parse(pIdEmpresa), int.Parse(pIdContador)))
                {
                    FileInfo fi = new FileInfo("C:\\T2Ti\\Arquivos\\SpedContribuicoes.txt");
                    FileStream fs = fi.OpenRead();
                    MemoryStream ms = new MemoryStream((int)fs.Length);
                    fs.CopyTo(ms);
                    fs.Close();
                    ms.Position = 0L;
                    return ms.ToArray();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] GerarSpedContabil(string pDataIni, string pDataFim, string pFormaEscrituracao, string pLayoutVersao, string pIdEmpresa)
        {
            SpedContabilDAL sped = new SpedContabilDAL();

            try
            {
                if (sped.GerarArquivoSpedContabil(pDataIni, pDataFim, int.Parse(pFormaEscrituracao), int.Parse(pLayoutVersao), int.Parse(pIdEmpresa)))
                {
                    FileInfo fi = new FileInfo("C:\\T2Ti\\Arquivos\\SpedContabil.txt");
                    FileStream fs = fi.OpenRead();
                    MemoryStream ms = new MemoryStream((int)fs.Length);
                    fs.CopyTo(ms);
                    fs.Close();
                    ms.Position = 0L;
                    return ms.ToArray();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region === BalcaoPAF ===

        #region DavCabecalho
        public void DeleteDavCabecalho(DavCabecalhoDTO davCabecalho)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<DavCabecalhoDTO> DAL = new NHibernateDAL<DavCabecalhoDTO>(Session);
                    DAL.Delete(davCabecalho);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public DavCabecalhoDTO SalvarAtualizarDavCabecalho(DavCabecalhoDTO davCabecalho)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<DavCabecalhoDTO> DAL = new NHibernateDAL<DavCabecalhoDTO>(Session);
                    DAL.SaveOrUpdate(davCabecalho);
                    Session.Flush();
                }
                return davCabecalho;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<DavCabecalhoDTO> SelectDavCabecalho(DavCabecalhoDTO davCabecalho)
        {
            try
            {
                IList<DavCabecalhoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<DavCabecalhoDTO> DAL = new NHibernateDAL<DavCabecalhoDTO>(Session);
                    Resultado = DAL.Select(davCabecalho);

                    foreach (DavCabecalhoDTO objP in Resultado)
                    {
                        NHibernateDAL<DavDetalheDTO> DALDetalhe = new NHibernateDAL<DavDetalheDTO>(Session);
                        objP.ListaDavDetalhe = DAL.Select<DavDetalheDTO>(new DavDetalheDTO { IdDavCabecalho = objP.Id });

                        if (objP.ListaDavDetalhe == null)
                            objP.ListaDavDetalhe = new List<DavDetalheDTO>();
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<DavCabecalhoDTO> SelectDavCabecalhoPagina(int primeiroResultado, int quantidadeResultados, DavCabecalhoDTO davCabecalho)
        {
            try
            {
                IList<DavCabecalhoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<DavCabecalhoDTO> DAL = new NHibernateDAL<DavCabecalhoDTO>(Session);
                    Resultado = DAL.SelectPagina<DavCabecalhoDTO>(primeiroResultado, quantidadeResultados, davCabecalho);

                    foreach (DavCabecalhoDTO objP in Resultado)
                    {
                        NHibernateDAL<DavDetalheDTO> DALDetalhe = new NHibernateDAL<DavDetalheDTO>(Session);
                        objP.ListaDavDetalhe = DAL.Select<DavDetalheDTO>(new DavDetalheDTO { IdDavCabecalho = objP.Id });

                        if (objP.ListaDavDetalhe == null)
                            objP.ListaDavDetalhe = new List<DavDetalheDTO>();
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public DavCabecalhoDTO SelectObjetoDavCabecalho(string pFiltro)
        {
            try
            {
                DavCabecalhoDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<DavCabecalhoDTO> DAL = new NHibernateDAL<DavCabecalhoDTO>(Session);
                    Resultado = DAL.SelectObjetoSql<DavCabecalhoDTO>(pFiltro);

                    if (Resultado != null)
                    {
                        NHibernateDAL<DavDetalheDTO> DALDetalhe = new NHibernateDAL<DavDetalheDTO>(Session);
                        Resultado.ListaDavDetalhe = DAL.Select<DavDetalheDTO>(new DavDetalheDTO { IdDavCabecalho = Resultado.Id });

                        if (Resultado.ListaDavDetalhe == null)
                            Resultado.ListaDavDetalhe = new List<DavDetalheDTO>();
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        #endregion

        #region PreVendaCabecalho
        public void DeletePreVendaCabecalho(PreVendaCabecalhoDTO preVendaCabecalho)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PreVendaCabecalhoDTO> DAL = new NHibernateDAL<PreVendaCabecalhoDTO>(Session);
                    DAL.Delete(preVendaCabecalho);
                    Session.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PreVendaCabecalhoDTO SalvarAtualizarPreVendaCabecalho(PreVendaCabecalhoDTO preVendaCabecalho)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PreVendaCabecalhoDTO> DAL = new NHibernateDAL<PreVendaCabecalhoDTO>(Session);
                    DAL.SaveOrUpdate(preVendaCabecalho);
                    Session.Flush();
                }
                return preVendaCabecalho;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PreVendaCabecalhoDTO> SelectPreVendaCabecalho(PreVendaCabecalhoDTO preVendaCabecalho)
        {
            try
            {
                IList<PreVendaCabecalhoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PreVendaCabecalhoDTO> DAL = new NHibernateDAL<PreVendaCabecalhoDTO>(Session);
                    Resultado = DAL.Select(preVendaCabecalho);

                    foreach (PreVendaCabecalhoDTO objP in Resultado)
                    {
                        NHibernateDAL<PreVendaDetalheDTO> DALDetalhe = new NHibernateDAL<PreVendaDetalheDTO>(Session);
                        objP.ListaPreVendaDetalhe = DAL.Select<PreVendaDetalheDTO>(new PreVendaDetalheDTO { IdPreVendaCabecalho = objP.Id });

                        if (objP.ListaPreVendaDetalhe == null)
                            objP.ListaPreVendaDetalhe = new List<PreVendaDetalheDTO>();
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PreVendaCabecalhoDTO> SelectPreVendaCabecalhoPagina(int primeiroResultado, int quantidadeResultados, PreVendaCabecalhoDTO preVendaCabecalho)
        {
            try
            {
                IList<PreVendaCabecalhoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PreVendaCabecalhoDTO> DAL = new NHibernateDAL<PreVendaCabecalhoDTO>(Session);
                    Resultado = DAL.SelectPagina<PreVendaCabecalhoDTO>(primeiroResultado, quantidadeResultados, preVendaCabecalho);

                    foreach (PreVendaCabecalhoDTO objP in Resultado)
                    {
                        NHibernateDAL<PreVendaDetalheDTO> DALDetalhe = new NHibernateDAL<PreVendaDetalheDTO>(Session);
                        objP.ListaPreVendaDetalhe = DAL.Select<PreVendaDetalheDTO>(new PreVendaDetalheDTO { IdPreVendaCabecalho = objP.Id });

                        if (objP.ListaPreVendaDetalhe == null)
                            objP.ListaPreVendaDetalhe = new List<PreVendaDetalheDTO>();
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PreVendaCabecalhoDTO SelectObjetoPreVendaCabecalho(string pFiltro)
        {
            try
            {
                PreVendaCabecalhoDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PreVendaCabecalhoDTO> DAL = new NHibernateDAL<PreVendaCabecalhoDTO>(Session);
                    Resultado = DAL.SelectObjetoSql<PreVendaCabecalhoDTO>(pFiltro);

                    if (Resultado != null)
                    {
                        NHibernateDAL<PreVendaDetalheDTO> DALDetalhe = new NHibernateDAL<PreVendaDetalheDTO>(Session);
                        Resultado.ListaPreVendaDetalhe = DAL.Select<PreVendaDetalheDTO>(new PreVendaDetalheDTO { IdPreVendaCabecalho = Resultado.Id });

                        if (Resultado.ListaPreVendaDetalhe == null)
                            Resultado.ListaPreVendaDetalhe = new List<PreVendaDetalheDTO>();
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        #endregion 

        #endregion

        #region === PCP ===

        #region PcpServicoColaborador
        public int DeletePcpServicoColaborador(PcpServicoColaboradorDTO pcpServicoColaborador)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpServicoColaboradorDTO> DAL = new NHibernateDAL<PcpServicoColaboradorDTO>(Session);
                    DAL.Delete(pcpServicoColaborador);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PcpServicoColaboradorDTO SalvarAtualizarPcpServicoColaborador(PcpServicoColaboradorDTO pcpServicoColaborador)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpServicoColaboradorDTO> DAL = new NHibernateDAL<PcpServicoColaboradorDTO>(Session);
                    DAL.SaveOrUpdate(pcpServicoColaborador);
                    Session.Flush();
                }
                return pcpServicoColaborador;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PcpServicoColaboradorDTO> SelectPcpServicoColaborador(PcpServicoColaboradorDTO pcpServicoColaborador)
        {
            try
            {
                IList<PcpServicoColaboradorDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpServicoColaboradorDTO> DAL = new NHibernateDAL<PcpServicoColaboradorDTO>(Session);
                    Resultado = DAL.Select(pcpServicoColaborador);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PcpServicoColaboradorDTO> SelectPcpServicoColaboradorPagina(int primeiroResultado, int quantidadeResultados, PcpServicoColaboradorDTO pcpServicoColaborador)
        {
            try
            {
                IList<PcpServicoColaboradorDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpServicoColaboradorDTO> DAL = new NHibernateDAL<PcpServicoColaboradorDTO>(Session);
                    Resultado = DAL.SelectPagina<PcpServicoColaboradorDTO>(primeiroResultado, quantidadeResultados, pcpServicoColaborador);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PcpServico
        public int DeletePcpServico(PcpServicoDTO pcpServico)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpServicoDTO> DAL = new NHibernateDAL<PcpServicoDTO>(Session);
                    DAL.Delete(pcpServico);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PcpServicoDTO SalvarAtualizarPcpServico(PcpServicoDTO pcpServico)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpServicoDTO> DAL = new NHibernateDAL<PcpServicoDTO>(Session);
                    DAL.SaveOrUpdate(pcpServico);
                    Session.Flush();
                }
                return pcpServico;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PcpServicoDTO> SelectPcpServico(PcpServicoDTO pcpServico)
        {
            try
            {
                IList<PcpServicoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpServicoDTO> DAL = new NHibernateDAL<PcpServicoDTO>(Session);
                    Resultado = DAL.Select(pcpServico);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PcpServicoDTO> SelectPcpServicoPagina(int primeiroResultado, int quantidadeResultados, PcpServicoDTO pcpServico)
        {
            try
            {
                IList<PcpServicoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpServicoDTO> DAL = new NHibernateDAL<PcpServicoDTO>(Session);
                    Resultado = DAL.SelectPagina<PcpServicoDTO>(primeiroResultado, quantidadeResultados, pcpServico);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PcpOpDetalhe
        public int DeletePcpOpDetalhe(PcpOpDetalheDTO pcpOpDetalhe)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpOpDetalheDTO> DAL = new NHibernateDAL<PcpOpDetalheDTO>(Session);
                    DAL.Delete(pcpOpDetalhe);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PcpOpDetalheDTO SalvarAtualizarPcpOpDetalhe(PcpOpDetalheDTO pcpOpDetalhe)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpOpDetalheDTO> DAL = new NHibernateDAL<PcpOpDetalheDTO>(Session);
                    DAL.SaveOrUpdate(pcpOpDetalhe);
                    Session.Flush();
                }
                return pcpOpDetalhe;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PcpOpDetalheDTO> SelectPcpOpDetalhe(PcpOpDetalheDTO pcpOpDetalhe)
        {
            try
            {
                IList<PcpOpDetalheDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpOpDetalheDTO> DAL = new NHibernateDAL<PcpOpDetalheDTO>(Session);
                    Resultado = DAL.Select(pcpOpDetalhe);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PcpOpDetalheDTO> SelectPcpOpDetalhePagina(int primeiroResultado, int quantidadeResultados, PcpOpDetalheDTO pcpOpDetalhe)
        {
            try
            {
                IList<PcpOpDetalheDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpOpDetalheDTO> DAL = new NHibernateDAL<PcpOpDetalheDTO>(Session);
                    Resultado = DAL.SelectPagina<PcpOpDetalheDTO>(primeiroResultado, quantidadeResultados, pcpOpDetalhe);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PcpOpCabecalho
        public int DeletePcpOpCabecalho(PcpOpCabecalhoDTO pcpOpCabecalho)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpOpCabecalhoDTO> DAL = new NHibernateDAL<PcpOpCabecalhoDTO>(Session);
                    DAL.Delete(pcpOpCabecalho);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PcpOpCabecalhoDTO SalvarAtualizarPcpOpCabecalho(PcpOpCabecalhoDTO pcpOpCabecalho)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpOpCabecalhoDTO> DAL = new NHibernateDAL<PcpOpCabecalhoDTO>(Session);
                    DAL.SaveOrUpdate(pcpOpCabecalho);
                    Session.Flush();
                }
                return pcpOpCabecalho;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PcpOpCabecalhoDTO> SelectPcpOpCabecalho(PcpOpCabecalhoDTO pcpOpCabecalho)
        {
            try
            {
                IList<PcpOpCabecalhoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpOpCabecalhoDTO> DAL = new NHibernateDAL<PcpOpCabecalhoDTO>(Session);
                    Resultado = DAL.Select(pcpOpCabecalho);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PcpOpCabecalhoDTO> SelectPcpOpCabecalhoPagina(int primeiroResultado, int quantidadeResultados, PcpOpCabecalhoDTO pcpOpCabecalho)
        {
            try
            {
                IList<PcpOpCabecalhoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpOpCabecalhoDTO> DAL = new NHibernateDAL<PcpOpCabecalhoDTO>(Session);
                    Resultado = DAL.SelectPagina<PcpOpCabecalhoDTO>(primeiroResultado, quantidadeResultados, pcpOpCabecalho);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PcpInstrucaoOp
        public int DeletePcpInstrucaoOp(PcpInstrucaoOpDTO pcpInstrucaoOp)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpInstrucaoOpDTO> DAL = new NHibernateDAL<PcpInstrucaoOpDTO>(Session);
                    DAL.Delete(pcpInstrucaoOp);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PcpInstrucaoOpDTO SalvarAtualizarPcpInstrucaoOp(PcpInstrucaoOpDTO pcpInstrucaoOp)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpInstrucaoOpDTO> DAL = new NHibernateDAL<PcpInstrucaoOpDTO>(Session);
                    DAL.SaveOrUpdate(pcpInstrucaoOp);
                    Session.Flush();
                }
                return pcpInstrucaoOp;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PcpInstrucaoOpDTO> SelectPcpInstrucaoOp(PcpInstrucaoOpDTO pcpInstrucaoOp)
        {
            try
            {
                IList<PcpInstrucaoOpDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpInstrucaoOpDTO> DAL = new NHibernateDAL<PcpInstrucaoOpDTO>(Session);
                    Resultado = DAL.Select(pcpInstrucaoOp);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PcpInstrucaoOpDTO> SelectPcpInstrucaoOpPagina(int primeiroResultado, int quantidadeResultados, PcpInstrucaoOpDTO pcpInstrucaoOp)
        {
            try
            {
                IList<PcpInstrucaoOpDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpInstrucaoOpDTO> DAL = new NHibernateDAL<PcpInstrucaoOpDTO>(Session);
                    Resultado = DAL.SelectPagina<PcpInstrucaoOpDTO>(primeiroResultado, quantidadeResultados, pcpInstrucaoOp);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PcpInstrucao
        public int DeletePcpInstrucao(PcpInstrucaoDTO pcpInstrucao)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpInstrucaoDTO> DAL = new NHibernateDAL<PcpInstrucaoDTO>(Session);
                    DAL.Delete(pcpInstrucao);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PcpInstrucaoDTO SalvarAtualizarPcpInstrucao(PcpInstrucaoDTO pcpInstrucao)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpInstrucaoDTO> DAL = new NHibernateDAL<PcpInstrucaoDTO>(Session);
                    DAL.SaveOrUpdate(pcpInstrucao);
                    Session.Flush();
                }
                return pcpInstrucao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PcpInstrucaoDTO> SelectPcpInstrucao(PcpInstrucaoDTO pcpInstrucao)
        {
            try
            {
                IList<PcpInstrucaoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpInstrucaoDTO> DAL = new NHibernateDAL<PcpInstrucaoDTO>(Session);
                    Resultado = DAL.Select(pcpInstrucao);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PcpInstrucaoDTO> SelectPcpInstrucaoPagina(int primeiroResultado, int quantidadeResultados, PcpInstrucaoDTO pcpInstrucao)
        {
            try
            {
                IList<PcpInstrucaoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpInstrucaoDTO> DAL = new NHibernateDAL<PcpInstrucaoDTO>(Session);
                    Resultado = DAL.SelectPagina<PcpInstrucaoDTO>(primeiroResultado, quantidadeResultados, pcpInstrucao);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PcpServicoEquipamento
        public int DeletePcpServicoEquipamento(PcpServicoEquipamentoDTO pcpServicoEquipamento)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpServicoEquipamentoDTO> DAL = new NHibernateDAL<PcpServicoEquipamentoDTO>(Session);
                    DAL.Delete(pcpServicoEquipamento);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PcpServicoEquipamentoDTO SalvarAtualizarPcpServicoEquipamento(PcpServicoEquipamentoDTO pcpServicoEquipamento)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpServicoEquipamentoDTO> DAL = new NHibernateDAL<PcpServicoEquipamentoDTO>(Session);
                    DAL.SaveOrUpdate(pcpServicoEquipamento);
                    Session.Flush();
                }
                return pcpServicoEquipamento;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PcpServicoEquipamentoDTO> SelectPcpServicoEquipamento(PcpServicoEquipamentoDTO pcpServicoEquipamento)
        {
            try
            {
                IList<PcpServicoEquipamentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpServicoEquipamentoDTO> DAL = new NHibernateDAL<PcpServicoEquipamentoDTO>(Session);
                    Resultado = DAL.Select(pcpServicoEquipamento);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PcpServicoEquipamentoDTO> SelectPcpServicoEquipamentoPagina(int primeiroResultado, int quantidadeResultados, PcpServicoEquipamentoDTO pcpServicoEquipamento)
        {
            try
            {
                IList<PcpServicoEquipamentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<PcpServicoEquipamentoDTO> DAL = new NHibernateDAL<PcpServicoEquipamentoDTO>(Session);
                    Resultado = DAL.SelectPagina<PcpServicoEquipamentoDTO>(primeiroResultado, quantidadeResultados, pcpServicoEquipamento);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 


        
        #endregion

        #region === Inventário ===

        #region InventarioContagemCab
        public int DeleteInventarioContagemCab(InventarioContagemCabDTO inventarioContagemCab)
        {
            /// EXERCICIO
            /// Implemente a exclusão dos detalhes
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<InventarioContagemCabDTO> DAL = new NHibernateDAL<InventarioContagemCabDTO>(Session);
                    DAL.Delete(inventarioContagemCab);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public InventarioContagemCabDTO SalvarAtualizarInventarioContagemCab(InventarioContagemCabDTO inventarioContagemCab)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<InventarioContagemCabDTO> DAL = new NHibernateDAL<InventarioContagemCabDTO>(Session);
                    DAL.SaveOrUpdate(inventarioContagemCab);

                    if (inventarioContagemCab.listaContagemDetalhe != null)
                    {
                        NHibernateDAL<InventarioContagemDetDTO> contagemDetalhe = new NHibernateDAL<InventarioContagemDetDTO>(Session);

                        IList<InventarioContagemDetDTO> listaContagemDetalheIncluir = inventarioContagemCab.listaContagemDetalhe;
                        foreach (InventarioContagemDetDTO contIncluir in listaContagemDetalheIncluir)
                        {
                            contIncluir.IdInventarioContagemCab = inventarioContagemCab.Id;
                            contagemDetalhe.SaveOrUpdate((InventarioContagemDetDTO)Session.Merge(contIncluir));
                        }
                    }                    
                    
                    Session.Flush();
                }
                return inventarioContagemCab;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<InventarioContagemCabDTO> SelectInventarioContagemCab(InventarioContagemCabDTO inventarioContagemCab)
        {
            try
            {
                IList<InventarioContagemCabDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<InventarioContagemCabDTO> DAL = new NHibernateDAL<InventarioContagemCabDTO>(Session);
                    Resultado = DAL.Select(inventarioContagemCab);

                    foreach (InventarioContagemCabDTO objP in Resultado)
                    {
                        NHibernateDAL<InventarioContagemDetDTO> contDetDAL = new NHibernateDAL<InventarioContagemDetDTO>(Session);
                        objP.listaContagemDetalhe = contDetDAL.Select<InventarioContagemDetDTO>(new InventarioContagemDetDTO { IdInventarioContagemCab = objP.Id });
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<InventarioContagemCabDTO> SelectInventarioContagemCabPagina(int primeiroResultado, int quantidadeResultados, InventarioContagemCabDTO inventarioContagemCab)
        {
            try
            {
                IList<InventarioContagemCabDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<InventarioContagemCabDTO> DAL = new NHibernateDAL<InventarioContagemCabDTO>(Session);
                    Resultado = DAL.SelectPagina<InventarioContagemCabDTO>(primeiroResultado, quantidadeResultados, inventarioContagemCab);

                    foreach (InventarioContagemCabDTO objP in Resultado)
                    {
                        NHibernateDAL<InventarioContagemDetDTO> contDetDAL = new NHibernateDAL<InventarioContagemDetDTO>(Session);
                        objP.listaContagemDetalhe = contDetDAL.Select<InventarioContagemDetDTO>(new InventarioContagemDetDTO { IdInventarioContagemCab = objP.Id });
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 


        #region EstoqueReajusteCabecalho
        public int DeleteEstoqueReajusteCabecalho(EstoqueReajusteCabecalhoDTO estoqueReajusteCabecalho)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EstoqueReajusteCabecalhoDTO> DAL = new NHibernateDAL<EstoqueReajusteCabecalhoDTO>(Session);
                    DAL.Delete(estoqueReajusteCabecalho);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public EstoqueReajusteCabecalhoDTO SalvarAtualizarEstoqueReajusteCabecalho(EstoqueReajusteCabecalhoDTO estoqueReajusteCabecalho)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EstoqueReajusteCabecalhoDTO> DAL = new NHibernateDAL<EstoqueReajusteCabecalhoDTO>(Session);
                    DAL.SaveOrUpdate(estoqueReajusteCabecalho);

                    if (estoqueReajusteCabecalho.ListaEstoqueReajusteDetalhe != null)
                    {
                        NHibernateDAL<EstoqueReajusteDetalheDTO> contagemDetalhe = new NHibernateDAL<EstoqueReajusteDetalheDTO>(Session);

                        IList<EstoqueReajusteDetalheDTO> listaContagemDetalheIncluir = estoqueReajusteCabecalho.ListaEstoqueReajusteDetalhe;
                        foreach (EstoqueReajusteDetalheDTO contIncluir in listaContagemDetalheIncluir)
                        {
                            contIncluir.IdEstoqueReajusteCabecalho = estoqueReajusteCabecalho.Id;
                            contagemDetalhe.SaveOrUpdate((EstoqueReajusteDetalheDTO)Session.Merge(contIncluir));
                        }
                    }
                    
                    Session.Flush();

                }
                return estoqueReajusteCabecalho;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<EstoqueReajusteCabecalhoDTO> SelectEstoqueReajusteCabecalho(EstoqueReajusteCabecalhoDTO estoqueReajusteCabecalho)
        {
            try
            {
                IList<EstoqueReajusteCabecalhoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EstoqueReajusteCabecalhoDTO> DAL = new NHibernateDAL<EstoqueReajusteCabecalhoDTO>(Session);
                    Resultado = DAL.Select(estoqueReajusteCabecalho);

                    foreach (EstoqueReajusteCabecalhoDTO objP in Resultado)
                    {
                        NHibernateDAL<EstoqueReajusteDetalheDTO> contDetDAL = new NHibernateDAL<EstoqueReajusteDetalheDTO>(Session);
                        objP.ListaEstoqueReajusteDetalhe = contDetDAL.Select<EstoqueReajusteDetalheDTO>(new EstoqueReajusteDetalheDTO { IdEstoqueReajusteCabecalho = objP.Id });
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<EstoqueReajusteCabecalhoDTO> SelectEstoqueReajusteCabecalhoPagina(int primeiroResultado, int quantidadeResultados, EstoqueReajusteCabecalhoDTO estoqueReajusteCabecalho)
        {
            try
            {
                IList<EstoqueReajusteCabecalhoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EstoqueReajusteCabecalhoDTO> DAL = new NHibernateDAL<EstoqueReajusteCabecalhoDTO>(Session);
                    Resultado = DAL.SelectPagina<EstoqueReajusteCabecalhoDTO>(primeiroResultado, quantidadeResultados, estoqueReajusteCabecalho);

                    foreach (EstoqueReajusteCabecalhoDTO objP in Resultado)
                    {
                        NHibernateDAL<EstoqueReajusteDetalheDTO> contDetDAL = new NHibernateDAL<EstoqueReajusteDetalheDTO>(Session);
                        objP.ListaEstoqueReajusteDetalhe = contDetDAL.Select<EstoqueReajusteDetalheDTO>(new EstoqueReajusteDetalheDTO { IdEstoqueReajusteCabecalho = objP.Id });
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #endregion

        #region === Comissões ===

        #region ComissaoPerfil
        public int DeleteComissaoPerfil(ComissaoPerfilDTO comissaoPerfil)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ComissaoPerfilDTO> DAL = new NHibernateDAL<ComissaoPerfilDTO>(Session);
                    DAL.Delete(comissaoPerfil);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public ComissaoPerfilDTO SalvarAtualizarComissaoPerfil(ComissaoPerfilDTO comissaoPerfil)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ComissaoPerfilDTO> DAL = new NHibernateDAL<ComissaoPerfilDTO>(Session);
                    DAL.SaveOrUpdate(comissaoPerfil);
                    Session.Flush();
                }
                return comissaoPerfil;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ComissaoPerfilDTO> SelectComissaoPerfil(ComissaoPerfilDTO comissaoPerfil)
        {
            try
            {
                IList<ComissaoPerfilDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ComissaoPerfilDTO> DAL = new NHibernateDAL<ComissaoPerfilDTO>(Session);
                    Resultado = DAL.Select(comissaoPerfil);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ComissaoPerfilDTO> SelectComissaoPerfilPagina(int primeiroResultado, int quantidadeResultados, ComissaoPerfilDTO comissaoPerfil)
        {
            try
            {
                IList<ComissaoPerfilDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ComissaoPerfilDTO> DAL = new NHibernateDAL<ComissaoPerfilDTO>(Session);
                    Resultado = DAL.SelectPagina<ComissaoPerfilDTO>(primeiroResultado, quantidadeResultados, comissaoPerfil);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ComissaoObjetivo
        public int DeleteComissaoObjetivo(ComissaoObjetivoDTO comissaoObjetivo)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ComissaoObjetivoDTO> DAL = new NHibernateDAL<ComissaoObjetivoDTO>(Session);
                    DAL.Delete(comissaoObjetivo);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public ComissaoObjetivoDTO SalvarAtualizarComissaoObjetivo(ComissaoObjetivoDTO comissaoObjetivo)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ComissaoObjetivoDTO> DAL = new NHibernateDAL<ComissaoObjetivoDTO>(Session);
                    DAL.SaveOrUpdate(comissaoObjetivo);
                    Session.Flush();
                }
                return comissaoObjetivo;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ComissaoObjetivoDTO> SelectComissaoObjetivo(ComissaoObjetivoDTO comissaoObjetivo)
        {
            try
            {
                IList<ComissaoObjetivoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ComissaoObjetivoDTO> DAL = new NHibernateDAL<ComissaoObjetivoDTO>(Session);
                    Resultado = DAL.Select(comissaoObjetivo);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ComissaoObjetivoDTO> SelectComissaoObjetivoPagina(int primeiroResultado, int quantidadeResultados, ComissaoObjetivoDTO comissaoObjetivo)
        {
            try
            {
                IList<ComissaoObjetivoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ComissaoObjetivoDTO> DAL = new NHibernateDAL<ComissaoObjetivoDTO>(Session);
                    Resultado = DAL.SelectPagina<ComissaoObjetivoDTO>(primeiroResultado, quantidadeResultados, comissaoObjetivo);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #endregion

        #region === Ordem de Serviço ===
        #region OsProdutoServico
        public int DeleteOsProdutoServico(OsProdutoServicoDTO osProdutoServico)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsProdutoServicoDTO> DAL = new NHibernateDAL<OsProdutoServicoDTO>(Session);
                    DAL.Delete(osProdutoServico);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public OsProdutoServicoDTO SalvarAtualizarOsProdutoServico(OsProdutoServicoDTO osProdutoServico)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsProdutoServicoDTO> DAL = new NHibernateDAL<OsProdutoServicoDTO>(Session);
                    DAL.SaveOrUpdate(osProdutoServico);
                    Session.Flush();
                }
                return osProdutoServico;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<OsProdutoServicoDTO> SelectOsProdutoServico(OsProdutoServicoDTO osProdutoServico)
        {
            try
            {
                IList<OsProdutoServicoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsProdutoServicoDTO> DAL = new NHibernateDAL<OsProdutoServicoDTO>(Session);
                    Resultado = DAL.Select(osProdutoServico);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<OsProdutoServicoDTO> SelectOsProdutoServicoPagina(int primeiroResultado, int quantidadeResultados, OsProdutoServicoDTO osProdutoServico)
        {
            try
            {
                IList<OsProdutoServicoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsProdutoServicoDTO> DAL = new NHibernateDAL<OsProdutoServicoDTO>(Session);
                    Resultado = DAL.SelectPagina<OsProdutoServicoDTO>(primeiroResultado, quantidadeResultados, osProdutoServico);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion


        #region OsEvolucao
        public int DeleteOsEvolucao(OsEvolucaoDTO osEvolucao)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsEvolucaoDTO> DAL = new NHibernateDAL<OsEvolucaoDTO>(Session);
                    DAL.Delete(osEvolucao);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public OsEvolucaoDTO SalvarAtualizarOsEvolucao(OsEvolucaoDTO osEvolucao)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsEvolucaoDTO> DAL = new NHibernateDAL<OsEvolucaoDTO>(Session);
                    DAL.SaveOrUpdate(osEvolucao);
                    Session.Flush();
                }
                return osEvolucao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<OsEvolucaoDTO> SelectOsEvolucao(OsEvolucaoDTO osEvolucao)
        {
            try
            {
                IList<OsEvolucaoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsEvolucaoDTO> DAL = new NHibernateDAL<OsEvolucaoDTO>(Session);
                    Resultado = DAL.Select(osEvolucao);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<OsEvolucaoDTO> SelectOsEvolucaoPagina(int primeiroResultado, int quantidadeResultados, OsEvolucaoDTO osEvolucao)
        {
            try
            {
                IList<OsEvolucaoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsEvolucaoDTO> DAL = new NHibernateDAL<OsEvolucaoDTO>(Session);
                    Resultado = DAL.SelectPagina<OsEvolucaoDTO>(primeiroResultado, quantidadeResultados, osEvolucao);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 


        #region OsEquipamento
        public int DeleteOsEquipamento(OsEquipamentoDTO osEquipamento)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsEquipamentoDTO> DAL = new NHibernateDAL<OsEquipamentoDTO>(Session);
                    DAL.Delete(osEquipamento);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public OsEquipamentoDTO SalvarAtualizarOsEquipamento(OsEquipamentoDTO osEquipamento)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsEquipamentoDTO> DAL = new NHibernateDAL<OsEquipamentoDTO>(Session);
                    DAL.SaveOrUpdate(osEquipamento);
                    Session.Flush();
                }
                return osEquipamento;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<OsEquipamentoDTO> SelectOsEquipamento(OsEquipamentoDTO osEquipamento)
        {
            try
            {
                IList<OsEquipamentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsEquipamentoDTO> DAL = new NHibernateDAL<OsEquipamentoDTO>(Session);
                    Resultado = DAL.Select(osEquipamento);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<OsEquipamentoDTO> SelectOsEquipamentoPagina(int primeiroResultado, int quantidadeResultados, OsEquipamentoDTO osEquipamento)
        {
            try
            {
                IList<OsEquipamentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsEquipamentoDTO> DAL = new NHibernateDAL<OsEquipamentoDTO>(Session);
                    Resultado = DAL.SelectPagina<OsEquipamentoDTO>(primeiroResultado, quantidadeResultados, osEquipamento);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 


        #region OsAberturaEquipamento
        public int DeleteOsAberturaEquipamento(OsAberturaEquipamentoDTO osAberturaEquipamento)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsAberturaEquipamentoDTO> DAL = new NHibernateDAL<OsAberturaEquipamentoDTO>(Session);
                    DAL.Delete(osAberturaEquipamento);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public OsAberturaEquipamentoDTO SalvarAtualizarOsAberturaEquipamento(OsAberturaEquipamentoDTO osAberturaEquipamento)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsAberturaEquipamentoDTO> DAL = new NHibernateDAL<OsAberturaEquipamentoDTO>(Session);
                    DAL.SaveOrUpdate(osAberturaEquipamento);
                    Session.Flush();
                }
                return osAberturaEquipamento;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<OsAberturaEquipamentoDTO> SelectOsAberturaEquipamento(OsAberturaEquipamentoDTO osAberturaEquipamento)
        {
            try
            {
                IList<OsAberturaEquipamentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsAberturaEquipamentoDTO> DAL = new NHibernateDAL<OsAberturaEquipamentoDTO>(Session);
                    Resultado = DAL.Select(osAberturaEquipamento);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<OsAberturaEquipamentoDTO> SelectOsAberturaEquipamentoPagina(int primeiroResultado, int quantidadeResultados, OsAberturaEquipamentoDTO osAberturaEquipamento)
        {
            try
            {
                IList<OsAberturaEquipamentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsAberturaEquipamentoDTO> DAL = new NHibernateDAL<OsAberturaEquipamentoDTO>(Session);
                    Resultado = DAL.SelectPagina<OsAberturaEquipamentoDTO>(primeiroResultado, quantidadeResultados, osAberturaEquipamento);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 


        #region OsAbertura
        public int DeleteOsAbertura(OsAberturaDTO osAbertura)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsAberturaDTO> DAL = new NHibernateDAL<OsAberturaDTO>(Session);
                    DAL.Delete(osAbertura);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public OsAberturaDTO SalvarAtualizarOsAbertura(OsAberturaDTO osAbertura)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsAberturaDTO> DAL = new NHibernateDAL<OsAberturaDTO>(Session);
                    DAL.SaveOrUpdate(osAbertura);
                    Session.Flush();
                }
                return osAbertura;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<OsAberturaDTO> SelectOsAbertura(OsAberturaDTO osAbertura)
        {
            try
            {
                IList<OsAberturaDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsAberturaDTO> DAL = new NHibernateDAL<OsAberturaDTO>(Session);
                    Resultado = DAL.Select(osAbertura);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<OsAberturaDTO> SelectOsAberturaPagina(int primeiroResultado, int quantidadeResultados, OsAberturaDTO osAbertura)
        {
            try
            {
                IList<OsAberturaDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsAberturaDTO> DAL = new NHibernateDAL<OsAberturaDTO>(Session);
                    Resultado = DAL.SelectPagina<OsAberturaDTO>(primeiroResultado, quantidadeResultados, osAbertura);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 


        #region OsStatus
        public int DeleteOsStatus(OsStatusDTO osStatus)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsStatusDTO> DAL = new NHibernateDAL<OsStatusDTO>(Session);
                    DAL.Delete(osStatus);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public OsStatusDTO SalvarAtualizarOsStatus(OsStatusDTO osStatus)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsStatusDTO> DAL = new NHibernateDAL<OsStatusDTO>(Session);
                    DAL.SaveOrUpdate(osStatus);
                    Session.Flush();
                }
                return osStatus;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<OsStatusDTO> SelectOsStatus(OsStatusDTO osStatus)
        {
            try
            {
                IList<OsStatusDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsStatusDTO> DAL = new NHibernateDAL<OsStatusDTO>(Session);
                    Resultado = DAL.Select(osStatus);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<OsStatusDTO> SelectOsStatusPagina(int primeiroResultado, int quantidadeResultados, OsStatusDTO osStatus)
        {
            try
            {
                IList<OsStatusDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<OsStatusDTO> DAL = new NHibernateDAL<OsStatusDTO>(Session);
                    Resultado = DAL.SelectPagina<OsStatusDTO>(primeiroResultado, quantidadeResultados, osStatus);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 



        #endregion


        #region === Etiquetas ===

        #region EtiquetaTemplate
        public int DeleteEtiquetaTemplate(EtiquetaTemplateDTO etiquetaTemplate)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EtiquetaTemplateDTO> DAL = new NHibernateDAL<EtiquetaTemplateDTO>(Session);
                    DAL.Delete(etiquetaTemplate);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public EtiquetaTemplateDTO SalvarAtualizarEtiquetaTemplate(EtiquetaTemplateDTO etiquetaTemplate)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EtiquetaTemplateDTO> DAL = new NHibernateDAL<EtiquetaTemplateDTO>(Session);
                    DAL.SaveOrUpdate(etiquetaTemplate);
                    Session.Flush();
                }
                return etiquetaTemplate;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<EtiquetaTemplateDTO> SelectEtiquetaTemplate(EtiquetaTemplateDTO etiquetaTemplate)
        {
            try
            {
                IList<EtiquetaTemplateDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EtiquetaTemplateDTO> DAL = new NHibernateDAL<EtiquetaTemplateDTO>(Session);
                    Resultado = DAL.Select(etiquetaTemplate);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<EtiquetaTemplateDTO> SelectEtiquetaTemplatePagina(int primeiroResultado, int quantidadeResultados, EtiquetaTemplateDTO etiquetaTemplate)
        {
            try
            {
                IList<EtiquetaTemplateDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EtiquetaTemplateDTO> DAL = new NHibernateDAL<EtiquetaTemplateDTO>(Session);
                    Resultado = DAL.SelectPagina<EtiquetaTemplateDTO>(primeiroResultado, quantidadeResultados, etiquetaTemplate);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #endregion

        #region === WMS ===

        #region WmsRua
        public int DeleteWmsRua(WmsRuaDTO wmsRua)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<WmsRuaDTO> DAL = new NHibernateDAL<WmsRuaDTO>(Session);
                    DAL.Delete(wmsRua);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public WmsRuaDTO SalvarAtualizarWmsRua(WmsRuaDTO wmsRua)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<WmsRuaDTO> DAL = new NHibernateDAL<WmsRuaDTO>(Session);
                    DAL.SaveOrUpdate(wmsRua);
                    Session.Flush();
                }
                return wmsRua;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<WmsRuaDTO> SelectWmsRua(WmsRuaDTO wmsRua)
        {
            try
            {
                IList<WmsRuaDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<WmsRuaDTO> DAL = new NHibernateDAL<WmsRuaDTO>(Session);
                    Resultado = DAL.Select(wmsRua);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<WmsRuaDTO> SelectWmsRuaPagina(int primeiroResultado, int quantidadeResultados, WmsRuaDTO wmsRua)
        {
            try
            {
                IList<WmsRuaDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<WmsRuaDTO> DAL = new NHibernateDAL<WmsRuaDTO>(Session);
                    Resultado = DAL.SelectPagina<WmsRuaDTO>(primeiroResultado, quantidadeResultados, wmsRua);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 


        #endregion
        #region VendaCabecalho
        public int DeleteVendaCabecalho(VendaCabecalhoDTO vendaCabecalho)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<VendaCabecalhoDTO> DAL = new NHibernateDAL<VendaCabecalhoDTO>(Session);
                    DAL.Delete(vendaCabecalho);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public VendaCabecalhoDTO SalvarAtualizarVendaCabecalho(VendaCabecalhoDTO vendaCabecalho)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<VendaCabecalhoDTO> DAL = new NHibernateDAL<VendaCabecalhoDTO>(Session);
                    DAL.SaveOrUpdate(vendaCabecalho);
                    Session.Flush();
                }
                return vendaCabecalho;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<VendaCabecalhoDTO> SelectVendaCabecalho(VendaCabecalhoDTO vendaCabecalho)
        {
            try
            {
                IList<VendaCabecalhoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<VendaCabecalhoDTO> DAL = new NHibernateDAL<VendaCabecalhoDTO>(Session);
                    Resultado = DAL.Select(vendaCabecalho);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<VendaCabecalhoDTO> SelectVendaCabecalhoPagina(int primeiroResultado, int quantidadeResultados, VendaCabecalhoDTO vendaCabecalho)
        {
            try
            {
                IList<VendaCabecalhoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<VendaCabecalhoDTO> DAL = new NHibernateDAL<VendaCabecalhoDTO>(Session);
                    Resultado = DAL.SelectPagina<VendaCabecalhoDTO>(primeiroResultado, quantidadeResultados, vendaCabecalho);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

    }
}

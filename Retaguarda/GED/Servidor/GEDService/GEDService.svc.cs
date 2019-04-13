using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using GEDService.Model;
using GEDService.NHibernate;
using NHibernate;

namespace GEDService
{
    public class GEDService : IGEDService
    {

        #region GedTipoDocumento
        public int deleteGedTipoDocumento(GedTipoDocumentoDTO gedTipoDocumento)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<GedTipoDocumentoDTO> DAL = new NHibernateDAL<GedTipoDocumentoDTO>(session);
                    DAL.delete(gedTipoDocumento);
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


        public GedTipoDocumentoDTO salvarAtualizarGedTipoDocumento(GedTipoDocumentoDTO gedTipoDocumento)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<GedTipoDocumentoDTO> DAL = new NHibernateDAL<GedTipoDocumentoDTO>(session);
                    DAL.saveOrUpdate(gedTipoDocumento);
                    session.Flush();
                }
                return gedTipoDocumento;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<GedTipoDocumentoDTO> selectGedTipoDocumento(GedTipoDocumentoDTO gedTipoDocumento)
        {
            try
            {
                IList<GedTipoDocumentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<GedTipoDocumentoDTO> DAL = new NHibernateDAL<GedTipoDocumentoDTO>(session);
                    resultado = DAL.select(gedTipoDocumento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<GedTipoDocumentoDTO> selectGedTipoDocumentoPagina(int primeiroResultado, int quantidadeResultados, GedTipoDocumentoDTO gedTipoDocumento)
        {
            try
            {
                IList<GedTipoDocumentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<GedTipoDocumentoDTO> DAL = new NHibernateDAL<GedTipoDocumentoDTO>(session);
                    resultado = DAL.selectPagina<GedTipoDocumentoDTO>(primeiroResultado, quantidadeResultados, gedTipoDocumento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region Arquivo
        private void salvarArquivo(ArquivoDTO arquivo)
        {
            try
            {
                using (FileStream fs = File.Create(arquivo.caminhoServidor))
                {
                    fs.Write(arquivo.memoryStream.GetBuffer(), 0, (int)arquivo.memoryStream.Length);
                }
                if (arquivo.streamAssinatura != null && arquivo.streamAssinatura.Length > 0)
                {
                    using (FileStream fs = File.Create(arquivo.caminhoServidorAssinatura))
                    {
                        fs.Write(arquivo.streamAssinatura.GetBuffer(), 0, (int)arquivo.streamAssinatura.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Documento
        public GedDocumentoDTO saveDocumento(GedDocumentoDTO documento)
        {
            try
            {
                GedVersaoDocumentoDTO versaoDocumento = new GedVersaoDocumentoDTO();

                versaoDocumento.HashArquivo = documento.arquivo.calcularHash();

                salvarArquivo(documento.arquivo);

                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    IDAL<GedDocumentoDTO> documentoDAL = new NHibernateDAL<GedDocumentoDTO>(session);
                    documentoDAL.save(documento);
                    versaoDocumento.IdColaborador = 1;
                    versaoDocumento.IdDocumento = documento.Id;
                    versaoDocumento.DataHora = DateTime.Now;
                    versaoDocumento.Caminho = documento.arquivo.caminhoServidor;
                    versaoDocumento.Acao = "I";

                    IDAL<GedVersaoDocumentoDTO> versaoDocumentoDAL = new NHibernateDAL<GedVersaoDocumentoDTO>(session);
                    versaoDocumentoDAL.save(versaoDocumento);
                    session.Flush();
                    return documento;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GedDocumentoDTO updateDocumento(GedDocumentoDTO documento)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    DateTime dataAlteracao = DateTime.Now;
                    IDAL<GedDocumentoDTO> documentoDAL = new NHibernateDAL<GedDocumentoDTO>(session);

                    IDAL<GedVersaoDocumentoDTO> versaoDocumentoDAL = new NHibernateDAL<GedVersaoDocumentoDTO>(session);
                    GedVersaoDocumentoDTO versaoDocumento = new GedVersaoDocumentoDTO();
                    versaoDocumento.IdColaborador = 1;
                    versaoDocumento.IdDocumento = documento.Id;
                    versaoDocumento = versaoDocumentoDAL.select(versaoDocumento).Last();

                    session.Evict(versaoDocumento);

                    versaoDocumento.HashArquivo = documento.arquivo.calcularHash();
                    this.salvarArquivo(documento.arquivo);

                    versaoDocumento.Versao += 1;
                    versaoDocumento.DataHora = dataAlteracao;
                    versaoDocumento.Acao = "A";
                    versaoDocumento.Caminho = documento.arquivo.caminhoServidor;
                    versaoDocumentoDAL.save(versaoDocumento);

                    session.Flush();
                    return documento;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int deleteDocumento(GedDocumentoDTO documento)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    DateTime dataExclusao = DateTime.Now;
                    IDAL<GedDocumentoDTO> documentoDAL = new NHibernateDAL<GedDocumentoDTO>(session);
                    documento.DataExclusao = dataExclusao;
                    documentoDAL.update(documento);

                    IDAL<GedVersaoDocumentoDTO> versaoDocumentoDAL = new NHibernateDAL<GedVersaoDocumentoDTO>(session);
                    GedVersaoDocumentoDTO versaoDocumento = new GedVersaoDocumentoDTO();
                    versaoDocumento.IdColaborador = 1;
                    versaoDocumento.IdDocumento = documento.Id;
                    versaoDocumento = versaoDocumentoDAL.select(versaoDocumento).Last();

                    session.Evict(versaoDocumento);

                    versaoDocumento.DataHora = dataExclusao;
                    versaoDocumento.Acao = "E";
                    versaoDocumentoDAL.save(versaoDocumento);
                    session.Flush();
                    resultado = 0;

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<GedDocumentoDTO> selectDocumento(GedDocumentoDTO documento)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    DocumentoDAL documentoDAL = new DocumentoDAL(session);
                    IList<GedDocumentoDTO> resultado = documentoDAL.selectDocumentosAtivos(documento);
                    session.Flush();
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GedDocumentoDTO selectDocumentoId(GedDocumentoDTO documento)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    IDAL<GedDocumentoDTO> documentoDAL = new NHibernateDAL<GedDocumentoDTO>(session);
                    GedDocumentoDTO resultado = documentoDAL.selectId<GedDocumentoDTO>((int) documento.Id);

                    if (resultado != null)
                    {
                        IDAL<GedVersaoDocumentoDTO> versaoDocumentoDAL = new NHibernateDAL<GedVersaoDocumentoDTO>(session);
                        GedVersaoDocumentoDTO versaoDoc = new GedVersaoDocumentoDTO();
                        versaoDoc.IdDocumento = documento.Id;
                        IList<GedVersaoDocumentoDTO> listaVersaoDoc = versaoDocumentoDAL.select(versaoDoc);
                        versaoDoc = listaVersaoDoc.Last();

                        FileInfo fi = new FileInfo(versaoDoc.Caminho);
                        FileStream fs = fi.OpenRead();
                        MemoryStream ms = new MemoryStream((int)fs.Length);
                        fs.CopyTo(ms);
                        fs.Close();
                        ms.Position = 0;

                        ArquivoDTO arquivo = new ArquivoDTO();
                        arquivo.fileInfo = fi;
                        arquivo.memoryStream = ms;

                        if (resultado.Assinado != null && resultado.Assinado == "S")
                        {
                            FileInfo fiAssinatura = new FileInfo(arquivo.caminhoServidorAssinatura);
                            FileStream fsAssinatura = fiAssinatura.OpenRead();
                            MemoryStream msAssinatura = new MemoryStream((int)fsAssinatura.Length);
                            fsAssinatura.CopyTo(msAssinatura);
                            fsAssinatura.Close();
                            msAssinatura.Position = 0;

                            arquivo.streamAssinatura = msAssinatura;
                        }

                        resultado.arquivo = arquivo;

                        session.Flush();
                    }
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GedVersaoDocumento
        public int deleteGedVersaoDocumento(GedVersaoDocumentoDTO gedVersaoDocumento)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<GedVersaoDocumentoDTO> DAL = new NHibernateDAL<GedVersaoDocumentoDTO>(session);
                    DAL.delete(gedVersaoDocumento);
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


        public GedVersaoDocumentoDTO salvarAtualizarGedVersaoDocumento(GedVersaoDocumentoDTO gedVersaoDocumento)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<GedVersaoDocumentoDTO> DAL = new NHibernateDAL<GedVersaoDocumentoDTO>(session);
                    DAL.saveOrUpdate(gedVersaoDocumento);
                    session.Flush();
                }
                return gedVersaoDocumento;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<GedVersaoDocumentoDTO> selectGedVersaoDocumento(GedVersaoDocumentoDTO gedVersaoDocumento)
        {
            try
            {
                IList<GedVersaoDocumentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<GedVersaoDocumentoDTO> DAL = new NHibernateDAL<GedVersaoDocumentoDTO>(session);
                    resultado = DAL.select(gedVersaoDocumento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<GedVersaoDocumentoDTO> selectGedVersaoDocumentoPagina(int primeiroResultado, int quantidadeResultados, GedVersaoDocumentoDTO gedVersaoDocumento)
        {
            try
            {
                IList<GedVersaoDocumentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<GedVersaoDocumentoDTO> DAL = new NHibernateDAL<GedVersaoDocumentoDTO>(session);
                    resultado = DAL.selectPagina<GedVersaoDocumentoDTO>(primeiroResultado, quantidadeResultados, gedVersaoDocumento);
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

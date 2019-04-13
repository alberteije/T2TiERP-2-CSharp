using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EstoqueService.Model;
using NHibernate;
using EstoqueService.NHibernate;
using EstoqueService.Util;

namespace EstoqueService
{
    public class ServicoEstoque : IServicoEstoque
    {
        #region EstoqueContagemCabecalho
        public IList<EstoqueContagemCabecalhoDTO> selectEstoqueContagemCabecalho(EstoqueContagemCabecalhoDTO contagem)
        {
            try
            {
                IList<EstoqueContagemCabecalhoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<EstoqueContagemCabecalhoDTO> contDAL = new NHibernateDAL<EstoqueContagemCabecalhoDTO>(session);
                    resultado = contDAL.select(contagem);

                    foreach (EstoqueContagemCabecalhoDTO objP in resultado)
                    {
                        NHibernateDAL<EstoqueContagemDetalheDTO> contDetDAL = new NHibernateDAL<EstoqueContagemDetalheDTO>(session);
                        objP.listaContagemDetalhe = contDetDAL.select<EstoqueContagemDetalheDTO>(new EstoqueContagemDetalheDTO { IdEstoqueContagemCabecalho = objP.Id });
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public int deleteEstoqueContagemCabecalho(EstoqueContagemCabecalhoDTO estoqueContagemCabecalho)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {

                    NHibernateDAL<EstoqueContagemDetalheDTO> contDetDAL = new NHibernateDAL<EstoqueContagemDetalheDTO>(session);
                    IList<EstoqueContagemDetalheDTO> listaContagemDetalhe = contDetDAL.select<EstoqueContagemDetalheDTO>(new EstoqueContagemDetalheDTO { IdEstoqueContagemCabecalho = estoqueContagemCabecalho.Id });

                    foreach (EstoqueContagemDetalheDTO req in listaContagemDetalhe)
                    {
                        contDetDAL.delete(req);
                    }

                    NHibernateDAL<EstoqueContagemCabecalhoDTO> contDAL = new NHibernateDAL<EstoqueContagemCabecalhoDTO>(session);
                    contDAL.delete(estoqueContagemCabecalho);

                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public EstoqueContagemCabecalhoDTO salvarAtualizarEstoqueContagemCabecalho(EstoqueContagemCabecalhoDTO contagem)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {

                    NHibernateDAL<EstoqueContagemCabecalhoDTO> contDAL = new NHibernateDAL<EstoqueContagemCabecalhoDTO>(session);
                    contDAL.saveOrUpdate(contagem);

                    if (contagem.listaContagemDetalhe != null)
                    {
                        NHibernateDAL<EstoqueContagemDetalheDTO> contDetDAL = new NHibernateDAL<EstoqueContagemDetalheDTO>(session);
                        IList<EstoqueContagemDetalheDTO> listaContagemDetalheExcluir = contDetDAL.select<EstoqueContagemDetalheDTO>(new EstoqueContagemDetalheDTO { IdEstoqueContagemCabecalho = contagem.Id });

                        foreach (EstoqueContagemDetalheDTO contExc in listaContagemDetalheExcluir)
                        {
                            contDetDAL.delete(contExc);
                        }

                        IList<EstoqueContagemDetalheDTO> listaContagemDetalheIncluir = contagem.listaContagemDetalhe;

                        foreach (EstoqueContagemDetalheDTO contIncluir in listaContagemDetalheIncluir)
                        {
                            contIncluir.IdEstoqueContagemCabecalho = contagem.Id;
                            contDetDAL.saveOrUpdate((EstoqueContagemDetalheDTO)session.Merge(contIncluir));
                        }
                    }

                    session.Flush();
                }
                return contagem;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<EstoqueContagemCabecalhoDTO> selectEstoqueContagemCabecalhoPagina(int primeiroResultado, int quantidadeResultados, EstoqueContagemCabecalhoDTO estoqueContagemCabecalho)
        {
            try
            {
                IList<EstoqueContagemCabecalhoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<EstoqueContagemCabecalhoDTO> DAL = new NHibernateDAL<EstoqueContagemCabecalhoDTO>(session);
                    resultado = DAL.selectPagina<EstoqueContagemCabecalhoDTO>(primeiroResultado, quantidadeResultados, estoqueContagemCabecalho);

                    foreach (EstoqueContagemCabecalhoDTO objP in resultado)
                    {
                        NHibernateDAL<EstoqueContagemDetalheDTO> contDetDAL = new NHibernateDAL<EstoqueContagemDetalheDTO>(session);
                        objP.listaContagemDetalhe = contDetDAL.select<EstoqueContagemDetalheDTO>(new EstoqueContagemDetalheDTO { IdEstoqueContagemCabecalho = objP.Id });
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        #endregion

        #region RequisicaoInternaCabecalho

        public IList<RequisicaoInternaCabecalhoDTO> selectRequisicaoInternaCabecalho(RequisicaoInternaCabecalhoDTO requisicao)
        {
            try
            {
                IList<RequisicaoInternaCabecalhoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<RequisicaoInternaCabecalhoDTO> reqDAL = new NHibernateDAL<RequisicaoInternaCabecalhoDTO>(session);
                    resultado = reqDAL.select(requisicao);

                    foreach (RequisicaoInternaCabecalhoDTO objP in resultado)
                    {
                        NHibernateDAL<RequisicaoInternaDetalheDTO> detalheDAL = new NHibernateDAL<RequisicaoInternaDetalheDTO>(session);
                        objP.ListaRequisicaoInternaDetalhe = detalheDAL.select<RequisicaoInternaDetalheDTO>(new RequisicaoInternaDetalheDTO { IdRequisicaoInternaCabecalho = objP.Id });
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public int deleteRequisicaoInternaCabecalho(RequisicaoInternaCabecalhoDTO requisicao)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {

                    NHibernateDAL<RequisicaoInternaDetalheDTO> reqDetDAL = new NHibernateDAL<RequisicaoInternaDetalheDTO>(session);
                    IList<RequisicaoInternaDetalheDTO> listaRequisicaoDetalhe = reqDetDAL.select<RequisicaoInternaDetalheDTO>(new RequisicaoInternaDetalheDTO { IdRequisicaoInternaCabecalho = requisicao.Id });

                    foreach (RequisicaoInternaDetalheDTO req in listaRequisicaoDetalhe)
                    {
                        reqDetDAL.delete(req);
                    }

                    NHibernateDAL<RequisicaoInternaCabecalhoDTO> reqDAL = new NHibernateDAL<RequisicaoInternaCabecalhoDTO>(session);
                    reqDAL.delete(requisicao);

                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<RequisicaoInternaCabecalhoDTO> selectRequisicaoInternaCabecalhoPagina(int primeiroResultado, int quantidadeResultados, RequisicaoInternaCabecalhoDTO requisicaoInternaCabecalho)
        {
            try
            {
                IList<RequisicaoInternaCabecalhoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<RequisicaoInternaCabecalhoDTO> DAL = new NHibernateDAL<RequisicaoInternaCabecalhoDTO>(session);
                    resultado = DAL.selectPagina<RequisicaoInternaCabecalhoDTO>(primeiroResultado, quantidadeResultados, requisicaoInternaCabecalho);

                    foreach (RequisicaoInternaCabecalhoDTO objP in resultado)
                    {
                        NHibernateDAL<RequisicaoInternaDetalheDTO> detalheDAL = new NHibernateDAL<RequisicaoInternaDetalheDTO>(session);
                        objP.ListaRequisicaoInternaDetalhe = detalheDAL.select<RequisicaoInternaDetalheDTO>(new RequisicaoInternaDetalheDTO { IdRequisicaoInternaCabecalho = objP.Id });
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public RequisicaoInternaCabecalhoDTO salvarAtualizarRequisicaoInternaCabecalho(RequisicaoInternaCabecalhoDTO requisicao)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {

                    NHibernateDAL<RequisicaoInternaCabecalhoDTO> reqDAL = new NHibernateDAL<RequisicaoInternaCabecalhoDTO>(session);
                    reqDAL.saveOrUpdate(requisicao);

                    NHibernateDAL<RequisicaoInternaDetalheDTO> reqDetDAL = new NHibernateDAL<RequisicaoInternaDetalheDTO>(session);
                    IList<RequisicaoInternaDetalheDTO> listaReqDetalheExcluir = reqDetDAL.select<RequisicaoInternaDetalheDTO>(new RequisicaoInternaDetalheDTO { IdRequisicaoInternaCabecalho = requisicao.Id });

                    foreach (RequisicaoInternaDetalheDTO reqExc in listaReqDetalheExcluir)
                    {
                        reqDetDAL.delete(reqExc);
                    }

                    IList<RequisicaoInternaDetalheDTO> listaReqDetalheIncluir = requisicao.ListaRequisicaoInternaDetalhe;

                    foreach (RequisicaoInternaDetalheDTO reqIncluir in listaReqDetalheIncluir)
                    {
                        reqIncluir.IdRequisicaoInternaCabecalho = requisicao.Id;
                        reqDetDAL.saveOrUpdate((RequisicaoInternaDetalheDTO)session.Merge(reqIncluir));
                    }

                    session.Flush();
                    resultado = 0;
                }
                return requisicao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        #endregion

        #region Entrada da Nota

        public IList<NFeCabecalhoDTO> selectNFeCabecalho(NFeCabecalhoDTO nfeCabecalho)
        {
            try
            {
                IList<NFeCabecalhoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<NFeCabecalhoDTO> nfeDAL = new NHibernateDAL<NFeCabecalhoDTO>(session);
                    resultado = nfeDAL.select(nfeCabecalho);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public NFeCabecalhoDTO selectNFeCabecalhoId(int id)
        {
            try
            {
                NFeCabecalhoDTO resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<NFeCabecalhoDTO> nfeDAL = new NHibernateDAL<NFeCabecalhoDTO>(session);
                    resultado = nfeDAL.selectId<NFeCabecalhoDTO>(id);

                    NHibernateDAL<NFeDestinatarioDTO> nfeDest = new NHibernateDAL<NFeDestinatarioDTO>(session);
                    IList<NFeDestinatarioDTO> listDest = nfeDest.select<NFeDestinatarioDTO>(new NFeDestinatarioDTO { idNFeCabecalho = id });
                    if (listDest.Count > 0)
                    {
                        resultado.destinatario = listDest.First();
                    }

                    NHibernateDAL<NFeEmitenteDTO> nfeEmit = new NHibernateDAL<NFeEmitenteDTO>(session);
                    IList<NFeEmitenteDTO> listEmit = nfeDest.select<NFeEmitenteDTO>(new NFeEmitenteDTO { idNFeCabecalho = id });
                    if (listEmit.Count > 0)
                    {
                        resultado.emitente = listEmit.First();
                    }

                    NHibernateDAL<NFeLocalEntregaDTO> nfeLE = new NHibernateDAL<NFeLocalEntregaDTO>(session);
                    IList<NFeLocalEntregaDTO> listLE = nfeLE.select<NFeLocalEntregaDTO>(new NFeLocalEntregaDTO { idNFeCabecalho = id });
                    if (listLE.Count > 0)
                    {
                        resultado.localEntrega = listLE.First();
                    }

                    NHibernateDAL<NFeLocalRetiradaDTO> nfeLR = new NHibernateDAL<NFeLocalRetiradaDTO>(session);
                    IList<NFeLocalRetiradaDTO> listLR = nfeLR.select<NFeLocalRetiradaDTO>(new NFeLocalRetiradaDTO { idNFeCabecalho = id });
                    if (listLR.Count > 0)
                    {
                        resultado.localRetirada = listLR.First();
                    }

                    NHibernateDAL<NFeTransporteDTO> nfeTransporte = new NHibernateDAL<NFeTransporteDTO>(session);
                    IList<NFeTransporteDTO> listTransp = nfeTransporte.select<NFeTransporteDTO>(new NFeTransporteDTO { idNFeCabecalho = id });
                    if (listTransp.Count > 0)
                    {
                        resultado.transporte = listTransp.First();
                    }

                    NHibernateDAL<NFeFaturaDTO> nfeFatura = new NHibernateDAL<NFeFaturaDTO>(session);
                    IList<NFeFaturaDTO> listFat = nfeFatura.select<NFeFaturaDTO>(new NFeFaturaDTO { idNFeCabecalho = id });
                    if (listFat.Count > 0)
                    {
                        resultado.fatura = listFat.First();
                    }

                    NHibernateDAL<NFeCupomFiscalDTO> nfeCF = new NHibernateDAL<NFeCupomFiscalDTO>(session);
                    resultado.listaCupomFiscal = nfeCF.select<NFeCupomFiscalDTO>(new NFeCupomFiscalDTO { idNFeCabecalho = id });

                    NHibernateDAL<NFeDetalheDTO> nfeDetDAL = new NHibernateDAL<NFeDetalheDTO>(session);
                    resultado.listaDetalhe = nfeDetDAL.select<NFeDetalheDTO>(new NFeDetalheDTO { idNFeCabecalho = id });

                    foreach (NFeDetalheDTO item in resultado.listaDetalhe)
                    {
                        NHibernateDAL<NfeDetalheImpostoCofinsDTO> nfeDetCofins = new NHibernateDAL<NfeDetalheImpostoCofinsDTO>(session);
                        item.impostoCofins = nfeDetCofins.selectObjeto<NfeDetalheImpostoCofinsDTO>(new NfeDetalheImpostoCofinsDTO { idNFeDetalhe = item.id });

                        NHibernateDAL<NfeDetalheImpostoIcmsDTO> nfeDetIcms = new NHibernateDAL<NfeDetalheImpostoIcmsDTO>(session);
                        item.impostoIcms = nfeDetIcms.selectObjeto<NfeDetalheImpostoIcmsDTO>(new NfeDetalheImpostoIcmsDTO { idNFeDetalhe = item.id });

                        NHibernateDAL<NfeDetalheImpostoIssqnDTO> nfeDetIss = new NHibernateDAL<NfeDetalheImpostoIssqnDTO>(session);
                        item.impostoIss = nfeDetIss.selectObjeto<NfeDetalheImpostoIssqnDTO>(new NfeDetalheImpostoIssqnDTO { idNFeDetalhe = item.id });

                        NHibernateDAL<NfeDetalheImpostoPisDTO> nfeDetPis = new NHibernateDAL<NfeDetalheImpostoPisDTO>(session);
                        item.impostoPis = nfeDetPis.selectObjeto<NfeDetalheImpostoPisDTO>(new NfeDetalheImpostoPisDTO { idNFeDetalhe = item.id });

                        NHibernateDAL<NfeDetalheImpostoIpiDTO> nfeDetIpi = new NHibernateDAL<NfeDetalheImpostoIpiDTO>(session);
                        item.impostoIpi = nfeDetIpi.selectObjeto<NfeDetalheImpostoIpiDTO>(new NfeDetalheImpostoIpiDTO { idNFeDetalhe = item.id });

                        NHibernateDAL<NfeDetalheImpostoIiDTO> nfeDetII = new NHibernateDAL<NfeDetalheImpostoIiDTO>(session);
                        item.impostoII = nfeDetII.selectObjeto<NfeDetalheImpostoIiDTO>(new NfeDetalheImpostoIiDTO { idNFeDetalhe = item.id });
                    }


                    NHibernateDAL<NFeDuplicataDTO> nfeDupl = new NHibernateDAL<NFeDuplicataDTO>(session);
                    resultado.listaDuplicata = nfeDupl.select<NFeDuplicataDTO>(new NFeDuplicataDTO { idNFeCabecalho = id });
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public int salvarNFeCabecalho(NFeCabecalhoDTO nfeCabecalho)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ITransaction transaction = session.BeginTransaction();
                    NHibernateDAL<NFeCabecalhoDTO> nfeDAL = new NHibernateDAL<NFeCabecalhoDTO>(session);

                    nfeDAL.saveOrUpdate(nfeCabecalho);

                    if (nfeCabecalho.destinatario != null)
                    {
                        NHibernateDAL<NFeDestinatarioDTO> nfeDest = new NHibernateDAL<NFeDestinatarioDTO>(session);
                        nfeCabecalho.destinatario.idNFeCabecalho = nfeCabecalho.id;
                        nfeDest.saveOrUpdate(nfeCabecalho.destinatario);
                    }

                    if (nfeCabecalho.emitente != null)
                    {
                        NHibernateDAL<NFeEmitenteDTO> nfeEmit = new NHibernateDAL<NFeEmitenteDTO>(session);
                        nfeCabecalho.emitente.idNFeCabecalho = nfeCabecalho.id;
                        nfeEmit.saveOrUpdate(nfeCabecalho.emitente);
                    }

                    if (nfeCabecalho.fatura != null)
                    {
                        NHibernateDAL<NFeFaturaDTO> nfeFatura = new NHibernateDAL<NFeFaturaDTO>(session);
                        nfeCabecalho.fatura.idNFeCabecalho = nfeCabecalho.id;
                        nfeFatura.saveOrUpdate(nfeCabecalho.fatura);
                    }

                    if (nfeCabecalho.listaDuplicata.Count > 0)
                    {
                        NHibernateDAL<NFeDuplicataDTO> nfeDuplicata = new NHibernateDAL<NFeDuplicataDTO>(session);

                        IList<NFeDuplicataDTO> listaDuplicataExistente = nfeDuplicata.select(new NFeDuplicataDTO { idNFeCabecalho = nfeCabecalho.id });
                        foreach (NFeDuplicataDTO duplicata in listaDuplicataExistente)
                        {
                            nfeDuplicata.delete(duplicata);
                        }

                        IList<NFeDuplicataDTO> listaDuplic = nfeCabecalho.listaDuplicata;
                        foreach (NFeDuplicataDTO duplic in listaDuplic)
                        {
                            duplic.idNFeCabecalho = nfeCabecalho.id;
                            nfeDuplicata.saveOrUpdate((NFeDuplicataDTO)session.Merge(duplic));
                        }
                    }

                    if (nfeCabecalho.listaCupomFiscal != null && nfeCabecalho.listaCupomFiscal.Count > 0)
                    {
                        NHibernateDAL<NFeCupomFiscalDTO> nfeCF = new NHibernateDAL<NFeCupomFiscalDTO>(session);

                        IList<NFeCupomFiscalDTO> listaCFExistente = nfeCF.select(new NFeCupomFiscalDTO { idNFeCabecalho = nfeCabecalho.id });
                        foreach (NFeCupomFiscalDTO cf in listaCFExistente)
                        {
                            nfeCF.delete(cf);
                        }

                        IList<NFeCupomFiscalDTO> listaCupom = nfeCabecalho.listaCupomFiscal;
                        foreach (NFeCupomFiscalDTO nfeCupom in listaCupom)
                        {
                            nfeCupom.idNFeCabecalho = nfeCabecalho.id;
                            nfeCF.saveOrUpdate((NFeCupomFiscalDTO)session.Merge(nfeCupom));
                        }
                    }

                    if (nfeCabecalho.listaDetalhe.Count > 0)
                    {
                        NHibernateDAL<NFeDetalheDTO> nfeDetDAL = new NHibernateDAL<NFeDetalheDTO>(session);

                        IList<NFeDetalheDTO> listaDetalhe = nfeCabecalho.listaDetalhe;
                        foreach (NFeDetalheDTO nfeDet in listaDetalhe)
                        {
                            nfeDet.idNFeCabecalho = nfeCabecalho.id;
                            nfeDetDAL.saveOrUpdate(nfeDet);

                            nfeDetDAL.saveOrUpdate((NFeDetalheDTO)session.Merge(nfeDet));

                            if (nfeDet.impostoIcms != null)
                            {
                                NHibernateDAL<NfeDetalheImpostoIcmsDTO> impostoIcms = new NHibernateDAL<NfeDetalheImpostoIcmsDTO>(session);
                                nfeDet.impostoIcms.idNFeDetalhe = nfeDet.id;
                                impostoIcms.saveOrUpdate(nfeDet.impostoIcms);
                            }

                            if (nfeDet.impostoCofins != null)
                            {
                                NHibernateDAL<NfeDetalheImpostoCofinsDTO> impostoCofins = new NHibernateDAL<NfeDetalheImpostoCofinsDTO>(session);
                                nfeDet.impostoCofins.idNFeDetalhe = nfeDet.id;
                                impostoCofins.saveOrUpdate(nfeDet.impostoIcms);
                            }

                            if (nfeDet.impostoPis != null)
                            {
                                NHibernateDAL<NfeDetalheImpostoPisDTO> impostoPis = new NHibernateDAL<NfeDetalheImpostoPisDTO>(session);
                                nfeDet.impostoPis.idNFeDetalhe = nfeDet.id;
                                impostoPis.saveOrUpdate(nfeDet.impostoIcms);
                            }

                        }
                    }

                    if (nfeCabecalho.localEntrega != null)
                    {
                        NHibernateDAL<NFeLocalEntregaDTO> nfeLE = new NHibernateDAL<NFeLocalEntregaDTO>(session);
                        nfeCabecalho.localEntrega.idNFeCabecalho = nfeCabecalho.id;
                        nfeLE.saveOrUpdate(nfeCabecalho.localEntrega);
                    }

                    if (nfeCabecalho.localRetirada != null)
                    {
                        NHibernateDAL<NFeLocalRetiradaDTO> nfeLR = new NHibernateDAL<NFeLocalRetiradaDTO>(session);
                        nfeCabecalho.localRetirada.idNFeCabecalho = nfeCabecalho.id;
                        nfeLR.saveOrUpdate(nfeCabecalho.localRetirada);
                    }

                    if (nfeCabecalho.transporte != null)
                    {
                        NHibernateDAL<NFeTransporteDTO> nfeTransporte = new NHibernateDAL<NFeTransporteDTO>(session);
                        nfeCabecalho.transporte.idNFeCabecalho = nfeCabecalho.id;
                        nfeTransporte.saveOrUpdate(nfeCabecalho.transporte);
                    }

                    session.Flush();
                    transaction.Commit();
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
        
        #endregion

        #region EstoqueReajusteCabecalho
        public IList<EstoqueReajusteCabecalhoDTO> selectEstoqueReajusteCabecalho(EstoqueReajusteCabecalhoDTO reajuste)
        {
            try
            {
                IList<EstoqueReajusteCabecalhoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<EstoqueReajusteCabecalhoDTO> reajusteDAL = new NHibernateDAL<EstoqueReajusteCabecalhoDTO>(session);
                    resultado = reajusteDAL.select(reajuste);

                    foreach (EstoqueReajusteCabecalhoDTO objP in resultado)
                    {
                        NHibernateDAL<EstoqueReajusteDetalheDTO> detalheDAL = new NHibernateDAL<EstoqueReajusteDetalheDTO>(session);
                        objP.ListaEstoqueReajusteDetalhe = detalheDAL.select<EstoqueReajusteDetalheDTO>(new EstoqueReajusteDetalheDTO { IdEstoqueReajusteCabecalho = objP.Id });
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public EstoqueReajusteCabecalhoDTO salvarAtualizarEstoqueReajusteCabecalho(EstoqueReajusteCabecalhoDTO reajuste)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {

                    NHibernateDAL<EstoqueReajusteCabecalhoDTO> reajusteDAL = new NHibernateDAL<EstoqueReajusteCabecalhoDTO>(session);
                    reajusteDAL.saveOrUpdate(reajuste);

                    NHibernateDAL<EstoqueReajusteDetalheDTO> reajDetDAL = new NHibernateDAL<EstoqueReajusteDetalheDTO>(session);
                    IList<EstoqueReajusteDetalheDTO> listaReajusteDetalheExcluir = reajDetDAL.select<EstoqueReajusteDetalheDTO>(new EstoqueReajusteDetalheDTO { IdEstoqueReajusteCabecalho = reajuste.Id });

                    foreach (EstoqueReajusteDetalheDTO reajExc in listaReajusteDetalheExcluir)
                    {
                        reajDetDAL.delete(reajExc);
                    }

                    IList<EstoqueReajusteDetalheDTO> listaReajusteDetalheIncluir = reajuste.ListaEstoqueReajusteDetalhe;

                    NHibernateDAL<ProdutoDTO> prodDAL = new NHibernateDAL<ProdutoDTO>(session);

                    foreach (EstoqueReajusteDetalheDTO reajIncluir in listaReajusteDetalheIncluir)
                    {
                        reajIncluir.IdEstoqueReajusteCabecalho = reajuste.Id;
                        reajDetDAL.saveOrUpdate((EstoqueReajusteDetalheDTO)session.Merge(reajIncluir));
                        ProdutoDTO prod = reajIncluir.Produto;
                        prod.valorVenda = reajIncluir.ValorReajuste;
                        prodDAL.saveOrUpdate((ProdutoDTO)session.Merge(prod));
                    }

                    session.Flush();
                    resultado = 0;
                }
                return reajuste;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IList<EstoqueReajusteCabecalhoDTO> selectEstoqueReajusteCabecalhoPagina(int primeiroResultado, int quantidadeResultados, EstoqueReajusteCabecalhoDTO estoqueReajusteCabecalho)
        {
            try
            {
                IList<EstoqueReajusteCabecalhoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<EstoqueReajusteCabecalhoDTO> DAL = new NHibernateDAL<EstoqueReajusteCabecalhoDTO>(session);
                    resultado = DAL.selectPagina<EstoqueReajusteCabecalhoDTO>(primeiroResultado, quantidadeResultados, estoqueReajusteCabecalho);

                    foreach (EstoqueReajusteCabecalhoDTO objP in resultado)
                    {
                        NHibernateDAL<EstoqueReajusteDetalheDTO> detalheDAL = new NHibernateDAL<EstoqueReajusteDetalheDTO>(session);
                        objP.ListaEstoqueReajusteDetalhe = detalheDAL.select<EstoqueReajusteDetalheDTO>(new EstoqueReajusteDetalheDTO { IdEstoqueReajusteCabecalho = objP.Id });
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public int deleteEstoqueReajusteCabecalho(EstoqueReajusteCabecalhoDTO estoqueReajusteCabecalho)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<EstoqueReajusteCabecalhoDTO> DAL = new NHibernateDAL<EstoqueReajusteCabecalhoDTO>(session);
                    DAL.delete(estoqueReajusteCabecalho);
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
        #endregion


        public IList<ProdutoDTO> selectProduto(ProdutoDTO produto)
        {
            try
            {
                IList<ProdutoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoDTO> produtoDAL = new NHibernateDAL<ProdutoDTO>(session);
                    resultado = produtoDAL.select(produto);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public int salvarProduto(ProdutoDTO produto)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {

                    NHibernateDAL<ProdutoDTO> prodDAL = new NHibernateDAL<ProdutoDTO>(session);
                    prodDAL.saveOrUpdate(produto);

                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public ProdutoDTO selectProdutoId(int id)
        {
            try
            {
                ProdutoDTO resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoDTO> prodDAL = new NHibernateDAL<ProdutoDTO>(session);
                    resultado = prodDAL.selectId<ProdutoDTO>(id);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        #region Apenas Consultas

        public IList<ColaboradorDTO> selectColaborador(ColaboradorDTO colaborador)
        {
            try
            {
                IList<ColaboradorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ColaboradorDTO> colaboradorDAL = new NHibernateDAL<ColaboradorDTO>(session);
                    resultado = colaboradorDAL.select(colaborador);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
       
        public EmpresaDTO selectEmpresaId(int id)
        {
            try
            {
                EmpresaDTO resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<EmpresaDTO> empresaDAL = new NHibernateDAL<EmpresaDTO>(session);
                    resultado = empresaDAL.selectId<EmpresaDTO>(id);

                    NHibernateDAL<EnderecoDTO> endDAL = new NHibernateDAL<EnderecoDTO>(session);
                    IList<EnderecoDTO> listaEnd = endDAL.select(new EnderecoDTO { idEmpresa = resultado.Id, principal = "S" });
                    if (listaEnd.Count > 0)
                        resultado.endereco = listaEnd.First();

                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
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

        #region TributOperacaoFiscal

        public IList<TributOperacaoFiscalDTO> selectTributOperacaoFiscal(TributOperacaoFiscalDTO tributOperacaoFiscal)
        {
            try
            {
                IList<TributOperacaoFiscalDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributOperacaoFiscalDTO> DAL = new NHibernateDAL<TributOperacaoFiscalDTO>(session);
                    resultado = DAL.select(tributOperacaoFiscal);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion

        #region ViewTributacaoPis

        public ViewTributacaoPisDTO selectViewTributacaoPis(ViewTributacaoPisDTO viewTributacaoPis)
        {
            try
            {
                ViewTributacaoPisDTO resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewTributacaoPisDTO> DAL = new NHibernateDAL<ViewTributacaoPisDTO>(session);
                    resultado = DAL.selectObjeto(viewTributacaoPis);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion

        #region ViewTributacaoCofins

        public ViewTributacaoCofinsDTO selectViewTributacaoCofins(ViewTributacaoCofinsDTO viewTributacaoCofins)
        {
            try
            {
                ViewTributacaoCofinsDTO resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewTributacaoCofinsDTO> DAL = new NHibernateDAL<ViewTributacaoCofinsDTO>(session);
                    resultado = DAL.selectObjeto(viewTributacaoCofins);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion

        #region ViewTributacaoIcms
        public ViewTributacaoIcmsDTO selectViewTributacaoIcms(ViewTributacaoIcmsDTO viewTributacaoIcms)
        {
            try
            {
                ViewTributacaoIcmsDTO resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewTributacaoIcmsDTO> DAL = new NHibernateDAL<ViewTributacaoIcmsDTO>(session);
                    resultado = DAL.selectObjeto(viewTributacaoIcms);
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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ConciliacaoService.Model;
using NHibernate;
using ConciliacaoService.NHibernate;

namespace ConciliacaoService
{
    public class ConciliacaoService : IConciliacaoService
    {
        public IList<ExtratoContaBancoDTO> selectExtrato(ExtratoContaBancoDTO extrato)
        {
            using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
            {
                NHibernateDAL<ExtratoContaBancoDTO> extratoDAL = new NHibernateDAL<ExtratoContaBancoDTO>(session);
                return extratoDAL.select(extrato);
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

        public int saveUpdateListaExtrato(IList<ExtratoContaBancoDTO> listaExtrato)
        {
            using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
            {
                int resultado = -1;
                NHibernateDAL<ExtratoContaBancoDTO> extratoDAL = new NHibernateDAL<ExtratoContaBancoDTO>(session);

                IList<ExtratoContaBancoDTO> listaExcluir = new List<ExtratoContaBancoDTO>();
                string ano = listaExtrato.First().ano;
                string mes = listaExtrato.First().mes;
                listaExcluir = extratoDAL.select(new ExtratoContaBancoDTO { ano = ano, mes = mes });

                foreach (ExtratoContaBancoDTO extratoExcluir in listaExcluir)
                {
                    extratoDAL.delete(extratoExcluir);
                }
                foreach (ExtratoContaBancoDTO extrato in listaExtrato)
                {
                    extratoDAL.saveUpdate(extrato);
                }
                session.Flush();
                resultado = 0;
                return resultado;
            }
        }

        public int conciliarCheques(ExtratoContaBancoDTO extrato)
        {
            using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
            {
                int resultado = -1;

                NHibernateDAL<ExtratoContaBancoDTO> extratoDAL = new NHibernateDAL<ExtratoContaBancoDTO>(session);
                extrato.historico = "Cheque Compensado";
                IList<ExtratoContaBancoDTO> listaCheques = extratoDAL.select(extrato);

                NHibernateDAL<ChequeDTO> chequeDAL = new NHibernateDAL<ChequeDTO>(session);
                foreach (ExtratoContaBancoDTO chequeExtrato in listaCheques)
                {
                    ChequeDTO filtroCheque = new ChequeDTO { numero = int.Parse(chequeExtrato.documento) };

                    IList<ChequeDTO> listaChequeCompensado = chequeDAL.select(filtroCheque);
                    chequeExtrato.conciliado = "N";
                    if (listaChequeCompensado.Count > 0)
                    {
                        chequeExtrato.conciliado = "S";
                    }
                }

                foreach (ExtratoContaBancoDTO extratoCheque in listaCheques)
                {
                    extratoDAL.saveUpdate(extratoCheque);
                }
                resultado = 0;
                session.Flush();

                return resultado;
            }
        }


        public int conciliarLancamentos(ExtratoContaBancoDTO extrato)
        {
            using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
            {
                int resultado = -1;

                ExtratoContaBancoDAL extratoDAL = new ExtratoContaBancoDAL(session);
                IList<ExtratoContaBancoDTO> listaLancamentos = extratoDAL.selectLancamentos(extrato);

                NHibernateDAL<ParcelaPagamentoDTO> pagamentoDAL = new NHibernateDAL<ParcelaPagamentoDTO>(session);
                NHibernateDAL<ParcelaRecebimentoDTO> recebimentoDAL = new NHibernateDAL<ParcelaRecebimentoDTO>(session);

                foreach (ExtratoContaBancoDTO lancamento in listaLancamentos)
                {
                    lancamento.conciliado = "N";
                    if (lancamento.valor > 0)
                    {
                        ParcelaRecebimentoDTO parcelaConc = new ParcelaRecebimentoDTO { valorRecebido = lancamento.valor };

                        IList<ParcelaRecebimentoDTO> listaRec = recebimentoDAL.select(parcelaConc);
                        if (listaRec.Count > 0)
                        {
                            lancamento.conciliado = "S";
                            lancamento.observacao = listaRec.First().historico;
                        }
                    }
                    else 
                    {
                        ParcelaPagamentoDTO parcelaConc = new ParcelaPagamentoDTO { valorPago = lancamento.valor * -1};

                        IList<ParcelaPagamentoDTO> listaPag = pagamentoDAL.select(parcelaConc);
                        if (listaPag.Count > 0)
                        {
                            lancamento.conciliado = "S";
                            lancamento.observacao = listaPag.First().historico;
                        }
                    }
                }

                foreach (ExtratoContaBancoDTO lancamento in listaLancamentos)
                {
                    extratoDAL.saveUpdate(lancamento);
                }
                resultado = 0;
                session.Flush();

                return resultado;
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
        public IList<EmpresaDTO> selectEmpresa(EmpresaDTO empresa)
        {
            try
            {
                IList<EmpresaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<EmpresaDTO> DAL = new NHibernateDAL<EmpresaDTO>(session);
                    resultado = DAL.select(empresa);
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

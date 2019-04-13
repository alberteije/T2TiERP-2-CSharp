using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;
using Servidor.NHibernate;
using Servidor.Model;

namespace Servidor.DAL
{
    public class EmpresaDAL : NHibernateDAL<EmpresaDTO>
    {
        public EmpresaDAL(ISession Session) : base(Session) { }

        public EmpresaDTO SaveOrUpdate(EmpresaDTO objeto)
        {
            try
            {
                base.SaveOrUpdate<EmpresaDTO>(objeto);
                Session.Flush();
                return objeto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmpresaDTO SelectId(int id)
        {
            try
            {
                EmpresaDTO resultado = Session.Get<EmpresaDTO>(id);

                NHibernateDAL<EmpresaEnderecoDTO> DAL = new NHibernateDAL<EmpresaEnderecoDTO>(Session);
                resultado.ListaEndereco = DAL.Select<EmpresaEnderecoDTO>(new EmpresaEnderecoDTO { IdEmpresa = resultado.Id });

                if (resultado.ListaEndereco == null)
                    resultado.ListaEndereco = new List<EmpresaEnderecoDTO>();
                else 
                {
                    for (int i = 0; i <= resultado.ListaEndereco.Count - 1; i++)
                    {
                        if (resultado.ListaEndereco[i].Principal == "S")
                            resultado.EnderecoPrincipal = resultado.ListaEndereco[i];
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IList<EmpresaDTO> Select(EmpresaDTO objeto)
        {
            try
            {
                IList<EmpresaDTO> resultado = base.Select<EmpresaDTO>(objeto);

                foreach (EmpresaDTO objP in resultado)
                {
                    NHibernateDAL<EmpresaEnderecoDTO> DAL = new NHibernateDAL<EmpresaEnderecoDTO>(Session);
                    objP.ListaEndereco = DAL.Select<EmpresaEnderecoDTO>(new EmpresaEnderecoDTO { IdEmpresa = objP.Id });

                    if (objP.ListaEndereco == null)
                        objP.ListaEndereco = new List<EmpresaEnderecoDTO>();
                    else
                    {
                        for (int i = 0; i <= objP.ListaEndereco.Count - 1; i++)
                        {
                            if (objP.ListaEndereco[i].Principal == "S")
                                objP.EnderecoPrincipal = objP.ListaEndereco[i];
                        }
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<EmpresaDTO> SelectPagina(int primeiroResultado, int quantidadeResultados, EmpresaDTO objeto)
        {
            try
            {
                IList<EmpresaDTO> resultado = base.SelectPagina<EmpresaDTO>(primeiroResultado, quantidadeResultados, objeto);
                
                foreach (EmpresaDTO objLista in resultado)
                {
                    NHibernateDAL<EmpresaEnderecoDTO> DAL = new NHibernateDAL<EmpresaEnderecoDTO>(Session);
                    objLista.ListaEndereco = DAL.Select<EmpresaEnderecoDTO>(new EmpresaEnderecoDTO { IdEmpresa = objLista.Id });

                    if (objLista.ListaEndereco == null)
                        objLista.ListaEndereco = new List<EmpresaEnderecoDTO>();
                    else
                    {
                        for (int i = 0; i <= objLista.ListaEndereco.Count - 1; i++)
                        {
                            if (objLista.ListaEndereco[i].Principal == "S")
                                objLista.EnderecoPrincipal = objLista.ListaEndereco[i];
                        }
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete(EmpresaDTO objeto)
        {
            try
            {
                IList<EmpresaEnderecoDTO> listaExclusao = Session.CreateCriteria(typeof(EmpresaEnderecoDTO)).
                    Add(Expression.Eq("IdEmpresa", objeto.Id)).List<EmpresaEnderecoDTO>();

                foreach (EmpresaEnderecoDTO objLista in listaExclusao)
                {
                    Session.Delete(objLista);
                }

                int resultado = base.Delete<EmpresaDTO>(objeto);

                Session.Flush();

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
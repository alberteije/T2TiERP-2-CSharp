using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;
using Servidor.Util;
using Servidor.NHibernate;
using Servidor.Model;

namespace Servidor.DAL
{
    public class UsuarioDAL : NHibernateDAL<UsuarioDTO>
    {
        public UsuarioDAL(ISession Session) : base(Session) { }

        public UsuarioDTO Select(String login, String senha)
        {
            try
            {
                String consultaSql = "from UsuarioDTO where Login=" + Biblioteca.QuotedStr(login) + " and Senha=" + Biblioteca.QuotedStr(Biblioteca.MD5String(login + senha));
                UsuarioDTO resultado = base.SelectObjetoSql<UsuarioDTO>(consultaSql);
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
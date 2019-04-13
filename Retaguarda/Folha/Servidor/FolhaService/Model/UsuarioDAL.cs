using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;
using FolhaService.Util;

namespace FolhaService.Model
{
    public class UsuarioDAL : NHibernateDAL<UsuarioDTO>
    {
        public UsuarioDAL(ISession session) : base(session) { }

        public UsuarioDTO select(String login, String senha)
        {
            try
            {
                String consultaSql = "from UsuarioDTO where Login=" + Biblioteca.QuotedStr(login) + " and Senha=" + Biblioteca.QuotedStr(Biblioteca.MD5String(login + senha));
                UsuarioDTO resultado = base.selectObjetoSql<UsuarioDTO>(consultaSql);
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
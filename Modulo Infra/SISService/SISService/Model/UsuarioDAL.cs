using System;
using NHibernate;
using SISService.Util;
using SISService.NHibernate;

namespace SISService.Model
{
    public class UsuarioDAL : NHibernateDAL<UsuarioDTO>
    {
        public UsuarioDAL(ISession session) : base(session) { }

        public UsuarioDTO Select(String login, String senha)
        {
            try
            {
                String ConsultaSql = "from UsuarioDTO where Login=" + Biblioteca.QuotedStr(login) + " and Senha=" + Biblioteca.QuotedStr(Biblioteca.MD5String(login + senha));
                UsuarioDTO Resultado = base.SelectObjetoSql<UsuarioDTO>(ConsultaSql);
                return Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SISGMFWeb.Servico;

namespace SISGMFWeb.Account
{
    public partial class Contato : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdColaborador"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["UsuarioAdministrador"].ToString() != "S")
                {
                    Response.Redirect("SemAcesso.aspx");
                }

                LabelTitulo.Text = "Cliente Logado: " + Session["UsuarioNome"].ToString();
            }

            //
            LabelTitulo.Text = "Cliente Logado: " + Session["UsuarioNome"].ToString();
            LabelMensagens.Text = "Formulário de Contato"; 

        }

        /// EXERCICIO
        /// Concluir o formulário de contato para que o mesmo envie o e-mail

    }
}
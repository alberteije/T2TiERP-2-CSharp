using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SISGMFWeb.Servico;

namespace SISGMFWeb.Account
{
    public partial class Chat : System.Web.UI.Page
    {
        private int IdMercado;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.DataBind();
        }


    }
}
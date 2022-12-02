using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LivrotecTCC
{
    public partial class editarlivro : System.Web.UI.Page
    {
        public string Email;
        Identificador Identificador;
        BancoDeDados BD = new BancoDeDados();
        protected void Page_Load(object sender, EventArgs e)
        {
            Identificador = new Identificador(BD, this);
            if (!Identificador.EhAdministrador())
                Response.Redirect("login.aspx");

        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Identificador.Logout();
        }
    }
}
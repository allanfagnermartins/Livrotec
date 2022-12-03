using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LivrotecTCC
{
    public partial class adminUsuario : System.Web.UI.Page
    {
        public string Email => Identificador.Email;
        Identificador Identificador;
        protected void Page_Load(object sender, EventArgs e)
        {
            var BD = new BancoDeDados();
            Identificador = new Identificador(BD, this);
            if (!Identificador.EhAdministrador())
                Response.Redirect("login.aspx");

        }
         

    }
}
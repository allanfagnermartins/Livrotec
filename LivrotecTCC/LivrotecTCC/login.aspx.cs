using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LivrotecTCC
{
    public partial class login : System.Web.UI.Page
    {
        BancoDeDados BD = new BancoDeDados();
        Identificador Identificador;
        protected void Page_Load(object sender, EventArgs e)
        {
            Identificador = new Identificador(BD, this);
            email.Text = "";
            senha.Text = "";

            if (Identificador.LoginValido())
            {
                if (Identificador.EhAdministrador())
                    Response.Redirect("admin.aspx"); 
                else
                    Response.Redirect("index.aspx");
            } 
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Identificador.RegistrarCookie(Request.Form["email"], Request.Form["senha"]);

            if (!Identificador.LoginValido())
            {
                erro.Text = "Login e/ou senha incorretos!";
                return;
            }
         
            if (Identificador.EhAdministrador())
                Response.Redirect("admin.aspx");
            else
                Response.Redirect("index.aspx");
        }
    }
}
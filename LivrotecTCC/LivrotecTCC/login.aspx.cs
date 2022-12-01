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
        HttpCookie cookie = new HttpCookie("loginUsuario");
        BancoDeDados BD = new BancoDeDados();
        protected void Page_Load(object sender, EventArgs e)
        {

            email.Text = "";
            senha.Text = "";

            if (cookie["Email"] != null && cookie["Senha"] != null)
            {
                HttpCookie cookie = Request.Cookies["loginUsuario"];

                if (BD.Usuarios.VerificarAdmin(cookie["Email"]))
                    Response.Redirect("admin.aspx"); 
                else
                    Response.Redirect("index.aspx");

                email.Text = "";
                senha.Text = "";
            } 
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            cookie["Email"] = Request.Form["email"];
            cookie["Senha"] = Request.Form["senha"];
            cookie.HttpOnly = true;
            Response.Cookies.Add(cookie);

            if (BD.Usuarios.LoginValido(cookie["Email"], cookie["Senha"]))
            {
                erro.Text = "";
                if (BD.Usuarios.VerificarAdmin(cookie["Email"]))
                {
                    Response.Redirect("admin.aspx");
                    email.Text = "";
                    senha.Text = "";
                }
                else
                {
                    Response.Redirect("index.aspx");
                    email.Text = "";
                    senha.Text = "";
                }
            }
            else 
            {
                erro.Text = "Login e/ou senha incorretos!";
            }
        }
    }
}
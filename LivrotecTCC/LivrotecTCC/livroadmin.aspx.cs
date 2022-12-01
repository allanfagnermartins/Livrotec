using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LivrotecTCC
{
    public partial class livroAdmin : System.Web.UI.Page
    {
        string Email;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetMaxAge(TimeSpan.Zero);
            Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            Response.Cache.SetNoStore();
            HttpCookie cookie = Request.Cookies["loginUsuario"];

            litLogin.Text = "Login";

            if (cookie == null)
                Response.Redirect("login.aspx");

            if (cookie != null)
            {
                litLogin.Text = "";
                Email = cookie["Email"];
                icone.Visible = true;
                dropdown.Visible = true;
                litInicialEmail.Text = "<p>" + Email.Substring(0, 1).ToUpper() + "</p>";

                if (Email == "" || Email == null)
                {
                    Response.Redirect("index.aspx");
                } 
            }

        } 

        protected void btnSair_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["loginUsuario"] != null)
            {
                Response.Cookies["loginUsuario"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Redirect("index.aspx");
        }
    }
}
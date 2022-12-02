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
        public string Email;
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["loginUsuario"];

            if (cookie == null)
            {
                dropdown.Visible = false;
            }

            if (cookie == null)
                Response.Redirect("login.aspx");

            Email = cookie["Email"];
            dropdown.Visible = true;


            cookie.HttpOnly = true;

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
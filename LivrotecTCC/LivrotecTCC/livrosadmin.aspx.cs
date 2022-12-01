using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace LivrotecTCC
{
    public partial class livrosadmin : Page
    {
        public string Email;
        BancoDeDados BD = new BancoDeDados();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetMaxAge(TimeSpan.Zero);
            Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            Response.Cache.SetNoStore();
            HttpCookie cookie = Request.Cookies["loginUsuario"];

  

            if (cookie == null)
                Response.Redirect("index.aspx");

            if (cookie != null)
            {
                Email = cookie["Email"];
                icone.Visible = true;
                dropdown.Visible = true;
            }
             
              CarregarLivros();

        }

        void CarregarLivros()
        {
            HttpCookie cookie = Request.Cookies["loginUsuario"];
            if (cookie != null)
                 Email = cookie["Email"];
            List<Livro> listaLivros = BD.Livros.ConsultarTodos();
            MainTodasFilas.Visible = true; 
            FilasRepeater.DataSource = listaLivros;
            FilasRepeater.DataBind(); 
        }
         
        protected void btnSair_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["loginUsuario"] != null)
                Response.Cookies["loginUsuario"].Expires = DateTime.Now.AddDays(-1);

            Response.Redirect("index.aspx");
        }

    }
}
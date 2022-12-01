using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace LivrotecTCC
{
    public partial class index1 : System.Web.UI.Page
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

            AreaLogin.Visible= true;

            if (cookie == null)
            {
                icone.Visible = false;
                dropdown.Visible = false;
            }

            if (cookie != null)
            {
                AreaLogin.Visible = false;
                Email = cookie["Email"];
                icone.Visible = true;
                dropdown.Visible = true;
                if (BD.Usuarios.VerificarAdmin(cookie["Email"]))
                    Response.Redirect("admin.aspx");
            }
            
            if (Email == "" || Email == null)
                CarregarLivros();
            else
                CarregarLivrosLogin();

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

        void CarregarLivrosLogin()
        {
            HttpCookie cookie = Request.Cookies["loginUsuario"];
            Email = cookie["Email"];
            MainOutrasFilas.Visible = true;
            bool InscritoAlgumaFila = BD.Usuarios.ContarFilaPessoa(Email) >= 1;
            MainMeusLivros.Visible = InscritoAlgumaFila;
            TituloNaoMinhasFilas.Visible = InscritoAlgumaFila;
            TituloMinhasFilas.Visible = InscritoAlgumaFila;
            List<Livro> listaLivros = BD.Livros.ConsultarMeus(Email);
            MinhasFilasRepeater.DataSource = listaLivros;
            MinhasFilasRepeater.DataBind();

            List<Livro> listaNaoLivros = BD.Livros.ConsultarNaoMeus(Email);
            OutrasFilasRepeater.DataSource = listaNaoLivros;
            OutrasFilasRepeater.DataBind(); 

        }
        protected void btnSair_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["loginUsuario"] != null)
                Response.Cookies["loginUsuario"].Expires = DateTime.Now.AddDays(-1);

            Response.Redirect("index.aspx");
        }

    }
}
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
        string Email;
        BancoDeDados BD = new BancoDeDados();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetMaxAge(TimeSpan.Zero);
            Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            Response.Cache.SetNoStore();
            HttpCookie cookie = Request.Cookies["loginUsuario"];

            litLogin.Text = "Login";

            if (cookie == null)
            {
                icone.Visible = false;
                dropdown.Visible = false;
            }

            if (cookie != null)
            {
                litLogin.Text = "";
                Email = cookie["Email"];
                icone.Visible = true;
                dropdown.Visible = true;
                litInicialEmail.Text = "<p>" + Email.Substring(0, 1).ToUpper() + "</p>";
            }
            if (Email == "" || Email == null)
            {
                CarregarLivros();
            }
            else
            {
                CarregarLivrosLogin();
            }

        }

        void CarregarLivros()
        {
            HttpCookie cookie = Request.Cookies["loginUsuario"];
            if (cookie != null)
            {
                string Email = cookie["Email"];
            }
            litFilas.Text = "";  
            List<Livro> listaLivros = BD.Livros.ConsultarTodos();
            foreach(var livro in listaLivros)
            {
                litFilas.Text += $@"<a href='livro.aspx?cd={ livro.ISBN}&email={ Email }' class = 'cardFila'>
                                        <img src='imagens/{ livro.Caminho}.jpg'  class='imgLivro' alt='capa do livro '{livro.Nome}>
                                        <p id='titulo'>{livro.Nome}</p>
                                    </a>";
            }
        }

        void CarregarLivrosLogin()
        {
            HttpCookie cookie = Request.Cookies["loginUsuario"];
            string Email = cookie["Email"];

            litMinhasFilas.Text = "";
            litNaoMinhaFilas.Text = "";
            litTituloFila1.Text = "";
            litTituloFila2.Text = "";
            List<Livro> listaLivros = BD.Livros.ConsultarMeus(Email);
            if (BD.Usuarios.ContarFilaPessoa(Email) >= 1)
            {
                litTituloFila1.Text = "<h2 style='text-align: center'> Minhas Filas </h2>";
            };
            foreach (var livro in listaLivros)
            {
                litMinhasFilas.Text += $@"<a href='livro.aspx?cd={ livro.ISBN}&email={ Email }' class = 'cardFila'>
                                        <img src='imagens/{ livro.Caminho}.jpg'  class='imgLivro' alt='capa do livro '{livro.Nome}>
                                        <p id='titulo'>{livro.Nome}</p>
                                    </a>";
            }
            List<Livro> listaNaoLivros = BD.Livros.ConsultarNaoMeus(Email);
            if (BD.Usuarios.ContarFilaPessoa(Email) >= 1)
            {
                litTituloFila2.Text = "<h2 style='text-align: center'> Outras Filas </h2>";
            };
            foreach (var livro in listaNaoLivros)
            {
                litNaoMinhaFilas.Text += $@"<a href='livro.aspx?cd={ livro.ISBN}&email={ Email }' class = 'cardFila'>
                                        <img src='imagens/{ livro.Caminho}.jpg'  class='imgLivro' alt='capa do livro '{livro.Nome}>
                                        <p id='titulo'>{livro.Nome}</p>
                                    </a>";
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
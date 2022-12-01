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

        public string Email;
        string ISBN;
        BancoDeDados BD = new BancoDeDados();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["loginUsuario"];
            ISBN = Request["cd"];
            Email = Request["email"];


            if (cookie == null)
                Response.Redirect("login.aspx");

            if (cookie != null)
            {
                Email = cookie["Email"];
                icone.Visible = true;
                dropdown.Visible = true;
            }

            if (ISBN == null || Email == null)
                Response.Redirect("login.aspx");
            
            CarregarInfosLivro();

        }

 


        void CarregarInfosLivro()
        {
            Livro livro = BD.Livros.Consultar(ISBN);
            var quantidade = BD.Filas.Tamanho(ISBN);



            litImagemLivro.Text = $"<img id='imgInfoLivro' src='imagens/{livro.Caminho}.jpg'></img>";
            litTituloLivro.Text = $"<p id='pTituloLivro'>{ livro.Nome }</p>";
            litSinopseLivro.Text = $"<p id='pSinopseLivro'>{ livro.Sinopse }</p>";
            litQuantidadeFila.Text = $"<p id='QtPessoasFila'>{ quantidade }</p>";


        }

        protected void btnEditarLivro_Click(object sender, EventArgs e)
        {
            Response.Redirect("editarlivro.aspx");
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
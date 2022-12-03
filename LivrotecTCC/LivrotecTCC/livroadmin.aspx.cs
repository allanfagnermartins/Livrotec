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
        public string Email => Identificador.Email;
        string ISBN;
        Identificador Identificador;
        BancoDeDados BD = new BancoDeDados();
        protected void Page_Load(object sender, EventArgs e)
        {
            Identificador = new Identificador(BD, this);
            ISBN = Request["cd"];


            if (!Identificador.EhAdministrador())
                Response.Redirect("login.aspx");

            if (BD.Livros.consultarISBNDoacao(ISBN) == null)
                Response.Redirect("livrosadmin.aspx");


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
            Response.Redirect($"editarlivro.aspx?cd={ISBN}");
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Identificador.Logout();
        }

    }
}
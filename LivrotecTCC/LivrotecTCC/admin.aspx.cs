using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LivrotecTCC
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["loginUsuario"];

            if (cookie == null)
            {
                icone.Visible = false;
                dropdown.Visible = false;
            }

            if (cookie != null)
            {
                    string Email = cookie["Email"];
                    icone.Visible = true;
                    dropdown.Visible = true;
                    litInicialEmail.Text = "<p>" + Email.Substring(0, 1).ToUpper() + "</p>";
                string emailUsuario = cookie["Email"];

                string emailUrl = Request["email"];

                litDoacao.Text = $"<a href='doacao.aspx?email={emailUsuario}' class='aAdmin'> <div class='divAdmin'> <img src = 'imagens/imgDoacaoLivro.png' alt='Uma mão segurando um livro' class='imgAdmin' style='height: 250px;'> <p class='prAdmin'>Doações</p> </div> </a>";
                litEmprestimo.Text = $"<a href='emprestimos.aspx?email={emailUsuario}' class='aAdmin'> <div class='divAdmin'> <img src = 'imagens/imgEmprestimoLivro.png' alt='Pilha de livros' class='imgAdmin' style='height: 250px;'> <p class='prAdmin'>Empréstimos</p> </div> </a>";
                litLivro.Text = $"<a href='livroadimin.aspx?email={emailUsuario}' class='aAdmin'> <div class='divAdmin'> <img src = 'imagens/imgEmprestimoLivro.png' alt='Pilha de livros' class='imgAdmin' style='height: 250px;'> <p class='prAdmin'>Livros</p> </div> </a>";

                if (emailUrl != emailUsuario)
                {
                    Response.Redirect("login.aspx");
                }

                cookie.HttpOnly = true;
            }
            else
            {
                Response.Redirect("login.aspx");
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LivrotecTCC;

namespace LivrotecTCC
{
    public partial class emprestimos : System.Web.UI.Page
    {
        BancoDeDados BD = new BancoDeDados();
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarEmprestimos();

            HttpCookie cookie = Request.Cookies["loginUsuario"];

            if (cookie != null)
            {
                string emailUsuario = cookie["Email"];

                string emailUrl = Request["email"];

                if (emailUrl != emailUsuario)
                {
                    Response.Redirect("login.aspx");
                }

                cookie.HttpOnly = true;
            }

        }

        void CarregarEmprestimos()
        {
            HttpCookie cookie = Request.Cookies["loginUsuario"];
            litEmprestimos.Text = "";
            List<Emprestimo> listaEmprestimos = BD.Emprestimos.ConsultarTodos();
            foreach (var emprestimo in listaEmprestimos)
            {
                Livro livro = BD.Livros.Consultar(emprestimo.ISBN);

                if (emprestimo.DataEmprestimo != null)
                {
                    litEmprestimos.Text += $@"<a href='emprestimo.aspx?cd={ emprestimo.Codigo}&email={cookie["Email"]}' class='cardEmprestimo'> 
                    <section>
                        <img src='imagens/{livro.Caminho}.jpg'  class='imgLivroEmprestimo' alt='capa do livro '{livro.Nome}>
                    </section>
                    <section class='sctContEmprestimo'>
                        <p class='contEmprestimo' style='font-weight: bold;'>{livro.Nome}</p>
                    <p class='contEmprestimo'>{emprestimo.Email}</p>
                    <p class='contEmprestimo'></p>
                    </section>
                </a>";
                }

            }
        }
    }
}
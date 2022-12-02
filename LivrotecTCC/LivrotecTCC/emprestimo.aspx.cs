using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LivrotecTCC
{
    public partial class emprestimo : System.Web.UI.Page
    {

        BancoDeDados BD = new BancoDeDados();
        string Codigo;
        string ISBN;

        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["loginUsuario"];

            if (cookie != null)
            {

                cookie.HttpOnly = true;
            }

            Codigo = Request["cd"];
            if (Codigo != null)
            {
                Emprestimo emprestimo = BD.Emprestimos.Consultar(Codigo);
                ISBN = emprestimo.ISBN;
                if (ISBN != null)
                {
                    CarregarInfoEmprestimos();

                    btnConfirmarDevolucao.Visible = false;

                    if (emprestimo.DataEmprestimo == "")
                    {
                        btnConfirmarDevolucao.Visible = false;
                        btnConfirmarEmprestimo.Visible = true;
                        btnCancelarEmprestimo.Visible = true;
                        btnEmprestimoRoubado.Visible = false;
                    }
                    else
                    {
                        if (emprestimo.DataDevolucaoEfetiva == "" && emprestimo.Roubado == false)
                        {
                            btnConfirmarEmprestimo.Visible = false;
                            btnCancelarEmprestimo.Visible = false;
                            btnConfirmarDevolucao.Visible = true;
                            btnEmprestimoRoubado.Visible = true;
                        }

                        if (emprestimo.Roubado == true)
                        {
                            litSituacaoEmprestimo.Text = "Que pena! O livro foi roubado. :(";
                            btnConfirmarEmprestimo.Visible = false;
                            btnCancelarEmprestimo.Visible = false;
                            btnConfirmarDevolucao.Visible = false;
                            btnEmprestimoRoubado.Visible = false;
                        }

                        if (emprestimo.DataDevolucaoEfetiva != "")
                        {
                            litSituacaoEmprestimo.Text = "O empréstimo já foi concluído!";
                            btnConfirmarEmprestimo.Visible = false;
                            btnCancelarEmprestimo.Visible = false;
                            btnConfirmarDevolucao.Visible = false;
                            btnEmprestimoRoubado.Visible = false;
                        }

                    }

                }
            }

            else
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void btnCancelarEmprestimo_Click(object sender, EventArgs e)
        {
            ClicarBotaoCancelarEmprestimo();
        }

        protected void outroBtnEmprestimo_Click(object sender, EventArgs e)
        {
            ClicarBotaoConfirmarEmprestimo();
            CarregarInfoEmprestimos();
            Response.Redirect(Request.RawUrl);

        }

        protected void btnEmprestimo_Click(object sender, EventArgs e)
        {
            ClicarBotaoConfirmarDevolucao();
            CarregarInfoEmprestimos();
            Response.Redirect(Request.RawUrl);
        }

        protected void btnEmprestimoRoubado_Click(object sender, EventArgs e)
        {
            ClicarBotaoRoubado();
            Response.Redirect(Request.RawUrl);
        }

        void CarregarInfoEmprestimos()
        {
            Emprestimo emprestimo = BD.Emprestimos.Consultar(Codigo);
            Livro livro = BD.Livros.Consultar(ISBN);

            litImagemLivro.Text = $"<img id='imgInfoLivro' src='imagens/{livro.Caminho}.jpg'></img>";
            litTituloLivro.Text = $"<h2>{livro.Nome}</h2>";
            litEmailUsuario.Text = $"<p>{emprestimo.Email}</p>";

            if(emprestimo.DataEmprestimo != "")
            {
                litDataEmprestimo.Text = $"{emprestimo.DataEmprestimo.Substring(0, 10)}";
            }
            
            if(emprestimo.DataDevolucaoPrevista != "")
            {
                litDataDevolucao.Text = $"{emprestimo.DataDevolucaoPrevista.Substring(0, 10)}";
            }

            if(emprestimo.DataDevolucaoEfetiva != "")
            {
                litDataEfetiva.Text = $"{emprestimo.DataDevolucaoEfetiva.Substring(0, 10)}";
            }
            
        }

        void ClicarBotaoCancelarEmprestimo()
        {
            HttpCookie cookie = Request.Cookies["loginUsuario"];
            string emailUsuario = cookie["Email"];

            BD.Emprestimos.CancelarEmprestimo(int.Parse(Codigo));
            Response.Redirect($"emprestimos.aspx?email={emailUsuario}");
        }

        void ClicarBotaoConfirmarEmprestimo()
        {
            BD.Emprestimos.ConfirmarEmprestimo(int.Parse(Codigo));
        }

        void ClicarBotaoConfirmarDevolucao()
        {
            BD.Emprestimos.ConfirmarDevolucao(Codigo);
        }

        void ClicarBotaoRoubado()
        {
            BD.Emprestimos.EmprestimoRoubado(int.Parse(Codigo));
        }

    }
}
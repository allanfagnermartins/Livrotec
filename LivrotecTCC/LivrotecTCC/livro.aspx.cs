using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace LivrotecTCC
{
    public partial class livro : System.Web.UI.Page
    {

        string Email;
        string ISBN;
        BancoDeDados BD = new BancoDeDados();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["loginUsuario"];
            ISBN = Request["cd"];
            Email = Request["email"];

            AreaLogin.Visible = true;

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
                litInicialEmail.Text = "<p>" + Email.Substring(0, 1).ToUpper() + "</p>";
            }

            if (ISBN != null)
            {
                if(Email != null)
                {
                    CarregarInfosLivro();
                    NomeBotaoLivro();
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }

            else 
            {
                Response.Redirect("index.aspx");
            }

        }

        protected void btnInfoLivro_Click(object sender, EventArgs e)
        {
            if (Request["cd"] != null)
            {
                ClicarBotao();
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }


        void CarregarInfosLivro()
        {
            Livro livro = BD.Livros.Consultar(ISBN);
            var codigoEmprestimo = BD.Emprestimos.CodigoEmprestimo(Email, ISBN);
            var posicao = BD.Filas.Posicao(Email, ISBN);
            var quantidade = BD.Filas.Tamanho(ISBN);


            litImagemLivro.Text = $"<img id='imgInfoLivro' src='imagens/{livro.Caminho}.jpg'></img>";
            litTituloLivro.Text = $"<p id='pTituloLivro'>{ livro.Nome }</p>";
            litSinopseLivro.Text = $"<p id='pSinopseLivro'>{ livro.Sinopse }</p>";

            if (posicao == null)
            {

                if (BD.Emprestimos.ChecarEmprestimoLivro(Email, ISBN))
                {

                    if (BD.Emprestimos.ChecarEmprestimo(Email))
                    {
                        if (BD.Emprestimos.ConsultarRoubos(Email))
                        {
                            btnInfoLivro.Visible = false;
                            litQuantidadeFila.Text = $"<p class='avisoImportante'> Você roubou um livro, verifique como proceder <a href='duvidas.aspx'>aqui!</a></p>";
                        }
                        else
                        {
                            if (BD.Emprestimos.ChecarEmprestimoConfirmado(codigoEmprestimo.ToString()))
                            {
                                var dias = BD.Emprestimos.DiasRestantes(codigoEmprestimo.ToString());
                                btnInfoLivro.Visible = false;
                                litQuantidadeFila.Text = $"<p class='avisoImportante'> Você tem {dias} dias restantes em seu empréstimo</p>";
                            }

                            else
                            {
                                btnInfoLivro.Visible = false;
                                litQuantidadeFila.Text = $"<p class='avisoImportante'> Venha buscar seu livro na unidade escolar!</p>";
                            }

                        }
                    }

                }
                else
                {
                    if (BD.Emprestimos.ConsultarRoubos(Email))
                    {
                        btnInfoLivro.Visible = false;
                        litQuantidadeFila.Text = $"<p class='avisoImportante'> Você roubou um livro, verifique como proceder <a href='duvidas.aspx'>aqui!</a></p>";
                    }
                    else
                    {
                        litQuantidadeFila.Text = $"<p id='QtPessoasFila'>{quantidade}</p>";
                    }
                }

            }
            else
            {
                litQuantidadeFila.Text = $"<p id='QtPessoasFila'>Sua posição na fila: {posicao}</p>";
            }


        }

        void NomeBotaoLivro()
        { 
            EstadoUsuarioFila Estado = BD.Filas.EstadoUsuario(Email, ISBN);
            btnInfoLivro.Text = Estado.InscritoFila ? "Sair da fila" : "Entrar na fila";
        }

        void ClicarBotao()
        {
            HttpCookie cookie = Request.Cookies["loginUsuario"];

            if (cookie != null)
            {
                Email = cookie["Email"];


                EstadoUsuarioFila Estado = BD.Filas.EstadoUsuario(Email, ISBN);
                if (Estado.InscritoFila)
                {
                    BD.Filas.Sair(Email, ISBN);
                    NomeBotaoLivro();
                    CarregarInfosLivro();
                }
                else
                {
                    BD.Filas.Entrar(Email, ISBN);
                    NomeBotaoLivro();
                    CarregarInfosLivro();
                }

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
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
        public string Email => Identificador.Email;
        BancoDeDados BD = new BancoDeDados();
        Identificador Identificador;
        protected void Page_Load(object sender, EventArgs e)
        {
            Identificador = new Identificador(BD, this);

             

            AreaLogin.Visible= true;

            if (Identificador.LoginValido())
            {
                AreaLogin.Visible = false;
                icone.Visible = true;
                dropdown.Visible = true;
                if (Identificador.EhAdministrador())
                    Response.Redirect("admin.aspx");
            }
            else
            {
                icone.Visible = false;
                dropdown.Visible = false;
            }

            if (Identificador.EstaLogado())
                CarregarLivrosLogin();
            else
                CarregarLivros();

        }

        void CarregarLivros()
        {
            List<Livro> listaLivros = BD.Livros.ConsultarTodos();
            MainTodasFilas.Visible = true; 
            FilasRepeater.DataSource = listaLivros;
            FilasRepeater.DataBind(); 
        }

        void CarregarLivrosLogin()
        {
            MainOutrasFilas.Visible = true;

            List<Livro> listaLivros = BD.Livros.ConsultarMeus(Identificador.Email);
            MinhasFilasRepeater.DataSource = listaLivros;
            MinhasFilasRepeater.DataBind();

            List<Livro> listaNaoLivros = BD.Livros.ConsultarNaoMeus(Identificador.Email);
            OutrasFilasRepeater.DataSource = listaNaoLivros;
            OutrasFilasRepeater.DataBind();

            bool InscritoAlgumaFila = listaLivros.Count() >= 1;
            MainMeusLivros.Visible = InscritoAlgumaFila;
            TituloNaoMinhasFilas.Visible = InscritoAlgumaFila;
            TituloMinhasFilas.Visible = InscritoAlgumaFila;

        }
        protected void btnSair_Click(object sender, EventArgs e)
        {
            Identificador.Logout();
        }

    }
}
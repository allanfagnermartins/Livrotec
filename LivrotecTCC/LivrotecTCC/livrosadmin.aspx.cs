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
        public string Email => Identificador.Email;
        Identificador Identificador;
        BancoDeDados BD = new BancoDeDados();
        protected void Page_Load(object sender, EventArgs e)
        {
            Identificador = new Identificador(BD, this);

            if (!Identificador.EhAdministrador())
                Response.Redirect("login.aspx");
            
            CarregarLivros();

        }

        void CarregarLivros()
        {
            List<Livro> listaLivros = BD.Livros.ConsultarTodos();
            MainTodasFilas.Visible = true; 
            FilasRepeater.DataSource = listaLivros;
            FilasRepeater.DataBind(); 
        }
         
        protected void btnSair_Click(object sender, EventArgs e)
        {
            Identificador.Logout();
        }

    }
}
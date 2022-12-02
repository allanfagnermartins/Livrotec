using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace LivrotecTCC
{
	
	public partial class editarUsuario : System.Web.UI.Page
	{
        public string Email;
        BancoDeDados BD = new BancoDeDados();
        protected void Page_Load(object sender, EventArgs e)
		{
            HttpCookie cookie = Request.Cookies["loginUsuario"];

            if (cookie == null)
            {
                dropdown.Visible = false;
            }

            if (cookie == null)
                Response.Redirect("login.aspx");

            Email = cookie["Email"];
            dropdown.Visible = true;


            cookie.HttpOnly = true;
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["loginUsuario"] != null)
            {
                Response.Cookies["loginUsuario"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Redirect("index.aspx");
        }

        protected void btnSelecionarUsuario_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                if (BD.Usuarios.VerificarUsuario(txtEmail.Text))
                {
                    EditarUsuario();
                }
                else
                {
                    txtEmail.Text = "";
                    erro.Text = "";
                    erro.Text = "Não existe usuário cadastrado nesse e-mail";
                }
            }
            else
            {
                txtEmail.Text = "";
                erro.Text = "";
                erro.Text = "Preencha todos os campos";
            }
        }

        void EditarUsuario ()
        {
           
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}
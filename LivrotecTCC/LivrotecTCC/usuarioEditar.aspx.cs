using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace LivrotecTCC
{
    public partial class usuarioEditar : System.Web.UI.Page
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

            litEmail.Visible = true;
            litEmail.Text = "Email";
            btnEditarUsuario.Visible = false;
            txtEmailAlterar.Visible = false;
            litNome.Visible = false;
            litNome.Text = "Novo Nome";
            txtNome.Visible = false;
            litCPF.Visible = false;
            litCPF.Text = "Novo CPF";
            txtCPF.Visible = false;
            litTelefone.Visible = false;
            litTelefone.Text = "Novo Telefone";
            txtTelefone.Visible = false;
            litSenha.Visible = false;
            litSenha.Text = "Nova Senha";
            txtSenha.Visible = false;

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
                    string emailUsuario = txtEmail.Text;
                    EditarUsuario();
                    erro.Text = "";
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

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        void EditarUsuario()
        {
            btnSelecionarUsuario.Visible = false;
            litEmail.Text = "Novo Email";
            txtEmailAlterar.Visible = true;
            txtEmail.Visible = false;
            btnEditarUsuario.Visible = true;
            litEmail.Visible = true;
            litNome.Visible = true;
            txtNome.Visible = true;
            litCPF.Visible = true;
            txtCPF.Visible = true;
            litTelefone.Visible = true;
            txtTelefone.Visible = true;
            litSenha.Visible = true;
            txtSenha.Visible = true;
        }

    }
}
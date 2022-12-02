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
        public string emailUsuario;
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

            txtCPF.Attributes.Add("onkeypress", "if (event.keyCode < 48 || event.keyCode > 57) {event.keyCode = 0;}");
            txtTelefone.Attributes.Add("onkeypress", "if (event.keyCode < 48 || event.keyCode > 57) {event.keyCode = 0;}");


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
                    emailVerificado();
                    erro.Text = "";
                }
                else
                {
                    txtEmail.Text = "";
                    erro.Text = "";
                    erro.Text = "Não existe um usuário cadastrado nesse e-mail";
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
            if (txtNome.Text.Length > 150 && txtNome.Text != "" )
            {
                erro.Text = "";
                erro.Text = "O nome atingiu o máximo de caracteres";
                emailVerificado();
                return;
            }

            if (txtSenha.Text.Length > 64 && txtSenha.Text != "")
            {
                erro.Text = "";
                erro.Text = "A senha atingiu o máximo de caracteres";
                emailVerificado();
                return;
            }

            if (txtTelefone.Text.Length != 20 && txtTelefone.Text != "")
            {
                erro.Text = "";
                erro.Text = "Digite um número de telefone válido";
                emailVerificado();
                return;
            }

            if (txtCPF.Text.Length != 20 && txtCPF.Text != "")
            {
                erro.Text = "";
                erro.Text = "Digite um CPF válido";
                emailVerificado();
                return;
            }

            if(txtCPF.Text == ""  && txtSenha.Text == "" && txtTelefone.Text =="" && txtNome.Text == "" )
            {
                erro.Text = "Preencha algum campo para fazer uma alteração";
            }
            else
            {
                editarUsuario();
            }

            emailVerificado();

        }

        void emailVerificado()
        {
            btnSelecionarUsuario.Visible = false;
            litEmail.Visible = false;
            txtEmail.Visible = false;
            btnEditarUsuario.Visible = true;
            litNome.Visible = true;
            txtNome.Visible = true;
            litCPF.Visible = true;
            txtCPF.Visible = true;
            litTelefone.Visible = true;
            txtTelefone.Visible = true;
            litSenha.Visible = true;
            txtSenha.Visible = true;
        }

        void editarUsuario()
        {
            emailUsuario = txtEmail.Text;
            string telefone = txtTelefone.Text.Trim(' ');
            string nome = txtNome.Text;
            string cpf = txtCPF.Text.Trim(' ');
            string senha = txtSenha.Text;

            if (txtTelefone.Text == "")
            {
                telefone = null;
            }
            if (txtNome.Text == "")
            {
                nome = null;
            }
            if (txtCPF.Text == "")
            {
                cpf = null;
            }
            if (txtSenha.Text == "")
            {
                senha = null;
            }
            BD.Usuarios.EditarUsuario(emailUsuario, senha, nome, telefone, cpf);
            Response.Redirect("adminUsuario.aspx");
        }

    }
}
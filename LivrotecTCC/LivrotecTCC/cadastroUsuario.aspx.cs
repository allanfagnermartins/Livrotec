using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace LivrotecTCC
{
    public partial class cadastroUsuario : System.Web.UI.Page
    {
        BancoDeDados BD = new BancoDeDados();

        Identificador Identificador;
        protected void Page_Load(object sender, EventArgs e)
        {
            Identificador = new Identificador(BD, this);
            if (!Identificador.EhAdministrador())
                Response.Redirect("login.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (BD.Usuarios.validarEmail(Email.Text)==1)
            {
                Email.Text = "";
                erro.Text = "Email duplicado. Digite outro.";
                return;
            }
            if (Email.Text.Length > 200)
            {
                erro.Text = "Email inválido. Máximo 200 caracteres.";
                return;
            }
            if (Nome.Text.Length > 150)
            {
                erro.Text = "Nome inválido. Máximo 200 caracteres.";
                return;
            }
            if (Telefone.Text.Length > 20)
            {
                erro.Text = "Senha inválida. Máximo 64 caracteres.";
                return;
            }
            if (CPF.Text.Length > 20)
            {
                erro.Text = "Senha inválida. Máximo 64 caracteres.";
                return;
            }
            if (Email.Text != "" && Nome.Text != "" && Telefone.Text != "" && CPF.Text !="")
            {
            BD.Usuarios.CriarUsuario(Email.Text, Senha.Text, Nome.Text, Telefone.Text, CPF.Text);
            Email.Text = "";
            Nome.Text = "";
            Telefone.Text = "";
            CPF.Text = "";
            }
        }
    }
}
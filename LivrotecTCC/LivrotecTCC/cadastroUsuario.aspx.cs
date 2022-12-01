using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LivrotecTCC
{
    public partial class cadastroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
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

        }
    }
}
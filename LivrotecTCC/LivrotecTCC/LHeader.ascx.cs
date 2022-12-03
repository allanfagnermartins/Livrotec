using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LivrotecTCC
{
    public partial class LHeader : UserControl
    {
        public string Email => Identificador.Email;
        public bool MostrarLogin = false;
        Identificador Identificador { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var BD = new BancoDeDados();
            Identificador = new Identificador(BD, Page);
            MostrarLogin = !Identificador.LoginValido();
            AreaLogin.Visible = MostrarLogin;
            icone.Visible = !MostrarLogin;
            btnSair.Visible = !MostrarLogin;

        }
        protected void btnSair_Click(object sender, EventArgs e)
        {
            Identificador.Logout();
        }
    }
}
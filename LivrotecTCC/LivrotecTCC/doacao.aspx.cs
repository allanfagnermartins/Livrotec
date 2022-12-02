using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace LivrotecTCC
{
    public partial class doacao : System.Web.UI.Page
    {
        BancoDeDados BD = new BancoDeDados();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            checarISBNdoacao();
        }
        public bool ValidarCampos()
        {
            if (ISBN.Text == "" || Nome.Text == "" || Sinopse.Text == "" || fileUp.PostedFile == null)
            {
                erro.Text = "Preencha todos os campos!";
                return false;
            }
            if (ISBN.Text.Length > 10)
            {
                erro.Text = "ISBN inválido. Máximo 10 caracteres.";
                return false;
            }
            if (Nome.Text.Length > 100)
            {
                erro.Text = "Nome inválido. Máximo 100 caracteres.";
                return false;
            }
            if (Sinopse.Text.Length > 2000)
            {
                erro.Text = "Sinopse inválido. Máximo 2000 caracteres.";
                return false;
            }
            string TipoArq = fileUp.PostedFile.ContentType;
            if (TipoArq != "image/jpeg")
            {
                erro.Text = "Arquivo não permitido! Somente Jpeg.";
                return false;
            }
            return true;
        }
        void checarISBNdoacao()
        {
            if (BD.Livros.consultarISBNDoacao(ISBN.Text) != null)
            {
                BD.Livros.ConfirmarDoacaoLivroExistente(ISBN.Text);
                Nome.Visible = false;
                Sinopse.Visible = false;
                fileUp.Visible = false;
                ISBN.Text = "";
                Nome.Text = "";
                Sinopse.Text = "";
                litNome.Text = "";
                litSinopse.Text = "";
                litFotoCapa.Text = "";
                erro.Text = "";
            }
            else
            {
                Nome.Visible = true;
                Sinopse.Visible = true;
                fileUp.Visible = true;
                litNome.Text = "Nome Livro";
                litFotoCapa.Text = "Foto da Capa";
                litSinopse.Text = "Sinopse";
                if (ValidarCampos())
                {
                    string NomeArq = Path.GetFileName(fileUp.PostedFile.FileName);
                    BD.Livros.confirmarDoacaoLivroNovo(ISBN.Text, Nome.Text, Sinopse.Text, Nome.Text.Replace(" ", ""));
                    fileUp.PostedFile.SaveAs(Request.PhysicalApplicationPath + @"imagens\" + Nome.Text.Replace(" ", "") + ".jpg");
                    Nome.CssClass = "form-contrl filtroLogin invisivel";
                    Sinopse.CssClass = "form-contrl filtroLogin invisivel";
                    fileUp.CssClass = "invisivel";
                    ISBN.Text = "";
                    Nome.Text = "";
                    Sinopse.Text = "";
                    litNome.Text = "";
                    litSinopse.Text = "";
                    litFotoCapa.Text = "";
                    erro.Text = "";
                }
            }
        }

    }
}
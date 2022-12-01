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

        void checarISBNdoacao()
        {
            if (BD.Livros.consultarISBNDoacao(ISBN.Text) != null)
            {
                BD.Livros.ConfirmarDoacaoLivroExistente(ISBN.Text);
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
            else
            {
                Nome.CssClass = "form-contrl filtroLogin";
                Sinopse.CssClass = "form-contrl filtroLogin";
                litNome.Text = "Nome Livro";
                litFotoCapa.Text = "Foto da Capa";
                litSinopse.Text = "Sinopse";
                fileUp.CssClass = "nada";
                if (ISBN.Text != "" && Nome.Text != "" && Sinopse.Text != "" && fileUp.PostedFile != null)
                {
                    string TipoArq = fileUp.PostedFile.ContentType;
                    if (TipoArq != "image/jpeg")
                    {
                        erro.Text = "Arquivo não permitido! Somente Jpeg.";
                        return;
                    }
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
                else {
                    erro.Text = "Preencha todos os campos!";
                }
            }
        }

    }
}
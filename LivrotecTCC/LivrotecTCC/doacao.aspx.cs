using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;

namespace LivrotecTCC
{
    public partial class doacao : System.Web.UI.Page
    {
        BancoDeDados BD = new BancoDeDados();
        Livro livro;
        Identificador Identificador;
        protected void Page_Load(object sender, EventArgs e)
        {
            Identificador = new Identificador(BD, this);
            if (!Identificador.EhAdministrador())
                Response.Redirect("login.aspx");
            secNome.Visible = false;
            secImagem.Visible = false;
            secCapa.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Salvar();
        }
        public string ValidarCampos(Livro livro)
        {
            if (livro.ISBN == "" || livro.Nome == "" || livro.Sinopse == "" || fileUp.PostedFile == null)
                return "Preencha todos os campos!";    
            if (livro.ISBN.Length > 10)
                return "ISBN inválido. Máximo 10 caracteres.";
            if (livro.Nome.Length > 100)
                return "Nome inválido. Máximo 100 caracteres.";
            if (livro.Sinopse.Length > 2000)
                return "Sinopse inválido. Máximo 2000 caracteres.";
            string TipoArq = fileUp.PostedFile.ContentType;
            if (TipoArq != "image/jpeg")
                return "Arquivo não permitido! Somente Jpeg.";
            
            return null;
        }
        void Salvar()
        {
            livro = new Livro(TxtISBN.Text, TxtNome.Text, 0,TxtISBN.Text, TxtSinopse.Text ) ;
            
            var JaTemLivro = BD.Livros.consultarISBNDoacao(livro.ISBN) != null;

            secNome.Visible = !JaTemLivro;
            secImagem.Visible = !JaTemLivro;
            secCapa.Visible = !JaTemLivro;

            if (JaTemLivro)
                BD.Livros.ConfirmarDoacaoLivroExistente(livro.ISBN);
            else
            { 
                var erro = ValidarCampos(livro);
                if (erro != null)
                {
                    txtErro.Text = erro;
                    return;
                }
                string NomeArq = Path.GetFileName(fileUp.PostedFile.FileName);
                BD.Livros.confirmarDoacaoLivroNovo(livro.ISBN, livro.Nome, livro.Sinopse, livro.ISBN);
                fileUp.PostedFile.SaveAs($@"{Request.PhysicalApplicationPath }imagens\{livro.ISBN}.jpg");
            }
        }

    }
}
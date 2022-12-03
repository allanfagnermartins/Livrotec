using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LivrotecTCC
{
    public partial class editarlivro : System.Web.UI.Page
    {
        public string Email => Identificador.Email;
        public Livro livro;
        BancoDeDados BD = new BancoDeDados();
        Identificador Identificador;
        public string ISBN;
        string Nome ;
        string Sinopse ;
        int Quantidade ;
        protected void Page_Load(object sender, EventArgs e)
        {
            Identificador = new Identificador(BD, this);
            if (!Identificador.EhAdministrador())
                Response.Redirect("login.aspx");
            ISBN = Request["cd"];
            
            if (BD.Livros.consultarISBNDoacao(ISBN) == null)
                Response.Redirect("livrosadmin.aspx");
            if (!IsPostBack)
            {
                var livro = BD.Livros.Consultar(ISBN);
                TxtNome.Text = livro.Nome;
                TxtSinopse.Text = livro.Sinopse;
                TxtQuantidade.Text = livro.Quantidade.ToString();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Salvar();
        }
        public string ValidarCampos()
        {
            Nome = TxtNome.Text;
            Sinopse = TxtSinopse.Text;
            var strQuantidade = TxtQuantidade.Text;
            if ( Nome == "" || Sinopse == "" || strQuantidade == "" || fileUp.PostedFile == null)
                return "Preencha todos os campos!";
            if (ISBN.Length > 10)
                return "ISBN inválido. Máximo 10 caracteres.";
            if (Nome.Length > 100)
                return "Nome inválido. Máximo 100 caracteres.";
            if (Sinopse.Length > 2000)
                return "Sinopse inválido. Máximo 2000 caracteres.";

            if(!int.TryParse(strQuantidade, out Quantidade))
                return "Insira um numero valido";
            if (Quantidade <= 0)
                return "Insira um valor maior que zero";
            if (fileUp.HasFile)
            {
                string TipoArq = fileUp.PostedFile.ContentType;
                if (TipoArq != "image/jpeg")
                    return "Arquivo não permitido! Somente Jpeg.";
            }

            return null;
        }
        void Salvar()
        {
            var erro = ValidarCampos();
            if (erro != null)
            {
                txtErro.Text = erro;
                return;
            }
            var novoLivro = new Livro(ISBN, Nome, Quantidade, ISBN, Sinopse);
            BD.Livros.Editar(novoLivro);
            if(fileUp.HasFile)
                fileUp.PostedFile.SaveAs($@"{Request.PhysicalApplicationPath}imagens\{novoLivro.ISBN}.jpg");
            Response.Redirect($"livroadmin.aspx?cd={ISBN}");
        }
        protected void btnSair_Click(object sender, EventArgs e)
        {
            Identificador.Logout();
        }
    }
}
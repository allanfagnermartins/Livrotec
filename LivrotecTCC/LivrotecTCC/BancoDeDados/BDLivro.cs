using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using GerenciadorBD;

namespace LivrotecTCC
{
	class BDLivro : GerenciadorBancoDeDados
	{
		public BDLivro(MySqlConnection connection) : base(connection)
		{
		}


		public static Livro LinhaToLivro(Linha linha)
		{
			return new Livro(
				(string)linha.Get("nm_isbn"),
				(string)linha.Get("nm_livro"),
				(int)linha.Get("qt_livro"),
				(string)linha.Get("nm_caminho_foto_livro"),
				(string)linha.Get("ds_sinopse_livro")
			);
		}

		public Livro Consultar(string isbn)
		{
			return LinhaToLivro(LerProcLinha("infoLivros", ("vISBN", isbn)));
		}

        public List<Livro> ConsultarTodos()
        {
            List<Linha> Linhas = LerProcTabela("listarLivros");
            List<Livro> Lista = Linhas.Select((linha) => LinhaToLivro(linha)).ToList(); 
            return Lista;
        }

		public List<Livro> ConsultarMeus(string email)
        {
			List<Linha> Linhas = LerProcTabela("listarLivrosPessoa", ("vEmail", email));
			List<Livro> Lista = Linhas.Select((linha)=>LinhaToLivro(linha)).ToList();
			return Lista;
        }

		public List<Livro> ConsultarNaoMeus(string email)
		{
			List<Linha> Linhas = LerProcTabela("listarLivrosNaoPessoa", ("vEmail", email));
			List<Livro> Lista = Linhas.Select((linha) => LinhaToLivro(linha)).ToList();
			return Lista;
		}

		public string consultarISBNDoacao(string isbn){
			return (string)LerProcValorUnico("infoLivros", ("vISBN", isbn));
		}

		public void ConfirmarDoacaoLivroExistente(string isbn)
		{
			ExecutarProc("confirmarDoacaoLivroExistente", ("vISBN", isbn));
		}

		public void confirmarDoacaoLivroNovo(string isbn, string nome, string sinopse, string caminho)
		{
			ExecutarProc("confirmarDoacaoLivroNovo", ("vISBN", isbn), ("vNome", nome), ("vSinopse", sinopse), ("vCaminho", caminho));
		}
		public void Editar(Livro livro)
		{
			ExecutarProc("editarLivro",
				("vISBN", livro.ISBN),
				("vNome", livro.Nome),
				("vSinopse", livro.Sinopse),
				("vQuantidade", livro.Quantidade),
				("vCaminho", livro.Caminho)
			);
		}
	}
}


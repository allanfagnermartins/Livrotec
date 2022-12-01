using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using GerenciadorBD;
using System.Collections.Generic;

namespace LivrotecTCC
{
    class BDEmprestimo : GerenciadorBancoDeDados
    {
        public BDEmprestimo(MySqlConnection connection) : base(connection)
        {
        }

		public static Emprestimo LinhaToEmprestimo(Linha linha)
		{
			return new Emprestimo(
				(int)linha.Get("cd_emprestimo"),
				(string)linha.Get("nm_isbn"),
				(string)linha.Get("nm_email_usuario"),
				(string)linha.Get("dt_emprestimo").ToString(),
				(string)linha.Get("dt_devolucao_prevista_emprestimo").ToString(),
				(string)linha.Get("dt_devolucao_efetiva_emprestimo").ToString(),
				(bool)linha.Get("ic_roubado")
			);
		}
		public List<Emprestimo> ConsultarTodos()
		{
			List<Linha> Linhas = LerProcTabela("listarEmprestimos");
			List<Emprestimo> Lista = Linhas.Select((linha) => LinhaToEmprestimo(linha)).ToList();
			return Lista;
		}

		public Emprestimo Consultar(string codigo)
		{
			return LinhaToEmprestimo(LerProcLinha("infoEmprestimo", ("vCodigo", codigo)));
		}

		public void ConfirmarDevolucao(string codigo)
		{
				ExecutarProc("confirmarDevolucao",("vCodigo", codigo));
		}

		public void EmprestimoRoubado(int codigo)
        {
			ExecutarProc("emprestimoRoubado", ("vCodigo", codigo));
        }

		public void CancelarEmprestimo(int codigo)
		{
			ExecutarProc("cancelarEmprestimo", ("vCodigo", codigo));
		}

		public void ConfirmarEmprestimo(int codigo)
		{
			ExecutarProc("ConfirmarEmprestimo", ("vCodigo", codigo));
		}

		public bool ChecarEmprestimo(string email)
		{
			long emprestimo = (long)LerProcValorUnico("icEmprestimoPessoa", ("vEmail", email));
			return emprestimo == 1;
		}

		public bool ChecarEmprestimoLivro(string email, string isbn)
        {
			long emprestimo = (long)LerProcValorUnico("icEmprestimoLivro", ("vEmail", email), ("vISBN", isbn));
			return emprestimo == 1;
		}

		public bool ConsultarEmprestimoEmail(string isbn, string email)
        {
			long esseEmprestimo = (long)LerProcValorUnico("infoEmprestimoSemCodigo", ("vISBN", isbn), ("vEmail", email));
			return esseEmprestimo == 1;
        }

		public int? CodigoEmprestimo(string email, string isbn)
        {
			int? codigo = (int?)LerProcValorUnico("codigoEmprestimo", ("vEmail", email), ("vISBN", isbn));
			return codigo;
		}

		public long DiasRestantes(string codigo)
		{
			var a = LerProcValorUnico("calcDataEmprestimo", ("vCodigo", codigo));

			long dias = (long)a;
			return dias;
		}

		public bool ConsultarRoubos(string email)
		{
			long roubado = (long)LerProcValorUnico("icRoubadosPessoa", ("vEmail", email));
			return roubado == 1;
		}

		public bool ChecarEmprestimoConfirmado(string codigo)
        {
			long confirmado = (long)LerProcValorUnico("icConfirmado", ("vCodigo", codigo));
			return confirmado == 1;
		}

	}
}
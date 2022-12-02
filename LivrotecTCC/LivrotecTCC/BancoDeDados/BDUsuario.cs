using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using GerenciadorBD;
using System.Collections.Generic;

namespace LivrotecTCC
{

    public class BDUsuario : GerenciadorBancoDeDados
	{
		public BDUsuario(MySqlConnection connection) : base(connection)
		{
		}


		public static Usuario LinhaToPessoa(Linha linha)
		{
			return new Usuario(
				(string)linha.Get("nm_email_usuario"),
				(string)linha.Get("cd_tipo_usuario"),
				(string)linha.Get("nm_usuario"),
				(string)linha.Get("nm_telefone_usuario"),
				(string)linha.Get("nm_cpf_usuario")
			);
		}

		public bool LoginValido(string Email, string Senha)
		{
			long Valido = (long)LerProcValorUnico("LoginValido", ("vEmail", Email), ("vSenha", Senha));
			return Valido == 1;
		}

		public bool VerificarAdmin(string Email)
		{
			long Admin = (long)LerProcValorUnico("VerificarAdmin", ("vEmail", Email));
			return Admin == 1;
		}

		public long ContarFilaPessoa(string Email)
		{
			long Fila = (long)LerProcValorUnico("ContarFilaPessoa", ("vEmail", Email));
			return Fila;
		}

		public void CriarUsuario(string email, string senha, string nome, string telefone, string cpf)
		{
			ExecutarProc("criarUsuario", ("vEmail", email), ("vSenha", senha), ("vNome", nome), ("vTelefone", telefone), ("vCPF", cpf));
		}

		public bool VerificarUsuario(string Email)
        {
			long usuario = (long)LerProcValorUnico("consultarEmail", ("vEmail", Email));
			return usuario == 1;
		}

		public void EditarUsuario(string email, string senha, string nome, string telefone, string cpf)
        {
			ExecutarProc("editarUsuario", ("vEmail", email), ("vNovaSenha", senha), ("vNovoNome", nome), ("vNovoTelefone", telefone), ("vNovoCPF", cpf));
        }

	}
}

 
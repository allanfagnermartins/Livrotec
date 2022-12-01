
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GerenciadorBD
{



	public class GerenciadorBancoDeDados
	{


		protected GerenciadorBancoDeDados(MySqlConnection connection)
		{
			Conn = connection;
		}

		protected  MySqlConnection Conn { get; set; }


		public void Abrir()
		{
			try
			{
				if (Conn.State != ConnectionState.Open)
					Conn.Open();
			}

			catch (Exception ex)
			{
				throw new BDException("Erro na abertura do banco de dados", ex);
			}
		}
		public void Fechar() {
			if (Conn != null && Conn.State == ConnectionState.Open)
			{
				try
				{
					Conn.Close();
				}
				catch (Exception ex)
				{
					throw new BDException("Erro no fechamento do banco de dados", ex);
				}
			}
		}

		protected MySqlCommand CriaChamadaProcedure(string procedure , params (string nome,object valor)[] parametros)
        {
			var cSQL= new MySqlCommand(procedure, Conn);
			cSQL.CommandType = CommandType.StoredProcedure;
			if (parametros != null)
				foreach (var parametro in parametros)
					cSQL.Parameters.AddWithValue(parametro.nome, parametro.valor);
			return cSQL;
        }
		

		protected MySqlDataReader ConsultarProcedure(string procedure, params (string nome, object valor)[] parametros)
        {
			return CriaChamadaProcedure(procedure, parametros).ExecuteReader();
        }


		static protected List<Linha> ReaderToTabela(MySqlDataReader reader) {
			var linhas = new List<Linha>();
			while (reader.Read()) {
				var linha = new Linha();
				for (int i = 0; i < reader.FieldCount; i++)
					linha.AdicionarColuna(reader.GetName(i), reader[i]);
				linhas.Add(linha);
			};
			reader.Close();
			return linhas;
		}
		static protected Linha ReaderToLinha(MySqlDataReader reader) {
			Linha linha = null;
			if (reader.Read())
            { 
				linha = new Linha();
				for (int i = 0; i < reader.FieldCount; i++)
					linha.AdicionarColuna(reader.GetName(i), reader[i]);
            }
			reader.Close();
			return linha;
		}

 
		protected void ExecutarProc(string procedure , params (string nome,object valor)[] parametros)
        {
			Abrir();
			CriaChamadaProcedure(procedure, parametros).ExecuteNonQuery();
			Fechar();
        }
		protected List<Linha> LerProcTabela(string procedure , params (string nome,object valor)[] parametros)
		{
			try {
				Abrir();
				return  ReaderToTabela(ConsultarProcedure(procedure, parametros));
			}
			finally {
				Fechar();
			}
		}
		protected Linha LerProcLinha(string procedure , params (string nome,object valor)[] parametros)
		{
			try {
				Abrir();
				return ReaderToLinha(ConsultarProcedure(procedure, parametros));
			}
			finally {
				Fechar();
			}
		}
		protected object LerProcValorUnico(string procedure , params (string nome,object valor)[] parametros)
		{
			try {
				Abrir();
				return CriaChamadaProcedure(procedure, parametros).ExecuteScalar();
			}
			finally {
				Fechar();
			}
		}

    }

}


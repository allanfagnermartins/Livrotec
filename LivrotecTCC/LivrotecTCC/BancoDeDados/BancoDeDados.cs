using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GerenciadorBD;

namespace LivrotecTCC
{
    class BancoDeDados : GerenciadorBancoDeDados
    {
        public const string linhaConexao = "server=localhost;database=scriptLivrotec;uid=root;pwd=root";

        public BancoDeDados() : base(NovaConexao())
        {
            Usuarios = new BDUsuario(Conn);
            Livros = new BDLivro(Conn);
            Filas = new BDFila(Conn);
            Emprestimos = new BDEmprestimo(Conn);
        }
        public BDUsuario Usuarios { get; private set; }
        public BDLivro Livros { get; private set; } 
        public BDFila Filas { get; private set; }
        public BDEmprestimo Emprestimos{ get; private set; }
        public static MySqlConnection NovaConexao()
        {
            return new MySqlConnection(linhaConexao);

        }
        public static BDUsuario NovoBDUsuario()
        {
            return new BDUsuario(new MySqlConnection(linhaConexao));
        }
        public static BDLivro NovoBDLivro()
        {
            return new BDLivro(new MySqlConnection(linhaConexao));
        }
        public static BDLivro NovoBDFila()
        {
            return new BDLivro(new MySqlConnection(linhaConexao));
        }
        public static BDEmprestimo NovoBDEmprestimo()
        {
            return new BDEmprestimo(new MySqlConnection(linhaConexao));
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LivrotecTCC
{
    class Emprestimo
    {
        public int Codigo { get; set; }

        public string ISBN { get; set; }

        public string Email { get; set; }

        public string DataEmprestimo { get; set; }

        public string DataDevolucaoPrevista { get; set; }

        public string DataDevolucaoEfetiva { get; set; }

        public bool Roubado { get; set; }

        public Emprestimo()
        {
        }

        public Emprestimo(int codigo, string isbn, string email, string dataEmprestimo, string dataDevolucaoPrevista, string dataDevolucaoEfetiva, bool roubado)
        {
            this.Codigo = codigo;
            this.ISBN = isbn;
            this.Email = email;
            this.DataEmprestimo = dataEmprestimo;
            this.DataDevolucaoPrevista = dataDevolucaoPrevista;
            this.DataDevolucaoEfetiva = dataDevolucaoEfetiva;
            this.Roubado = roubado;
        }

    }

}
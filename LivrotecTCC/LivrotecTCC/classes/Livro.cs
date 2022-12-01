using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace LivrotecTCC
{
    class Livro
    {
        public string ISBN { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public string Caminho { get; set; }

        public string Sinopse { get; set; }

        public string MaxFila { get; set; }

        public Livro()
        {

        }

        public Livro(string isbn, string nome)
        {
            this.ISBN = isbn;
            this.Nome = nome;
        }

        public Livro(string isbn, string nome, int quantidade, string caminho, string sinopse)
        {
            this.ISBN = isbn;
            this.Nome = nome;
            this.Quantidade = quantidade;
            this.Caminho = caminho;
            this.Sinopse = sinopse;
        }
    }
}
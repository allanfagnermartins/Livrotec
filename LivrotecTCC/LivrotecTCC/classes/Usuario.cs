using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LivrotecTCC
{

    public class Usuario 
    {
        public string Email { get; set; }
        public string TipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }

        public Usuario()
        { }

        public Usuario(string email, string tipoUsuario, string nome, string tel, string cpf)
        {
            this.Email = email;
            this.TipoUsuario = tipoUsuario;
            this.Nome = nome;
            this.Telefone = tel;
            this.CPF = cpf;
        }

    

   


    }
}
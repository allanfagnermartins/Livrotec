using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using GerenciadorBD;
using System.Collections.Generic;

namespace LivrotecTCC
{
	class BDFila : GerenciadorBancoDeDados
	{
		public BDFila(MySqlConnection connection) : base(connection)
		{
		}

  
     	public int? Posicao(string usuario, string isbn)
        {
            Linha linha = LerProcLinha("checarFilaPessoa", ("vEmail", usuario), ("vISBN", isbn));
            if (linha == null)
                return null;
            return (int?)linha["cd_lugar_fila"];
        }

		public string Tamanho(string isbn)
        {
            long? tamanho = (long?)LerProcValorUnico("contarFila", ("vISBN", isbn));
            if(tamanho == 0 || tamanho is null)
            {
                return "Não existem pessoas nessa fila.";
            }
            else 
            {
            if (tamanho == 1)
            {
                return "Existe " + tamanho.ToString() + " pessoa nessa fila";
            }
            else
            {
                return "Existem " + tamanho.ToString() + " pessoas nessa fila";
            }
            }
        }
        public EstadoUsuarioFila EstadoUsuario(string email, string isbn){            
            Linha linha = LerProcLinha("VerificarUsuarioFila",("vEmail", email), ("vISBN", isbn));
            return new EstadoUsuarioFila( (bool)linha["ComLivro"], (bool)linha["InscritoFila"]);
        }
        
        public void Entrar(string usuario, string isbn)
        {
            ExecutarProc("inserirFilaPessoa", ("vEmail", usuario), ("vISBN", isbn));
        }

        public void Sair(string usuario, string isbn)
        {
            ExecutarProc("deletarFilaPessoa", ("vEmail", usuario), ("vISBN", isbn));
        }

    }
}
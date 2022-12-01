using System.Collections.Generic;

namespace GerenciadorBD
{

	//Chave Valor
	public class CV {
        public string Coluna;
        public object Valor;

		public CV(string chave, object valor)
		{
			Coluna = chave;
			Valor = valor;
		}
	}





	public class Linha 
	{
		public List<CV> ChavesValores;
		public List<string> Chaves {
			get{
				var chaves = new List<string>();
				foreach (var CV in ChavesValores)
					chaves.Add(CV.Coluna);
				return chaves;
			}	
		}
		public List<object> Valores {
			get{
				var Valores = new List<object>();
				foreach (var CV in ChavesValores)
					Valores.Add(CV.Valor);
				return Valores;
			}	
		}

		public Linha(CV[] colunas)
		{
			ChavesValores = new List<CV>(colunas);
		}
		public Linha()
		{
			ChavesValores = new List<CV>();
		}
		public Linha(string[] chaves, object[] valores)
		{
			ChavesValores = new List<CV>();
			for (int i = 0; i < chaves.Length; i++)
				ChavesValores.Add(new CV(chaves[i], valores[i]));

		}
		public object this[string chave]
        {
            get
            {
				return Get(chave);
            }
        }

		public object Get(string chave)
		{
			foreach (var c in ChavesValores)
				if (c.Coluna == chave)
					return c.Valor;

			throw new KeyNotFoundException();
		}
		public void Set(string chave, object novoValor)
		{
			foreach (var c in ChavesValores)
			{
				if (c.Coluna == chave)
				{
					c.Valor = novoValor;
					return;
				}
			}
			throw new KeyNotFoundException();
		}
		public void AdicionarColuna(string coluna, object valor)
		{
			ChavesValores.Add(new CV(coluna, valor));
		}
	}
}

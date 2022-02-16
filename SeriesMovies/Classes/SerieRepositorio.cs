using System.Text.Json;

using SeriesMovies.Interface;

namespace SeriesMovies
{
	public class SerieRepositorio : IRepositorio<Serie>
	{
		private List<Serie> lista = new List<Serie>();
		private string caminho = Path.Join("Dados", "series.txt");
		public void Atualiza(int id, Serie entidade)
		{
			lista[id] = entidade;
		}

		public void Exclui(int id)
		{
			lista[id].Excluir();
		}

		public void Insere(Serie entidade)
		{
			lista.Add(entidade);
			SalvaArquivo();
		}

		public void LeArquivo()
		{
			using (StreamReader arquivo = File.OpenText(caminho))
			{
				string linha;
				while ((linha = arquivo.ReadLine()) != null)
				{
					Console.WriteLine(linha);
				}
			}
		}

		public List<Serie> Lista()
		{
			return lista;
		}

		public int ProximoId()
		{
			return lista.Count();
		}

		public Serie RetornaPorId(int id)
		{
			return lista[id];
		}

		public void SalvaArquivo()
		{
			string linha = "";
			using (StreamWriter arquivo = File.CreateText(caminho))
			{
				foreach (Serie item in lista)
				{
					// linha = JsonSerializer.Serialize(item);
					// Console.WriteLine(item);
					Console.WriteLine(item.toJSON());
					// arquivo.WriteLine(linha);
				}
			}
		}
	}
}
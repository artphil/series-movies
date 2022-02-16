using System.IO;
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
			SalvaArquivo();
		}

		public void Exclui(int id)
		{
			lista[id].Excluir();
			SalvaArquivo();
		}

		public void Insere(Serie entidade)
		{
			lista.Add(entidade);
			SalvaArquivo();
		}

		public void adicionaTemporada(int serieID, int ano, int episodios)
		{
			int id = lista[serieID].Temporadas.Count();
			Temporada temporada = new Temporada(id, ano, episodios);
			lista[serieID].Temporadas.Add(temporada);
			SalvaArquivo();
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

		public void LeArquivo()
		{
			if (File.Exists(caminho))
			{
				using (StreamReader arquivo = File.OpenText(caminho))
				{
					string linha;
					while ((linha = arquivo.ReadLine()) != null)
					{
						lista.Add(Serie.ParseJSON(linha));
						Console.WriteLine(lista.Last());
					}
				}
			}
		}
		public void SalvaArquivo()
		{
			string linha = "";
			using (StreamWriter arquivo = File.CreateText(caminho))
			{
				foreach (Serie item in lista)
				{
					arquivo.WriteLine(item.toJSON());
				}
			}
		}
	}
}
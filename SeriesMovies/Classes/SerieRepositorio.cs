using System.IO;
using System.Text.Json;

using SeriesMovies.Interface;

namespace SeriesMovies
{
	public class SerieRepositorio : IRepositorio<Serie>
	{
		private List<Serie> lista = new List<Serie>();
		private string caminho = Path.Join("Dados", "series.txt");
		
		public void ImprimeLista()
		{
			Console.WriteLine("SÉRIES:");

			if (this.lista.Count() == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in this.lista)
			{
				if (!serie.EhExcluido())
				{
					Console.WriteLine("#ID {0}: - {1}", serie.RetornaId(), serie.RetornaTitulo());
				}
			}
		}

		public void ImprimeTemporadas(int serieID)
		{
			Console.WriteLine("TEMPORADAS:");

			var listaTemporadas = this.lista[serieID].RetornaTemporadas();

			if (listaTemporadas.Count() == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var temporada in listaTemporadas)
			{
				if (!temporada.EhExcluido())
				{
					Console.WriteLine("#ID {0}: {1}º Temporada - {2}", temporada.Id, temporada.Id + 1, temporada.Ano);
				}
			}
		}
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

		public void AdicionaTemporada(int serieID, Temporada temporada)
		{
			lista[serieID].Temporadas.Add(temporada);
			SalvaArquivo();
		}
		public List<Serie> RetornaLista()
		{
			return lista;
		}

		public int ProximoId()
		{
			return lista.Count();
		}

		public Serie RetornaPorId(int id)
		{
			return (Serie)lista[id].Clone();
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
					arquivo.WriteLine(item.ToJSON());
				}
			}
		}
	}
}
using System.IO;
using System.Text.Json;

using SeriesMovies.Interface;

namespace SeriesMovies
{
	public class SerieRepositorio : RepositorioBase<Serie>, IRepositorio<Serie>
	{
		public SerieRepositorio():	base(Path.Join("Dados", "series.json"))
		{
			LeArquivo();
		}

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
		public void ExcluiTemporada(int serieID, int temporadaID)
		{
			lista[serieID].Temporadas[temporadaID].Excluir();
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

	}
}
using System.IO;
using SeriesMovies.Interface;

namespace SeriesMovies
{
	public class TemporadaRepositorio : IRepositorio<Temporada>
	{
		private List<Temporada> lista = new List<Temporada>();

		public void Atualiza(int id, Temporada entidade)
		{
			lista[id] = entidade;
		}

		public void Exclui(int id)
		{
			lista[id].Excluir();
		}

		public void Insere(Temporada entidade)
		{
			lista.Add(entidade);
		}

		public void LeArquivo()
		{
			throw new NotImplementedException();
		}

		public List<Temporada> Lista()
		{
			return lista;
		}

		public int ProximoId()
		{
			return lista.Count();
		}

		public Temporada RetornaPorId(int id)
		{
			return lista[id];
		}

		public void SalvaArquivo()
		{
			throw new NotImplementedException();
		}

		// public string toJSON()
		// {
		// 	List<String> jsonList = new List<string>();
		// 	foreach(var item in lista)
		// 	{
		// 		jsonList.Add(item.toJSON());
		// 	}
		// 	return jsonList.ToArray();
		// }
	}
}
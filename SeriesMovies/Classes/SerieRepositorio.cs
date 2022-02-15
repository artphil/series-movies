using SeriesMovies.Interface;

namespace SeriesMovies
{
	public class SerieRepositorio : IRepositorio<Serie>
	{
		private List<Serie> lista = new List<Serie>();
		private string caminho = @"Data\series.txt";
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
		}

		public void LeArquivo()
		{
			using (FileStream fs = File.OpenRead(caminho))
			{}
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
			using (FileStream arquivo = File.OpenWrite(caminho))
			{

			}
		}
	}
}
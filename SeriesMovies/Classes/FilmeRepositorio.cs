using System.IO;
using System.Text.Json;

using SeriesMovies.Interface;

namespace SeriesMovies
{
	public class FilmeRepositorio : IRepositorio<Filme>
	{
		private List<Filme> lista = new List<Filme>();
		private string caminho = Path.Join("Dados", "filmes.txt");
		public void Atualiza(int id, Filme entidade)
		{
			lista[id] = entidade;
			SalvaArquivo();
		}

		public void Exclui(int id)
		{
			lista[id].Excluir();
			SalvaArquivo();
		}

		public void Insere(Filme entidade)
		{
			lista.Add(entidade);
			SalvaArquivo();
		}

		public void adicionaTemporada(int FilmeID, Temporada temporada)
		{
			lista[FilmeID].Temporadas.Add(temporada);
			SalvaArquivo();
		}
		public List<Filme> Lista()
		{
			return lista;
		}

		public int ProximoId()
		{
			return lista.Count();
		}

		public Filme RetornaPorId(int id)
		{
			return (Filme)lista[id].Clone();
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
						lista.Add(Filme.ParseJSON(linha));
					}
				}
			}
		}
		public void SalvaArquivo()
		{
			string linha = "";
			using (StreamWriter arquivo = File.CreateText(caminho))
			{
				foreach (Filme item in lista)
				{
					arquivo.WriteLine(item.ToJSON());
				}
			}
		}
	}
}
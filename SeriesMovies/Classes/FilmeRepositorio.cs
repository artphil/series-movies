using System.IO;
using System.Text.Json;

using SeriesMovies.Interface;

namespace SeriesMovies
{
	public class FilmeRepositorio : RepositorioBase<Filme>, IRepositorio<Filme>
	{
		public FilmeRepositorio():	base(Path.Join("Dados", "filmes.json"))
		{
			LeArquivo();
		}
		public void ImprimeLista()
		{
			Console.WriteLine("Filmes:");

			if (this.lista.Count() == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			foreach (var filme in this.lista)
			{
				if (!filme.EhExcluido())
				{
					Console.WriteLine("#ID {0}: - {1}", filme.RetornaId(), filme.RetornaTitulo());
				}
			}
		}
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

		public List<Filme> RetornaLista()
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

	}
}
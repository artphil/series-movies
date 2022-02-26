using System;
namespace SeriesMovies
{
	class Program
	{
		static SerieRepositorio series = new SerieRepositorio();
		static FilmeRepositorio filmes = new FilmeRepositorio();
		static void Main(string[] args)
		{
			series.LeArquivo();
			// filmes.LeArquivo();

			string opcaoUsuario = InterfaceUsuario.Inicio();

			while (opcaoUsuario != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarTudo();
						InterfaceUsuario.Pausa();
						break;
					case "2":
						OpcaoSeries();
						break;
					case "3":
						OpcaoFilmes();
						break;

					default:
						Console.WriteLine($"Opção '{opcaoUsuario}' invalida.");
						InterfaceUsuario.Pausa();
						break;
				}

				opcaoUsuario = InterfaceUsuario.Inicio();
			}

			InterfaceUsuario.Despedida();
		}

		private static void ListarTudo()
		{
			series.ImprimeLista();
			System.Console.WriteLine();
			filmes.ImprimeLista();
		}

		// SERIES
		private static void OpcaoSeries()
		{
			string opcaoUsuario = InterfaceUsuario.Series();

			while (opcaoUsuario != "0")
			{
				switch (opcaoUsuario)
				{
					case "1":
						series.ImprimeLista(); ;
						InterfaceUsuario.Pausa();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						InterfaceUsuario.Pausa();
						break;
					case "4":
						ExcluirSerie();
						InterfaceUsuario.Pausa();
						break;
					case "5":
						VisualizarSerie();
						InterfaceUsuario.Pausa();
						break;

					default:
						Console.WriteLine($"Opção '{opcaoUsuario}' invalida.");
						InterfaceUsuario.Pausa();
						break;
				}

				opcaoUsuario = InterfaceUsuario.Series();
			}
		}
		private static void InserirSerie()
		{
			var serie = InterfaceUsuario.InserirSerie(series.ProximoId());
			series.Insere(serie);
			bool continua = true;
			while (continua)
			{
				InserirTemporada(serie);
				continua = InterfaceUsuario.Confirma("Deseja adicionar mais Temporadas?");
			}
		}
		private static void InserirTemporada(Serie serie)
		{
			var temporada = InterfaceUsuario.InserirTemporada(serie.RetornaNumeroTemporadas());
			series.AdicionaTemporada(serie.RetornaId(), temporada);
		}

		private static void ExcluirSerie()
		{
			series.ImprimeLista(); ;
			Console.WriteLine();
			Console.Write("Digite o id da série: ");
			try
			{
				int indiceSerie = int.Parse(Console.ReadLine());
				if (indiceSerie < series.ProximoId())
				{
					series.Exclui(indiceSerie);
					Console.WriteLine($"Série removida com sucesso.");
				}
				else
				{
					Console.WriteLine($"Indice invalido.");

				}
			}
			catch (System.Exception)
			{

				Console.WriteLine($"Opção invalida.");
			}

		}

		private static void VisualizarSerie()
		{
			series.ImprimeLista(); ;
			Console.WriteLine();
			Console.Write("Digite o id da série: ");
			try
			{
				int indiceSerie = int.Parse(Console.ReadLine());
				if (indiceSerie < series.ProximoId())
				{
					var serie = series.RetornaPorId(indiceSerie);
					Console.WriteLine(serie);
				}
				else
				{
					Console.WriteLine($"Indice invalido.");

				}
			}
			catch (System.Exception)
			{

				Console.WriteLine($"Opção invalida.");
			}
		}

		private static void AtualizarSerie()
		{
			Serie serie;
			int indiceSerie;
			series.ImprimeLista(); ;
			Console.WriteLine();
			Console.Write("Digite o id da série: ");
			try
			{
				indiceSerie = int.Parse(Console.ReadLine());
				if (indiceSerie < series.ProximoId())
				{
					serie = series.RetornaPorId(indiceSerie);
					Console.WriteLine(serie);
				}
				else
				{
					Console.WriteLine($"Indice invalido.");
					return;
				}
			}
			catch (System.Exception)
			{

				Console.WriteLine($"Opção invalida.");
				return;
			}

			string opcaoSeries = InterfaceUsuario.AtualizarSerie(serie);

			while (opcaoSeries != "0")
			{
				switch (opcaoSeries)
				{
					case "1":
						serie.Titulo = InterfaceUsuario.ObterTitulo();
						break;

					case "2":
						serie.Genero = InterfaceUsuario.ObterGenero();
						break;

					case "3":
						serie.Descricao = InterfaceUsuario.ObterDescricao();
						break;

					case "4":
						AtualizarTemporada(serie);
						InterfaceUsuario.Pausa();
						break;
					case "5":
						InserirTemporada(serie);
						break;
					case "6":
						ExcluirTemporada(serie);
						InterfaceUsuario.Pausa();
						break;

					default:
						Console.WriteLine($"Opção '{opcaoSeries}' invalida.");
						InterfaceUsuario.Pausa();
						break;

				}
				opcaoSeries = InterfaceUsuario.AtualizarSerie(serie);
			}
			series.Atualiza(indiceSerie, serie);
		}
		public static void AtualizarTemporada(Serie serie)
		{

			Temporada temporada;
			int indiceTemporada;
			series.ImprimeTemporadas(serie.Id);
			Console.WriteLine();
			Console.Write("Digite o id da temporada: ");
			try
			{
				indiceTemporada = int.Parse(Console.ReadLine());
				if (indiceTemporada < serie.RetornaNumeroTemporadas())
				{
					temporada = serie.TemporadaPorId(indiceTemporada);
				}
				else
				{
					Console.WriteLine($"Indice invalido.");
					return;
				}
			}
			catch (System.Exception)
			{

				Console.WriteLine($"Opção invalida.");
				return;
			}

			string opcaoTemporadas = InterfaceUsuario.AtualizarTemporada(temporada);

			while (opcaoTemporadas != "0")
			{
				switch (opcaoTemporadas)
				{
					case "1":
						temporada.Ano = InterfaceUsuario.ObterAno();
						break;

					case "2":
						temporada.Episodios = InterfaceUsuario.ObterEpisodios();
						break;

					default:
						Console.WriteLine($"Opção '{opcaoTemporadas}' invalida.");
						InterfaceUsuario.Pausa();
						break;

				}
				opcaoTemporadas = InterfaceUsuario.AtualizarTemporada(temporada);
			}
			serie.AtualizaTemporada(indiceTemporada, temporada);
			Console.WriteLine($"Temporada atualizada com sucesso.");
		}

		private static void ExcluirTemporada(Serie serie)
		{
			series.ImprimeTemporadas(serie.Id);
			Console.WriteLine();
			Console.Write("Digite o id da temorada: ");
			try
			{
				int indiceTemporada = int.Parse(Console.ReadLine());
				if (indiceTemporada < serie.RetornaNumeroTemporadas())
				{
					series.ExcluiTemporada(serie.Id, indiceTemporada);
					Console.WriteLine($"Temporada removida com sucesso.");
				}
				else
				{
					Console.WriteLine($"Indice invalido.");
				}
			}
			catch (System.Exception)
			{

				Console.WriteLine($"Opção invalida.");
			}

		}
		// FILMES
		private static void OpcaoFilmes()
		{
			string opcaoUsuario = InterfaceUsuario.Filmes();

			while (opcaoUsuario != "0")
			{
				switch (opcaoUsuario)
				{
					case "1":
						filmes.ImprimeLista(); ;
						InterfaceUsuario.Pausa();
						break;
					case "2":
						InserirFilme();
						break;
					case "3":
						AtualizarFilme();
						InterfaceUsuario.Pausa();
						break;
					case "4":
						ExcluirFilme();
						InterfaceUsuario.Pausa();
						break;
					case "5":
						VisualizarFilme();
						InterfaceUsuario.Pausa();
						break;

					default:
						Console.WriteLine($"Opção '{opcaoUsuario}' invalida.");
						InterfaceUsuario.Pausa();
						break;
				}

				opcaoUsuario = InterfaceUsuario.Filmes();
			}
		}
		private static void InserirFilme()
		{
			var filme = InterfaceUsuario.InserirFilme(filmes.ProximoId());
			filmes.Insere(filme);
		}

		private static void ExcluirFilme()
		{
			filmes.ImprimeLista();
			Console.WriteLine();
			Console.Write("Digite o id do filme: ");
			try
			{
				int indiceFilme = int.Parse(Console.ReadLine());
				if (indiceFilme < filmes.ProximoId())
				{
					filmes.Exclui(indiceFilme);
					Console.WriteLine($"Filme removido com sucesso.");
				}
				else
				{
					Console.WriteLine($"Indice invalido.");
				}
			}
			catch (System.Exception)
			{

				Console.WriteLine($"Opção invalida.");
			}
		}

		private static void VisualizarFilme()
		{
			filmes.ImprimeLista();
			Console.WriteLine();
			Console.Write("Digite o id do filme: ");
			try
			{
				int indiceFilme = int.Parse(Console.ReadLine());
				if (indiceFilme < filmes.ProximoId())
				{
					var filme = filmes.RetornaPorId(indiceFilme);
					Console.WriteLine(filme);
				}
				else
				{
					Console.WriteLine($"Indice invalido.");
				}
			}
			catch (System.Exception)
			{

				Console.WriteLine($"Opção invalida.");
			}
		}

		private static void AtualizarFilme()
		{
			int indiceFilme;
			Filme filme;
			filmes.ImprimeLista(); ;
			Console.WriteLine();
			Console.Write("Digite o id da série: ");
			try
			{
				indiceFilme = int.Parse(Console.ReadLine());
				if (indiceFilme < filmes.ProximoId())
				{
					filme = filmes.RetornaPorId(indiceFilme);
				}
				else
				{
					Console.WriteLine($"Indice invalido.");
					return;
				}
			}
			catch (System.Exception)
			{

				Console.WriteLine($"Opção invalida.");
				return;
			}
			string opcaoFilmes = InterfaceUsuario.AtualizarFilme(filme);

			while (opcaoFilmes != "0")
			{
				switch (opcaoFilmes)
				{
					case "1":
						filme.Titulo = InterfaceUsuario.ObterTitulo();
						break;

					case "2":
						filme.Genero = InterfaceUsuario.ObterGenero();
						break;

					case "3":
						filme.Descricao = InterfaceUsuario.ObterDescricao();
						break;

					case "4":
						filme.Ano = InterfaceUsuario.ObterAno();
						break;

					default:
						Console.WriteLine($"Opção '{opcaoFilmes}' invalida.");
						InterfaceUsuario.Pausa();
						break;

				}
				opcaoFilmes = InterfaceUsuario.AtualizarFilme(filme);
			}
			filmes.Atualiza(indiceFilme, filme);
			Console.WriteLine($"Filme atualizado com sucesso.");
		}
	}
}
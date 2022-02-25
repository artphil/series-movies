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
						break;
					case "4":
						ExcluirSerie();
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
			int indiceSerie = int.Parse(Console.ReadLine());

			series.Exclui(indiceSerie);
		}

		private static void VisualizarSerie()
		{
			series.ImprimeLista(); ;
			Console.WriteLine();
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = series.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

		private static void AtualizarSerie()
		{
			series.ImprimeLista(); ;
			Console.WriteLine();
			Console.Write("Digite o id da série: ");
			int serieID = int.Parse(Console.ReadLine());
			Serie serie = series.RetornaPorId(serieID);
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
						break;
					case "5":
						InserirTemporada(serie);
						break;
					case "6":
						ExcluirTemporada(serie);
						break;

					default:
						Console.WriteLine($"Opção '{opcaoSeries}' invalida.");
						InterfaceUsuario.Pausa();
						break;

				}
				opcaoSeries = InterfaceUsuario.AtualizarSerie(serie);
			}
			series.Atualiza(serieID, serie);
		}
		public static void AtualizarTemporada(Serie serie)
		{

			series.ImprimeTemporadas(serie.Id);
			Console.WriteLine();
			Console.Write("Digite o id da temporada: ");
			int TemporadaID = int.Parse(Console.ReadLine());
			Temporada temporada = serie.TemporadaPorId(TemporadaID);
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
			serie.AtualizaTemporada(TemporadaID, temporada);
		}

		private static void ExcluirTemporada(Serie serie)
		{
			series.ImprimeTemporadas(serie.Id);
			Console.WriteLine();
			Console.Write("Digite o id da temorada: ");
			int indiceTemporada = int.Parse(Console.ReadLine());

			series.ExcluiTemporada(serie.Id, indiceTemporada);
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
						break;
					case "4":
						ExcluirFilme();
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

				opcaoUsuario = InterfaceUsuario.Series();
			}
		}
		private static void InserirFilme()
		{
			var filme = InterfaceUsuario.InserirFilme(filmes.ProximoId());
			filmes.Insere(filme);
		}

		private static void ExcluirFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			filmes.Exclui(indiceFilme);
		}

		private static void VisualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var filme = filmes.RetornaPorId(indiceFilme);

			Console.WriteLine(filme);
		}

		private static void AtualizarFilme()
		{
			filmes.ImprimeLista(); ;
			Console.WriteLine();
			Console.Write("Digite o id da série: ");
			int filmeID = int.Parse(Console.ReadLine());
			Filme filme = filmes.RetornaPorId(filmeID);
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
			filmes.Atualiza(filmeID, filme);
		}
	}
}
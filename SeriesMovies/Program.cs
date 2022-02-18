using System;
namespace SeriesMovies
{
	class Program
	{
		static SerieRepositorio series = new SerieRepositorio();
		static void Main(string[] args)
		{
			series.LeArquivo();

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
						// OpcaoFilmes();
						break;

					default:
						Console.WriteLine($"Opção '{opcaoUsuario}' invalida.");
						InterfaceUsuario.Pausa();
						break;
				}

				opcaoUsuario = InterfaceUsuario.Inicio();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			InterfaceUsuario.Pausa();
		}

		private static void ListarTudo()
		{
			ListarSeries();
		}
		private static void ListarSeries()
		{
			Console.WriteLine("SÉRIES:");

			var lista = series.Lista();

			if (lista.Count() == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
				if (!serie.EhExcluido())
				{
					Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
				}
			}
		}

		private static void OpcaoSeries()
		{
			string opcaoUsuario = InterfaceUsuario.Series();

			while (opcaoUsuario != "0")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						InterfaceUsuario.Pausa();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						// ExcluirSerie();
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
				var temporada = InterfaceUsuario.InserirTemporada(serie.retornaTemporadas());
				series.adicionaTemporada(serie.retornaId(), temporada);
				continua = InterfaceUsuario.Confirma("Deseja adicionar mais Temporadas?");
			}
		}

		// private static void ExcluirSerie()
		// {
		// 	Console.Write("Digite o id da série: ");
		// 	int indiceSerie = int.Parse(Console.ReadLine());

		// 	repositorio.Exclui(indiceSerie);
		// }

		private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = series.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

		private static void AtualizarSerie()
		{
			ListarSeries();
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


	}
}
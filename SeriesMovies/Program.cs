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
						// AtualizarSerie();
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

		// private static void AtualizarSerie()
		// {
		// 	Console.Write("Digite o id da série: ");
		// 	int indiceSerie = int.Parse(Console.ReadLine());

		// 	// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
		// 	// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
		// 	foreach (int i in Enum.GetValues(typeof(Genero)))
		// 	{
		// 		Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
		// 	}
		// 	Console.Write("Digite o gênero entre as opções acima: ");
		// 	int entradaGenero = int.Parse(Console.ReadLine());

		// 	Console.Write("Digite o Título da Série: ");
		// 	string entradaTitulo = Console.ReadLine();

		// 	Console.Write("Digite o Ano de Início da Série: ");
		// 	int entradaAno = int.Parse(Console.ReadLine());

		// 	Console.Write("Digite a Descrição da Série: ");
		// 	string entradaDescricao = Console.ReadLine();

		// 	Serie atualizaSerie = new Serie(id: indiceSerie,
		// 								genero: (Genero)entradaGenero,
		// 								titulo: entradaTitulo,
		// 								ano: entradaAno,
		// 								descricao: entradaDescricao);

		// 	repositorio.Atualiza(indiceSerie, atualizaSerie);
		// }
		//

	}
}
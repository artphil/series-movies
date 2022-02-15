namespace SeriesMovies
{
	public static class InterfaceUsuario
	{
		private static void Cabecalho()
		{
			Console.Clear();
			Console.WriteLine("Sua lista de Séries e Filmes");
			Console.WriteLine("Informe a opção desejada:");
		}
		public static void Pausa()
		{
			Console.WriteLine("Tecle ENTER para continuar...");
			Console.ReadKey();
		}
		public static string Inicio()
		{
			InterfaceUsuario.Cabecalho();
			Console.WriteLine("1- Listar tudo");
			Console.WriteLine("2- Ir para séries");
			Console.WriteLine("3- Ir para filmes");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		public static string Series()
		{
			InterfaceUsuario.Cabecalho();
			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("0- Voltar");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		public static void InserirSerie(SerieRepositorio repositorio)
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();


			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
			string continua = "S";
			int temporadaAno;
			int temporadaEpisodios;
			while (continua == "S")
			{
			Console.Write($"Informações da {novaSerie.retornaTemporadas()} temporada");
			Console.Write("Digite o Ano de Início da Temporada: ");
			temporadaAno = int.Parse(Console.ReadLine());
			Console.Write("Digite o número de episódios da Temporada: ");
			temporadaEpisodios = int.Parse(Console.ReadLine());
			novaSerie.adicionaTemporada(temporadaAno, temporadaEpisodios);

			Console.Write("Deseja adicionar outra temporada? (S/N): ");
			continua = Console.ReadLine().ToUpper();
			}
		}
	}
}
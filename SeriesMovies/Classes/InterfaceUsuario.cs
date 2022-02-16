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
			Console.WriteLine("1- Listar titulos");
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

		public static Serie InserirSerie(int serieID)
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

			return new Serie(id: serieID,
							 genero: (Genero)entradaGenero,
							 titulo: entradaTitulo,
							 descricao: entradaDescricao);
		}

		private static Temporada InserirTemporada(int temporadaID)
		{
			Console.Write($"Informações da {temporadaID} temporada");

			Console.Write("Digite o Ano de Início da Temporada: ");
			int temporadaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite o número de episódios da Temporada: ");
			int temporadaEpisodios = int.Parse(Console.ReadLine());

			return new Temporada(id: temporadaID, 
								 ano: temporadaAno, 
								 episodios: temporadaEpisodios);
		}
	}
}
namespace SeriesMovies
{
	public static class InterfaceUsuario
	{
		private static void Cabecalho()
		{
			Console.Clear();
			Console.WriteLine("# # # # # # # # # # # # # # # # #");
			Console.WriteLine("# Sua lista de Séries e Filmes  #");
			Console.WriteLine("# # # # # # # # # # # # # # # # #");
			Console.WriteLine();
		}
		public static void Pausa()
		{
			Console.WriteLine("Tecle ENTER para continuar...");
			Console.ReadKey();
		}

		public static void Despedida()
		{
			Cabecalho();
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Pausa();
		}

		public static bool Confirma(string mensagen)
		{
			Console.Write($"{mensagen} (S/N):");
			string opcaoUsuario = Console.ReadLine().ToUpper();
			return (opcaoUsuario == "S") ? true : false;
		}

		public static string Inicio()
		{
			InterfaceUsuario.Cabecalho();
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine("1 - Listar todos os títulos");
			Console.WriteLine("2 - Ir para séries");
			Console.WriteLine("3 - Ir para filmes");
			Console.WriteLine("X - Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		public static string Series()
		{
			InterfaceUsuario.Cabecalho();
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine("1 - Listar séries");
			Console.WriteLine("2 - Inserir nova série");
			Console.WriteLine("3 - Atualizar série");
			Console.WriteLine("4 - Remover série");
			Console.WriteLine("5 - Visualizar série");
			Console.WriteLine("0 - Voltar");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		public static Serie InserirSerie(int serieID)
		{
			InterfaceUsuario.Cabecalho();
			Console.WriteLine("Inserir nova série");
			Genero entradaGenero = ObterGenero();
			string entradaTitulo = ObterTitulo();
			string entradaDescricao = ObterDescricao();

			return new Serie(id: serieID,
							 genero: entradaGenero,
							 titulo: entradaTitulo,
							 descricao: entradaDescricao);
		}

		public static string AtualizarSerie(Serie serie)
		{
			InterfaceUsuario.Cabecalho();
			Console.WriteLine($"Atualizar série #{serie.Id}");
			Console.WriteLine();
			Console.WriteLine($"1 - Titulo: {serie.Titulo}");
			Console.WriteLine($"2 - Genero: {serie.Genero}");
			Console.WriteLine($"3 - Descrição: {serie.Descricao}");
			Console.WriteLine($"4 - Atualizar Temporadas");
			Console.WriteLine($"5 - Inserir Temporada");
			Console.WriteLine($"6 - Remover Temporada");
			Console.WriteLine($"0 - Voltar");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		public static Temporada InserirTemporada(int temporadaID)
		{
			InterfaceUsuario.Cabecalho();
			Console.WriteLine($"Informações da temporada");
			int temporadaAno = ObterAno();
			int temporadaEpisodios = ObterEpisodios();

			return new Temporada(id: temporadaID,
								 ano: temporadaAno,
								 episodios: temporadaEpisodios);
		}

		public static string AtualizarTemporada(Temporada temporada)
		{
			InterfaceUsuario.Cabecalho();
			Console.WriteLine($"Atualizar temporada #{temporada.Id}");
			Console.WriteLine();
			Console.WriteLine($"1 - Ano: {temporada.Ano}");
			Console.WriteLine($"2 - Episodios: {temporada.Episodios}");
			Console.WriteLine($"0 - Voltar");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		public static string Filmes()
		{
			InterfaceUsuario.Cabecalho();
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine("1 - Listar filmes");
			Console.WriteLine("2 - Inserir novo filme");
			Console.WriteLine("3 - Atualizar filme");
			Console.WriteLine("4 - Remover filme");
			Console.WriteLine("5 - Visualizar filme");
			Console.WriteLine("0 - Voltar");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		public static Filme InserirFilme(int filmeID)
		{
			InterfaceUsuario.Cabecalho();
			Console.WriteLine("Inserir novo filme");
			Genero entradaGenero = ObterGenero();
			string entradaTitulo = ObterTitulo();
			string entradaDescricao = ObterDescricao();
			int entradaAno = ObterAno();

			return new Filme(id: filmeID,
							 genero: entradaGenero,
							 titulo: entradaTitulo,
							 descricao: entradaDescricao,
							 ano: entradaAno);
		}

		public static string AtualizarFilme(Filme filme)
		{
			InterfaceUsuario.Cabecalho();
			Console.WriteLine($"Atualizar filme #{filme.Id}");
			Console.WriteLine();
			Console.WriteLine($"1 - Titulo: {filme.Titulo}");
			Console.WriteLine($"2 - Genero: {filme.Genero}");
			Console.WriteLine($"3 - Descrição: {filme.Descricao}");
			Console.WriteLine($"4 - Ano: {filme.Ano}");
			Console.WriteLine($"0 - Voltar");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}


		public static string ObterDescricao()
		{
			Console.Write("Digite a Descrição: ");
			string entradaDescricao = Console.ReadLine();
			return entradaDescricao;
		}

		public static string ObterTitulo()
		{
			Console.Write("Digite o Título: ");
			string entradaTitulo = Console.ReadLine();
			return entradaTitulo;
		}

		public static Genero ObterGenero()
		{
			int nGeneros = 0;
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				nGeneros++;
				Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
			}

			while (true)
			{
			Console.Write("Digite o gênero entre as opções acima: ");

				try
				{
					int entradaGenero = int.Parse(Console.ReadLine());
					if (entradaGenero < nGeneros)
					{
						return (Genero)entradaGenero;
					}
					else
					{
						Console.WriteLine("Genero inválido.");
					}
				}
				catch (System.Exception)
				{
					Console.WriteLine("Opção inválida.");
				}
			}
		}

		public static int ObterEpisodios()
		{
			Console.Write("Digite o número de episódios da temporada: ");
			int temporadaEpisodios = int.Parse(Console.ReadLine());
			return temporadaEpisodios;
		}

		public static int ObterAno()
		{
			Console.Write("Digite o ano de lançamento: ");
			int temporadaAno = int.Parse(Console.ReadLine());
			return temporadaAno;
		}
	}
}
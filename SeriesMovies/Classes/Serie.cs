namespace SeriesMovies
{
	public class Serie : EntidadeBase
	{
		private Genero Genero { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private TemporadaRepositorio Temporadas = new TemporadaRepositorio();
		public Serie(int id,
			   Genero genero,
			   string titulo,
			   string descricao)
		{
			this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Excluido = false;
		}
		public override string ToString()
		{
			string retorno = "";
			retorno += $"Série: {this.Titulo}" + Environment.NewLine;
			retorno += $"Gênero: {this.Genero}" + Environment.NewLine;
			retorno += $"Descrição: {this.Descricao}" + Environment.NewLine;
			retorno += $"Temporadas: {this.Temporadas.ProximoId()}" + Environment.NewLine;
			foreach (Temporada item in Temporadas.Lista())
			{
				retorno += item.ToString();
			}
			return retorno;
		}

		public void adicionaTemporada(int ano, int episodios)
		{
			int id = Temporadas.ProximoId();
			Temporada temporada = new Temporada(id, ano, episodios);
			Temporadas.Insere(temporada);
		}

		internal int retornaId()
		{
			return this.Id;
		}

		internal string retornaTitulo()
		{
			return this.Titulo;
		}

		internal int retornaTemporadas()
		{
			return this.Temporadas.ProximoId();
		}

		
	}
}
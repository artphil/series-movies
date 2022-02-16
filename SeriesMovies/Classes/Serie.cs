using System.Text.Json;

namespace SeriesMovies
{
	public class Serie : EntidadeBase
	{
		public Genero Genero { get; set; }
		public string Titulo { get; set; }
		public string Descricao { get; set; }
		public List<Temporada> Temporadas = new List<Temporada>();
		// public TemporadaRepositorio Temporadas = new TemporadaRepositorio();
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
			// retorno += $"Temporadas: {this.Temporadas.ProximoId()}" + Environment.NewLine;
			retorno += $"Temporadas: {this.Temporadas.Count()}" + Environment.NewLine;
			// foreach (Temporada item in Temporadas.Lista())
			foreach (Temporada item in Temporadas)
			{
				retorno += item.ToString();
			}
			return retorno;
		}

		public void adicionaTemporada(int ano, int episodios)
		{
			// int id = Temporadas.ProximoId();
			int id = Temporadas.Count();
			Temporada temporada = new Temporada(id, ano, episodios);
			// Temporadas.Insere(temporada);
			Temporadas.Add(temporada);
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
			// return this.Temporadas.ProximoId();
			return this.Temporadas.Count();
		}

		public string toJSON()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
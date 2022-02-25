using System;
using System.Text.Json;

namespace SeriesMovies
{
	public class Serie : EntidadeBase
	{
		public Genero Genero { get; set; }
		public string Titulo { get; set; }
		public string Descricao { get; set; }
		public List<Temporada> Temporadas = new List<Temporada>();

		public Serie(int id, Genero genero, string titulo, string descricao)
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
			retorno += "Temporadas:" + Environment.NewLine;
			retorno += ImprimeTemporadas();
			return retorno;
		}

		public string ImprimeTemporadas(bool todas = false)
		{
			string retorno = "";
			foreach (Temporada item in Temporadas)
			{
				if (todas || !item.EhExcluido())
				{
					retorno += item.ToString() + Environment.NewLine; ;
				}
			}

			return retorno;
		}

		public int RetornaId()
		{
			return this.Id;
		}

		public string RetornaTitulo()
		{
			return this.Titulo;
		}

		public int RetornaNumeroTemporadas()
		{
			return this.Temporadas.Count();
		}

		public Temporada[] RetornaTemporadas()
		{
			return Temporadas.ToArray();
		}
		public Temporada TemporadaPorId(int id)
		{
			return (Temporada)Temporadas[id].Clone();
		}
		public void AtualizaTemporada(int id, Temporada entidade)
		{
			Temporadas[id] = entidade;
		}
		public string ToJSON()
		{
			JsonSerializerOptions options = new JsonSerializerOptions()
			{
				IncludeFields = true,
			};
			return JsonSerializer.Serialize(this, options);
		}

		public static Serie ParseJSON(string json)
		{
			JsonSerializerOptions options = new JsonSerializerOptions()
			{
				IncludeFields = true,
			};
			return JsonSerializer.Deserialize<Serie>(json, options);
		}
	}
}
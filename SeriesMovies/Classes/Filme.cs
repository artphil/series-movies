using System;
using System.Text.Json;

namespace SeriesMovies
{
	public class Filme : EntidadeBase
	{
		public Genero Genero { get; set; }
		public string Titulo { get; set; }
		public string Descricao { get; set; }
		public int Ano { get; set; }

		public Filme(int id, Genero genero, string titulo, string descricao, string ano)
		{
			this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
			this.Excluido = false;
		}

		public override string ToString()
		{
			string retorno = "";
			retorno += $"Filme: {this.Titulo} - ({this.Ano})" + Environment.NewLine;
			retorno += $"Gênero: {this.Genero}" + Environment.NewLine;
			retorno += $"Descrição: {this.Descricao}" + Environment.NewLine;
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

		public string ToJSON()
		{
			JsonSerializerOptions options = new JsonSerializerOptions()
			{
				IncludeFields = true,
			};
			return JsonSerializer.Serialize(this, options);
		}

		public static Filme ParseJSON(string json)
		{
			JsonSerializerOptions options = new JsonSerializerOptions()
			{
				IncludeFields = true,
			};
			return JsonSerializer.Deserialize<Serie>(json, options);
		}
	}
}
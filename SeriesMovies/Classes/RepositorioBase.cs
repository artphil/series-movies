using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using SeriesMovies.Interface;

namespace SeriesMovies
{
	public abstract class RepositorioBase<T>
	{
		protected List<T> lista;
		private string caminho;
		public RepositorioBase (string caminho)
		{
			this.caminho = caminho;
		}
		private string ToJSON(List<T> dados)
		{
			JsonSerializerOptions options = new JsonSerializerOptions()
			{
				IncludeFields = true,
				WriteIndented = true,
			};
			return JsonSerializer.Serialize(dados, options);
		}

		private List<T> ParseJSON(string json)
		{
			JsonSerializerOptions options = new JsonSerializerOptions()
			{
				IncludeFields = true,
			};
			return JsonSerializer.Deserialize<List<T>>(json, options);
		}
		public void LeArquivo()
		{
			if (File.Exists(caminho))
			{
				string dados = File.ReadAllText(caminho);
				this.lista = new List<T>(ParseJSON(dados));
				// using (var arquivo = File.Open(caminho, FileMode.Open))
				// {
				// 	lista = List<T>(ParseJSON(arquivo.Read));
				// }
			}
			else
			{
				this.lista = new List<T>();
			}
		}
		public void SalvaArquivo()
		{
			// using (var arquivo = File.Open(caminho, FileMode.CreateNew))
			// {
			File.WriteAllText(caminho, ToJSON(this.lista));
			// }
		}
	}
}
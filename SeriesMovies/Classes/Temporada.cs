using System.Text.Json;

namespace SeriesMovies
{
	public class Temporada : EntidadeBase
	{
		public int Ano { get; set; }
		public int Episodios { get; set; }
		public Temporada(int id, int ano, int episodios)
		{
			this.Id = id;
			this.Ano = ano;
			this.Episodios = episodios;
			this.Excluido = false;
		}

	
		public override string ToString()
		{
			string retorno = "";
			retorno += $"Temporada: {this.Id + 1}º - ({this.Ano})" + Environment.NewLine;
			retorno += $"Episodios: {this.Episodios}" + Environment.NewLine;
			return retorno;
		}
		
	}
}
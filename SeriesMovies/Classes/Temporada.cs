namespace SeriesMovies
{
	public class Temporada : EntidadeBase
	{
		private int Ano { get; set; }
		private int Episodios { get; set; }
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
			retorno += $"Temporada: {this.Id + 1} - {this.Ano}" + Environment.NewLine;
			retorno += $"Episodios: {this.Episodios}" + Environment.NewLine;
			return retorno;
		}
	}
}
namespace SeriesMovies
{
	public abstract class EntidadeBase
	{
		public int Id { get; set; }
		public bool Excluido { get; set;}

		public void Excluir()
		{
			this.Excluido = true;
		}

		public void Restaurar()
		{
			this.Excluido = false;
		}

		public bool EhExcluido()
		{
			return this.Excluido;
		} 
	}
}
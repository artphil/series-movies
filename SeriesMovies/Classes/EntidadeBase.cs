namespace SeriesMovies
{
	public abstract class EntidadeBase
	{
		protected int Id { get; set; }
		protected bool Excluido { get; set; }

		public void Excluir()
		{
			this.Excluido = true;
		}

		public bool EhExcluido()
		{
			return this.Excluido;
		} 
	}
}
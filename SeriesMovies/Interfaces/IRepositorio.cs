namespace SeriesMovies.Interface
{
	public interface IRepositorio<T>
	{
		public T RetornaPorId(int id);
		public void Insere(T entidade);
		public void Exclui(int id);
		public void Atualiza(int id, T entidade);
		public int ProximoId();
	}
}
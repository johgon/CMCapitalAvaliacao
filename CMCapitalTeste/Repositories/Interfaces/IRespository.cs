namespace CMCapitalAvaliacao.Repositories.Interfaces
{
    public interface IRepository<T> 
    {
        public Retorno<IEnumerable<T>> GetAll();
        public Retorno<T?> GetById(int id);
        public Retorno<T> AddOrUpdate(T entity, int? id);
        public Retorno<bool> Delete(int id);
    }
}

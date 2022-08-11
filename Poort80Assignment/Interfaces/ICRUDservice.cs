namespace Poort80Assignment.Interfaces
{
    public interface ICRUDservice<T, Y>
    {
        public List<T> All();
        public T? Find(int id);
        public T Create(Y entity);
        public T? Update(Y change, T current);
        public void Delete(T entity);
    }
}

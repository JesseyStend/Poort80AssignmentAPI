namespace Poort80Assignment.Interfaces
{
    public interface ICRUDservice<T>
    {
        public List<T> All();
        public T Find(int id);
        public T Create(T entity);
        public T Update(T entity);
        public void Delete(T entity);
    }
}

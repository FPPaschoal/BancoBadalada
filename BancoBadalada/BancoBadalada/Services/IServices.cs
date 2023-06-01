namespace BancoBadalada.Services
{
    public interface IServices<T>
    {
        public void Create(T services);
        public void Update(T services);
        public void Delete(T services); 
        public T Find(T services);
        public ICollection<T> FindAll();
        public int GetNextId();

    }
}

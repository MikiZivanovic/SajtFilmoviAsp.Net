using WebApp.Models;

namespace WebApp.Data
{
    public interface IRepository<T> where T : class 
    {

        IEnumerable<T> GetAll();

        T GetById(int id);
        void Add(T t);
        void Update(T t);
        void Delete(int id);
    }
}

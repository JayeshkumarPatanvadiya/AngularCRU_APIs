using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularCRU_APIs.Repository.Classes
{
    public interface IWorkoutRepository<T> where T : class
    {
        public IEnumerable<T> GetWorkout(int id);
        public T GetById(object id);

        public IEnumerable<T> GetRecords();
        public void Insert(T obj);
        public void Update(T obj);
        public void Delete(object id);
        //public void Save();

        Task SaveAsync();



    }
}
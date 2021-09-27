using System.Collections.Generic;

namespace AngularCRU_APIs.Repository.Classes
{
    public interface IWorkoutRepository<T> where T : class
    {
        public IEnumerable<T> GetWorkout(int id);


        public IEnumerable<T> GetRecords();
        public void Insert(T obj);
        public void Update(T obj);
        public void Delete(object id);
        public void Save();



    }
}
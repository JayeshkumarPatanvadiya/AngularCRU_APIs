using System.Collections.Generic;

namespace AngularCRU_APIs.Repository.Classes
{
    public interface IWorkoutRepository<T> where T : class
    {
        public IEnumerable<T> GetWorkout(int id);

    }
}
using AngularCRU_APIs.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCRU_APIs.Repository.Classes
{
    public class WorkoutRepository<T> : IWorkoutRepository<T> where T : class
    {
        private readonly WorkoutContext _context;
        private DbSet<T> table = null;

        public WorkoutRepository(WorkoutContext context)
        {
            this._context = context;
            table = context.Set<T>();
        }
        public IEnumerable<T> GetWorkout(int id)
        {
            var workout =  _context.Workout.SingleOrDefault(m => m.Id == id);
            return ((IEnumerable<T>)workout);
        }

    }
}

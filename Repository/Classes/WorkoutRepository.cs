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
            var workout = _context.Workout.SingleOrDefault(m => m.Id == id);
            return ((IEnumerable<T>)workout);
        }


        public T GetById(object id)
        {
            return table.Find(id);
        }



        public IEnumerable<T> GetRecords()
        {
            return table.ToList();
        }


        public void Insert(T obj)
        {
            table.AddAsync(obj);
        }


        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }


        //public async void Save()
        //{
        //    //  _context.SaveChanges();
        // await   _context.SaveChangesAsync();
        //}

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

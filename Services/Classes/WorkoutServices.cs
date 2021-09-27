using AngularCRU_APIs.Models;
using AngularCRU_APIs.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCRU_APIs.Services.Classes
{
    public class WorkoutServices
    {
        private readonly IWorkoutRepository<Workout> _WorkoutRepo;

        public  WorkoutServices(IWorkoutRepository<Workout> WorkoutRepo)
        {
            _WorkoutRepo = WorkoutRepo;
        }

        public Workout GetWorkout(int id)
        {
            return (Workout)_WorkoutRepo.GetWorkout(id);
        }

        public List<Workout> GetRecordsServices() => (List<Workout>)_WorkoutRepo.GetRecords();

        public  void InsertWorkout(Workout workout)
        {
            _WorkoutRepo.Insert(workout);
        }

        public void UpdateWorkout(Workout workout)
        {
            _WorkoutRepo.Update(workout);
        }
        public void DeleteWorkout(int id)
        {
            var temp = _WorkoutRepo.GetWorkout(id);
            _WorkoutRepo.Delete(temp);
            _WorkoutRepo.Save();
        }


        public void Save()
        {
            _WorkoutRepo.Save();
        }


    }
}

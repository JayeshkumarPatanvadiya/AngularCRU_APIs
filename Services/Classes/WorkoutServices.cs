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
            return (Workout)_WorkoutRepo.GetById(id);
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
        public async void DeleteWorkout(int id)
        {
            try
            {              
                _WorkoutRepo.Delete(id);
               await _WorkoutRepo.SaveAsync();
            }
            catch(Exception e)
            {

            }
           
        }

        public bool WorkoutExists(int id)
        {
            var temp =   _WorkoutRepo.GetById(id);
            if(temp != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task SaveAsync()
        {
           await _WorkoutRepo.SaveAsync();
        }


    }
}

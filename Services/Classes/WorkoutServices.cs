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

    }
}

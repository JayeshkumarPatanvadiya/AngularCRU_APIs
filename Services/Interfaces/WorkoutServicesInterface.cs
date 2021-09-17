using AngularCRU_APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCRU_APIs.Services.Interfaces
{
    public interface WorkoutServicesInterface
    {
        public Workout GetWorkout(int id);
    }
}

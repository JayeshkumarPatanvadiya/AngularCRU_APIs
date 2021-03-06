using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCRU_APIs.Data
{
    public class WorkoutContext : DbContext
    {
        public WorkoutContext(DbContextOptions<WorkoutContext> options)
              : base(options)
        {
        }

        public DbSet<AngularCRU_APIs.Models.Workout> Workout { get; set; }

    }
}

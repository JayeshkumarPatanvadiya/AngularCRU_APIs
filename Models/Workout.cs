using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCRU_APIs.Models
{
    public class Workout
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int DistanceInMeters { get; set; }

        public int TimeInSeconds { get; set; }
                //[DataType(DataType.Date)]

        public DateTime InsertDateTime { get; set; }

       

    }
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}

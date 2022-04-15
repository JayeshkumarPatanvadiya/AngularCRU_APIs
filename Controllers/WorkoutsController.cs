using AngularCRU_APIs.Data;
using AngularCRU_APIs.JwtFeatures;
using AngularCRU_APIs.Models;
using AngularCRU_APIs.Services.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularCRU_APIs.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[DisableCors]
    public class WorkoutsController : ControllerBase
    {

        private readonly WorkoutContext _context;
        private WorkoutServices _workoutServices;
        //private readonly JwtHandler _jwtHandler;



        public WorkoutsController(WorkoutServices workoutServices, WorkoutContext context)
        {
            _context = context;
            _workoutServices = workoutServices;
            //_jwtHandler = jwtHandler;
        }
        //[HttpPost("Login")]
        //public async Task<IActionResult> Login([FromBody] Workout workout)
        //{
        //    var user = await _context.FindAsync(workout.Email);
        //    if (user == null || !await _context.CheckPasswordAsync(user, workout.Password))
        //        return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
        //    var signingCredentials = _jwtHandler.GetSigningCredentials();
        //    var claims = _jwtHandler.GetClaims(user);
        //    var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
        //    var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        //    return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        //}

        [HttpGet]
        //[Authorize]
        [AllowAnonymous]
        public ActionResult GetRecords()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Workout> workout = _workoutServices.GetRecordsServices();


            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }
        // GET: api/Workouts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkout([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workout = _workoutServices.GetWorkout(id);
            //var workout1 =   _workoutServices.GetWorkout(id);
            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }

        // PUT: api/Workouts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkout([FromRoute] int id, [FromBody] Workout workout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workout.Id)
            {
                return BadRequest();
            }

            _workoutServices.UpdateWorkout(workout);

            try
            {
                await _workoutServices.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Workouts
        [HttpPost]
        public async Task<IActionResult> PostWorkout([FromBody] Workout workout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _workoutServices.InsertWorkout(workout);
                workout.InsertDateTime = DateTime.Now;
                await _workoutServices.SaveAsync();
            }
            catch (Exception e)
            {
            }


            return CreatedAtAction("GetRecords", new { id = workout.Id }, workout);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workout = _workoutServices.GetWorkout(id);

            if (workout == null)
            {
                return NotFound();
            }

            _context.Workout.Remove(workout);
            //  _workoutServices.DeleteWorkout(id);
            await _context.SaveChangesAsync();
            //await _workoutServices.SaveAsync();


            return Ok(workout);
        }

        private bool WorkoutExists(int id)
        {
            //return _context.Workout.Any(e => e.Id == id);
            return _workoutServices.WorkoutExists(id);
        }

    }
}

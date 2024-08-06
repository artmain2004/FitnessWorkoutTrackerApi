using FitnessWorkoutTrackerApi.Request.Workouts;
using FitnessWorkoutTrackerApi.Service.Workouts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorkoutTrackerApi.Controllers
{
    [Route("api/workouts")]
    [ApiController]
    public class WorkoutController(IWorkoutService workoutService) : ControllerBase
    {
        [HttpGet("")]
        public async Task<ActionResult> GetAll()
        {
            var result = await workoutService.GetAllWorkouts();

            return Ok(result);
        }  
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] Guid id)
        {
            var result = await workoutService.GetWorkoutById(id);

            return Ok(result);
        }  
        
        [HttpGet("type")]
        public async Task<ActionResult> GetAll([FromQuery] string type)
        {
            var result = await workoutService.GetAllWorkoutsByType(type);

            return Ok(result);
        }

        [HttpPost("")]
        [Authorize]
        public async Task<ActionResult> Create([FromBody] CreateWorkoutRequest createWorkoutRequest)
        {
            var result = await workoutService.CreateWorkout(createWorkoutRequest);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Update([FromRoute] Guid id,
            [FromBody] UpdateWorkoutRequest updateWorkoutRequest)
        {
            var result = await workoutService.UpdateWorkout(id, updateWorkoutRequest);

            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var result = await workoutService.DeleteWorkout(id);

            return Ok(result);
        }
    }
}

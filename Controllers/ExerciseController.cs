using FitnessWorkoutTrackerApi.Request.Exercises;
using FitnessWorkoutTrackerApi.Service.Exercises;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorkoutTrackerApi.Controllers
{
    [Route("api/exercises")]
    [ApiController]
    [Authorize]
    public class ExerciseController(IExerciseService exerciseService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<ActionResult> Create([FromBody] CreateExerciseRequest createExerciseRequest)
        {
            var result = await exerciseService.CreateExercise(createExerciseRequest);

            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid id,[FromBody] UpdateExerciseRequest updateExerciseRequest)
        {
            var result = await exerciseService.UpdateExercise(id,updateExerciseRequest);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var result = await exerciseService.DeleteExercise(id);

            return Ok(result);
        }
        
    }
}

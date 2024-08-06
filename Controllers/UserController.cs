using FitnessWorkoutTrackerApi.Request.User;
using FitnessWorkoutTrackerApi.Service.User;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorkoutTrackerApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult> UserLogin([FromBody] UserLoginRequest userLoginRequest)
        {

            var loginResult = await userService.UserLoginAsync(userLoginRequest);
            
            return Ok(loginResult);
        } 
        
        [HttpPost("register")]
        public async Task<ActionResult> UserRegister([FromBody] UserRegisterRequest userRegisterRequest)
        {
            var registerResult = await userService.UserRegisterAsync(userRegisterRequest);
            
            return Ok(registerResult);
        } 
        
        [HttpPost("change-password")]
        public async Task<ActionResult> UserChangePassword([FromBody] UserChangePasswordRequest changePasswordRequest)
        {
            var changePasswordResult = await userService.UserChangePasswordAsync(changePasswordRequest);
            
            return Ok(changePasswordResult);
        }

        [HttpGet("sign-out")]

        public async Task<ActionResult> UserSignOut()
        {
            var result = await userService.UserSignOut();
            return Ok(result);
        }
        
    }
}

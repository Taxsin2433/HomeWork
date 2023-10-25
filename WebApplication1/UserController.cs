using Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApiHomeWork.Services;

namespace WebApiHomeWork.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _userService.CreateUser(user);

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            var updatedUser = await _userService.UpdateUser(id, user);

            if (updatedUser == null)
            {
                return NotFound(new { message = "User not found" });
            }

            return Ok(updatedUser);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUserPartial(int id, [FromBody] Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<User> patchDocument)
        {
            var existingUser = await _userService.GetUserById(id);

            if (existingUser == null)
            {
                return NotFound(new { message = "User not found" });
            }

            var patchedUser = new User();
            patchDocument.ApplyTo(patchedUser);

            if (string.IsNullOrEmpty(patchedUser.Name))
            {
                ModelState.AddModelError("Name", "Name is required");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedUser = await _userService.UpdateUserPartial(id, patchedUser);

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await _userService.DeleteUser(id);

            if (!deleted)
            {
                return NotFound(new { message = "User not found" });
            }

            return NoContent();
        }
    }
}

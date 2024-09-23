using CCI.Service;
using Microsoft.AspNetCore.Mvc;

namespace CCIAdmin;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("update-department-status")]
    public async Task<IActionResult> UpdateDepartmentStatusAsync([FromQuery] Guid userId, bool status)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _userService.UpdateDepartmentStatusAsync(userId, status);

        return result.Success ? Ok(result) : BadRequest(result);
    }
}

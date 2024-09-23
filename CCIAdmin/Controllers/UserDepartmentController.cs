using CCI.Model;
using CCI.Service.Contractors;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UserDepartmentController : Controller
{
    private readonly IUserDepartmentService _userDepartmentService;

    public UserDepartmentController(IUserDepartmentService userDepartmentService)
    {
        _userDepartmentService = userDepartmentService;
    }

    [HttpPost("create-user-department-profile")]
    public async Task<IActionResult> CreateUserProfile([FromBody] CreateUserDepartmentRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userDepartmentService.CreateUserDepartmentProfile(request);

        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("delete-user-department-profile")]
    public async Task<IActionResult> DeleteUserProfile([FromBody] DeleteUserDepartmentRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userDepartmentService.DeleteUserDepartmentProfile(request);

        return result.Success ? Ok(result) : BadRequest(result);
    }
}
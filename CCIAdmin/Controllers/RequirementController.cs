using CCI.Common;
using CCI.Model;
using CCI.Service;
using Microsoft.AspNetCore.Mvc;

namespace CCIAdmin;

[Route("api/[controller]")]
[ApiController]
public class RequirementController : Controller
{
    private readonly IRequirementService _requirementService;

    public RequirementController(IRequirementService requirementService)
    {
        _requirementService = requirementService;
    }

    [HttpGet("get-by-type")]
    public async Task<IActionResult> GetByType([FromQuery] RequirementType idJobPost)
    {
        var result = await _requirementService.GetByTypeAsync(idJobPost);

        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("update-status")]
    public async Task<IActionResult> UpdateRequirementStatus([FromBody] UpdateRequirementStatusRequest request)
    {
        var result = await _requirementService.UpdateStatusAsync(request);

        return result.Success ? Ok(result) : BadRequest(result);
    }
}

using CCI.Model;
using CCI.Model.DepartmentModels;
using CCI.Service.Contractors;
using Microsoft.AspNetCore.Mvc;

namespace CCIAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _departmentService.CreateAsync(model);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _departmentService.GetAllAsync();

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-by-id/{departmentId}")]
        public async Task<IActionResult> GetById(Guid departmentId)
        {
            var result = await _departmentService.GetById(departmentId);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateDepartmentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _departmentService.UpdateAsync(request);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("assign-user-to-department")]
        public async Task<IActionResult> AssignUserToDepartment([FromBody] AssignUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _departmentService.AssignUserToDepartment(request);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}

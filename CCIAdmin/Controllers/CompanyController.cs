using CCI.Service.Contractors;
using Microsoft.AspNetCore.Mvc;

namespace CCIAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("get-by-id/{departmentId}")]
        public async Task<ActionResult> GetById(Guid departmentId)
        {
            var result = await _companyService.GetCompanyByIdAsync(departmentId);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _companyService.GetAllAsync();

            return result.Success ? Ok(result) : BadRequest();
        }
    }
}

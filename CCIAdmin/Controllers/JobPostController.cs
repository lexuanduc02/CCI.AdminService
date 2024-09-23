using CCI.Service.Contractors;
using Microsoft.AspNetCore.Mvc;

namespace CCIAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostController : Controller
    {
        private readonly IJobPostService _jobPostService;

        public JobPostController(IJobPostService jobPostService)
        {
            _jobPostService = jobPostService;
        }

        [HttpPut("detect-job-post")]
        public async Task<IActionResult> DetectPost([FromQuery] Guid idJobPost)
        {
            var result = await _jobPostService.DetectJobPost(idJobPost);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("undetect-job-post")]
        public async Task<IActionResult> UnDetectPost([FromQuery] Guid idJobPost)
        {
            var result = await _jobPostService.UnDetectJobPost(idJobPost);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}

using CCI.Common.Extensions;
using CCI.Model.CommonModels;
using CCI.Repository.Contractors;
using CCI.Service.Contractors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Events;

namespace CCI.Service;

public class JobPostService : IJobPostService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<JobPostService> _logger;
    private const string ClassName = nameof(DepartmentService);

    public JobPostService(IUnitOfWork unitOfWork,
    ILogger<JobPostService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<BaseResponseModel<bool>> DetectJobPost(Guid idJobPost)
    {
        try
        {
            var result = await _unitOfWork.JobPostRepository.DetectPost(idJobPost);
            if (result == 2)
                return ErrorResponse<bool>("Job Post do not exits!", StatusCodes.Status400BadRequest);

            _logger.LogInformation("Detective Job Post Successfully!".GeneratedLog(ClassName, LogEventLevel.Information));
            return new BaseResponseModel<bool>()
            {
                Success = true,
                StatusCode = StatusCodes.Status200OK,
                Message = "Ẩn Job Post thành công!",
            };
        }
        catch (System.Exception ex)
        {
            return ErrorResponse<bool>("Detective Job Post Failed!", StatusCodes.Status400BadRequest, ex);
        }
    }

    public async Task<BaseResponseModel<bool>> UnDetectJobPost(Guid idJobPost)
    {
        try
        {
            var result = await _unitOfWork.JobPostRepository.UnDetectPost(idJobPost);

            if (result == 2)
                return ErrorResponse<bool>("Job Post do not exits!", StatusCodes.Status400BadRequest);

            _logger.LogInformation("Detective Job Post Succeed".GeneratedLog(ClassName, LogEventLevel.Information));
            return new BaseResponseModel<bool>()
            {
                Success = true,
                StatusCode = StatusCodes.Status200OK,
                Message = "Ẩn Job Post thành công!",
            };
        }
        catch (System.Exception ex)
        {
            return ErrorResponse<bool>("Detective Job Post Failed!", StatusCodes.Status400BadRequest, ex);
        }
    }

    private BaseResponseModel<T> ErrorResponse<T>(string message, int statusCode, Exception ex = null)
    {
        _logger.LogError($"{message}: {ex?.ToString() ?? ""}".GeneratedLog(ClassName, LogEventLevel.Error));

        return new BaseResponseModel<T>
        {
            Success = false,
            StatusCode = statusCode,
            Message = message,
        };
    }
}

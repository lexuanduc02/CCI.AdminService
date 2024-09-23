using CCI.Common;
using CCI.Common.Extensions;
using CCI.Model;
using CCI.Model.CommonModels;
using CCI.Repository.Contractors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Events;

namespace CCI.Service;

public class RequirementService : IRequirementService
{
    private readonly ILogger<RequirementService> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private const string ClassName = nameof(RequirementService);

    public RequirementService(ILogger<RequirementService> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
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

    public async Task<BaseResponseModel<List<RequirementViewModel>>> GetByTypeAsync(RequirementType requirementType)
    {
        try
        {
            var result = await _unitOfWork.RequirementRepository.GetByTypeAsync(requirementType);

            if (result == null)
                return ErrorResponse<List<RequirementViewModel>>("Cannot Get Data", StatusCodes.Status400BadRequest);

            if (result.Count == 0)
            {
                _logger.LogInformation("Get Requirement Successfully But Have No Data!");
                return new BaseResponseModel<List<RequirementViewModel>>()
                {
                    Message = "Get Requirement Successfully But Have No Data!",
                    StatusCode = StatusCodes.Status200OK,
                    Success = true,
                    Data = result,
                };
            }

            _logger.LogInformation("Get Requirement Successfully!");
            return new BaseResponseModel<List<RequirementViewModel>>()
            {
                Message = "Get Requirement Successfully!",
                StatusCode = StatusCodes.Status200OK,
                Success = true,
                Data = result,
            };
        }
        catch (System.Exception ex)
        {
            return ErrorResponse<List<RequirementViewModel>>("Cannot Get Data", StatusCodes.Status400BadRequest, ex);
        }
    }

    public async Task<BaseResponseModel<bool>> UpdateStatusAsync(UpdateRequirementStatusRequest request)
    {
        try
        {
            var result = await _unitOfWork.RequirementRepository.UpdateRequirementStatus(request);

            if (result != 1)
                return ErrorResponse<bool>("Cannot Update RequirementStatus", StatusCodes.Status400BadRequest);

            _logger.LogInformation("Update RequirementStatus Successfully!");
            return new BaseResponseModel<bool>()
            {
                Message = "Update RequirementStatus Successfully!",
                StatusCode = StatusCodes.Status200OK,
                Success = true,
            };

        }
        catch (System.Exception ex)
        {
            return ErrorResponse<bool>("Cannot Update RequirementStatus", StatusCodes.Status400BadRequest, ex);
        }
    }
}

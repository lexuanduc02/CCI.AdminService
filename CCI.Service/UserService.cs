using CCI.Common.Extensions;
using CCI.Model.CommonModels;
using CCI.Repository.Contractors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Events;

namespace CCI.Service;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UserService> _logger;
    private const string ClassName = nameof(UserService);


    public UserService(IUnitOfWork unitOfWork,
        ILogger<UserService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<BaseResponseModel<bool>> UpdateDepartmentStatusAsync(Guid userId, bool status)
    {
        try
        {
            var result = await _unitOfWork.UserRepository.UpdateDepartmentStatusAsync(userId, status);

            if (result != 1)
                return ErrorResponse<bool>("Update User Department Status Failed", StatusCodes.Status400BadRequest);

            _logger.LogInformation("Update User Department Status Successfully".GeneratedLog(ClassName, LogEventLevel.Information));
            return new BaseResponseModel<bool>
            {
                Success = false,
                StatusCode = StatusCodes.Status200OK,
                Message = "Update User Department Status Successfully",
            };
        }
        catch (System.Exception ex)
        {
            return ErrorResponse<bool>("Update User Department Status Failed", StatusCodes.Status400BadRequest, ex);
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

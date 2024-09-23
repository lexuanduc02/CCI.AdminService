using CCI.Model;
using CCI.Common.Extensions;
using CCI.Model.CommonModels;
using CCI.Service.Contractors;
using CCI.Repository.Contractors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Events;

namespace CCI.Service;

public class UserDepartmentService : IUserDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UserDepartmentService> _logger;
    private const string ClassName = nameof(UserDepartmentService);

    public UserDepartmentService(IUnitOfWork unitOfWork,
        ILogger<UserDepartmentService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
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

    public async Task<BaseResponseModel<bool>> CreateUserDepartmentProfile(CreateUserDepartmentRequest request)
    {
        var response = new BaseResponseModel<bool>()
        {
            Success = false,
            StatusCode = StatusCodes.Status400BadRequest
        };

        try
        {
            var user = await _unitOfWork.UserRepository.GetById(request.UserId);
            if (user == null)
                return ErrorResponse<bool>("Cannot Found User Information", StatusCodes.Status400BadRequest);

            var department = await _unitOfWork.DepartmentRepository.GetById(request.DepartmentId);
            if (department == null)
                return ErrorResponse<bool>("Create New User Department Profile Failed Because Department Do Not Exist", StatusCodes.Status400BadRequest);

            var userDepartment = await _unitOfWork.UserDepartmentRepository.GetByUserIdAsync(request.UserId);
            if (userDepartment != null)
                return ErrorResponse<bool>("User Department Profile already exits", StatusCodes.Status400BadRequest);

            var result = await _unitOfWork.UserDepartmentRepository.CreateUserDepartmentAsync(request);
            if (result == 1)
            {
                _logger.LogInformation("Create new User Department Profile Successfully!".GeneratedLog(ClassName, LogEventLevel.Information));

                response.Success = true;
                response.StatusCode = StatusCodes.Status201Created;
                response.Message = "Thêm mới thông tin phòng ban người dùng thành công!";

                return response;
            }

            return ErrorResponse<bool>("Create New User Department Profile Failed!", StatusCodes.Status400BadRequest);
        }
        catch (System.Exception ex)
        {
            return ErrorResponse<bool>("Create New User Department Profile Failed!", StatusCodes.Status400BadRequest, ex);
        }
    }

    public async Task<BaseResponseModel<bool>> DeleteUserDepartmentProfile(DeleteUserDepartmentRequest request)
    {
        try
        {
            var user = await _unitOfWork.UserRepository.GetById(request.UserId);
            if (user == null)
                return ErrorResponse<bool>("User Not Found!", StatusCodes.Status400BadRequest);

            var department = await _unitOfWork.DepartmentRepository.GetById(request.DepartmentId);
            if (department == null)
                return ErrorResponse<bool>("Department Not Found!", StatusCodes.Status400BadRequest);

            var result = await _unitOfWork.UserDepartmentRepository.DeleteUserDepartmentProfile(request);
            if (result != 1)
                return ErrorResponse<bool>("Delete User Department Profile Failed!", StatusCodes.Status400BadRequest);

            _logger.LogInformation("Delete User Department Profile Successfully");
            return new BaseResponseModel<bool>()
            {
                Message = "Delete User Department Profile Successfully!!",
                StatusCode = StatusCodes.Status200OK,
                Success = true,
            };
        }
        catch (System.Exception ex)
        {
            return ErrorResponse<bool>("Delete User Department Profile Failed!", StatusCodes.Status400BadRequest, ex);
        }
    }
}

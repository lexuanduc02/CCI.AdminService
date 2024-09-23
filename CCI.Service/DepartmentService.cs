using CCI.Common.Extensions;
using CCI.Domain.Entities;
using CCI.Model;
using CCI.Model.CommonModels;
using CCI.Model.DepartmentModels;
using CCI.Repository.Contractors;
using CCI.Service.Contractors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Events;

namespace CCI.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DepartmentService> _logger;
        private const string ClassName = nameof(DepartmentService);

        public DepartmentService(IUnitOfWork unitOfWork,
            ILogger<DepartmentService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<BaseResponseModel<bool>> CreateAsync(CreateDepartmentRequest request)
        {
            try
            {
                _logger.LogInformation($"Creating department".GeneratedLog(ClassName, LogEventLevel.Information));

                var company = await _unitOfWork.CompanyRepository.GetById(request.CompanyId);
                if (company == null)
                    return ErrorResponse<bool>("Create New Department Failed Because Company Information Do Not Exist!", StatusCodes.Status400BadRequest);

                var result = await _unitOfWork.DepartmentRepository.CreateDepartmentAsync(request);
                if (result != 1)
                    return ErrorResponse<bool>("Create New Department failed!", StatusCodes.Status400BadRequest);

                _logger.LogInformation("Create New Department Succeed".GeneratedLog(ClassName, LogEventLevel.Information));
                return new BaseResponseModel<bool>
                {
                    Success = true,
                    StatusCode = StatusCodes.Status201Created,
                    Message = "Tạo phòng ban mới thành công!"
                };
            }
            catch (Exception ex)
            {
                return ErrorResponse<bool>("Create New Department failed!", StatusCodes.Status400BadRequest, ex);
            }
        }

        public async Task<BaseResponseModel<List<DepartmentModel>>> GetAllAsync()
        {
            try
            {
                var result = await _unitOfWork.DepartmentRepository.GetAllAsync();
                if (result.Count() > 0)
                {
                    _logger.LogInformation("Get Departments Succeed".GeneratedLog(ClassName, LogEventLevel.Information));
                    return new BaseResponseModel<List<DepartmentModel>>
                    {
                        Success = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "Lấy thông tin các phòng ban thành công!",
                        Data = result.ToList(),
                    };
                }

                return ErrorResponse<List<DepartmentModel>>("Cannot Found Information!", StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return ErrorResponse<List<DepartmentModel>>("Cannot Found Information!", StatusCodes.Status400BadRequest, ex);
            }
        }

        public async Task<BaseResponseModel<Department>> GetById(Guid departmentId)
        {
            try
            {
                var result = await _unitOfWork.DepartmentRepository.GetById(departmentId);
                if (result == null)
                    return ErrorResponse<Department>("Cannot Found Information!", StatusCodes.Status400BadRequest);

                _logger.LogInformation("Department Found!".GeneratedLog(ClassName, LogEventLevel.Information));
                return new BaseResponseModel<Department>
                {
                    Success = true,
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Lấy thông tin phòng ban thành công!",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return ErrorResponse<Department>("Cannot Found Information!", StatusCodes.Status400BadRequest, ex);
            }
        }

        public async Task<BaseResponseModel<bool>> UpdateAsync(UpdateDepartmentRequest request)
        {
            try
            {
                var company = await _unitOfWork.CompanyRepository.GetById(request.CompanyId);
                if (company == null)
                    return ErrorResponse<bool>("Company do not exits!", StatusCodes.Status400BadRequest);

                var result = await _unitOfWork.DepartmentRepository.UpdateDepartmentAsync(request);
                if (result == 1)
                {
                    _logger.LogInformation("Update Department Information Successfully".GeneratedLog(ClassName, LogEventLevel.Information));
                    return new BaseResponseModel<bool>
                    {
                        Success = true,
                        StatusCode = StatusCodes.Status200OK,
                        Message = "Cập nhật thành công"
                    };
                };

                return ErrorResponse<bool>("Update Department Information Failed!", StatusCodes.Status400BadRequest);
            }
            catch (System.Exception ex)
            {
                return ErrorResponse<bool>("Update Department Information Failed!", StatusCodes.Status400BadRequest, ex);
            };
        }

        public async Task<BaseResponseModel<bool>> AssignUserToDepartment(AssignUserRequest request)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetById(request.UserId);
                if (user == null)
                    return ErrorResponse<bool>("Can Not Found User Information!", StatusCodes.Status400BadRequest);

                var userDepartment = await _unitOfWork.UserDepartmentRepository.GetByUserIdAndDepartmentIdAsync(request.UserId, request.DepartmentId);
                if (userDepartment != null)
                    return ErrorResponse<bool>("User is currently in a Department!", StatusCodes.Status400BadRequest);

                var result = await _unitOfWork.DepartmentRepository.AssignUserToDepartment(request);
                if (result != 1)
                    return ErrorResponse<bool>("Assign Failed!", StatusCodes.Status400BadRequest);

                _logger.LogInformation("Assign Successfully".GeneratedLog(ClassName, LogEventLevel.Information));
                return new BaseResponseModel<bool>()
                {
                    Success = true,
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Assign Successfully!",
                };
            }
            catch (System.Exception ex)
            { return ErrorResponse<bool>("Assign Failed!", StatusCodes.Status400BadRequest, ex); }
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
}

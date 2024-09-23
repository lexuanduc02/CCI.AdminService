using CCI.Common.Extensions;
using CCI.Domain.Entities;
using CCI.Model.CommonModels;
using CCI.Repository.Contractors;
using CCI.Service.Contractors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Events;

namespace CCI.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CompanyService> _logger;
        private const string ClassName = nameof(CompanyService);

        public CompanyService(IUnitOfWork unitOfWork,
            ILogger<CompanyService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<BaseResponseModel<Company>> GetCompanyByIdAsync(Guid companyId)
        {
            try
            {
                var result = await _unitOfWork.CompanyRepository.GetCompanyByIdAsync(companyId);
                if (result == null)
                    return ErrorResponse<Company>("Cannot Found Company Information!", StatusCodes.Status400BadRequest);

                _logger.LogInformation($"Found Company Information".GeneratedLog(ClassName, LogEventLevel.Information));
                return new BaseResponseModel<Company>
                {
                    Success = true,
                    Message = "Tìm thấy thông tin công ty!",
                    StatusCode = StatusCodes.Status200OK,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return ErrorResponse<Company>("Cannot Found Company Information!", StatusCodes.Status400BadRequest, ex);
            }
        }

        public async Task<BaseResponseModel<List<Company>>> GetAllAsync()
        {
            try
            {
                var result = await _unitOfWork.CompanyRepository.GetAllAsync();
                if (result == null)
                    return ErrorResponse<List<Company>>("Cannot Get List Company!", StatusCodes.Status400BadRequest);


                _logger.LogInformation($"Get List Company Successfully!".GeneratedLog(ClassName, LogEventLevel.Information));
                return new BaseResponseModel<List<Company>>
                {
                    Success = true,
                    Message = "Tìm thấy thông tin công ty!",
                    StatusCode = StatusCodes.Status200OK,
                    Data = result
                };

            }
            catch (System.Exception ex)
            {
                return ErrorResponse<List<Company>>("Cannot Get List Company!", StatusCodes.Status400BadRequest, ex);
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
}

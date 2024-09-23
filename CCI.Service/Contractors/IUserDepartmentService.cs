using CCI.Model;
using CCI.Model.CommonModels;

namespace CCI.Service.Contractors;

public interface IUserDepartmentService
{
    Task<BaseResponseModel<bool>> CreateUserDepartmentProfile(CreateUserDepartmentRequest request);
    Task<BaseResponseModel<bool>> DeleteUserDepartmentProfile(DeleteUserDepartmentRequest request);
}

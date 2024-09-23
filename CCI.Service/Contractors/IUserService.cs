using CCI.Model.CommonModels;

namespace CCI.Service;

public interface IUserService
{
    Task<BaseResponseModel<bool>> UpdateDepartmentStatusAsync(Guid userId, bool status);
}

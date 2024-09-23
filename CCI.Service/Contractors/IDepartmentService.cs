using CCI.Domain.Entities;
using CCI.Model;
using CCI.Model.CommonModels;
using CCI.Model.DepartmentModels;

namespace CCI.Service.Contractors
{
    public interface IDepartmentService
    {
        Task<BaseResponseModel<List<DepartmentModel>>> GetAllAsync();
        Task<BaseResponseModel<Department>> GetById(Guid departmentId);
        Task<BaseResponseModel<bool>> CreateAsync(CreateDepartmentRequest model);
        Task<BaseResponseModel<bool>> UpdateAsync(UpdateDepartmentRequest request);
        Task<BaseResponseModel<bool>> AssignUserToDepartment(AssignUserRequest request);
    }
}

using CCI.Domain;
using CCI.Domain.Entities;
using CCI.Model;
using CCI.Model.DepartmentModels;

namespace CCI.Repository.Contractors
{
    public interface IDepartmentRepository : IRepository<Department, Guid, DataContext>
    {
        Task<List<DepartmentModel>?> GetAllAsync();
        Task<Department?> GetById(Guid departmentId);
        Task<int?> CreateDepartmentAsync(CreateDepartmentRequest model);
        Task<int?> UpdateDepartmentAsync(UpdateDepartmentRequest request);
        Task<int?> AssignUserToDepartment(AssignUserRequest request);
    }
}

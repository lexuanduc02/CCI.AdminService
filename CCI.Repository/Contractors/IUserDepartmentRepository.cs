using CCI.Domain;
using CCI.Domain.Entities;
using CCI.Model;

namespace CCI.Repository.Contractors;

public interface IUserDepartmentRepository : IRepository<UserDepartment, Guid, DataContext>
{
    Task<int?> CreateUserDepartmentAsync(CreateUserDepartmentRequest request);
    Task<UserDepartment?> GetByUserIdAsync(Guid UserId);
    Task<UserDepartment?> GetByUserIdAndDepartmentIdAsync(Guid UserId, Guid DepartmentId);
    Task<int?> DeleteUserDepartmentProfile(DeleteUserDepartmentRequest request);

}

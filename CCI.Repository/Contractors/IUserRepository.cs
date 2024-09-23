using CCI.Domain;
using CCI.Repository.Contractors;

namespace CCI.Repository;

public interface IUserRepository : IRepository<User, Guid, IdentityContext>
{
    Task<int?> UpdateDepartmentStatusAsync(Guid userId, bool status);

}

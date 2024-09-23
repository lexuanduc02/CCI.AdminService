using CCI.Domain;
using Dapper;

namespace CCI.Repository;

public class UserRepository : Repository<User, Guid, IdentityContext>, IUserRepository
{
    public UserRepository(IdentityContext context) : base(context)
    {
    }

    public async Task<int?> UpdateDepartmentStatusAsync(Guid userId, bool status)
    {
        var queryString =
            $"""
                UPDATE "Users"
                SET "IsInDepartment" = {status}
                WHERE "Id" = '{userId}'
            """;

        var result = await _context.GetDbConnect().ExecuteAsync(queryString);

        return result;
    }
}

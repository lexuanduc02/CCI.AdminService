using CCI.Domain;
using CCI.Domain.Entities;
using CCI.Model;
using CCI.Repository.Contractors;
using Dapper;

namespace CCI.Repository;

public class UserDepartmentRepository : Repository<UserDepartment, Guid, DataContext>, IUserDepartmentRepository
{
    public UserDepartmentRepository(DataContext context) : base(context)
    {
    }

    public async Task<int?> CreateUserDepartmentAsync(CreateUserDepartmentRequest request)
    {
        var queryString =
            $"""
                INSERT INTO "MappingUserDepartment" ("UserId", "DepartmentId", "StatusUser", "IsAdminSystem", "IsAdminDepartment")
                VALUES ('{request.UserId}', '{request.DepartmentId}', '{request.StatusUser}', '{request.IsAdminSystem}', '{request.IsAdminDepartment}')
            """;

        var result = await _context.GetDbConnect().ExecuteAsync(queryString);

        return result;
    }

    public async Task<int?> DeleteUserDepartmentProfile(DeleteUserDepartmentRequest request)
    {
        var queryString =
            $"""
                DELETE FROM "MappingUserDepartment"
                WHERE "UserId" = '{request.UserId}' AND "DepartmentId" = '{request.DepartmentId}' 
            """;

        var result = await _context.GetDbConnect().ExecuteAsync(queryString);

        return result;
    }

    public async Task<UserDepartment?> GetByUserIdAndDepartmentIdAsync(Guid UserId, Guid DepartmentId)
    {
        var queryString =
            $"""
                Select * From "MappingUserDepartment"
                Where "UserId" = '{UserId}' And "DepartmentId" = '{DepartmentId}'
            """;

        var result = await _context.GetDbConnect().QueryFirstOrDefaultAsync<UserDepartment>(queryString);

        return result;
    }

    public async Task<UserDepartment?> GetByUserIdAsync(Guid UserId)
    {
        var queryString =
            $"""
                Select * From "MappingUserDepartment"
                Where "UserId" = '{UserId}'
            """;

        var result = await _context.GetDbConnect().QueryFirstOrDefaultAsync<UserDepartment>(queryString);

        return result;
    }
}

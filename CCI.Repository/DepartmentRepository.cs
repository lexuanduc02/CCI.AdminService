using CCI.Domain;
using CCI.Domain.Entities;
using CCI.Model;
using CCI.Model.DepartmentModels;
using CCI.Repository.Contractors;
using Dapper;

namespace CCI.Repository
{
    public class DepartmentRepository : Repository<Department, Guid, DataContext>, IDepartmentRepository
    {
        public DepartmentRepository(DataContext context) : base(context)
        {
        }

        public async Task<int?> AssignUserToDepartment(AssignUserRequest request)
        {
            var queryString =
                    $""" 
                        Insert into "MappingUserDepartment" ("UserId", "DepartmentId", "IsAdminDepartment", "StatusUser", "IsAdminSystem") 
                        values ('{request.UserId}', '{request.DepartmentId}', false,1,false) 
                    """;

            var result = await _context.GetDbConnect().ExecuteAsync(queryString);

            return result;
        }

        public async Task<int?> CreateDepartmentAsync(CreateDepartmentRequest model)
        {
            var queryString =
                $"""
                    INSERT INTO "Department" ("Name", "Description", "Status", "CompanyId")
                    VALUES ('{model.Name}', '{model.Description}', '{model.Status}', '{model.CompanyId}')
                """;

            var result = await _context.GetDbConnect().ExecuteAsync(queryString);

            return result;
        }

        public async Task<List<DepartmentModel>?> GetAllAsync()
        {
            var queryString =
                $@" SELECT ""Department"".*, ""Company"".""Id"" as ""CompanyId"", ""Company"".""Name"" as ""CompanyName""
                    FROM ""Department"" LEFT JOIN ""Company""
                    ON ""Department"".""CompanyId"" = ""Company"".""Id""";

            var result = await _context.GetDbConnect().QueryAsync<DepartmentModel>(queryString);

            return (List<DepartmentModel>?)result.ToList();
        }

        public async Task<Department?> GetById(Guid departmentId)
        {
            var department = await _context.Department.FindAsync(departmentId);

            return department;
        }
        public async Task<int?> UpdateDepartmentAsync(UpdateDepartmentRequest request)
        {
            var queryString =
                    $"""
                        UPDATE "Department" 
                        SET "Name" = '{request.Name}', "Description" = '{request.Description}', "Status" = {request.Status}, "CompanyId" = '{request.CompanyId}'
                        WHERE "Id" = '{request.Id}'
                    """;

            var result = await _context.GetDbConnect().ExecuteAsync(queryString);

            return result;
        }
    }
}

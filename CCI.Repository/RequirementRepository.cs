using CCI.Domain;
using CCI.Model;
using Dapper;

namespace CCI.Repository;

public class RequirementRepository : Repository<Requirement, int, DataContext>, IRequirementRepository
{
    public RequirementRepository(DataContext context) : base(context)
    {
    }
    public async Task<List<RequirementViewModel>> GetAllAsync()
    {
        var queryString =
            $"""
                SELECT "Requirement".*, 
                        "RequirementType"."Name" as "RequirementTypeName"
                FROM "Requirement"
                LEFT JOIN "RequirementType" ON "Requirement"."RequirementType" = "RequirementType"."Id"
            """;

        var result = await _context.GetDbConnect().QueryAsync<RequirementViewModel>(queryString);

        return result.ToList();
    }

    public async Task<List<RequirementViewModel>> GetByTypeAsync(Common.RequirementType requirementType)
    {
        string queryString = "";

        switch (requirementType)
        {
            case Common.RequirementType.JobPost:
                queryString =
                    $"""
                        SELECT "Requirement".*, 
                                "RequirementType"."Name" as "RequirementTypeName" , 
                                "JobPost"."Title" as "SourceName"
                        FROM "Requirement"
                        LEFT JOIN "RequirementType" ON "Requirement"."RequirementType" = "RequirementType"."Id"
                        LEFT JOIN "JobPost" On "Requirement"."Source" = "JobPost"."Id"
                        WHERE "Requirement"."RequirementType" = {(int)requirementType}
                    """;
                break;
            case Common.RequirementType.Account:
                queryString =
                    $"""
                        SELECT "Requirement".*, 
                                "RequirementType"."Name" as "RequirementTypeName"
                        FROM "Requirement"
                        LEFT JOIN "RequirementType" ON "Requirement"."RequirementType" = "RequirementType"."Id"
                        WHERE "Requirement"."RequirementType" = {(int)requirementType}
                    """;
                break;
            default:
                break;
        }

        var result = await _context.GetDbConnect().QueryAsync<RequirementViewModel>(queryString);

        return result.ToList();
    }

    public async Task<int> UpdateRequirementStatus(UpdateRequirementStatusRequest request)
    {

        var updatedAt = DateTime.UtcNow.ToString();

        var queryString =
            $"""
                UPDATE "Requirement"
                SET
                "Status" = {(int)request.RequirementStatus},  
                "UpdatedAt" = '{updatedAt}'
                WHERE "Id" = {request.RequirementId}
            """;

        var result = await _context.GetDbConnect().ExecuteAsync(queryString);

        return result;
    }
}

using CCI.Domain.Entities;
using CCI.Domain;
using Dapper;
using Microsoft.EntityFrameworkCore;
using CCI.Repository.Contractors;

namespace CCI.Repository;

public class JobPostRepository : Repository<JobPost, Guid, DataContext>, IJobPostRepository
{
    public JobPostRepository(DataContext context) : base(context)
    {
    }

    public async Task<int> DetectPost(Guid idJobPost)
    {
        /// <summary>
        ///     Return 1 => Updated
        ///     Return 0 => JobPost do not exits
        /// </summary>

        DateTime updatedAt = DateTime.Now;

        var queryString =
            $"""
                Update "JobPost" 
                Set "IsActive" = 0, "UpdatedAt" = '{updatedAt}'
                Where "Id" = '{idJobPost}'
            """;

        var result = await _context.GetDbConnect().ExecuteAsync(queryString);

        return result;
    }

    public async Task<int> UnDetectPost(Guid idJobPost)
    {
        /// <summary>
        ///     Return 1 => Updated
        ///     Return 0 => JobPost do not exits
        /// </summary>

        DateTime updatedAt = DateTime.Now;

        var queryString =
            $"""
                Update "JobPost" 
                Set "IsActive" = 1, "UpdatedAt" = '{updatedAt}'
                Where "Id" = '{idJobPost}'
            """;

        var result = await _context.GetDbConnect().ExecuteAsync(queryString);

        return result;
    }
}

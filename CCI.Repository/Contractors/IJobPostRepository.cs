using CCI.Domain;
using CCI.Domain.Entities;

namespace CCI.Repository.Contractors;

public interface IJobPostRepository : IRepository<JobPost, Guid, DataContext>
{
    Task<int> DetectPost(Guid idJobPost);
    Task<int> UnDetectPost(Guid idJobPost);
}

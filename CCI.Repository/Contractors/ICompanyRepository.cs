using CCI.Domain;
using CCI.Domain.Entities;

namespace CCI.Repository.Contractors
{
    public interface ICompanyRepository : IRepository<Company, Guid, DataContext>
    {
        Task<Company?> GetCompanyByIdAsync(Guid companyId);
        Task<List<Company>> GetAllAsync();
    }
}

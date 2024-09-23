using CCI.Domain;
using CCI.Domain.Entities;
using CCI.Repository.Contractors;
using Dapper;

namespace CCI.Repository
{
    public class CompanyRepository : Repository<Company, Guid, DataContext>, ICompanyRepository
    {
        public CompanyRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Company>> GetAllAsync()
        {
            var queryString =
                $"""
                    Select * From "Company"
                """;

            var companies = await _context.GetDbConnect().QueryAsync<Company>(queryString);

            return companies.ToList();
        }

        public async Task<Company?> GetCompanyByIdAsync(Guid companyId)
        {
            var company = await _context.Company.FindAsync(companyId);
            return company;
        }
    }
}

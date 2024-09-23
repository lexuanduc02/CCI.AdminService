using System.Data.Common;

namespace CCI.Repository.Contractors
{
    public interface IUnitOfWork
    {
        DbConnection DbConnection();
        ICompanyRepository CompanyRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IJobPostRepository JobPostRepository { get; }
        IRequirementRepository RequirementRepository { get; }
        IUserDepartmentRepository UserDepartmentRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
